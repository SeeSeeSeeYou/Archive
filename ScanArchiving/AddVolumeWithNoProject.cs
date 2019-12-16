using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanArchiving
{
    public partial class AddVolumeWithNoProject : Form
    {
        private Guid projectId; 
        private readonly ScanArchivingEntities db = new ScanArchivingEntities();
        public AddVolumeWithNoProject()
        {
            InitializeComponent();
            this.ArchiveDate.Format = DateTimePickerFormat.Custom;
            this.ArchiveDate.CustomFormat = " ";
            this.IdentifyDate.Format = DateTimePickerFormat.Custom;
            this.IdentifyDate.CustomFormat = " ";
            this.OrganizationDate.Format = DateTimePickerFormat.Custom;
            this.OrganizationDate.CustomFormat = " ";
        } 

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.ProjectCode.Text) || string.IsNullOrEmpty(this.projectId.ToString()))
                {
                    MessageBox.Show("请输入正确的项目代号");
                    return;
                };
                int maxSort = 0;
                if (db.Volume.ToList() != null && db.Volume.ToList().Count > 0)
                {
                    maxSort = db.Volume.Max(f => f.Sort);
                }
                Volume volume = new Volume
                {
                    ProjectID = projectId,
                    VolumeID = Guid.NewGuid(),
                    ProjectName = this.ProjectName.Text,
                    ProjectCode = this.ProjectCode.Text,
                    TypeCode = this.TypeCode.Text,
                    Keyword = this.Keyword.Text,
                    ArchiveCode = this.ArchiveCode.Text,
                    VolumeCode = this.VolumeCode.Text,
                    VolumeTitle = this.VolumeTitle.Text,
                    TemporaryCode = this.TemporaryCode.Text,
                    VolumeText = this.VolumeText.Text,
                    VolumeName = this.VolumeName.Text,
                    ArchiveNumber = int.TryParse(this.ArchiveNumber.Text, out int i) ? i : 0,
                    VolumeLocation = this.VolumeLocation.Text,
                    OrganizationDate = this.OrganizationDate.Value,
                    OrganizationUnit = this.OrganizationUnit.Text,
                    Phase = this.Phase.Text,
                    PageSize = int.TryParse(this.PageSize.Text, out int l) ? l : 0,
                    Themewords = this.Themewords.Text,
                    KeepDate = this.KeepDate.Text,
                    SecretLevel = this.SecretLevel.Text,
                    IdentifyDate = this.IdentifyDate.Value,
                    SerialNumber = this.SerialNumber.Text,
                    Symbol = this.Symbol.Text,
                    Responsibler = this.Responsibler.Text,
                    DepartmentCode = this.DepartmentCode.Text,
                    ArchiveDate = this.ArchiveDate.Value,
                    Remarks = this.Remarks.Text,
                    IsDelete = false,
                    Sort = maxSort + 1
                };
                db.Volume.Add(volume);
                db.SaveChanges();
                MessageBox.Show("添加成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
        private void ProjectCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string code = this.ProjectCode.Text;
                if (string.IsNullOrEmpty(code))
                {
                    MessageBox.Show("请输入正确的项目代号"); ;
                    return;
                }
                Project project = db.Project.AsNoTracking().SingleOrDefault(p => p.ProjectCode == code);
                if (project == null)
                {
                    this.ProjectCode.Text = string.Empty;
                    MessageBox.Show("请输入正确的项目代号");
                    return;
                };
                this.projectId = project.ProjectID;
                this.ProjectName.Text = project.ProjectName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrganizationDate_ValueChanged(object sender, EventArgs e)
        {
            this.OrganizationDate.Format = DateTimePickerFormat.Long;
            this.OrganizationDate.CustomFormat = null;
        }

        private void IdentifyDate_ValueChanged(object sender, EventArgs e)
        {
            this.IdentifyDate.Format = DateTimePickerFormat.Long;
            this.IdentifyDate.CustomFormat = null;
        }

        private void ArchiveDate_ValueChanged(object sender, EventArgs e)
        {
            this.ArchiveDate.Format = DateTimePickerFormat.Long;
            this.ArchiveDate.CustomFormat = null;
        }
    }
}

