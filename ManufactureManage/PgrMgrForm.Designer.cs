namespace ManufactureManage
{
    partial class PgrMgrForm
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_CratBtnTb = new System.Windows.Forms.Button();
            this.Btn_SqlSet = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1699, 68);
            this.panel4.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(17, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 36);
            this.label2.TabIndex = 6;
            this.label2.Text = "程 序 管 理";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_SqlSet);
            this.panel1.Controls.Add(this.button_CratBtnTb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1699, 798);
            this.panel1.TabIndex = 6;
            // 
            // button_CratBtnTb
            // 
            this.button_CratBtnTb.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button_CratBtnTb.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_CratBtnTb.Location = new System.Drawing.Point(121, 80);
            this.button_CratBtnTb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_CratBtnTb.Name = "button_CratBtnTb";
            this.button_CratBtnTb.Size = new System.Drawing.Size(181, 62);
            this.button_CratBtnTb.TabIndex = 0;
            this.button_CratBtnTb.Text = "建中间表";
            this.button_CratBtnTb.UseVisualStyleBackColor = false;
            this.button_CratBtnTb.Click += new System.EventHandler(this.button_CratBtnTb_Click);
            // 
            // Btn_SqlSet
            // 
            this.Btn_SqlSet.BackColor = System.Drawing.Color.MediumTurquoise;
            this.Btn_SqlSet.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SqlSet.Location = new System.Drawing.Point(446, 80);
            this.Btn_SqlSet.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_SqlSet.Name = "Btn_SqlSet";
            this.Btn_SqlSet.Size = new System.Drawing.Size(181, 62);
            this.Btn_SqlSet.TabIndex = 2;
            this.Btn_SqlSet.Text = "数据库设置";
            this.Btn_SqlSet.UseVisualStyleBackColor = false;
            this.Btn_SqlSet.Click += new System.EventHandler(this.Btn_SqlSet_Click);
            // 
            // PgrMgrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1699, 866);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PgrMgrForm";
            this.Text = "程序管理";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_CratBtnTb;
        private System.Windows.Forms.Button Btn_SqlSet;
    }
}