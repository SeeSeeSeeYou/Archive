namespace ScanArchiving
{
    partial class MyConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConfigIP = new System.Windows.Forms.TextBox();
            this.PingIp = new System.Windows.Forms.Button();
            this.ConfigCatalog = new System.Windows.Forms.TextBox();
            this.ConfigPassWord = new System.Windows.Forms.TextBox();
            this.ConfigUser = new System.Windows.Forms.TextBox();
            this.Config_Save = new System.Windows.Forms.Button();
            this.连接IP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConfigIP
            // 
            this.ConfigIP.Location = new System.Drawing.Point(129, 16);
            this.ConfigIP.Name = "ConfigIP";
            this.ConfigIP.Size = new System.Drawing.Size(100, 21);
            this.ConfigIP.TabIndex = 0;
            // 
            // PingIp
            // 
            this.PingIp.Location = new System.Drawing.Point(38, 166);
            this.PingIp.Name = "PingIp";
            this.PingIp.Size = new System.Drawing.Size(75, 23);
            this.PingIp.TabIndex = 1;
            this.PingIp.Text = "测试连接";
            this.PingIp.UseVisualStyleBackColor = true;
            this.PingIp.Click += new System.EventHandler(this.PingIp_Click);
            // 
            // ConfigCatalog
            // 
            this.ConfigCatalog.Location = new System.Drawing.Point(129, 55);
            this.ConfigCatalog.Name = "ConfigCatalog";
            this.ConfigCatalog.Size = new System.Drawing.Size(100, 21);
            this.ConfigCatalog.TabIndex = 2;
            // 
            // ConfigPassWord
            // 
            this.ConfigPassWord.Location = new System.Drawing.Point(129, 134);
            this.ConfigPassWord.Name = "ConfigPassWord";
            this.ConfigPassWord.Size = new System.Drawing.Size(100, 21);
            this.ConfigPassWord.TabIndex = 3;
            // 
            // ConfigUser
            // 
            this.ConfigUser.Location = new System.Drawing.Point(129, 90);
            this.ConfigUser.Name = "ConfigUser";
            this.ConfigUser.Size = new System.Drawing.Size(100, 21);
            this.ConfigUser.TabIndex = 4;
            // 
            // Config_Save
            // 
            this.Config_Save.Location = new System.Drawing.Point(144, 166);
            this.Config_Save.Name = "Config_Save";
            this.Config_Save.Size = new System.Drawing.Size(75, 23);
            this.Config_Save.TabIndex = 5;
            this.Config_Save.Text = "保存配置";
            this.Config_Save.UseVisualStyleBackColor = true;
            this.Config_Save.Click += new System.EventHandler(this.Config_Save_Click);
            // 
            // 连接IP
            // 
            this.连接IP.AutoSize = true;
            this.连接IP.Location = new System.Drawing.Point(36, 19);
            this.连接IP.Name = "连接IP";
            this.连接IP.Size = new System.Drawing.Size(65, 12);
            this.连接IP.TabIndex = 6;
            this.连接IP.Text = "远程主机IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "数据库目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "密码";
            // 
            // MyConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 209);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.连接IP);
            this.Controls.Add(this.Config_Save);
            this.Controls.Add(this.ConfigUser);
            this.Controls.Add(this.ConfigPassWord);
            this.Controls.Add(this.ConfigCatalog);
            this.Controls.Add(this.PingIp);
            this.Controls.Add(this.ConfigIP);
            this.Name = "MyConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "连接配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ConfigIP;
        private System.Windows.Forms.Button PingIp;
        private System.Windows.Forms.TextBox ConfigCatalog;
        private System.Windows.Forms.TextBox ConfigPassWord;
        private System.Windows.Forms.TextBox ConfigUser;
        private System.Windows.Forms.Button Config_Save;
        private System.Windows.Forms.Label 连接IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}