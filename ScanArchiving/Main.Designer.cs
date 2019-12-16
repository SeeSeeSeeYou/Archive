namespace ScanArchiving
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.IconImages = new System.Windows.Forms.ImageList(this.components);
            this.ToolBar = new System.Windows.Forms.MenuStrip();
            this.Tool = new System.Windows.Forms.ToolStripMenuItem();
            this.Files_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Files_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_Operations = new System.Windows.Forms.ToolStripMenuItem();
            this.Operation_ImportDir = new System.Windows.Forms.ToolStripMenuItem();
            this.Operation_ImportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_Projects = new System.Windows.Forms.ToolStripMenuItem();
            this.Projects_Select = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_Helps = new System.Windows.Forms.ToolStripMenuItem();
            this.Helps_Center = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.Menu_AddProject = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_AddVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_AddVolumeWithNoProject = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Archiving = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_CardSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_DeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TreeP = new System.Windows.Forms.Panel();
            this.TreeV = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.p = new System.Windows.Forms.Panel();
            this.ExpList = new System.Windows.Forms.ListView();
            this.FileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileMenu_EditFile = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu_DeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu_WatchFile = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu_EditFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu_ExportAsPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu_ExportAsDWF = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu_ExportAsPLT = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu_Preview = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu_DownLoadAttachment = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu_ExportAsDWG = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ProjectMenu_EditProject = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectMenu_DeleteProject = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectMenu_AddVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectMenu_WatchProject = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.VolumeMenu_EditVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumeMenu_DeleteVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumeMenu_ScanArchiving = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumeMenu_WatchVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumeMenu_AddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumeMenu_ExcelImport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBar.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TreeP.SuspendLayout();
            this.p.SuspendLayout();
            this.FileMenu.SuspendLayout();
            this.ProjectMenu.SuspendLayout();
            this.VolumeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // IconImages
            // 
            this.IconImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.IconImages.ImageSize = new System.Drawing.Size(16, 16);
            this.IconImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ToolBar
            // 
            this.ToolBar.AutoSize = false;
            this.ToolBar.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tool,
            this.Tool_Operations,
            this.Tool_Projects,
            this.Tool_Helps});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.ToolBar.Size = new System.Drawing.Size(1424, 44);
            this.ToolBar.TabIndex = 6;
            this.ToolBar.Text = "menuStrip1";
            this.ToolBar.Visible = false;
            // 
            // Tool
            // 
            this.Tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Files_Add,
            this.Files_Delete});
            this.Tool.Name = "Tool";
            this.Tool.Size = new System.Drawing.Size(49, 38);
            this.Tool.Text = "文件";
            // 
            // Files_Add
            // 
            this.Files_Add.Name = "Files_Add";
            this.Files_Add.Size = new System.Drawing.Size(134, 24);
            this.Files_Add.Text = "添加文件";
            // 
            // Files_Delete
            // 
            this.Files_Delete.Name = "Files_Delete";
            this.Files_Delete.Size = new System.Drawing.Size(134, 24);
            this.Files_Delete.Text = "删除文件";
            // 
            // Tool_Operations
            // 
            this.Tool_Operations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Operation_ImportDir,
            this.Operation_ImportFile});
            this.Tool_Operations.Name = "Tool_Operations";
            this.Tool_Operations.Size = new System.Drawing.Size(49, 38);
            this.Tool_Operations.Text = "操作";
            // 
            // Operation_ImportDir
            // 
            this.Operation_ImportDir.Name = "Operation_ImportDir";
            this.Operation_ImportDir.Size = new System.Drawing.Size(148, 24);
            this.Operation_ImportDir.Text = "导入文件夹";
            // 
            // Operation_ImportFile
            // 
            this.Operation_ImportFile.Name = "Operation_ImportFile";
            this.Operation_ImportFile.Size = new System.Drawing.Size(148, 24);
            this.Operation_ImportFile.Text = "导入文件";
            // 
            // Tool_Projects
            // 
            this.Tool_Projects.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Projects_Select});
            this.Tool_Projects.Name = "Tool_Projects";
            this.Tool_Projects.Size = new System.Drawing.Size(49, 38);
            this.Tool_Projects.Text = "项目";
            // 
            // Projects_Select
            // 
            this.Projects_Select.Name = "Projects_Select";
            this.Projects_Select.Size = new System.Drawing.Size(134, 24);
            this.Projects_Select.Text = "选择项目";
            // 
            // Tool_Helps
            // 
            this.Tool_Helps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Helps_Center});
            this.Tool_Helps.Name = "Tool_Helps";
            this.Tool_Helps.Size = new System.Drawing.Size(49, 38);
            this.Tool_Helps.Text = "帮助";
            // 
            // Helps_Center
            // 
            this.Helps_Center.Name = "Helps_Center";
            this.Helps_Center.Size = new System.Drawing.Size(134, 24);
            this.Helps_Center.Text = "帮助中心";
            // 
            // MenuBar
            // 
            this.MenuBar.AutoSize = false;
            this.MenuBar.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_AddProject,
            this.Menu_AddVolume,
            this.Menu_AddVolumeWithNoProject,
            this.Menu_Archiving,
            this.Menu_CardSearch,
            this.Menu_DeleteFile});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.MenuBar.Size = new System.Drawing.Size(1424, 45);
            this.MenuBar.TabIndex = 10;
            this.MenuBar.Text = "MenuBar";
            // 
            // Menu_AddProject
            // 
            this.Menu_AddProject.Image = ((System.Drawing.Image)(resources.GetObject("Menu_AddProject.Image")));
            this.Menu_AddProject.Name = "Menu_AddProject";
            this.Menu_AddProject.Size = new System.Drawing.Size(89, 39);
            this.Menu_AddProject.Text = "添加项目";
            this.Menu_AddProject.Click += new System.EventHandler(this.Menu_AddProject_Click);
            // 
            // Menu_AddVolume
            // 
            this.Menu_AddVolume.Image = ((System.Drawing.Image)(resources.GetObject("Menu_AddVolume.Image")));
            this.Menu_AddVolume.Name = "Menu_AddVolume";
            this.Menu_AddVolume.Size = new System.Drawing.Size(141, 39);
            this.Menu_AddVolume.Text = "添加卷册（项目）";
            this.Menu_AddVolume.Click += new System.EventHandler(this.Menu_AddVolume_Click);
            // 
            // Menu_AddVolumeWithNoProject
            // 
            this.Menu_AddVolumeWithNoProject.Image = ((System.Drawing.Image)(resources.GetObject("Menu_AddVolumeWithNoProject.Image")));
            this.Menu_AddVolumeWithNoProject.Name = "Menu_AddVolumeWithNoProject";
            this.Menu_AddVolumeWithNoProject.Size = new System.Drawing.Size(89, 39);
            this.Menu_AddVolumeWithNoProject.Text = "添加卷册";
            this.Menu_AddVolumeWithNoProject.Click += new System.EventHandler(this.Menu_AddVolumeWithNoProject_Click);
            // 
            // Menu_Archiving
            // 
            this.Menu_Archiving.Image = ((System.Drawing.Image)(resources.GetObject("Menu_Archiving.Image")));
            this.Menu_Archiving.Name = "Menu_Archiving";
            this.Menu_Archiving.Size = new System.Drawing.Size(89, 39);
            this.Menu_Archiving.Text = "选择归档";
            this.Menu_Archiving.Click += new System.EventHandler(this.Menu_Archiving_Click);
            // 
            // Menu_CardSearch
            // 
            this.Menu_CardSearch.Image = ((System.Drawing.Image)(resources.GetObject("Menu_CardSearch.Image")));
            this.Menu_CardSearch.Name = "Menu_CardSearch";
            this.Menu_CardSearch.Size = new System.Drawing.Size(89, 39);
            this.Menu_CardSearch.Text = "卡片检索";
            this.Menu_CardSearch.Click += new System.EventHandler(this.Menu_CardSearch_Click);
            // 
            // Menu_DeleteFile
            // 
            this.Menu_DeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("Menu_DeleteFile.Image")));
            this.Menu_DeleteFile.Name = "Menu_DeleteFile";
            this.Menu_DeleteFile.Size = new System.Drawing.Size(89, 39);
            this.Menu_DeleteFile.Text = "修改配置";
            this.Menu_DeleteFile.Click += new System.EventHandler(this.Menu_DeleteFile_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.90741F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.09259F));
            this.tableLayoutPanel1.Controls.Add(this.TreeP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.p, 1, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 49);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.7648F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1424, 535);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // TreeP
            // 
            this.TreeP.Controls.Add(this.TreeV);
            this.TreeP.Controls.Add(this.panel1);
            this.TreeP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeP.Location = new System.Drawing.Point(3, 4);
            this.TreeP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TreeP.Name = "TreeP";
            this.TreeP.Size = new System.Drawing.Size(277, 527);
            this.TreeP.TabIndex = 0;
            // 
            // TreeV
            // 
            this.TreeV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeV.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TreeV.FullRowSelect = true;
            this.TreeV.Location = new System.Drawing.Point(0, 0);
            this.TreeV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TreeV.Name = "TreeV";
            this.TreeV.Size = new System.Drawing.Size(277, 527);
            this.TreeV.TabIndex = 2;
            this.TreeV.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeV_NodeMouseClick);
            this.TreeV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeV_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(91, 830);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 22);
            this.panel1.TabIndex = 3;
            // 
            // p
            // 
            this.p.Controls.Add(this.ExpList);
            this.p.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p.Location = new System.Drawing.Point(286, 4);
            this.p.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(1135, 527);
            this.p.TabIndex = 1;
            // 
            // ExpList
            // 
            this.ExpList.AllowColumnReorder = true;
            this.ExpList.AllowDrop = true;
            this.ExpList.BackColor = System.Drawing.SystemColors.Window;
            this.ExpList.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpList.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExpList.FullRowSelect = true;
            this.ExpList.Location = new System.Drawing.Point(0, 0);
            this.ExpList.Margin = new System.Windows.Forms.Padding(0);
            this.ExpList.Name = "ExpList";
            this.ExpList.Size = new System.Drawing.Size(1135, 527);
            this.ExpList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ExpList.TabIndex = 0;
            this.ExpList.UseCompatibleStateImageBehavior = false;
            this.ExpList.View = System.Windows.Forms.View.Details;
            this.ExpList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ExpList_ItemDrag);
            this.ExpList.Click += new System.EventHandler(this.ExpList_Click);
            this.ExpList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExpList_DragDrop);
            this.ExpList.DragEnter += new System.Windows.Forms.DragEventHandler(this.ExpList_DragEnter);
            this.ExpList.DragOver += new System.Windows.Forms.DragEventHandler(this.ExpList_DragOver);
            this.ExpList.DoubleClick += new System.EventHandler(this.ExpList_DoubleClick);
            this.ExpList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExpList_MouseDown);
            // 
            // FileMenu
            // 
            this.FileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.FileMenu_EditFile,
            this.FileMenu_DeleteFile,
            this.FileMenu_WatchFile,
            this.FileMenu_EditFiles,
            this.FileMenu_ExportAsPDF,
            this.FileMenu_ExportAsDWF,
            this.FileMenu_ExportAsPLT,
            this.FileMenu_Preview,
            this.FileMenu_DownLoadAttachment,
            this.FileMenu_ExportAsDWG});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(143, 230);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // FileMenu_EditFile
            // 
            this.FileMenu_EditFile.Name = "FileMenu_EditFile";
            this.FileMenu_EditFile.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_EditFile.Text = "编辑文件";
            this.FileMenu_EditFile.Click += new System.EventHandler(this.FileMenu_EditFile_Click);
            // 
            // FileMenu_DeleteFile
            // 
            this.FileMenu_DeleteFile.Name = "FileMenu_DeleteFile";
            this.FileMenu_DeleteFile.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_DeleteFile.Text = "删除文件";
            this.FileMenu_DeleteFile.Click += new System.EventHandler(this.FileMenu_DeleteFile_Click);
            // 
            // FileMenu_WatchFile
            // 
            this.FileMenu_WatchFile.Name = "FileMenu_WatchFile";
            this.FileMenu_WatchFile.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_WatchFile.Text = "查看文件";
            this.FileMenu_WatchFile.Click += new System.EventHandler(this.FileMenu_WatchFile_Click);
            // 
            // FileMenu_EditFiles
            // 
            this.FileMenu_EditFiles.Name = "FileMenu_EditFiles";
            this.FileMenu_EditFiles.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_EditFiles.Text = "批量编辑";
            this.FileMenu_EditFiles.Click += new System.EventHandler(this.FileMenu_EditFiles_Click);
            // 
            // FileMenu_ExportAsPDF
            // 
            this.FileMenu_ExportAsPDF.Name = "FileMenu_ExportAsPDF";
            this.FileMenu_ExportAsPDF.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_ExportAsPDF.Text = "导出为PDF";
            this.FileMenu_ExportAsPDF.Click += new System.EventHandler(this.FileMenu_ExportAsPDF_Click);
            // 
            // FileMenu_ExportAsDWF
            // 
            this.FileMenu_ExportAsDWF.Name = "FileMenu_ExportAsDWF";
            this.FileMenu_ExportAsDWF.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_ExportAsDWF.Text = "导出为DWF";
            this.FileMenu_ExportAsDWF.Click += new System.EventHandler(this.FileMenu_ExportAsDWF_Click);
            // 
            // FileMenu_ExportAsPLT
            // 
            this.FileMenu_ExportAsPLT.Name = "FileMenu_ExportAsPLT";
            this.FileMenu_ExportAsPLT.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_ExportAsPLT.Text = "导出为PLT";
            this.FileMenu_ExportAsPLT.Click += new System.EventHandler(this.FileMenu_ExportAsPlot_Click);
            // 
            // FileMenu_Preview
            // 
            this.FileMenu_Preview.Name = "FileMenu_Preview";
            this.FileMenu_Preview.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_Preview.Text = "预览";
            this.FileMenu_Preview.Click += new System.EventHandler(this.FileMenu_Preview_Click);
            // 
            // FileMenu_DownLoadAttachment
            // 
            this.FileMenu_DownLoadAttachment.Name = "FileMenu_DownLoadAttachment";
            this.FileMenu_DownLoadAttachment.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_DownLoadAttachment.Text = "下载附件";
            this.FileMenu_DownLoadAttachment.Click += new System.EventHandler(this.FileMenu_DownLoadAttachment_Click);
            // 
            // FileMenu_ExportAsDWG
            // 
            this.FileMenu_ExportAsDWG.Name = "FileMenu_ExportAsDWG";
            this.FileMenu_ExportAsDWG.Size = new System.Drawing.Size(142, 22);
            this.FileMenu_ExportAsDWG.Text = "导出为DWG";
            this.FileMenu_ExportAsDWG.Click += new System.EventHandler(this.FileMenu_ExportAsDWG_Click);
            // 
            // ProjectMenu
            // 
            this.ProjectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.ProjectMenu_EditProject,
            this.ProjectMenu_DeleteProject,
            this.ProjectMenu_AddVolume,
            this.ProjectMenu_WatchProject});
            this.ProjectMenu.Name = "FileMenu";
            this.ProjectMenu.Size = new System.Drawing.Size(125, 98);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // ProjectMenu_EditProject
            // 
            this.ProjectMenu_EditProject.Name = "ProjectMenu_EditProject";
            this.ProjectMenu_EditProject.Size = new System.Drawing.Size(124, 22);
            this.ProjectMenu_EditProject.Text = "编辑项目";
            this.ProjectMenu_EditProject.Click += new System.EventHandler(this.ProjectMenu_EditProject_Click);
            // 
            // ProjectMenu_DeleteProject
            // 
            this.ProjectMenu_DeleteProject.Name = "ProjectMenu_DeleteProject";
            this.ProjectMenu_DeleteProject.Size = new System.Drawing.Size(124, 22);
            this.ProjectMenu_DeleteProject.Text = "删除项目";
            this.ProjectMenu_DeleteProject.Click += new System.EventHandler(this.ProjectMenu_DeleteProject_Click);
            // 
            // ProjectMenu_AddVolume
            // 
            this.ProjectMenu_AddVolume.Name = "ProjectMenu_AddVolume";
            this.ProjectMenu_AddVolume.Size = new System.Drawing.Size(124, 22);
            this.ProjectMenu_AddVolume.Text = "添加卷册";
            this.ProjectMenu_AddVolume.Click += new System.EventHandler(this.ProjectMenu_AddVolume_Click);
            // 
            // ProjectMenu_WatchProject
            // 
            this.ProjectMenu_WatchProject.Name = "ProjectMenu_WatchProject";
            this.ProjectMenu_WatchProject.Size = new System.Drawing.Size(124, 22);
            this.ProjectMenu_WatchProject.Text = "查看项目";
            this.ProjectMenu_WatchProject.Click += new System.EventHandler(this.ProjectMenu_WatchProject_Click);
            // 
            // VolumeMenu
            // 
            this.VolumeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.VolumeMenu_EditVolume,
            this.VolumeMenu_DeleteVolume,
            this.VolumeMenu_ScanArchiving,
            this.VolumeMenu_WatchVolume,
            this.VolumeMenu_AddFile,
            this.VolumeMenu_ExcelImport});
            this.VolumeMenu.Name = "FileMenu";
            this.VolumeMenu.Size = new System.Drawing.Size(130, 142);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(126, 6);
            // 
            // VolumeMenu_EditVolume
            // 
            this.VolumeMenu_EditVolume.Name = "VolumeMenu_EditVolume";
            this.VolumeMenu_EditVolume.Size = new System.Drawing.Size(129, 22);
            this.VolumeMenu_EditVolume.Text = "编辑卷册";
            this.VolumeMenu_EditVolume.Click += new System.EventHandler(this.VolumeMenu_EditVolume_Click);
            // 
            // VolumeMenu_DeleteVolume
            // 
            this.VolumeMenu_DeleteVolume.Name = "VolumeMenu_DeleteVolume";
            this.VolumeMenu_DeleteVolume.Size = new System.Drawing.Size(129, 22);
            this.VolumeMenu_DeleteVolume.Text = "删除卷册";
            this.VolumeMenu_DeleteVolume.Click += new System.EventHandler(this.VolumeMenu_DeleteVolume_Click);
            // 
            // VolumeMenu_ScanArchiving
            // 
            this.VolumeMenu_ScanArchiving.Name = "VolumeMenu_ScanArchiving";
            this.VolumeMenu_ScanArchiving.Size = new System.Drawing.Size(129, 22);
            this.VolumeMenu_ScanArchiving.Text = "扫码归档";
            this.VolumeMenu_ScanArchiving.Click += new System.EventHandler(this.VolumeMenu_ScanArchiving_Click);
            // 
            // VolumeMenu_WatchVolume
            // 
            this.VolumeMenu_WatchVolume.Name = "VolumeMenu_WatchVolume";
            this.VolumeMenu_WatchVolume.Size = new System.Drawing.Size(129, 22);
            this.VolumeMenu_WatchVolume.Text = "查看卷册";
            this.VolumeMenu_WatchVolume.Click += new System.EventHandler(this.VolumeMenu_WatchVolume_Click);
            // 
            // VolumeMenu_AddFile
            // 
            this.VolumeMenu_AddFile.Name = "VolumeMenu_AddFile";
            this.VolumeMenu_AddFile.Size = new System.Drawing.Size(129, 22);
            this.VolumeMenu_AddFile.Text = "添加文件";
            this.VolumeMenu_AddFile.Click += new System.EventHandler(this.VolumeMenu_AddFile_Click);
            // 
            // VolumeMenu_ExcelImport
            // 
            this.VolumeMenu_ExcelImport.Name = "VolumeMenu_ExcelImport";
            this.VolumeMenu_ExcelImport.Size = new System.Drawing.Size(129, 22);
            this.VolumeMenu_ExcelImport.Text = "Execl导入";
            this.VolumeMenu_ExcelImport.Click += new System.EventHandler(this.VolumeMenu_ExcelImport_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 582);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MenuBar);
            this.Controls.Add(this.ToolBar);
            this.Name = "Main";
            this.Text = "扫描归档";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TreeP.ResumeLayout(false);
            this.p.ResumeLayout(false);
            this.FileMenu.ResumeLayout(false);
            this.ProjectMenu.ResumeLayout(false);
            this.VolumeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList IconImages;
        private System.Windows.Forms.MenuStrip ToolBar;
        private System.Windows.Forms.ToolStripMenuItem Tool;
        private System.Windows.Forms.ToolStripMenuItem Files_Add;
        private System.Windows.Forms.ToolStripMenuItem Files_Delete;
        private System.Windows.Forms.ToolStripMenuItem Tool_Operations;
        private System.Windows.Forms.ToolStripMenuItem Operation_ImportDir;
        private System.Windows.Forms.ToolStripMenuItem Operation_ImportFile;
        private System.Windows.Forms.ToolStripMenuItem Tool_Projects;
        private System.Windows.Forms.ToolStripMenuItem Projects_Select;
        private System.Windows.Forms.ToolStripMenuItem Tool_Helps;
        private System.Windows.Forms.ToolStripMenuItem Helps_Center;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem Menu_Archiving;
        private System.Windows.Forms.ToolStripMenuItem Menu_AddProject;
        private System.Windows.Forms.ToolStripMenuItem Menu_DeleteFile;
        private System.Windows.Forms.ToolStripMenuItem Menu_AddVolumeWithNoProject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel TreeP;
        private System.Windows.Forms.TreeView TreeV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel p;
        private System.Windows.Forms.ListView ExpList;
        private System.Windows.Forms.ContextMenuStrip FileMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip ProjectMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip VolumeMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ProjectMenu_EditProject;
        private System.Windows.Forms.ToolStripMenuItem ProjectMenu_DeleteProject;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_EditFile;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_DeleteFile;
        private System.Windows.Forms.ToolStripMenuItem VolumeMenu_EditVolume;
        private System.Windows.Forms.ToolStripMenuItem VolumeMenu_DeleteVolume;
        private System.Windows.Forms.ToolStripMenuItem VolumeMenu_ScanArchiving;
        private System.Windows.Forms.ToolStripMenuItem ProjectMenu_AddVolume;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_WatchFile;
        private System.Windows.Forms.ToolStripMenuItem ProjectMenu_WatchProject;
        private System.Windows.Forms.ToolStripMenuItem VolumeMenu_WatchVolume;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_EditFiles;
        private System.Windows.Forms.ToolStripMenuItem VolumeMenu_AddFile;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_ExportAsPDF;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_ExportAsDWF;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_ExportAsPLT;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_Preview;
        private System.Windows.Forms.ToolStripMenuItem Menu_CardSearch;
        private System.Windows.Forms.ToolStripMenuItem VolumeMenu_ExcelImport;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_DownLoadAttachment;
        private System.Windows.Forms.ToolStripMenuItem FileMenu_ExportAsDWG;
        private System.Windows.Forms.ToolStripMenuItem Menu_AddVolume;
    }
}

