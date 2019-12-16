namespace ScanArchiving
{
    partial class Archiving
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
            this.label1 = new System.Windows.Forms.Label();
            this.Code = new System.Windows.Forms.TextBox();
            this.Btn_Colse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入二维码";
            // 
            // Code
            // 
            this.Code.Location = new System.Drawing.Point(96, 18);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(157, 21);
            this.Code.TabIndex = 1;
            this.Code.TextChanged += new System.EventHandler(this.Code_TextChanged);
            // 
            // Btn_Colse
            // 
            this.Btn_Colse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Colse.Location = new System.Drawing.Point(262, 16);
            this.Btn_Colse.Name = "Btn_Colse";
            this.Btn_Colse.Size = new System.Drawing.Size(75, 23);
            this.Btn_Colse.TabIndex = 2;
            this.Btn_Colse.Text = "关闭";
            this.Btn_Colse.UseVisualStyleBackColor = true;
            // 
            // Archiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Btn_Colse;
            this.ClientSize = new System.Drawing.Size(347, 66);
            this.Controls.Add(this.Btn_Colse);
            this.Controls.Add(this.Code);
            this.Controls.Add(this.label1);
            this.Name = "Archiving";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "输入二维码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Code;
        private System.Windows.Forms.Button Btn_Colse;
    }
}