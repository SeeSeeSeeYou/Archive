using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Data.OleDb;

namespace ScanArchiving
{
    public partial class Main : Form
    {
        private readonly ScanArchivingEntities db = new ScanArchivingEntities();
        private TreeNode selectedNode = null;
        private ListViewItem selectedItem = null;
        private string code = "";
        private List<TreeNode> treeNodes = new List<TreeNode>();
        public Main()
        {
            InitializeComponent(); 
            Init();
        }
        private void Init()
        {
            try
            {
                this.TreeV.Nodes.Clear();
                List<Project> projects = db.Project.AsNoTracking().Where(p => p.IsDelete == false).ToList();
                TreeNode root = new TreeNode
                {
                    Text = "全部项目",
                    Tag = new object(),
                };
                foreach (Project project in projects)
                {
                    CreateProjectNode(project, root);
                }
                this.TreeV.Nodes.Add(root);
                this.TreeV.ExpandAll();
                TreeV.SelectedNode = null;
                LoadListView(selectedNode);
            }
            catch (Exception)
            {
                MessageBox.Show("网络连接错误");
            }

        }

        #region 创建树
        private void CreateProjectNode(Project project, TreeNode trNode)
        {
            var childrenNode = new TreeNode
            {
                Text = project.ProjectName,
                ImageKey = "project.png",
                Name = project.ProjectID.ToString(),
                Tag = project,
                ContextMenu = ContextMenu
            };
            childrenNode.Expand();
            List<Volume> volumes = db.Volume.AsNoTracking().Where(v => v.ProjectID == project.ProjectID && v.IsDelete == false).ToList();
            foreach (Volume volume in volumes)
            {
                CreateVolumeNode(volume, childrenNode);
            }
            trNode.Nodes.Add(childrenNode);
        }
        private void CreateVolumeNode(Volume volume, TreeNode trNode)
        {
            var childrenNode = new TreeNode
            {
                Text = volume.VolumeName,
                ImageKey = "volume.png",
                Name = volume.VolumeID.ToString(),
                Tag = volume,
            };
            //List<File> files = db.File.Where(f => f.VolumID == volume.VolumeID).ToList();
            //foreach (File file in files)
            //{
            //    if (file.IsDelete) continue;
            //    CreateFileNode(file, childrenNode);
            //}
            trNode.Nodes.Add(childrenNode);
        }
        //private void CreateFileNode(File file, TreeNode trNode)
        //{
        //    var childrenNode = new TreeNode
        //    {
        //        Text = file.FileName,
        //        ImageKey = "file.png",
        //        Name = file.FileID.ToString(),
        //        Tag = file,
        //    };
        //    trNode.Nodes.Add(childrenNode);
        //}
        #endregion 

