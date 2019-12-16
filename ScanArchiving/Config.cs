using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static ScanArchiving.Config;

namespace ScanArchiving
{
    public static class Config
    {
        public static string sqlPath = Environment.CurrentDirectory + "\\ScanArchiving.exe.config";

        public static string fileConfigPath = Environment.CurrentDirectory + "\\config.ini";
        public static MainConfig Init()
        {
            //  metadata=res://*/DB.csdl|res://*/DB.ssdl|res://*/DB.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=40.73.103.36;initial catalog=ScanArchiving;persist security info=True;user id=sa;password=SJY@123456789;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient"
            MainConfig mainConfig = new MainConfig();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(sqlPath);
            string dataSourceFlag = "data source=";
            string initaialCaralogFlag = "initial catalog=";
            string userId = "user id=";
            string password = "password=";
            XmlElement configuration = (XmlElement)xmlDoc.SelectSingleNode("configuration");
            XmlElement connectionStrings = (XmlElement)configuration.SelectSingleNode("connectionStrings");
            XmlElement add = (XmlElement)connectionStrings.SelectSingleNode("add");
            string connectString = add.GetAttribute("connectionString");
            string[] configs = connectString.Split(';');
            foreach (string config in configs)
            {
                if (config.IndexOf(dataSourceFlag) != -1)
                {
                    mainConfig.DataSource = config.Substring(config.IndexOf(dataSourceFlag) + dataSourceFlag.Length);
                }
                if (config.IndexOf(initaialCaralogFlag) != -1)
                {
                    mainConfig.Catalog = config.Substring(config.IndexOf(initaialCaralogFlag) + initaialCaralogFlag.Length);
                }
                if (config.IndexOf(userId) != -1)
                {
                    mainConfig.User = config.Substring(config.IndexOf(userId) + userId.Length);
                }
                if (config.IndexOf(password) != -1)
                {
                    mainConfig.PassWord = config.Substring(config.IndexOf(password) + password.Length);
                }
            }
            return mainConfig;
        }
        public static void Save(MainConfig mainConfig)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(sqlPath);
                XmlElement configuration = (XmlElement)xmlDoc.SelectSingleNode("configuration");
                XmlElement connectionStrings = (XmlElement)configuration.SelectSingleNode("connectionStrings");
                XmlElement add = (XmlElement)connectionStrings.SelectSingleNode("add");
                XmlAttribute x = add.GetAttributeNode("connectionString");
                add.Attributes.Remove(x);
                string connectionString = $"metadata=res://*/DB.csdl|res://*/DB.ssdl|res://*/DB.msl;provider=System.Data.SqlClient;provider connection string=\" data source={mainConfig.DataSource};initial catalog={mainConfig.Catalog};persist security info=True;user id={mainConfig.User};password={mainConfig.PassWord};MultipleActiveResultSets=True;App=EntityFramework\"";
                add.SetAttribute("connectionString", connectionString);
                xmlDoc.Save(sqlPath);
                Win32API.INIWriteValue(fileConfigPath, "common", "serverip", mainConfig.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static bool Ping(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                MainConfig mainConfig = Init();
                ip = mainConfig.DataSource;
            }
            if (!ControlHelper.IpFilter(ip)) return false;
            PingOptions options = new PingOptions
            {
                DontFragment = true
            };
            using (Ping ping = new Ping())
            {
                return ping.Send(ip, 120, Encoding.ASCII.GetBytes(string.Empty), options).Status == IPStatus.Success;
            }
        }

        public class MainConfig
        {
            public string DataSource { get; set; }
            public string User { get; set; }
            public string PassWord { get; set; }
            public string Catalog { get; set; }
        }
    }
}