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
    public partial class Archiving : Form
    {
        public delegate void TransfDelegate(string value);
        public event TransfDelegate TransfEvent; 
        public Archiving()
        {
            InitializeComponent();
            this.Code.Focus();
        } 
        
        private void Code_TextChanged(object sender, EventArgs e)
        { 
            if (Code.Text.Length == 32)
            {
                TransfEvent(Code.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //this.Code.Text = "";
                return;
            }
            this.Code.Text = "";
        }
    }
}
