namespace ScanArchiving
{
    partial class AddProject
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
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.ProjectCode = new System.Windows.Forms.TextBox();
            this.TotalInvestment = new System.Windows.Forms.TextBox();
            this.RoadLevel = new System.Windows.Forms.TextBox();
            this.TypeCode = new System.Windows.Forms.TextBox();
            this.ProjectName = new System.Windows.Forms.TextBox();
            this.DesignUnit = new System.Windows.Forms.TextBox();
            this.Remarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Finished = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(316, 232);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.Btn_Cancel.TabIndex = 0;
            this.Btn_Cancel.Text = "关闭";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_Save.Location = new System.Drawing.Point(429, 232);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(75, 25);
            this.Btn_Save.TabIndex = 1;
            this.Btn_Save.Text = "保存";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // ProjectCode
            // 
            this.ProjectCode.Location = new System.Drawing.Point(123, 22);
            this.ProjectCode.Name = "ProjectCode";
            this.ProjectCode.Size = new System.Drawing.Size(126, 21);
            this.ProjectCode.TabIndex = 2;
            // 
            // TotalInvestment
            // 
            this.TotalInvestment.Location = new System.Drawing.Point(404, 147);
            this.TotalInvestment.Name = "TotalInvestment";
            this.TotalInvestment.Size = new System.Drawing.Size(100, 21);
            this.TotalInvestment.TabIndex = 3;
            // 
            // RoadLevel
            // 
            this.RoadLevel.Location = new System.Drawing.Point(123, 147);
            this.RoadLevel.Name = "RoadLevel";
            this.RoadLevel.Size = new System.Drawing.Size(126, 21);
            this.RoadLevel.TabIndex = 4;
            // 
            // TypeCode
            // 
            this.TypeCode.Location = new System.Drawing.Point(404, 22);
            this.TypeCode.Name = "TypeCode";
            this.TypeCode.Size = new System.Drawing.Size(100, 21);
            this.TypeCode.TabIndex = 6;
            // 
            // ProjectName
            // 
            this.ProjectName.Location = new System.Drawing.Point(123, 61);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(381, 21);
            this.ProjectName.TabIndex = 8;
            // 
            // DesignUnit
            // 
            this.DesignUnit.Location = new System.Drawing.Point(404, 101);
            this.DesignUnit.Name = "DesignUnit";
            this.DesignUnit.Size = new System.Drawing.Size(100, 21);
            this.DesignUnit.TabIndex = 9;
            // 
            // Remarks
            // 
            this.Remarks.Location = new System.Drawing.Point(123, 187);
            this.Remarks.Name = "Remarks";
            this.Remarks.Size = new System.Drawing.Size(381, 21);
            this.Remarks.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "项目代号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "项目名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "分类号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "备注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "完成时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(333, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "设计单位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "总投资";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "公路等级";
            // 
            // Finished
            // 
            this.Finished.Location = new System.Drawing.Point(123, 104);
            this.Finished.Name = "Finished";
            this.Finished.Size = new System.Drawing.Size(126, 21);
            this.Finished.TabIndex = 19;
            this.Finished.ValueChanged += new System.EventHandler(this.Finished_ValueChanged);
            // 
            // AddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 278);
            this.Controls.Add(this.Finished);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Remarks);
            this.Controls.Add(this.DesignUnit);
            this.Controls.Add(this.ProjectName);
            this.Controls.Add(this.TypeCode);
            this.Controls.Add(this.RoadLevel);
            this.Controls.Add(this.TotalInvestment);
            this.Controls.Add(this.ProjectCode);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Cancel);
            this.Name = "AddProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "项目信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.TextBox ProjectCode;
        private System.Windows.Forms.TextBox TotalInvestment;
        private System.Windows.Forms.TextBox RoadLevel;
        private System.Windows.Forms.TextBox TypeCode;
        private System.Windows.Forms.TextBox ProjectName;
        private System.Windows.Forms.TextBox DesignUnit;
        private System.Windows.Forms.TextBox Remarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker Finished;
    }
}