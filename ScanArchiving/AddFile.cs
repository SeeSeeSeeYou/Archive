using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanArchiving
{
    public partial class AddFile : Form
    {
        private Guid volumeId;
        private Guid fileId;
        private readonly string type;
        private readonly string code;
        private readonly List<Guid> fileIds;
        private string uploadPath;
        private readonly ScanArchivingEntities db = new ScanArchivingEntities();
        public AddFile(string type, Guid volumeId, Guid fileId, string code, List<Guid> fileIds)
        {
            this.volumeId = volumeId;
            this.fileId = fileId;
            this.code = code;
            this.type = type;
            this.fileIds = fileIds;
            InitializeComponent();
            this.OrganizationDate.Format = DateTimePickerFormat.Custom;
            this.OrganizationDate.CustomFormat = " ";
            Init();
        }
        private void Init()
        {
            this.Btn_Upload.Visible = false;
            Volume volume = db.Volume.AsNoTracking().SingleOrDefault(v => v.VolumeID == volumeId);
            if (volume == null) return;
            Project project = db.Project.AsNoTracking().SingleOrDefault(p => p.ProjectID == volume.ProjectID);
            if (project == null) return;
            switch (type)
            {
                case "Add":
                    {
                        File file = db.File.AsNoTracking().SingleOrDefault(f => f.FileID == fileId);
                        this.ProjectName.Text = project.ProjectName;
                        this.ProjectCode.Text = project.ProjectCode;
                        this.TypeCode.Text = project.TypeCode; 
                        this.VolumeCode.Text = volume.Keyword;
                        this.ProjectCode.Text = volume.ProjectCode;
                        this.ProjectName.Text = volume.ProjectName;
                        this.TypeCode.Text = volume.TypeCode;
                        this.VolumeName.Text = volume.VolumeName;
                        this.ArchiveCode.Text = volume.ArchiveCode;
                        this.RoadHeight.Text = project.RoadHeight.ToString();
                        this.QrCode.Text = code;
                        this.Btn_Save.Visible = true; 
                    }
                    break;
                case "Edit":
                    {
                        File file = db.File.AsNoTracking().SingleOrDefault(f => f.FileID == fileId);
                        if (file == null) return;
                        ArchiveInfo archiveInfo = db.ArchiveInfo.SingleOrDefault(a => a.编号 == file.QrCode);
                        if (archiveInfo == null) return;
                        this.Attchment.Text = archiveInfo.Attachment; 
                        this.ArchiveCode.Text = file.ArchiveCode;
                        this.VolumeCode.Text = file.V_VolumeCode;
                        this.Keyword.Text = file.Keyword;
                        this.TypeCode.Text = file.TypeCode;
                        this.SerialNumber.Text = file.SerialNumber.ToString();
                        this.ProjectCode.Text = project.ProjectCode; 
                        this.ProjectName.Text = project.ProjectName;
                        this.FileTitle.Text = file.FileTitle;
                        this.FileName.Text = file.FileName;
                        this.PageSize.Text = file.PageSize.ToString();
                        this.ElectronicsFileNumber.Text = file.ElectronicsFileNumber.ToString();
                        this.ArchiveNumber.Text = file.V_ArchiveNumber.ToString(); 
                        this.VolumeName.Text = file.VolumeName;
                        this.V_VolumeLocation.Text = file.V_VolumeLocation;
                        this.V_VolumeText.Text = file.V_VolumeText;
                        this.IconName.Text = file.IconName;
                        this.MapCode.Text = file.MapCode;
                        this.OrganizationDate.Value = volume.OrganizationDate ?? DateTime.Now;
                        this.Designer.Text = file.Designer;
                        this.Phase.Text = file.Phase;
                        this.PageSize.Text = file.PageSize.ToString();
                        this.RoadLevel.Text = project.RoadLevel.ToString();
                        this.RoodLength.Text = file.RoodLength.ToString();
                        this.RoadHeight.Text = file.P_RoadHeight.ToString();
                        this.RoadType.Text = file.RoadType;
                        this.InitialPile.Text = file.InitialPile;
                        this.MainTechnicalIndicators.Text = file.MainTechnicalIndicators;
                        this.Disc.Text = file.Disc;
                        this.SecretLevel.Text = file.SecretLevel.ToString();
                        this.KeepDate.Text = file.KeepDate;
                        this.SerialNumber.Text = file.SerialNumber.ToString();
                        this.Remarks.Text = file.Remarks;
                        this.QrCode.Text = file.QrCode;
                        this.Btn_Upload.Visible = true;
                        this.Btn_Save.Visible = true;
                    }
                    break;
                case "Display":
                    {
                        File file = db.File.AsNoTracking().SingleOrDefault(f => f.FileID == fileId);
                        if (file == null) return;
                        ArchiveInfo archiveInfo = db.ArchiveInfo.AsNoTracking().SingleOrDefault(a => a.编号 == file.QrCode);
                        if (archiveInfo == null) return;
                        this.Attchment.Text = archiveInfo.Attachment;
                        this.Keyword.Text = file.Keyword;
                        this.TypeCode.Text = file.TypeCode;
                        this.ArchiveCode.Text = file.ArchiveCode;
                        this.SerialNumber.Text = file.SerialNumber.ToString();
                        this.ProjectCode.Text = project.ProjectCode;
                        this.ProjectName.Text = project.ProjectName;
                        this.FileTitle.Text = file.FileTitle;
                        this.FileName.Text = file.FileName;
                        this.PageSize.Text = file.PageSize.ToString();
                        this.ElectronicsFileNumber.Text = file.ElectronicsFileNumber.ToString();
                        this.ArchiveNumber.Text = file.V_ArchiveNumber.ToString();
                        this.VolumeCode.Text = file.V_VolumeCode;
                        this.VolumeName.Text = file.VolumeName;
                        this.V_VolumeLocation.Text = file.V_VolumeLocation;
                        this.V_VolumeText.Text = file.V_VolumeText;
                        this.IconName.Text = file.IconName;
                        this.MapCode.Text = file.MapCode;
                        this.OrganizationDate.Value = volume.OrganizationDate ?? DateTime.Now;
                        this.Designer.Text = file.Designer;
                        this.Phase.Text = file.Phase;
                        this.PageSize.Text = file.PageSize.ToString();
                        this.RoadLevel.Text = project.RoadLevel.ToString();
                        this.RoodLength.Text = file.RoodLength.ToString();
                        this.RoadHeight.Text = file.P_RoadHeight.ToString();
                        this.RoadType.Text = file.RoadType;
                        this.InitialPile.Text = file.InitialPile;
                        this.MainTechnicalIndicators.Text = file.MainTechnicalIndicators;
                        this.Disc.Text = file.Disc;
                        this.SecretLevel.Text = file.SecretLevel.ToString();
                        this.KeepDate.Text = file.KeepDate;
                        this.SerialNumber.Text = file.SerialNumber.ToString();
                        this.Remarks.Text = file.Remarks;
                        this.QrCode.Text = file.QrCode;
                        this.Btn_Save.Visible = false;
                        this.Btn_Upload.Visible = false;
                    }
                    break;
                case "Archiving":
                    if (!string.IsNullOrEmpty(code))
                    {
                        ArchiveInfo archiveInfo = db.ArchiveInfo.AsNoTracking().SingleOrDefault(a => a.编号 == code);
                        if (archiveInfo == null)
                        {
                            this.DialogResult = DialogResult.No;
                            MessageBox.Show("二维码失效");
                            return;
                        }
                        this.ProjectName.Text = project.ProjectName;
                        this.ProjectCode.Text = project.ProjectCode;
                        this.TypeCode.Text = project.TypeCode; 
                        this.ArchiveCode.Text = volume.ArchiveCode; 
                        this.RoadHeight.Text = project.RoadHeight.ToString();
                        this.VolumeCode.Text = volume.Keyword; 
                        this.ProjectCode.Text = volume.ProjectCode;
                        this.ProjectName.Text = volume.ProjectName;
                        this.MapCode.Text = archiveInfo.图号;
                        this.IconName.Text = archiveInfo.图名;
                        this.FileName.Text = archiveInfo.FileName;
                        this.Btn_Save.Visible = true;
                        Btn_Save_Click(new object(), new EventArgs());
                    }
                    break;
                case "More":
                    {
                        if (fileIds == null || fileIds.Count == 0) return;
                        Guid id = fileIds[0];
                        File file = db.File.SingleOrDefault(f => f.FileID == id);
                        if (file == null) return;
                        ArchiveInfo archiveInfo = db.ArchiveInfo.SingleOrDefault(a => a.编号 == file.QrCode);
                        this.Attchment.Text = archiveInfo.Attachment; 
                        this.TypeCode.Text = file.TypeCode;
                        this.Keyword.Text = file.Keyword;
                        this.ArchiveCode.Text = file.ArchiveCode;
                        this.SerialNumber.Text = file.SerialNumber.ToString();
                        this.ProjectCode.Text = project.ProjectCode;
                        this.ProjectName.Text = project.ProjectName;
                        this.FileTitle.Text = file.FileTitle;
                        this.FileName.Text = file.FileName;
                        this.PageSize.Text = file.PageSize.ToString();
                        this.ElectronicsFileNumber.Text = file.ElectronicsFileNumber.ToString();
                        this.ArchiveNumber.Text = file.V_ArchiveNumber.ToString();
                        this.VolumeCode.Text = file.V_VolumeCode;
                        this.VolumeName.Text = file.VolumeName;
                        this.V_VolumeLocation.Text = file.V_VolumeLocation;
                        this.V_VolumeText.Text = file.V_VolumeText;
                        this.IconName.Text = file.IconName;
                        this.MapCode.Text = file.MapCode;
                        this.OrganizationDate.Value = volume.OrganizationDate ?? DateTime.Now;
                        this.Designer.Text = file.Designer;
                        this.Phase.Text = file.Phase;
                        this.PageSize.Text = file.PageSize.ToString();
                        this.RoadLevel.Text = project.RoadLevel.ToString();
                        this.RoodLength.Text = file.RoodLength.ToString();
                        this.RoadHeight.Text = file.P_RoadHeight.ToString();
                        this.RoadType.Text = file.RoadType;
                        this.InitialPile.Text = file.InitialPile;
                        this.MainTechnicalIndicators.Text = file.MainTechnicalIndicators;
                        this.Disc.Text = file.Disc;
                        this.SecretLevel.Text = file.SecretLevel.ToString();
                        this.KeepDate.Text = volume.KeepDate;
                        this.SerialNumber.Text = file.SerialNumber.ToString();
                        this.Remarks.Text = file.Remarks;
                        this.QrCode.Text = file.QrCode;
                        this.Btn_Save.Visible = true;
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
                Volume volume = db.Volume.SingleOrDefault(v => v.VolumeID == volumeId);
                if (volume == null) return;
                Project project = db.Project.SingleOrDefault(p => p.ProjectID == volume.ProjectID);
                if (project == null) return;
                string fileName = this.FileName.Text;
                if (type == "Archiving") fileName = Guid.NewGuid().ToString(); 
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("文件名必填");
                    return;
                }
                switch (type)
                {
                    case "Add":
                        {
                            int maxSort = 0;
                            int maxArchiveID = 0;
                            string qrCode = Guid.NewGuid().ToString("N").ToUpper();
                            if (db.File.ToList() != null && db.File.ToList().Count > 0)
                            {
                                maxSort = db.File.Max(f => f.Sort);
                            }
                            if (db.ArchiveInfo.ToList() != null && db.ArchiveInfo.ToList().Count > 0)
                            {
                                maxArchiveID = db.ArchiveInfo.Max(a => a.ID);
                            }
                            File file = new File
                            {
                                FileID = Guid.NewGuid(),
                                ProjectID = project.ProjectID,
                                VolumID = volumeId,
                                QrCode = qrCode,
                                Keyword = this.Keyword.Text,
                                TypeCode = this.TypeCode.Text,
                                ArchiveCode = this.ArchiveCode.Text,
                                SerialNumber = this.SerialNumber.Text,
                                FileTitle = this.FileTitle.Text,
                                FileName = this.FileName.Text,
                                PageSize = int.TryParse(this.PageSize.Text, out int h) ? h : 0,
                                ElectronicsFileNumber = int.TryParse(this.ElectronicsFileNumber.Text, out int j) ? j : 0,
                                V_ArchiveNumber = int.TryParse(this.ArchiveNumber.Text, out int k) ? k : 0,
                                V_VolumeCode = this.VolumeCode.Text,
                                VolumeName = this.VolumeName.Text,
                                V_VolumeLocation = this.V_VolumeLocation.Text,
                                V_VolumeText = this.V_VolumeText.Text,
                                IconName = this.IconName.Text,
                                MapCode = this.MapCode.Text,
                                V_OrganizationDate = this.OrganizationDate.Value,
                                Designer = this.Designer.Text,
                                Phase = this.Phase.Text,
                                P_RoadLevel = int.TryParse(this.RoadLevel.Text, out int l) ? l : 0,
                                RoodLength = double.TryParse(this.RoadLevel.Text, out double r) ? r : 0,
                                P_RoadHeight = double.TryParse(this.RoadHeight.Text, out double n) ? n : 0,
                                RoadType = this.RoadType.Text,
                                InitialPile = this.InitialPile.Text,
                                MainTechnicalIndicators = this.MainTechnicalIndicators.Text,
                                Disc = this.Disc.Text,
                                SecretLevel = this.SecretLevel.Text,
                                KeepDate = this.KeepDate.Text,
                                Remarks = this.Remarks.Text,
                                IsDelete = false,
                                Sort = maxSort + 1
                            };

                            ArchiveInfo archive = new ArchiveInfo
                            {
                                ID = maxArchiveID + 1,
                                Sort = maxArchiveID + 1,
                                是否归档 = 1,
                                编号 = qrCode,
                                Attachment = this.uploadPath
                            };
                            db.ArchiveInfo.Add(archive);
                            db.File.Add(file);
                            db.SaveChanges();
                            MessageBox.Show("保存成功");
                        }
                        break;
                    case "Archiving":
                        {
                            ArchiveInfo archiveInfo = db.ArchiveInfo.SingleOrDefault(a => a.编号 == code && a.是否归档 == 0);
                            if (archiveInfo == null)
                            {
                                this.DialogResult = DialogResult.No;
                                MessageBox.Show("二维码失效或重复使用");
                                return;
                            }
                            archiveInfo.是否归档 = 1;
                            File file = new File
                            {
                                FileID = Guid.NewGuid(),
                                ProjectID = project.ProjectID,
                                VolumID = volumeId,
                                QrCode = archiveInfo.编号,
                                Keyword = this.Keyword.Text,
                                TypeCode = this.TypeCode.Text,
                                ArchiveCode = this.ArchiveCode.Text,
                                SerialNumber = this.SerialNumber.Text,
                                FileTitle = this.FileTitle.Text,
                                FileName = this.FileName.Text,
                                PageSize = int.TryParse(this.PageSize.Text, out int h) ? h : 0,
                                ElectronicsFileNumber = int.TryParse(this.ElectronicsFileNumber.Text, out int j) ? j : 0,
                                V_ArchiveNumber = int.TryParse(this.ArchiveNumber.Text, out int k) ? k : 0,
                                V_VolumeCode = this.VolumeCode.Text,
                                VolumeName = this.VolumeName.Text,
                                V_VolumeLocation = this.V_VolumeLocation.Text,
                                V_VolumeText = this.V_VolumeText.Text,
                                IconName = this.IconName.Text,
                                MapCode = this.MapCode.Text,
                                V_OrganizationDate = this.OrganizationDate.Value,
                                Designer = this.Designer.Text,
                                Phase = this.Phase.Text,
                                P_RoadLevel = int.TryParse(this.RoadLevel.Text, out int l) ? l : 0,
                                RoodLength = double.TryParse(this.RoodLength.Text, out double r) ? r : 0,
                                P_RoadHeight = double.TryParse(this.RoadHeight.Text, out double n) ? n : 0,
                                RoadType = this.RoadType.Text,
                                InitialPile = this.InitialPile.Text,
                                MainTechnicalIndicators = this.MainTechnicalIndicators.Text,
                                Disc = this.Disc.Text,
                                SecretLevel = this.SecretLevel.Text,
                                KeepDate = this.KeepDate.Text,
                                Remarks = this.Remarks.Text,
                                IsDelete = false,
                                Sort = archiveInfo.Sort
                            };
                            db.File.Add(file);
                            db.SaveChanges(); 
                        }
                        break;
                    case "Edit":
                        {
                            File file = db.File.SingleOrDefault(f => f.FileID == fileId);
                            file.Keyword = this.Keyword.Text;
                            file.ArchiveCode = this.ArchiveCode.Text;
                            file.TypeCode = this.TypeCode.Text;
                            file.SerialNumber = this.SerialNumber.Text;
                            file.FileTitle = this.FileTitle.Text;
                            file.FileName = this.FileName.Text;
                            file.PageSize = int.TryParse(this.PageSize.Text, out int h) ? h : 0;
                            file.ElectronicsFileNumber = int.TryParse(this.ElectronicsFileNumber.Text, out int j) ? j : 0;
                            file.V_ArchiveNumber = int.TryParse(this.ArchiveNumber.Text, out int k) ? k : 0;
                            file.V_VolumeCode = this.VolumeCode.Text;
                            file.VolumeName = this.VolumeName.Text;
                            file.V_VolumeLocation = this.V_VolumeLocation.Text;
                            file.V_VolumeText = this.V_VolumeText.Text;
                            file.IconName = this.IconName.Text;
                            file.MapCode = this.MapCode.Text;
                            file.V_OrganizationDate = this.OrganizationDate.Value;
                            file.Designer = this.Designer.Text;
                            file.Phase = this.Phase.Text;
                            file.P_RoadLevel = int.TryParse(this.RoadLevel.Text, out int l) ? l : 0;
                            file.RoodLength = double.TryParse(this.RoadLevel.Text, out double r) ? r : 0;
                            file.P_RoadHeight = double.TryParse(this.RoadHeight.Text, out double n) ? n : 0;
                            file.RoadType = this.RoadType.Text;
                            file.InitialPile = this.InitialPile.Text;
                            file.MainTechnicalIndicators = this.MainTechnicalIndicators.Text;
                            file.Disc = this.Disc.Text;
                            file.SecretLevel = this.SecretLevel.Text;
                            file.KeepDate = this.KeepDate.Text;
                            file.Remarks = this.Remarks.Text; 
                            db.SaveChanges();
                            MessageBox.Show("保存成功");
                        }
                        break;
                    case "More":
                        {
                            if (fileIds == null || fileIds.Count == 0) return;
                            foreach (Guid id in fileIds)
                            {
                                File file = db.File.SingleOrDefault(f => f.FileID == id);
                                file.Keyword = this.Keyword.Text;
                                file.TypeCode = this.TypeCode.Text;
                                file.SerialNumber = this.SerialNumber.Text;
                                file.FileTitle = this.FileTitle.Text;
                                file.FileName = this.FileName.Text;
                                file.PageSize = int.TryParse(this.PageSize.Text, out int h) ? h : 0;
                                file.ElectronicsFileNumber = int.TryParse(this.ElectronicsFileNumber.Text, out int j) ? j : 0;
                                file.V_ArchiveNumber = int.TryParse(this.ArchiveNumber.Text, out int k) ? k : 0;
                                file.V_VolumeCode = this.VolumeCode.Text;
                                file.VolumeName = this.VolumeName.Text;
                                file.V_VolumeLocation = this.V_VolumeLocation.Text;
                                file.V_VolumeText = this.V_VolumeText.Text;
                                file.IconName = this.IconName.Text;
                                file.MapCode = this.MapCode.Text;
                                file.V_OrganizationDate = this.OrganizationDate.Value;
                                file.Designer = this.Designer.Text;
                                file.Phase = this.Phase.Text;
                                file.P_RoadLevel = int.TryParse(this.RoadLevel.Text, out int l) ? l : 0;
                                file.RoodLength = double.TryParse(this.RoodLength.Text, out double r) ? r : 0;
                                file.P_RoadHeight = double.TryParse(this.RoadHeight.Text, out double n) ? n : 0;
                                file.RoadType = this.RoadType.Text;
                                file.InitialPile = this.InitialPile.Text;
                                file.MainTechnicalIndicators = this.MainTechnicalIndicators.Text;
                                file.Disc = this.Disc.Text;
                                file.SecretLevel = this.SecretLevel.Text;
                                file.KeepDate = this.KeepDate.Text;
                                file.Remarks = this.Remarks.Text;
                                db.SaveChanges();
                            }
                            MessageBox.Show("保存成功");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Btn_Upload_Click(object sender, EventArgs e)
        {
            string qrCode = this.QrCode.Text;
            if (string.IsNullOrEmpty(qrCode))
            {
                MessageBox.Show("二维码不能为空");
                return;
            }
            ArchiveInfo archiveInfo = db.ArchiveInfo.SingleOrDefault(a => a.编号 == qrCode);
            if (archiveInfo == null) return;
            using (OpenFileDialog fileDialog = new OpenFileDialog { AddExtension = true, Multiselect = false })
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(fileDialog.FileName);
                    string uploadFileName = fileDialog.FileName;
                    string saveFilePath = ("设计库\\出版区\\" + fileName).Replace("/", "\\");
                    if (HttpServerHelper.UpLoadFile(uploadFileName, saveFilePath))
                    {
                        this.uploadPath = uploadFileName;  
                        archiveInfo.Attachment = saveFilePath;
                        db.SaveChanges();
                        MessageBox.Show("上传成功");
                    }
                }
            }
        }

        private void OrganizationDate_ValueChanged(object sender, EventArgs e)
        {
            this.OrganizationDate.Format = DateTimePickerFormat.Long;
            this.OrganizationDate.CustomFormat = null;
        }
    }
}
