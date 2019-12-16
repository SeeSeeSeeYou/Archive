using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace ScanArchiving
{
    public partial class MyConfig : Form
    {
        public string user;
        public string password;
        public string catalog;
        public string ip;
        public MyConfig()
        {
            InitializeComponent();
            Config.MainConfig mainConfig = Config.Init();
            this.user = mainConfig.User;
            this.password = mainConfig.PassWord;
            this.ip = mainConfig.DataSource;
            this.catalog = mainConfig.Catalog;
            Init();
        }

        private void Init()
        {

            this.ConfigUser.Text = this.user;
            this.ConfigCatalog.Text = this.catalog;
            this.ConfigIP.Text = this.ip;
            this.ConfigPassWord.Text = this.password;
        }

        private bool Save()
        {
            Config.MainConfig mainConfig = new Config.MainConfig
            {
                User = this.ConfigUser.Text,
                PassWord = this.ConfigPassWord.Text,
                Catalog = this.ConfigCatalog.Text,
                DataSource = this.ConfigIP.Text
            };
            try
            {
                Config.Save(mainConfig);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private void PingIp_Click(object sender, EventArgs e)
        {
            string ip = this.ConfigIP.Text;
            bool isResponse = Config.Ping(ip);
            if (isResponse)
            {
                MessageBox.Show("连接成功");
            }
            else
            {
                MessageBox.Show("连接失败，请确认您的IP");
            }
        }

        private void Config_Save_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                MessageBox.Show("保存成功"); 
                Application.ExitThread(); 
                Restart();
            }
            else
            {
                MessageBox.Show("保存失败"); 
                this.Close();
            }
        }

        private void Restart() 
        { 
            Thread thtmp = new Thread(new ParameterizedThreadStart(Run)); 
            object appName = Application.ExecutablePath;  
            thtmp.Start(appName);

        }

        private void Run(object obj)
        {
            Process ps = new Process();

            ps.StartInfo.FileName = obj.ToString();

            ps.Start();

        }
    }
}
