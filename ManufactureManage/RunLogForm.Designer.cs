namespace ManufactureManage
{
    partial class RunLogForm
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
            this.richTextBox_RunLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox_RunLog
            // 
            this.richTextBox_RunLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_RunLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_RunLog.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_RunLog.Name = "richTextBox_RunLog";
            this.richTextBox_RunLog.ReadOnly = true;
            this.richTextBox_RunLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox_RunLog.Size = new System.Drawing.Size(1549, 781);
            this.richTextBox_RunLog.TabIndex = 6;
            this.richTextBox_RunLog.Text = "";
            // 
            // RunLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 781);
            this.Controls.Add(this.richTextBox_RunLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RunLogForm";
            this.Text = "运行日志";
            this.Load += new System.EventHandler(this.RunLogForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_RunLog;
    }
}