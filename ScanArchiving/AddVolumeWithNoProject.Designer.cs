namespace ScanArchiving
{
    partial class AddVolumeWithNoProject
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
            this.KeepDate = new System.Windows.Forms.ComboBox();
            this.SecretLevel = new System.Windows.Forms.ComboBox();
            this.ArchiveDate = new System.Windows.Forms.DateTimePicker();
            this.OrganizationDate = new System.Windows.Forms.DateTimePicker();
            this.IdentifyDate = new System.Windows.Forms.DateTimePicker();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Remarks = new System.Windows.Forms.TextBox();
            this.DepartmentCode = new System.Windows.Forms.TextBox();
            this.Symbol = new System.Windows.Forms.TextBox();
            this.SerialNumber = new System.Windows.Forms.TextBox();
            this.Responsibler = new System.Windows.Forms.TextBox();
            this.Themewords = new System.Windows.Forms.TextBox();
            this.PageSize = new System.Windows.Forms.TextBox();
            this.Phase = new System.Windows.Forms.TextBox();
            this.OrganizationUnit = new System.Windows.Forms.TextBox();
            this.VolumeLocation = new System.Windows.Forms.TextBox();
            this.ArchiveNumber = new System.Windows.Forms.TextBox();
            this.VolumeTitle = new System.Windows.Forms.TextBox();
            this.VolumeText = new System.Windows.Forms.TextBox();
            this.VolumeName = new System.Windows.Forms.TextBox();
            this.TemporaryCode = new System.Windows.Forms.TextBox();
            this.DossierCode = new System.Windows.Forms.TextBox();
            this.TypeCode = new System.Windows.Forms.TextBox();
            this.ProjectName = new System.Windows.Forms.TextBox();
            this.ProjectCode = new System.Windows.Forms.TextBox();
            this.VolumeCode = new System.Windows.Forms.TextBox();
            this.ArchiveCode = new System.Windows.Forms.TextBox();
            this.Keyword = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KeepDate
            // 
            this.KeepDate.FormattingEnabled = true;
            this.KeepDate.Items.AddRange(new object[] {
            "永久",
            "10年",
            "30年"});
            this.KeepDate.Location = new System.Drawing.Point(155, 299);
            this.KeepDate.Name = "KeepDate";
            this.KeepDate.Size = new System.Drawing.Size(100, 20);
            this.KeepDate.TabIndex = 217;
            // 
            // SecretLevel
            // 
            this.SecretLevel.FormattingEnabled = true;
            this.SecretLevel.Items.AddRange(new object[] {
            "公开",
            "秘密",
            "机密",
            "绝密"});
            this.SecretLevel.Location = new System.Drawing.Point(369, 297);
            this.SecretLevel.Name = "SecretLevel";
            this.SecretLevel.Size = new System.Drawing.Size(100, 20);
            this.SecretLevel.TabIndex = 216;
            // 
            // ArchiveDate
            // 
            this.ArchiveDate.Location = new System.Drawing.Point(369, 380);
            this.ArchiveDate.Name = "ArchiveDate";
            this.ArchiveDate.Size = new System.Drawing.Size(100, 21);
            this.ArchiveDate.TabIndex = 212;
            this.ArchiveDate.ValueChanged += new System.EventHandler(this.ArchiveDate_ValueChanged);
            // 
            // OrganizationDate
            // 
            this.OrganizationDate.Location = new System.Drawing.Point(369, 212);
            this.OrganizationDate.Name = "OrganizationDate";
            this.OrganizationDate.Size = new System.Drawing.Size(100, 21);
            this.OrganizationDate.TabIndex = 202;
            this.OrganizationDate.ValueChanged += new System.EventHandler(this.OrganizationDate_ValueChanged);
            // 
            // IdentifyDate
            // 
            this.IdentifyDate.Location = new System.Drawing.Point(604, 339);
            this.IdentifyDate.Name = "IdentifyDate";
            this.IdentifyDate.Size = new System.Drawing.Size(111, 21);
            this.IdentifyDate.TabIndex = 210;
            this.IdentifyDate.ValueChanged += new System.EventHandler(this.IdentifyDate_ValueChanged);
            // 
            // Btn_Save
            // 
            this.Btn_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_Save.Location = new System.Drawing.Point(640, 410);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(75, 23);
            this.Btn_Save.TabIndex = 215;
            this.Btn_Save.Text = "保存";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(527, 410);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 214;
            this.Btn_Cancel.Text = "关闭";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Remarks
            // 
            this.Remarks.Location = new System.Drawing.Point(155, 418);
            this.Remarks.Name = "Remarks";
            this.Remarks.Size = new System.Drawing.Size(314, 21);
            this.Remarks.TabIndex = 213;
            // 
            // DepartmentCode
            // 
            this.DepartmentCode.Location = new System.Drawing.Point(155, 377);
            this.DepartmentCode.Name = "DepartmentCode";
            this.DepartmentCode.Size = new System.Drawing.Size(100, 21);
            this.DepartmentCode.TabIndex = 211;
            // 
            // Symbol
            // 
            this.Symbol.Location = new System.Drawing.Point(369, 339);
            this.Symbol.Name = "Symbol";
            this.Symbol.Size = new System.Drawing.Size(100, 21);
            this.Symbol.TabIndex = 209;
            // 
            // SerialNumber
            // 
            this.SerialNumber.Location = new System.Drawing.Point(155, 339);
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.Size = new System.Drawing.Size(100, 21);
            this.SerialNumber.TabIndex = 208;
            // 
            // Responsibler
            // 
            this.Responsibler.Location = new System.Drawing.Point(604, 302);
            this.Responsibler.Name = "Responsibler";
            this.Responsibler.Size = new System.Drawing.Size(100, 21);
            this.Responsibler.TabIndex = 207;
            // 
            // Themewords
            // 
            this.Themewords.Location = new System.Drawing.Point(604, 261);
            this.Themewords.Name = "Themewords";
            this.Themewords.Size = new System.Drawing.Size(100, 21);
            this.Themewords.TabIndex = 206;
            // 
            // PageSize
            // 
            this.PageSize.Location = new System.Drawing.Point(369, 258);
            this.PageSize.Name = "PageSize";
            this.PageSize.Size = new System.Drawing.Size(100, 21);
            this.PageSize.TabIndex = 205;
            // 
            // Phase
            // 
            this.Phase.Location = new System.Drawing.Point(155, 258);
            this.Phase.Name = "Phase";
            this.Phase.Size = new System.Drawing.Size(100, 21);
            this.Phase.TabIndex = 204;
            // 
            // OrganizationUnit
            // 
            this.OrganizationUnit.Location = new System.Drawing.Point(604, 212);
            this.OrganizationUnit.Name = "OrganizationUnit";
            this.OrganizationUnit.Size = new System.Drawing.Size(100, 21);
            this.OrganizationUnit.TabIndex = 203;
            // 
            // VolumeLocation
            // 
            this.VolumeLocation.Location = new System.Drawing.Point(155, 215);
            this.VolumeLocation.Name = "VolumeLocation";
            this.VolumeLocation.Size = new System.Drawing.Size(100, 21);
            this.VolumeLocation.TabIndex = 201;
            // 
            // ArchiveNumber
            // 
            this.ArchiveNumber.Location = new System.Drawing.Point(604, 169);
            this.ArchiveNumber.Name = "ArchiveNumber";
            this.ArchiveNumber.Size = new System.Drawing.Size(100, 21);
            this.ArchiveNumber.TabIndex = 200;
            // 
            // VolumeTitle
            // 
            this.VolumeTitle.Location = new System.Drawing.Point(369, 169);
            this.VolumeTitle.Name = "VolumeTitle";
            this.VolumeTitle.Size = new System.Drawing.Size(100, 21);
            this.VolumeTitle.TabIndex = 199;
            // 
            // VolumeText
            // 
            this.VolumeText.Location = new System.Drawing.Point(155, 172);
            this.VolumeText.Name = "VolumeText";
            this.VolumeText.Size = new System.Drawing.Size(100, 21);
            this.VolumeText.TabIndex = 198;
            // 
            // VolumeName
            // 
            this.VolumeName.Location = new System.Drawing.Point(155, 130);
            this.VolumeName.Name = "VolumeName";
            this.VolumeName.Size = new System.Drawing.Size(549, 21);
            this.VolumeName.TabIndex = 197;
            // 
            // TemporaryCode
            // 
            this.TemporaryCode.Location = new System.Drawing.Point(604, 95);
            this.TemporaryCode.Name = "TemporaryCode";
            this.TemporaryCode.Size = new System.Drawing.Size(100, 21);
            this.TemporaryCode.TabIndex = 196;
            // 
            // DossierCode
            // 
            this.DossierCode.Location = new System.Drawing.Point(369, 92);
            this.DossierCode.Name = "DossierCode";
            this.DossierCode.Size = new System.Drawing.Size(100, 21);
            this.DossierCode.TabIndex = 195;
            // 
            // TypeCode
            // 
            this.TypeCode.Location = new System.Drawing.Point(155, 92);
            this.TypeCode.Name = "TypeCode";
            this.TypeCode.Size = new System.Drawing.Size(100, 21);
            this.TypeCode.TabIndex = 194;
            // 
            // ProjectName
            // 
            this.ProjectName.Location = new System.Drawing.Point(369, 52);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            this.ProjectName.Size = new System.Drawing.Size(100, 21);
            this.ProjectName.TabIndex = 193;
            // 
            // ProjectCode
            // 
            this.ProjectCode.Location = new System.Drawing.Point(155, 52);
            this.ProjectCode.Name = "ProjectCode";
            this.ProjectCode.Size = new System.Drawing.Size(100, 21);
            this.ProjectCode.TabIndex = 192;
            this.ProjectCode.Leave += new System.EventHandler(this.ProjectCode_Leave);
            // 
            // VolumeCode
            // 
            this.VolumeCode.Location = new System.Drawing.Point(604, 15);
            this.VolumeCode.Name = "VolumeCode";
            this.VolumeCode.Size = new System.Drawing.Size(100, 21);
            this.VolumeCode.TabIndex = 191;
            // 
            // ArchiveCode
            // 
            this.ArchiveCode.Location = new System.Drawing.Point(369, 15);
            this.ArchiveCode.Name = "ArchiveCode";
            this.ArchiveCode.Size = new System.Drawing.Size(100, 21);
            this.ArchiveCode.TabIndex = 190;
            // 
            // Keyword
            // 
            this.Keyword.Location = new System.Drawing.Point(155, 12);
            this.Keyword.Name = "Keyword";
            this.Keyword.Size = new System.Drawing.Size(100, 21);
            this.Keyword.TabIndex = 189;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(86, 421);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 12);
            this.label27.TabIndex = 188;
            this.label27.Text = "备注";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(300, 382);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 187;
            this.label26.Text = "归档日期";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(86, 380);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 186;
            this.label25.Text = "部门代码";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(525, 305);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 185;
            this.label24.Text = "责任者";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(302, 342);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 184;
            this.label23.Text = "文号";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(86, 342);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 183;
            this.label22.Text = "序号";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(513, 345);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 182;
            this.label21.Text = "鉴定日期";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(302, 302);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 181;
            this.label20.Text = "密级";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(86, 305);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 180;
            this.label19.Text = "保存期限";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(530, 264);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 179;
            this.label18.Text = "主题词";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(302, 261);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 178;
            this.label17.Text = "页数";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(86, 261);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 177;
            this.label16.Text = "设计阶段";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(524, 215);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 176;
            this.label15.Text = "编制单位";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(300, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 175;
            this.label14.Text = "编制日期";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(86, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 174;
            this.label13.Text = "存放位置";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(524, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 173;
            this.label12.Text = "归档份数";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(300, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 172;
            this.label11.Text = "所在卷册";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(86, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 171;
            this.label10.Text = "文本";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 170;
            this.label9.Text = "案卷题名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(530, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 169;
            this.label8.Text = "临时号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 168;
            this.label7.Text = "案卷号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 167;
            this.label6.Text = "分类号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 166;
            this.label5.Text = "项目名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 165;
            this.label4.Text = "项目代号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 164;
            this.label3.Text = "所属卷册";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 163;
            this.label2.Text = "档号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 162;
            this.label1.Text = "关键字";
            // 
            // AddVolumeWithNoProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.KeepDate);
            this.Controls.Add(this.SecretLevel);
            this.Controls.Add(this.ArchiveDate);
            this.Controls.Add(this.OrganizationDate);
            this.Controls.Add(this.IdentifyDate);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Remarks);
            this.Controls.Add(this.DepartmentCode);
            this.Controls.Add(this.Symbol);
            this.Controls.Add(this.SerialNumber);
            this.Controls.Add(this.Responsibler);
            this.Controls.Add(this.Themewords);
            this.Controls.Add(this.PageSize);
            this.Controls.Add(this.Phase);
            this.Controls.Add(this.OrganizationUnit);
            this.Controls.Add(this.VolumeLocation);
            this.Controls.Add(this.ArchiveNumber);
            this.Controls.Add(this.VolumeTitle);
            this.Controls.Add(this.VolumeText);
            this.Controls.Add(this.VolumeName);
            this.Controls.Add(this.TemporaryCode);
            this.Controls.Add(this.DossierCode);
            this.Controls.Add(this.TypeCode);
            this.Controls.Add(this.ProjectName);
            this.Controls.Add(this.ProjectCode);
            this.Controls.Add(this.VolumeCode);
            this.Controls.Add(this.ArchiveCode);
            this.Controls.Add(this.Keyword);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddVolumeWithNoProject";
            this.Text = "添加案卷";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox KeepDate;
        private System.Windows.Forms.ComboBox SecretLevel;
        private System.Windows.Forms.DateTimePicker ArchiveDate;
        private System.Windows.Forms.DateTimePicker OrganizationDate;
        private System.Windows.Forms.DateTimePicker IdentifyDate;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.TextBox Remarks;
        private System.Windows.Forms.TextBox DepartmentCode;
        private System.Windows.Forms.TextBox Symbol;
        private System.Windows.Forms.TextBox SerialNumber;
        private System.Windows.Forms.TextBox Responsibler;
        private System.Windows.Forms.TextBox Themewords;
        private System.Windows.Forms.TextBox PageSize;
        private System.Windows.Forms.TextBox Phase;
        private System.Windows.Forms.TextBox OrganizationUnit;
        private System.Windows.Forms.TextBox VolumeLocation;
        private System.Windows.Forms.TextBox ArchiveNumber;
        private System.Windows.Forms.TextBox VolumeTitle;
        private System.Windows.Forms.TextBox VolumeText;
        private System.Windows.Forms.TextBox VolumeName;
        private System.Windows.Forms.TextBox TemporaryCode;
        private System.Windows.Forms.TextBox DossierCode;
        private System.Windows.Forms.TextBox TypeCode;
        private System.Windows.Forms.TextBox ProjectName;
        private System.Windows.Forms.TextBox ProjectCode;
        private System.Windows.Forms.TextBox VolumeCode;
        private System.Windows.Forms.TextBox ArchiveCode;
        private System.Windows.Forms.TextBox Keyword;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}