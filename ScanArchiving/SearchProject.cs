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
    public partial class SearchProject : Form
    {
        private readonly ScanArchivingEntities db = new ScanArchivingEntities();
        public delegate void TransfDelegate(List<TreeNode> treeNodes);
        public event TransfDelegate TransfEvent;
        private readonly List<TreeNode> treeNodes;
        public SearchProject(List<TreeNode> treeNodes)
        {
            this.treeNodes = treeNodes;
            InitializeComponent();
            this.Finished.Format = DateTimePickerFormat.Custom;
            this.Finished.CustomFormat = " ";
        }
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            string sql = "Select * From Project Where  IsDelete=0 ";
            sql=ControlHelper.GetSql(sql, this.Controls);
            List<Project> projects = db.Database.SqlQuery<Project>(sql).ToList();
            foreach (Project project in projects)
            {
                treeNodes.Add(new TreeNode
                {
                    Tag = project
                });
            }
            TransfEvent(treeNodes);
        }

        private void Finished_ValueChanged(object sender, EventArgs e)
        {
            this.Finished.Format = DateTimePickerFormat.Long;
            this.Finished.CustomFormat = null;
        }
    }
}
