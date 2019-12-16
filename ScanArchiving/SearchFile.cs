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
    public partial class SearchFile : Form
    {
        private readonly ScanArchivingEntities db = new ScanArchivingEntities();
        public delegate void TransfDelegate(List<TreeNode> treeNodes);
        public event TransfDelegate TransfEvent;
        private readonly List<TreeNode> treeNodes;
        public SearchFile(List<TreeNode> treeNodes)
        {
            this.treeNodes = treeNodes; 
            InitializeComponent();
            this.V_OrganizationDate.Format = DateTimePickerFormat.Custom;
            this.V_OrganizationDate.CustomFormat = " ";
        }
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void Btn_Search_Click(object sender, EventArgs e)
        { 
            string sql = "Select * From [dbo].[File] Where IsDelete=0 ";
            sql= ControlHelper.GetSql(sql, this.Controls);
            List<File> files = db.Database.SqlQuery<File>(sql).ToList();
            foreach (File file in files)
            {
                treeNodes.Add(new TreeNode
                {
                    Tag = file
                });
            }
            TransfEvent(treeNodes);
        }

        private void V_OrganizationDate_ValueChanged(object sender, EventArgs e)
        {
            this.V_OrganizationDate.Format = DateTimePickerFormat.Long;
            this.V_OrganizationDate.CustomFormat = null;
        }
    }
}