        #region 工具栏
        private void Menu_AddProject_Click(object sender, EventArgs e)
        {
            using (AddProject addProject = new AddProject("Add", null))
            {
                addProject.ShowDialog();
                if (addProject.DialogResult == DialogResult.OK) Init();
            }
        }
        private void Menu_AddVolume_Click(object sender, EventArgs e)
        {
            try
            {
                Guid projectId = Guid.NewGuid();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedNode.Name);
                }
                using (AddVolume volume = new AddVolume("Add", projectId, Guid.NewGuid()))
                {
                    volume.ShowDialog();
                    if (volume.DialogResult == DialogResult.OK)
                    {
                        Init();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Menu_AddVolumeWithNoProject_Click(object sender, EventArgs e)
        {
            using (AddVolumeWithNoProject addVolumeWithNoProject = new AddVolumeWithNoProject())
            {
                addVolumeWithNoProject.ShowDialog();
                if (addVolumeWithNoProject.DialogResult == DialogResult.OK)
                {
                    Init();
                }
            }
        }
        private void Menu_Archiving_Click(object sender, EventArgs e)
        {
            try
            {
                Guid projectId = Guid.NewGuid();
                Guid volumeId = Guid.NewGuid();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                    volumeId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                    volumeId = Guid.Parse(selectedNode.Name);
                }
                using (Archiving archiving = new Archiving())
                {
                    archiving.TransfEvent += Archiving_TransfEvent;
                    while (archiving.DialogResult != DialogResult.Cancel)
                    {
                        if (archiving.DialogResult == DialogResult.OK)
                        {
                            using (AddFile addFile = new AddFile("Archiving", volumeId, Guid.NewGuid(), code, new List<Guid>()))
                            {
                                Init();
                            }
                        }
                        archiving.ShowDialog();
                        Thread.Sleep(500);
                    }
                }
                TreeV.SelectedNode = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Menu_DeleteFile_Click(object sender, EventArgs e)
        {
            using (MyConfig myConfig = new MyConfig())
            {
                myConfig.ShowDialog();
            }
        }
        #endregion

        #region 右键菜单 -项目
        private void ProjectMenu_EditProject_Click(object sender, EventArgs e)
        {
            try
            {
                Guid projectId = Guid.NewGuid();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedNode.Name);
                }
                using (AddProject project = new AddProject("Edit", projectId))
                {
                    project.ShowDialog();
                    if (project.DialogResult == DialogResult.OK) Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ProjectMenu_DeleteProject_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("项目删除后，项目下案卷文件信息都将删除，是否确认删除？", "提示", MessageBoxButtons.OKCancel);
                if (dialogResult != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
                Guid projectId = Guid.NewGuid();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedNode.Name);
                }
                Project project = db.Project.SingleOrDefault(p => p.ProjectID == projectId);
                if (project == null)
                {
                    MessageBox.Show("项目不存在");
                    return;
                }
                db.Project.Remove(project);
                db.SaveChanges();
                Init();
                MessageBox.Show("删除成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ProjectMenu_AddVolume_Click(object sender, EventArgs e)
        {
            try
            {
                Guid projectId = Guid.NewGuid();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedNode.Name);
                }
                using (AddVolume addVolume = new AddVolume("Add", projectId, Guid.NewGuid()))
                {
                    addVolume.ShowDialog();
                    if (addVolume.DialogResult == DialogResult.OK)
                    {
                        Init();
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ProjectMenu_WatchProject_Click(object sender, EventArgs e)
        {
            try
            {
                Guid projectId = Guid.NewGuid();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Project") { MessageBox.Show("请选择一个项目"); return; }
                    projectId = Guid.Parse(selectedNode.Name);
                }
                using (AddProject project = new AddProject("Display", projectId))
                {
                    project.ShowDialog();
                    if (project.DialogResult == DialogResult.OK) Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion


        #region 右键菜单-卷册
        private void VolumeMenu_AddFile_Click(object sender, EventArgs e)
        {
            try
            {
                Guid fileId = Guid.NewGuid();
                Guid volumeId = Guid.NewGuid();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                    volumeId = Guid.Parse(selectedNode.Name);
                    fileId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                    volumeId = Guid.Parse(selectedNode.Name);
                    fileId = Guid.Parse(selectedNode.Name);
                }
                using (AddFile file = new AddFile("Add", volumeId, fileId, Guid.NewGuid().ToString("N"), new List<Guid>()))
                {
                    file.ShowDialog();
                    if (file.DialogResult == DialogResult.OK) Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void VolumeMenu_EditVolume_Click(object sender, EventArgs e)
        {
            try
            {
                Guid projectId = Guid.NewGuid();
                Guid volumeId = Guid.NewGuid();
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                bool isExpList = this.ExpList.Focused;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                    projectId = Guid.Parse(selectedNode.Parent.Name);
                    volumeId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                    projectId = Guid.Parse(selectedNode.Parent.Name);
                    volumeId = Guid.Parse(selectedNode.Name);
                }
                using (AddVolume volume = new AddVolume("Edit", projectId, volumeId))
                {
                    volume.ShowDialog();
                    if (volume.DialogResult == DialogResult.OK) Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void VolumeMenu_WatchVolume_Click(object sender, EventArgs e)
        {
            try
            {
                Guid projectId = Guid.NewGuid();
                Guid volumeId = Guid.NewGuid();
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                bool isExpList = this.ExpList.Focused;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                    projectId = Guid.Parse(selectedNode.Parent.Name);
                    volumeId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                    projectId = Guid.Parse(selectedNode.Parent.Name);
                    volumeId = Guid.Parse(selectedNode.Name);
                }
                using (AddVolume volume = new AddVolume("Display", projectId, volumeId))
                {
                    volume.ShowDialog();
                    if (volume.DialogResult == DialogResult.OK) Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void VolumeMenu_DeleteVolume_Click(object sender, EventArgs e)
        {
            try
            {

                List<Guid> fileIds = new List<Guid>();
                bool isExpList = this.ExpList.Focused;
                List<Guid> volumeIds = new List<Guid>();
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    ListView.SelectedListViewItemCollection selectItem = this.ExpList.SelectedItems;
                    if (selectItem.Count == 0 || selectItem == null || selectItem[0].Tag.GetType().Name != "Volume") { MessageBox.Show("请选择至少一个卷册"); return; }
                    foreach (ListViewItem item in selectItem)
                    {
                        Guid id = Guid.TryParse(item.Name, out Guid i) ? i : Guid.NewGuid();
                        Volume volume = db.Volume.SingleOrDefault(v => v.VolumeID == id);
                        if (volume == null)
                        {
                            continue;
                        }
                        db.Volume.Remove(volume);
                    }

                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                    Guid volumeId = Guid.Parse(selectedNode.Name);
                    Volume volume = db.Volume.SingleOrDefault(v => v.VolumeID == volumeId);
                    if (volume == null)
                    {
                        MessageBox.Show("案卷不存在");
                        return;
                    }
                    db.Volume.Remove(volume);

                }
                selectedNode = selectedNode.Parent;
                db.SaveChanges();
                Init();
                MessageBox.Show("删除成功");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Archiving_TransfEvent(string value) => code = value;
        private void Search_TransfEvent(List<TreeNode> value) => this.treeNodes = value;
        private void VolumeMenu_ScanArchiving_Click(object sender, EventArgs e)
        {
            Guid volumeId = Guid.NewGuid();
            bool isExpList = this.ExpList.Focused;
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            if (isExpList)
            {
                selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                if (selectedItem == null || selectedItem.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                volumeId = Guid.Parse(selectedItem.Name);
            }
            else
            {
                if (selectedNode == null || selectedNode.Tag.GetType().Name != "Volume") { MessageBox.Show("请选择一个卷册"); return; }
                volumeId = Guid.Parse(selectedNode.Name);
            }
            using (Archiving archiving = new Archiving())
            {
                archiving.TransfEvent += Archiving_TransfEvent;
                while (archiving.DialogResult != DialogResult.Cancel)
                {
                    if (archiving.DialogResult == DialogResult.OK)
                    {
                        using (AddFile addFile = new AddFile("Archiving", volumeId, Guid.NewGuid(), code, new List<Guid>()))
                        {
                            Init();
                        }
                    }
                    archiving.ShowDialog();
                    Thread.Sleep(500);
                }
            }
            TreeV.SelectedNode = null;
        }
        private void VolumeMenu_ExcelImport_Click(object sender, EventArgs e)
        {
            Guid projectId = Guid.NewGuid();
            Guid volumeId = Guid.NewGuid();
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            bool isExpList = this.ExpList.Focused;
            if (isExpList)
            {
                selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                if (selectedItem == null || selectedItem.Tag.GetType().Name != "Volume") { MessageBox.Show(@"请选择一个卷册"); return; }
                projectId = Guid.Parse(selectedNode.Parent.Name);
                volumeId = Guid.Parse(selectedItem.Name);
            }
            else
            {
                if (selectedNode == null || selectedNode.Tag.GetType().Name != "Volume") { MessageBox.Show(@"请选择一个卷册"); return; }
                projectId = Guid.Parse(selectedNode.Parent.Name);
                volumeId = Guid.Parse(selectedNode.Name);
            }
            using (OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "*.xls|*.xlsx",//过滤文件格式  
                Multiselect = false
            })
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = fileDialog.FileName;
                    string extension = Path.GetExtension(fileName);
                    string[] str = new string[] { ".xls", ".xlsx" };
                    if (!((IList)str).Contains(extension))
                    {
                        MessageBox.Show("仅能上传xsx,xsxl格式的文件！");
                        return;
                    }
                    else
                    {
                        FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                        if (fileInfo.Length > 20 * 1024 * 1024)
                        {
                            MessageBox.Show(@"上传文件不能大于20M");
                            return;
                        }
                        else
                        {
                            try
                            {
                                using (OleDbConnection oleDb = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=0'"))
                                {
                                    oleDb.Open();
                                    var sheets = oleDb.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                    if (sheets != null)
                                    {
                                        string sheet = sheets.Rows[0]["TABLE_NAME"].ToString();
                                        var odbcCommand = new OleDbCommand
                                        {
                                            Connection = oleDb,
                                            CommandText = "SELECT * FROM [" + sheet + "]"
                                        };
                                        using (var odbcDataAdapter = new OleDbDataAdapter(odbcCommand))
                                        {
                                            var dataSet = new DataSet();
                                            odbcDataAdapter.Fill(dataSet, fileName);
                                            oleDb.Close();
                                            var dataRows = dataSet.Tables[0].Rows;
                                            foreach (DataRow row in dataRows)
                                            {
                                                if (row.IsNull(5) || row.IsNull(6) || row.IsNull(7) || row.IsNull(8)) continue;
                                                int maxArchId = 0;
                                                int maxArchSort = 0;
                                                string qrCode = Guid.NewGuid().ToString("N").ToUpper();
                                                if (db.ArchiveInfo.ToList().Count > 0)
                                                {
                                                    maxArchId = db.ArchiveInfo.Select(a => a.ID).Max();
                                                    maxArchSort = db.ArchiveInfo.Max(a => a.ID);
                                                }
                                                if (db.File.ToList().Count > 0)
                                                {
                                                }
                                                var archiveInfo = new ArchiveInfo
                                                {
                                                    ID = maxArchId + 1,
                                                    编号 = qrCode,
                                                    图号 = row["图号"].ToString(),
                                                    Sort = maxArchSort + 1,
                                                    是否归档 = 1
                                                };
                                                db.ArchiveInfo.Add(archiveInfo);
                                                var volume = db.Volume.SingleOrDefault(v => v.VolumeID == volumeId);
                                                if (volume != null)
                                                {
                                                    var file = new File
                                                    {
                                                        FileID = Guid.NewGuid(),
                                                        ProjectID = projectId,
                                                        VolumID = volumeId,
                                                        QrCode = qrCode,
                                                        Keyword = row["关键字"].ToString(),
                                                        TypeCode = row["分类号"].ToString(),
                                                        ArchiveCode = volume.ArchiveCode,
                                                        SerialNumber = row["序号"].ToString(),
                                                        FileTitle = row["文件标题"].ToString(),
                                                        FileName = row["文件名"].ToString(),
                                                        PageSize = int.TryParse(row["页次"].ToString(), out int h) ? h : 0,
                                                        ElectronicsFileNumber = int.TryParse(row["电子文件数"].ToString(), out int j) ? j : 0,
                                                        V_ArchiveNumber = int.TryParse(row["归档份数"].ToString(), out int k) ? k : 0,
                                                        V_VolumeCode = row["所属卷号"].ToString(),
                                                        VolumeName = row["所在卷册"].ToString(),
                                                        V_VolumeLocation = row["存放位置"].ToString(),
                                                        V_VolumeText = row["文本"].ToString(),
                                                        IconName = row["图标名称"].ToString(),
                                                        MapCode = row["图号"].ToString(),
                                                        V_OrganizationDate = DateTime.TryParse(row["编制日期"].ToString(), out var organizationDate) ? organizationDate : DateTime.Now,
                                                        Designer = row["设计者"].ToString(),
                                                        Phase = row["设计阶段"].ToString(),
                                                        P_RoadLevel = int.TryParse(row["公路等级"].ToString(), out int l) ? l : 0,
                                                        RoodLength = double.TryParse(row["里程长度"].ToString(), out double r) ? r : 0,
                                                        P_RoadHeight = double.TryParse(row["路基宽度"].ToString(), out double n) ? n : 0,
                                                        RoadType = row["路面类型"].ToString(),
                                                        InitialPile = row["起始桩号"].ToString(),
                                                        MainTechnicalIndicators = row["主要技术指标"].ToString(),
                                                        Disc = row["光盘号"].ToString(),
                                                        SecretLevel = row["密级"].ToString(),
                                                        KeepDate = row["保管期限"].ToString(),
                                                        Remarks = row["备注"].ToString(),
                                                        IsDelete = false,
                                                        Sort = archiveInfo.Sort,

                                                    };
                                                    db.File.Add(file);
                                                }
                                                db.SaveChanges();
                                            }
                                        }
                                    }
                                }
                                MessageBox.Show(@"导入成功");
                                Init();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 右键菜单-文件
        private void FileMenu_EditFile_Click(object sender, EventArgs e)
        {
            try
            {
                Guid fileId;
                Guid volumeId;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                var isExpList = this.ExpList.Focused;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "File") { MessageBox.Show("@请选择一个文件"); return; }
                    volumeId = Guid.Parse(selectedNode.Name);
                    fileId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                    volumeId = Guid.Parse(selectedNode.Parent.Name);
                    fileId = Guid.Parse(selectedNode.Name);
                }
                using (AddFile file = new AddFile("Edit", volumeId, fileId, "", new List<Guid>()))
                {
                    file.ShowDialog();
                    if (file.DialogResult == DialogResult.OK) Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void FileMenu_WatchFile_Click(object sender, EventArgs e)
        {
            try
            {
                Guid fileId = Guid.NewGuid();
                Guid volumeId = Guid.NewGuid();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null || selectedItem.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                    volumeId = Guid.Parse(selectedNode.Name);
                    fileId = Guid.Parse(selectedItem.Name);
                }
                else
                {
                    if (selectedNode == null || selectedNode.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                    volumeId = Guid.Parse(selectedNode.Parent.Name);
                    fileId = Guid.Parse(selectedNode.Name);
                }
                using (AddFile file = new AddFile("Display", volumeId, fileId, "", new List<Guid>()))
                {
                    file.ShowDialog();
                    if (file.DialogResult == DialogResult.OK) Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void FileMenu_DeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                List<Guid> fileIds = new List<Guid>();
                bool isExpList = this.ExpList.Focused;
                if (!isExpList) return;
                ListView.SelectedListViewItemCollection selectItem = this.ExpList.SelectedItems;
                if (selectItem.Count == 0 || selectItem == null || selectItem[0].Tag.GetType().Name != "File") { MessageBox.Show("请选择至少一个文件"); return; }
                foreach (ListViewItem item in selectItem)
                {
                    Guid id = Guid.TryParse(item.Name, out Guid i) ? i : Guid.NewGuid();
                    File file = db.File.SingleOrDefault(f => f.FileID == id);
                    if (file == null)
                    {
                        continue;
                    }
                    db.File.Remove(file);
                    ArchiveInfo archiveInfo = db.ArchiveInfo.SingleOrDefault(a => a.编号 == file.QrCode);
                    if (archiveInfo.是否归档 == 0)
                    {
                        db.ArchiveInfo.Remove(archiveInfo);
                    }
                    else
                    {
                        archiveInfo.是否归档 = 0;
                    }
                    db.SaveChanges();
                }
                Init();
                MessageBox.Show("删除成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void FileMenu_EditFiles_Click(object sender, EventArgs e)
        {
            try
            {
                Guid volumeId = Guid.NewGuid();
                List<Guid> fileIds = new List<Guid>();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (!isExpList) return;
                ListView.SelectedListViewItemCollection selectItem = this.ExpList.SelectedItems;
                if (selectItem.Count == 0 || selectItem == null || selectItem[0].Tag.GetType().Name != "File") { MessageBox.Show("请选择至少一个文件"); return; }
                foreach (ListViewItem item in selectItem)
                {
                    fileIds.Add(Guid.Parse(item.Name));
                }
                volumeId = Guid.Parse(selectedNode.Name);
                using (AddFile file = new AddFile("More", volumeId, Guid.NewGuid(), "", fileIds))
                {
                    file.ShowDialog();
                    if (file.DialogResult == DialogResult.OK) Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void FileMenu_ExportAsDWF_Click(object sender, EventArgs e)
        {
            Guid fileId = Guid.NewGuid();
            Guid volumeId = Guid.NewGuid();
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            bool isExpList = this.ExpList.Focused;
            if (isExpList)
            {
                selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                if (selectedItem == null || selectedItem.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Name);
                fileId = Guid.Parse(selectedItem.Name);
            }
            else
            {
                if (selectedNode == null || selectedNode.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Parent.Name);
                fileId = Guid.Parse(selectedNode.Name);
            }
            File file = db.File.SingleOrDefault(f => f.FileID == fileId);
            Export(file.QrCode, "DWF");
        }
        private void FileMenu_ExportAsDWG_Click(object sender, EventArgs e)
        {
            Guid fileId = Guid.NewGuid();
            Guid volumeId = Guid.NewGuid();
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            bool isExpList = this.ExpList.Focused;
            if (isExpList)
            {
                selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                if (selectedItem == null || selectedItem.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Name);
                fileId = Guid.Parse(selectedItem.Name);
            }
            else
            {
                if (selectedNode == null || selectedNode.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Parent.Name);
                fileId = Guid.Parse(selectedNode.Name);
            }
            File file = db.File.SingleOrDefault(f => f.FileID == fileId);
            Export(file.QrCode, "DWG");
        }
        private void FileMenu_ExportAsPlot_Click(object sender, EventArgs e)
        {
            Guid fileId = Guid.NewGuid();
            Guid volumeId = Guid.NewGuid();
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            bool isExpList = this.ExpList.Focused;
            if (isExpList)
            {
                selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                if (selectedItem == null || selectedItem.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Name);
                fileId = Guid.Parse(selectedItem.Name);
            }
            else
            {
                if (selectedNode == null || selectedNode.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Parent.Name);
                fileId = Guid.Parse(selectedNode.Name);
            }
            File file = db.File.SingleOrDefault(f => f.FileID == fileId);
            Export(file.QrCode, "PLT");
        }
        private void FileMenu_Preview_Click(object sender, EventArgs e)
        {
            Guid fileId = Guid.NewGuid();
            Guid volumeId = Guid.NewGuid();
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            bool isExpList = this.ExpList.Focused;
            if (isExpList)
            {
                selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                if (selectedItem == null || selectedItem.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Name);
                fileId = Guid.Parse(selectedItem.Name);
            }
            else
            {
                if (selectedNode == null || selectedNode.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Parent.Name);
                fileId = Guid.Parse(selectedNode.Name);
            }
            File file = db.File.SingleOrDefault(f => f.FileID == fileId);
            ArchiveInfo info = db.ArchiveInfo.SingleOrDefault(a => a.编号 == file.QrCode && a.是否归档 == 1);
            string localName = "D:\\PreView\\" + (string.IsNullOrEmpty(info.FileName) ? Guid.NewGuid().ToString() : info.FileName.Trim()) + ".pdf";
            string filePath = DownLoad(localName, info.pdf).Ressult.ToString();
            if (!System.IO.File.Exists(filePath))
            {
                MessageBox.Show("文件不存在");
                return;
            }
            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FileMenu_ExportAsPDF_Click(object sender, EventArgs e)
        {
            Guid fileId = Guid.NewGuid();
            Guid volumeId = Guid.NewGuid();
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            bool isExpList = this.ExpList.Focused;
            if (isExpList)
            {
                selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                if (selectedItem == null || selectedItem.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Name);
                fileId = Guid.Parse(selectedItem.Name);
            }
            else
            {
                if (selectedNode == null || selectedNode.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Parent.Name);
                fileId = Guid.Parse(selectedNode.Name);
            }
            File file = db.File.SingleOrDefault(f => f.FileID == fileId);
            Export(file.QrCode, "PDF");
        }
        private void FileMenu_DownLoadAttachment_Click(object sender, EventArgs e)
        {
            Guid fileId = Guid.NewGuid();
            Guid volumeId = Guid.NewGuid();
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            bool isExpList = this.ExpList.Focused;
            if (isExpList)
            {
                selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                if (selectedItem == null || selectedItem.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Name);
                fileId = Guid.Parse(selectedItem.Name);
            }
            else
            {
                if (selectedNode == null || selectedNode.Tag.GetType().Name != "File") { MessageBox.Show("请选择一个文件"); return; }
                volumeId = Guid.Parse(selectedNode.Parent.Name);
                fileId = Guid.Parse(selectedNode.Name);
            }
            File file = db.File.SingleOrDefault(f => f.FileID == fileId);
            Export(file.QrCode, "Attachment");
            return;
        }
        #endregion

        #region 创建右键菜单
        private void TreeV_MouseDown(object sender, MouseEventArgs e)
        {
            if (TreeV.SelectedNode == null) return;
            LoadMenu(e.Button, TreeV.SelectedNode, TreeV);
        }
        private void ExpList_MouseDown(object sender, MouseEventArgs e)
        {
            if (ExpList.SelectedItems == null || ExpList.SelectedItems.Count == 0) return;
            LoadMenu(e.Button, ExpList.SelectedItems[0], ExpList);
        }
        private void LoadMenu(MouseButtons buttons, object data, Control c)
        {
            if (buttons != MouseButtons.Right) return;
            if (data == null)
            {
                MessageBox.Show("请选择一项");
                c.ContextMenuStrip = null;
                return;
            }
            try
            {
                if (data.GetType().Name == "TreeNode")
                {
                    TreeNode item = (TreeNode)data;
                    c.Tag = item;
                    switch (item.Tag.GetType().Name)
                    {
                        case "Project":
                            c.ContextMenuStrip = ProjectMenu;
                            break;
                        case "Volume":
                            c.ContextMenuStrip = VolumeMenu;
                            break;
                        case "File":
                            c.ContextMenuStrip = FileMenu;
                            break;
                    }
                }
                else
                {
                    ListViewItem item = (ListViewItem)data;
                    c.Tag = item;
                    switch (item.Tag.GetType().Name)
                    {
                        case "Project":
                            c.ContextMenuStrip = ProjectMenu;
                            break;
                        case "Volume":
                            c.ContextMenuStrip = VolumeMenu;
                            break;
                        case "File":
                            c.ContextMenuStrip = FileMenu;
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("获取菜单出错");
            }
        }
        private void TreeV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode treeNode = e.Node;
            LoadListView(treeNode);
        }
        public void LoadListView(TreeNode treeNode)
        {
            if (treeNode == null) return;
            this.ExpList.Items.Clear();
            this.ExpList.Columns.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            switch (treeNode.Tag.GetType().Name)
            {
                case "Object":
                    ExpList.Columns.AddRange(new ColumnHeader[]
                    {
                        new ColumnHeader  {  Text = "序号",   Width = 150 },
                         new ColumnHeader  {  Text = "项目名称",   Width = 150 },
                         new ColumnHeader  {  Text = "项目代号",    Width = 150 },
                         new ColumnHeader  {  Text = "完成时间",    Width = 150 },
                         new ColumnHeader  {  Text = "设计单位",    Width = 150 },
                         new ColumnHeader  {  Text = "备注",  Width = 300  }
                    });
                    List<Project> projects = db.Project.AsNoTracking().Where(pro => pro.IsDelete == false).OrderByDescending(pro => pro.Sort).ToList();
                    int projectNum = 1;
                    foreach (Project project in projects)
                    {
                        item = new ListViewItem(projectNum++.ToString(), 0)
                        {
                            Tag = project,
                            ImageKey = "Project.png",
                            Name = project.ProjectID.ToString()
                        };
                        subItems = new ListViewItem.ListViewSubItem[]
                        {
                            new ListViewItem.ListViewSubItem(item,project.ProjectName??""),
                            new ListViewItem.ListViewSubItem(item,project.ProjectCode??""),
                            new ListViewItem.ListViewSubItem(item,project.Finished.ToString()),
                            new ListViewItem.ListViewSubItem(item,project.DesignUnit),
                            new ListViewItem.ListViewSubItem(item,project.Remarks),
                        };
                        item.SubItems.AddRange(subItems);
                        this.ExpList.Items.Add(item);
                    }
                    break;
                case "Project":
                    ExpList.Columns.AddRange(new ColumnHeader[]
                    {
                        new ColumnHeader  {  Text = "序号",   Width = 150 },
                         new ColumnHeader  {  Text = "关键字",   Width = 150 },
                         new ColumnHeader  {  Text = "档号",   Width = 150 },
                         new ColumnHeader  {  Text = "案卷题名",   Width = 150 },
                         new ColumnHeader  {  Text = "文本",   Width = 150 },
                         new ColumnHeader  {  Text = "所在卷册",   Width = 150 },
                         new ColumnHeader  {  Text = "归档份数",   Width = 150 },
                         new ColumnHeader  {  Text = "编制日期",   Width = 150 },
                         new ColumnHeader  {  Text = "编制单位",   Width = 150 },
                         new ColumnHeader  {  Text = "设计阶段",    Width = 150 },
                    });
                    Guid projectId = Guid.TryParse(treeNode.Name, out Guid p) ? p : Guid.NewGuid();
                    List<Volume> volumes = db.Volume.AsNoTracking().Where(v => v.ProjectID == projectId && v.IsDelete == false).OrderByDescending(v => v.Sort).ToList();
                    int volumeNum = 1;
                    foreach (Volume volume in volumes)
                    {
                        item = new ListViewItem(volumeNum++.ToString(), volume.Sort)
                        {
                            Tag = volume,
                            ImageKey = "Volume.png",
                            Name = volume.VolumeID.ToString()
                        };
                        subItems = new ListViewItem.ListViewSubItem[]
                        {
                            new ListViewItem.ListViewSubItem(item,volume.Keyword??""),
                            new ListViewItem.ListViewSubItem(item,volume.ArchiveCode??""),
                            new ListViewItem.ListViewSubItem(item,volume.VolumeName??""),
                            new ListViewItem.ListViewSubItem(item,volume.VolumeText??""),
                            new ListViewItem.ListViewSubItem(item,volume.VolumeName??""),
                            new ListViewItem.ListViewSubItem(item,volume.ArchiveNumber.ToString()),
                            new ListViewItem.ListViewSubItem(item,volume.OrganizationDate.ToString()),
                            new ListViewItem.ListViewSubItem(item,volume.OrganizationUnit),
                            new ListViewItem.ListViewSubItem(item,volume.Phase),
                        };
                        item.SubItems.AddRange(subItems);
                        this.ExpList.Items.Add(item);
                    }
                    break;
                case "Volume":
                    ExpList.Columns.AddRange(new ColumnHeader[]
                   {
                         new ColumnHeader  {  Text = "序号",   Width = 150 },
                         new ColumnHeader  {  Text = "关键字",   Width = 150 },
                         new ColumnHeader  {  Text = "档号",    Width = 150 },
                         new ColumnHeader  {  Text = "文件标题",    Width = 150 },
                         new ColumnHeader  {  Text = "文件名",    Width = 150 },
                         new ColumnHeader  {  Text = "图号",    Width = 150 },
                         new ColumnHeader  {  Text = "图标名称",    Width = 150 },
                         new ColumnHeader  {  Text = "编制日期",    Width = 150 },
                         new ColumnHeader  {  Text = "设计者",    Width = 150 },
                         new ColumnHeader  {  Text = "设计阶段",  Width = 300  }

                   });
                    Guid volumeId = Guid.TryParse(treeNode.Name, out Guid g) ? g : Guid.NewGuid();
                    List<File> files = db.File.AsNoTracking().Where(f => f.VolumID == volumeId && f.IsDelete == false).OrderByDescending(f => f.Sort).ToList();
                    int fileNum = 1;
                    foreach (File file in files)
                    {
                        item = new ListViewItem(fileNum++.ToString(), 0)
                        {
                            Tag = file,
                            ImageKey = "File.png",
                            Name = file.FileID.ToString()
                        };
                        subItems = new ListViewItem.ListViewSubItem[]
                        {
                            new ListViewItem.ListViewSubItem(item,file.Keyword),
                            new ListViewItem.ListViewSubItem(item,file.ArchiveCode),
                            new ListViewItem.ListViewSubItem(item,file.FileTitle),
                            new ListViewItem.ListViewSubItem(item,file.FileName),
                            new ListViewItem.ListViewSubItem(item,file.MapCode),
                            new ListViewItem.ListViewSubItem(item,file.IconName),
                            new ListViewItem.ListViewSubItem(item,file.V_OrganizationDate.ToString()),
                            new ListViewItem.ListViewSubItem(item,file.Designer),
                            new ListViewItem.ListViewSubItem(item,file.Phase),
                        };
                        item.SubItems.AddRange(subItems);
                        this.ExpList.Items.Add(item);
                    }
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 双击编辑文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Guid fileId = Guid.NewGuid();
                Guid volumeId = Guid.NewGuid();
                selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                if (selectedItem == null) { MessageBox.Show("请选择一个项"); return; }
                switch (selectedItem.Tag.GetType().Name)
                {
                    case "Project":
                        {
                            TreeNode treeNode = new TreeNode
                            {
                                Tag = selectedItem.Tag,
                                Name = selectedItem.Name
                            };
                            LoadListView(treeNode);
                            TreeNode[] nodes = this.TreeV.Nodes.Find(selectedItem.Name, true);
                            if (nodes != null && nodes.Count() > 0)
                            {
                                this.TreeV.SelectedNode = nodes[0];
                            }
                        }
                        break;
                    case "Volume":
                        {
                            TreeNode treeNode = new TreeNode
                            {
                                Tag = selectedItem.Tag,
                                Name = selectedItem.Name
                            };
                            LoadListView(treeNode);
                            TreeNode[] nodes = this.TreeV.Nodes.Find(selectedItem.Name, true);
                            if (nodes != null && nodes.Count() > 0)
                            {
                                this.TreeV.SelectedNode = nodes[0];
                            }
                        }
                        break;
                    case "File":
                        {
                            selectedNode = TreeV.SelectedNode ?? selectedNode;
                            volumeId = Guid.Parse(TreeV.SelectedNode.Name);
                            fileId = Guid.Parse(selectedItem.Name);
                            using (AddFile file = new AddFile("Edit", volumeId, fileId, "", new List<Guid>()))
                            {
                                file.ShowDialog();
                                if (file.DialogResult == DialogResult.OK) Init();
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="qrCode">文件二维码</param>
        /// <param name="type">导出类型</param>
        private void Export(string qrCode, string type)
        {
            string filePath = "";
            string extendName = "";
            ArchiveInfo info = db.ArchiveInfo.AsNoTracking().SingleOrDefault(a => a.编号 == qrCode && a.是否归档 == 1);
            if (info == null)
            {
                MessageBox.Show("文件记录不存在");
                return;
            };
            string fileName = string.IsNullOrEmpty(info.FileName) ? Guid.NewGuid().ToString() : info.FileName.Trim();
            switch (type)
            {
                case "PDF":
                    {
                        filePath = info.pdf;
                        extendName = ".pdf";
                    }
                    break;
                case "DWF":
                    {
                        filePath = info.dwf;
                        extendName = ".dwf";
                    }
                    break;
                case "DWG":
                    {
                        filePath = info.dwg;
                        extendName = ".dwg";
                    }
                    break;
                case "PLT":
                    {
                        filePath = info.plt;
                        extendName = ".plt";
                    }
                    break;
                case "Preview":
                    {
                        filePath = info.pdf;
                        extendName = ".pdf";
                    }
                    break;
                case "Attachment":
                    {
                        filePath = info.Attachment;
                        fileName = info.Attachment.Substring(info.Attachment.LastIndexOf('\\') + 1);
                    }
                    break;
            }
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string localPath = $"{folderBrowserDialog.SelectedPath}\\{fileName + extendName}";
                    ResultMessage result = DownLoad(localPath, filePath);
                    MessageBox.Show(result.Message);
                }
            }
        }
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回下载信息</returns>
        private ResultMessage DownLoad(string localPath, string fileDownPath)
        {
            ResultMessage result = new ResultMessage();
            if (string.IsNullOrEmpty(fileDownPath))
            {
                result.Ressult = "";
                result.HasError = true;
                result.Message = "文件名失效";
            }
            else
            {
                if (!System.IO.File.Exists(localPath))
                {
                    bool IsOK = HttpServerHelper.DownLoadFile(fileDownPath, localPath);
                    if (IsOK)
                    {
                        result.HasError = false;
                        result.Message = "下载成功";
                        result.Ressult = localPath;
                    }
                    else
                    {
                        result.Ressult = fileDownPath;
                        result.HasError = true;
                        result.Message = "下载失败";
                    }
                }
                else
                {
                    result.Ressult = localPath;
                    result.HasError = false;
                    result.Message = "文件夹下已存在";
                }
            }
            return result;
        }

        #region 查找
        private void Menu_CardSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.treeNodes.Clear();
                bool isExpList = this.ExpList.Focused;
                selectedNode = TreeV.SelectedNode ?? selectedNode;
                if (isExpList)
                {
                    selectedItem = this.ExpList.SelectedItems.Count > 0 ? this.ExpList.SelectedItems[0] : null;
                    if (selectedItem == null) { MessageBox.Show("请选择一个项"); return; }
                    switch (selectedItem.Tag.GetType().Name)
                    {
                        case "Project":
                            {
                                using (SearchProject project = new SearchProject(treeNodes))
                                {
                                    project.TransfEvent += Search_TransfEvent;
                                    project.ShowDialog();
                                    if (project.DialogResult == DialogResult.OK)
                                    {
                                        LoadSearchListView(treeNodes);
                                    }
                                }
                            }
                            break;
                        case "Volume":
                            {
                                using (SearchVolume volume = new SearchVolume(treeNodes))
                                {
                                    volume.TransfEvent += Search_TransfEvent;
                                    volume.ShowDialog();
                                    if (volume.DialogResult == DialogResult.OK)
                                    {
                                        LoadSearchListView(treeNodes);
                                    }
                                }
                            }
                            break;
                        case "File":
                            {
                                using (SearchFile file = new SearchFile(treeNodes))
                                {
                                    file.TransfEvent += Search_TransfEvent;
                                    file.ShowDialog();
                                    if (file.DialogResult == DialogResult.OK)
                                    {
                                        LoadSearchListView(treeNodes);
                                    }
                                }
                            }
                            break;
                    }
                }
                else
                {
                    if (selectedNode == null) { MessageBox.Show("请选择一个项"); return; }
                    switch (selectedNode.Tag.GetType().Name)
                    {
                        case "Project":
                            {
                                using (SearchProject project = new SearchProject(treeNodes))
                                {
                                    project.TransfEvent += Search_TransfEvent;
                                    project.ShowDialog();
                                    if (project.DialogResult == DialogResult.OK)
                                    {
                                        LoadSearchListView(treeNodes);
                                    }
                                }
                            }
                            break;
                        case "Volume":
                            {
                                using (SearchVolume volume = new SearchVolume(treeNodes))
                                {
                                    volume.TransfEvent += Search_TransfEvent;
                                    volume.ShowDialog();
                                    if (volume.DialogResult == DialogResult.OK)
                                    {
                                        LoadSearchListView(treeNodes);
                                    }
                                }
                            }
                            break;
                        case "File":
                            {
                                using (SearchFile file = new SearchFile(treeNodes))
                                {
                                    file.TransfEvent += Search_TransfEvent;
                                    file.ShowDialog();
                                    if (file.DialogResult == DialogResult.OK)
                                    {
                                        LoadSearchListView(treeNodes);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void LoadSearchListView(List<TreeNode> treeNodes)
        {
            this.ExpList.Items.Clear();
            this.ExpList.Columns.Clear();
            if (treeNodes == null || treeNodes.Count == 0) return;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item;
            switch (treeNodes[0].Tag.GetType().Name)
            {
                case "Project":
                    ExpList.Columns.AddRange(new ColumnHeader[]
                    {
                         new ColumnHeader  {  Text = "项目名称",   Width = 150 },
                         new ColumnHeader  {  Text = "项目代号",    Width = 150 },
                         new ColumnHeader  {  Text = "完成时间",    Width = 150 },
                         new ColumnHeader  {  Text = "设计单位",    Width = 150 },
                         new ColumnHeader  {  Text = "备注",  Width = 300  }
                    });
                    foreach (TreeNode treeNode in treeNodes)
                    {
                        Project project = (Project)treeNode.Tag;
                        item = new ListViewItem(project.ProjectName, 0)
                        {
                            Tag = project,
                            ImageKey = "Project.png",
                            Name = project.ProjectID.ToString()
                        };
                        subItems = new ListViewItem.ListViewSubItem[]
                        {
                            new ListViewItem.ListViewSubItem(item,project.ProjectCode??""),
                            new ListViewItem.ListViewSubItem(item,project.Finished.ToString()),
                            new ListViewItem.ListViewSubItem(item,project.DesignUnit),
                            new ListViewItem.ListViewSubItem(item,project.Remarks),
                        };
                        item.SubItems.AddRange(subItems);
                        this.ExpList.Items.Add(item);
                    }
                    break;
                case "Volume":
                    ExpList.Columns.AddRange(new ColumnHeader[]
                    {
                         new ColumnHeader  {  Text = "关键字",   Width = 150 },
                         new ColumnHeader  {  Text = "档号",   Width = 150 },
                         new ColumnHeader  {  Text = "案卷题名",   Width = 150 },
                         new ColumnHeader  {  Text = "文本",   Width = 150 },
                         new ColumnHeader  {  Text = "所在卷册",   Width = 150 },
                         new ColumnHeader  {  Text = "归档份数",   Width = 150 },
                         new ColumnHeader  {  Text = "编制日期",   Width = 150 },
                         new ColumnHeader  {  Text = "编制单位",   Width = 150 },
                         new ColumnHeader  {  Text = "设计阶段",    Width = 150 },
                    });
                    foreach (TreeNode treeNode in treeNodes)
                    {
                        Volume volume = (Volume)treeNode.Tag;
                        item = new ListViewItem(volume.Keyword, 0)
                        {
                            Tag = volume,
                            ImageKey = "Volume.png",
                            Name = volume.VolumeID.ToString()
                        };
                        subItems = new ListViewItem.ListViewSubItem[]
                        {
                            new ListViewItem.ListViewSubItem(item,volume.ArchiveCode??""),
                            new ListViewItem.ListViewSubItem(item,volume.VolumeName??""),
                            new ListViewItem.ListViewSubItem(item,volume.VolumeText??""),
                            new ListViewItem.ListViewSubItem(item,volume.VolumeName??""),
                            new ListViewItem.ListViewSubItem(item,volume.ArchiveNumber.ToString()),
                            new ListViewItem.ListViewSubItem(item,volume.OrganizationDate.ToString()),
                            new ListViewItem.ListViewSubItem(item,volume.OrganizationUnit),
                            new ListViewItem.ListViewSubItem(item,volume.Phase),
                        };
                        item.SubItems.AddRange(subItems);
                        this.ExpList.Items.Add(item);
                    }
                    break;
                case "File":
                    ExpList.Columns.AddRange(new ColumnHeader[]
                   {
                         new ColumnHeader  {  Text = "关键字",   Width = 150 },
                         new ColumnHeader  {  Text = "档号",    Width = 150 },
                         new ColumnHeader  {  Text = "文件标题",    Width = 150 },
                         new ColumnHeader  {  Text = "文件名",    Width = 150 },
                         new ColumnHeader  {  Text = "图号",    Width = 150 },
                         new ColumnHeader  {  Text = "图标名称",    Width = 150 },
                         new ColumnHeader  {  Text = "编制日期",    Width = 150 },
                         new ColumnHeader  {  Text = "设计者",    Width = 150 },
                         new ColumnHeader  {  Text = "设计阶段",  Width = 300  }

                   });
                    foreach (TreeNode treeNode in treeNodes)
                    {
                        File file = (File)treeNode.Tag;
                        item = new ListViewItem(file.Keyword, 0)
                        {
                            Tag = file,
                            ImageKey = "File.png",
                            Name = file.FileID.ToString()
                        };
                        subItems = new ListViewItem.ListViewSubItem[]
                        {
                            new ListViewItem.ListViewSubItem(item,file.V_ArchiveNumber.ToString()),
                            new ListViewItem.ListViewSubItem(item,file.FileTitle),
                            new ListViewItem.ListViewSubItem(item,file.FileName),
                            new ListViewItem.ListViewSubItem(item,file.MapCode),
                            new ListViewItem.ListViewSubItem(item,file.IconName),
                            new ListViewItem.ListViewSubItem(item,file.V_OrganizationDate.ToString()),
                            new ListViewItem.ListViewSubItem(item,file.Designer),
                            new ListViewItem.ListViewSubItem(item,file.Phase),
                        };
                        item.SubItems.AddRange(subItems);
                        this.ExpList.Items.Add(item);
                    }
                    break;
                case "List":
                    {

                    }
                    break;
            }
        }
        #endregion

        #region  拖动排序
        /// <summary>
        /// 当拖动某项时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            ExpList.MultiSelect = false;
            ExpList.DoDragDrop(e.Item, DragDropEffects.Move);
        }
        /// <summary>
        /// 鼠标拖动某项至该控件的区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void ExpList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        /// <summary>
        /// 拖动时拖着某项置于某行上方时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void ExpList_DragOver(object sender, DragEventArgs e)
        {
            Point ptScreen = new Point(e.X, e.Y);
            Point pt = ExpList.PointToClient(ptScreen);
            ListViewItem item = ExpList.GetItemAt(pt.X, pt.Y);
            if (item != null) item.Selected = true;
            selectedNode = TreeV.SelectedNode ?? selectedNode;
        }

        /// <summary>
        /// 结束拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void ExpList_DragDrop(object sender, DragEventArgs e)
        {
            selectedNode = TreeV.SelectedNode ?? selectedNode;
            ListViewItem draggedItem = (ListViewItem) e.Data.GetData(typeof(ListViewItem));
            Point ptScreen = new Point(e.X, e.Y);
            Point pt = ExpList.PointToClient(ptScreen);
            ListViewItem TargetItem = ExpList.GetItemAt(pt.X, pt.Y); //拖动的项将放置于该项之前   
            if (null == TargetItem) return;
            ListViewItem newListViewItem = (ListViewItem) draggedItem.Clone();
            newListViewItem.Name = draggedItem.Name;
            ExpList.Items.Insert(TargetItem.Index, newListViewItem);
            ExpList.Items[TargetItem.Index].Selected = true;
            switch (draggedItem.Tag.GetType().Name)
            {
                case "Project":
                {
                    Project draggedProject = (Project) draggedItem.Tag;
                    Project targetProject = (Project) TargetItem.Tag;
                    draggedProject = db.Project.SingleOrDefault(p => p.ProjectID == draggedProject.ProjectID);
                    targetProject = db.Project.SingleOrDefault(p => p.ProjectID == targetProject.ProjectID);
                    int temp = draggedProject.Sort;
                    draggedProject.Sort = targetProject.Sort;
                    targetProject.Sort = temp;
                    db.SaveChanges();
                }
                    break;
                case "Volume":
                {
                    Volume draggedVolume = (Volume) draggedItem.Tag;
                    Volume targetVolume = (Volume) TargetItem.Tag;
                    draggedVolume = db.Volume.SingleOrDefault(p => p.VolumeID == draggedVolume.VolumeID);
                    targetVolume = db.Volume.SingleOrDefault(p => p.VolumeID == targetVolume.VolumeID);
                    int temp = draggedVolume.Sort;
                    draggedVolume.Sort = targetVolume.Sort;
                    targetVolume.Sort = temp;
                    db.SaveChanges();
                }
                    break;
                case "File":
                {
                    File draggedFile = (File) draggedItem.Tag;
                    File targetFile = (File) TargetItem.Tag;
                    draggedFile = db.File.SingleOrDefault(p => p.FileID == draggedFile.FileID);
                    targetFile = db.File.SingleOrDefault(p => p.FileID == targetFile.FileID);
                    int temp = draggedFile.Sort;
                    draggedFile.Sort = targetFile.Sort;
                    targetFile.Sort = temp;
                    db.SaveChanges();
                }
                    break;
            } 
            ExpList.Items.Remove(draggedItem);
            LoadListView(selectedNode);
            ExpList.MultiSelect = true;
        }

        #endregion 

        private void ExpList_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.ExpList.FocusedItem ?? this.ExpList.Items[0];
            string id = item.Name;
            TreeNode[] treeNodes = null;
            if (item.Tag.GetType().Name == "File")
            {
                Guid guid = Guid.TryParse(id, out guid) ? guid : Guid.NewGuid();
                File file = db.File.SingleOrDefault(f => f.FileID == guid);
                if (file != null)
                {
                    id = file.VolumID.ToString();
                    treeNodes = this.TreeV.Nodes.Find(id, true);
                    this.TreeV.SelectedNode = treeNodes[0];
                }
            }
            else
            {
                treeNodes = this.TreeV.Nodes.Find(id, true);
                this.TreeV.SelectedNode = treeNodes[0];
            }
            ClearColor(this.TreeV.Nodes);
            this.TreeV.ExpandAll();
            if (treeNodes != null && treeNodes.Count() > 0) AddColor(treeNodes[0]);
        }
        /// <summary>
        /// 给节点添加颜色
        /// </summary>
        /// <param name="node"></param>
        private void AddColor(TreeNode node)
        {
            node.ForeColor = Color.BurlyWood;
            if (node.Parent != null) AddColor(node.Parent);
        }
        /// <summary>
        /// 去掉节点树的颜色
        /// </summary>
        /// <param name="nodes"></param>
        private void ClearColor(TreeNodeCollection nodes)
        {
            foreach (object node in nodes)
            {
                TreeNode treeNode = (TreeNode)node;
                treeNode.ForeColor = Color.Black;
                if (treeNode.Nodes != null && treeNode.Nodes.Count > 0) ClearColor(treeNode.Nodes);
            }
        }   
    }
}
