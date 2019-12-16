using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScanArchiving
{
    public partial class AddProject : Form
    {
        private readonly string _type;
        private readonly Guid _projectId;
        private readonly ScanArchivingEntities _db = new ScanArchivingEntities();
        public AddProject(string type, Guid? projectId)
        {
            this._projectId = projectId ?? Guid.NewGuid();
            this._type = type;
            InitializeComponent();
            this.Finished.Format = DateTimePickerFormat.Custom;
            this.Finished.CustomFormat = " ";
            Init();
        }
        private void Init()
        { 
            switch (_type)
            {
                case "Add":
                    {
                        this.Btn_Save.Visible = true;
                    }
                    break;
                case "Edit":
                    {
                        Project project = _db.Project.AsNoTracking().SingleOrDefault(p => p.ProjectID == _projectId);
                        if (project == null) return;
                        this.ProjectName.Text = project.ProjectName;
                        this.ProjectCode.Text = project.ProjectCode;
                        this.Finished.Value = project.Finished ?? DateTime.Now;
                        this.TotalInvestment.Text = project.Investment.ToString();
                        this.RoadLevel.Text = project.RoadLevel.ToString();
                        this.DesignUnit.Text = project.DesignUnit;
                        this.TypeCode.Text = project.TypeCode;
                        this.Remarks.Text = project.Remarks;
                        this.Btn_Save.Visible = true;
                    }
                    break;
                case "Display":
                    {
                        Project project = _db.Project.AsNoTracking().SingleOrDefault(p => p.ProjectID == _projectId);
                        if (project == null) return;
                        this.ProjectName.Text = project.ProjectName;
                        this.ProjectCode.Text = project.ProjectCode;
                        this.Finished.Value = project.Finished ?? DateTime.Now;
                        this.TotalInvestment.Text = project.Investment.ToString();
                        this.RoadLevel.Text = project.RoadLevel.ToString();
                        this.DesignUnit.Text = project.DesignUnit;
                        this.TypeCode.Text = project.TypeCode;
                        this.Remarks.Text = project.Remarks;
                        this.Btn_Save.Visible = false;
                    }
                    break;
            }
        }
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string projectName = this.ProjectName.Text; 
                if (string.IsNullOrEmpty(projectName))
                {
                    MessageBox.Show(@"项目名称必填"); return;
                }  
                if (_type == "Add")
                { 
                    int maxSort=0;
                    if (_db.Project.ToList() != null && _db.Project.ToList().Count > 0)
                    {
                        maxSort = _db.Project.Max(p => p.Sort);
                    }  
                    Project project = new Project
                    {
                        ProjectID = Guid.NewGuid(),
                        ProjectName = projectName,
                        ProjectCode = this.ProjectCode.Text,
                        Finished = this.Finished.Value,
                        Investment = float.TryParse(this.RoadLevel.Text, out float j) ? j : 0,
                        RoadLevel = int.TryParse(this.RoadLevel.Text, out int i) ? i : 0,
                        DesignUnit = this.DesignUnit.Text,
                        TypeCode = this.TypeCode.Text,
                        Remarks = this.Remarks.Text,
                        IsDelete = false,
                        Sort= maxSort + 1
                    };
                    _db.Project.Add(project);
                }
                else
                {
                    var project = _db.Project.SingleOrDefault(p => p.ProjectID == _projectId); 
                    if (project.ProjectCode != this.ProjectCode.Text|| project.ProjectName != this.ProjectName.Text)
                    {
                        project.ProjectCode = this.ProjectCode.Text;
                        project.ProjectName = this.ProjectName.Text;
                        List<Volume> volumes = _db.Volume.Where(v => v.ProjectID == project.ProjectID).ToList(); 
                        volumes.ForEach(volume =>
                        {
                            volume.ProjectName = this.ProjectName.Text;
                            volume.ProjectCode= this.ProjectCode.Text; 
                        });
                     
                    } 
                    project.Finished = this.Finished.Value;
                    project.Investment = float.TryParse(this.RoadLevel.Text, out float j) ? j : 0;
                    project.RoadLevel = int.TryParse(this.RoadLevel.Text, out int i) ? i : 0;
                    project.DesignUnit = this.DesignUnit.Text;
                    project.TypeCode = this.TypeCode.Text;
                    project.Remarks = this.Remarks.Text;  
                }
                _db.SaveChanges();
                MessageBox.Show(@"保存成功");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Finished_ValueChanged(object sender, EventArgs e)
        {
            this.Finished.Format = DateTimePickerFormat.Long;
            this.Finished.CustomFormat = null;
        }
    }
}
