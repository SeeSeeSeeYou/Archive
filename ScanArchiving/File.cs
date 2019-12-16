//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScanArchiving
{
    using System;
    using System.Collections.Generic;
    
    public partial class File
    {
        public System.Guid FileID { get; set; }
        public Nullable<System.Guid> VolumID { get; set; }
        public Nullable<System.Guid> ProjectID { get; set; }
        public string Keyword { get; set; }
        public string ArchiveCode { get; set; }
        public string TypeCode { get; set; }
        public string SerialNumber { get; set; }
        public string FileTitle { get; set; }
        public string FileName { get; set; }
        public Nullable<int> PageSize { get; set; }
        public Nullable<int> ElectronicsFileNumber { get; set; }
        public Nullable<int> V_ArchiveNumber { get; set; }
        public string V_VolumeCode { get; set; }
        public string VolumeName { get; set; }
        public string V_VolumeLocation { get; set; }
        public string V_VolumeText { get; set; }
        public string IconName { get; set; }
        public string MapCode { get; set; }
        public Nullable<System.DateTime> V_OrganizationDate { get; set; }
        public string Designer { get; set; }
        public string Phase { get; set; }
        public Nullable<int> P_RoadLevel { get; set; }
        public Nullable<double> RoodLength { get; set; }
        public Nullable<double> P_RoadHeight { get; set; }
        public string RoadType { get; set; }
        public string InitialPile { get; set; }
        public string MainTechnicalIndicators { get; set; }
        public string Disc { get; set; }
        public string SecretLevel { get; set; }
        public string KeepDate { get; set; }
        public string Remarks { get; set; }
        public string QrCode { get; set; }
        public bool IsDelete { get; set; }
        public int Sort { get; set; }
    }
}
