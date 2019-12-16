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
    public partial class AddVolume : Form
    {
        private readonly string type;
        private readonly Guid volumeId;
        private readonly Guid projectId;
        private readonly ScanArchivingEntities db = new ScanArchivingEntities();
        public AddVolume(string type, Guid? projectId, Guid? volumeId)
        {
            this.volumeId = volumeId ?? Guid.NewGuid();
            this.projectId = projectId ?? Guid.NewGuid();
            this.type = type;
            InitializeComponent();
            this.ArchiveDate.Format = DateTimePickerFormat.Custom;
            this.ArchiveDate.CustomFormat = " ";
            this.IdentifyDate.Format = DateTimePickerFormat.Custom;
            this.IdentifyDate.CustomFormat = " ";
            this.OrganizationDate.Format = DateTimePickerFormat.Custom;
            this.OrganizationDate.CustomFormat = " ";
            Init();
        } 
        private void Init()
        { 
            Project project = db.Project.AsNoTracking().SingleOrDefault(p => p.ProjectID == projectId);
            if (project == null) return;
            switch (type)
            {
                case "Add":
                    this.ProjectName.Text = project.ProjectName;
                    this.ProjectCode.Text = project.ProjectCode;  
                    break;
                case "Edit":
                    {
                        Volume volume = db.Volume.AsNoTracking().SingleOrDefault(v => v.VolumeID == volumeId);
                        this.Keyword.Text = volume.Keyword;
                        this.ArchiveCode.Text = volume.ArchiveCode;
                        this.VolumeCode.Text = volume.VolumeCode;
                        this.ProjectCode.Text = project.ProjectCode;
                        this.ProjectName.Text = project.ProjectName;
                        this.TypeCode.Text = volume.TypeCode;
                        this.TemporaryCode.Text = volume.TemporaryCode;
                        this.VolumeText.Text = volume.VolumeText;
                        this.VolumeName.Text = volume.VolumeName;
                        this.DossierCode.Text = volume.DossierCode;
                        this.VolumeTitle.Text = volume.VolumeTitle;
                        this.ArchiveNumber.Text = volume.ArchiveNumber.ToString();
                        this.VolumeLocation.Text = volume.VolumeLocation;
                        this.OrganizationDate.Value = volume.OrganizationDate ?? DateTime.Now;
                        this.OrganizationUnit.Text = volume.OrganizationUnit;
                        this.Phase.Text = volume.Phase;
                        this.PageSize.Text = volume.PageSize.ToString();
                        this.Themewords.Text = volume.Themewords;
                        this.KeepDate.Text = volume.KeepDate;
                        this.SecretLevel.Text = volume.SecretLevel.ToString();
                        this.IdentifyDate.Value = volume.IdentifyDate ?? DateTime.Now;
                        this.SerialNumber.Text = volume.SerialNumber.ToString();
                        this.Symbol.Text = volume.Symbol;
                        this.Responsibler.Text = volume.Responsibler;
                        this.DepartmentCode.Text = volume.DepartmentCode;
                        this.ArchiveDate.Value = volume.ArchiveDate ?? DateTime.Now;
                        this.Remarks.Text = volume.Remarks;
                        this.Btn_Save.Visible = true;
                    }
                    break;
                case "Display":
                    {
                        Volume volume = db.Volume.AsNoTracking().SingleOrDefault(v => v.VolumeID == volumeId);
                        this.ProjectName.Text = project.ProjectName;
                        this.ProjectCode.Text = project.ProjectCode;
                        this.TypeCode.Text = project.TypeCode;
                        this.Remarks.Text = project.Remarks;
                        this.Keyword.Text = volume.Keyword;
                        this.ArchiveCode.Text = volume.ArchiveCode;
                        this.VolumeCode.Text = volume.VolumeCode;
                        this.VolumeTitle.Text = volume.VolumeTitle; 
                        this.ProjectCode.Text = volume.ProjectCode;
                        this.ProjectName.Text = volume.ProjectName;
                        this.DossierCode.Text = volume.DossierCode;
                        this.TypeCode.Text = volume.TypeCode;
                        this.TemporaryCode.Text = volume.TemporaryCode;
                        this.VolumeText.Text = volume.VolumeText;
                        this.VolumeName.Text = volume.VolumeName;
                        this.VolumeTitle.Text = volume.VolumeTitle;
                        this.ArchiveNumber.Text = volume.ArchiveNumber.ToString();
                        this.VolumeLocation.Text = volume.VolumeLocation;
                        this.OrganizationDate.Value = volume.OrganizationDate ?? DateTime.Now;
                        this.OrganizationUnit.Text = volume.OrganizationUnit;
                        this.Phase.Text = volume.Phase;
                        this.PageSize.Text = volume.PageSize.ToString();
                        this.Themewords.Text = volume.Themewords;
                        this.KeepDate.Text = volume.KeepDate;
                        this.SecretLevel.Text = volume.SecretLevel.ToString();
                        this.IdentifyDate.Value = volume.IdentifyDate ?? DateTime.Now;
                        this.SerialNumber.Text = volume.SerialNumber.ToString();
                        this.Symbol.Text = volume.Symbol;
                        this.Responsibler.Text = volume.Responsibler;
                        this.DepartmentCode.Text = volume.DepartmentCode;
                        this.ArchiveDate.Value = volume.ArchiveDate ?? DateTime.Now;
                        this.Remarks.Text = volume.Remarks;
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
                Project project = db.Project.SingleOrDefault(p => p.ProjectID == projectId);
                if (project == null)
                {
                    MessageBox.Show("项目不存在，无法操作卷册");return;
                }
                string volumeName = this.VolumeName.Text;
                if (string.IsNullOrEmpty(volumeName))
                {
                    MessageBox.Show("请输入案卷题名"); return;
                } 
                if (type == "Add")
                { 
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
                        VolumeName = volumeName,
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
                        DossierCode= this.DossierCode.Text,
                        Responsibler = this.Responsibler.Text,
                        DepartmentCode = this.DepartmentCode.Text,
                        ArchiveDate = this.ArchiveDate.Value,
                        Remarks = this.Remarks.Text,
                        IsDelete = false,
                        Sort= maxSort + 1

                    };
                    db.Volume.Add(volume); 
                    db.SaveChanges();
                }
                else
                { 
                    Volume volume = db.Volume.SingleOrDefault(v => v.VolumeID == volumeId);
                    volume.ProjectName = this.ProjectName.Text;
                    volume.ProjectCode = this.ProjectCode.Text;
                    volume.TypeCode = this.TypeCode.Text; 
                    volume.ArchiveCode = this.ArchiveCode.Text;
                    volume.VolumeCode = this.VolumeCode.Text;
                    volume.VolumeTitle = this.VolumeTitle.Text;
                    volume.DossierCode = this.DossierCode.Text;
                    volume.TemporaryCode = this.TemporaryCode.Text;
                    volume.VolumeText = this.VolumeText.Text;
                    volume.VolumeName = this.VolumeName.Text;
                    volume.ArchiveNumber = int.Parse(this.ArchiveNumber.Text ?? "-1");
                    volume.VolumeLocation = this.VolumeLocation.Text;
                    volume.OrganizationDate = this.OrganizationDate.Value;
                    volume.OrganizationUnit = this.OrganizationUnit.Text;
                    volume.Phase = this.Phase.Text;
                    volume.PageSize = int.Parse(this.PageSize.Text ?? "-1");
                    volume.Themewords = this.Themewords.Text;
                    volume.KeepDate = this.KeepDate.Text;
                    volume.SecretLevel = this.SecretLevel.Text;
                    volume.IdentifyDate = this.IdentifyDate.Value;
                    volume.SerialNumber = this.SerialNumber.Text;
                    volume.Symbol = this.Symbol.Text;
                    volume.Responsibler = this.Responsibler.Text;
                    volume.DepartmentCode = this.DepartmentCode.Text;
                    volume.ArchiveDate = this.ArchiveDate.Value;
                    volume.Remarks = this.Remarks.Text;
                    if(volume.Keyword != this.Keyword.Text)
                    {
                        volume.Keyword = this.Keyword.Text;
                        List<File> files = db.File.Where(f => f.VolumID == volumeId).ToList();
                        files.ForEach(f => f.V_VolumeCode = volume.Keyword);
                        db.SaveChanges();
                    }
                    db.SaveChanges();
                }
                MessageBox.Show("保存成功");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
