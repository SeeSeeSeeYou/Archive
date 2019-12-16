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
    public partial class SearchVolume : Form
    {
        public delegate void TransfDelegate(List<TreeNode> treeNodes);
        public event TransfDelegate TransfEvent;
        private readonly ScanArchivingEntities db = new ScanArchivingEntities();
        private readonly List<TreeNode> treeNodes;
        public SearchVolume(List<TreeNode> treeNodes)
        {
            this.treeNodes = treeNodes;
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

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            string sql = "Select * From Volume Where  IsDelete=0 ";
            sql = ControlHelper.GetSql(sql, this.Controls);
            List<Volume> volumes = db.Database.SqlQuery<Volume>(sql).ToList();
            foreach (Volume volume in volumes)
            { 
                treeNodes.Add(new TreeNode
                {
                    Tag = volume
                });
            }
            TransfEvent(treeNodes);
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
