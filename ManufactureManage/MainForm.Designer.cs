namespace ManufactureManage
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LogOffLb = new System.Windows.Forms.Label();
            this.userLoginBt = new HZH_Controls.Controls.UCBtnExt();
            this.UserTypeTx = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_ShowForm = new System.Windows.Forms.Panel();
            this.treeViewEx_Navigate = new HZH_Controls.Controls.TreeViewEx();
            this.button_ExitForm = new System.Windows.Forms.Button();
            this.button_MinForm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeViewEx_Navigate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 732);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.button_ExitForm);
            this.panel2.Controls.Add(this.button_MinForm);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1440, 46);
            this.panel2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(11, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "主控软件系统";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.LogOffLb);
            this.panel3.Controls.Add(this.userLoginBt);
            this.panel3.Controls.Add(this.UserTypeTx);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 778);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1440, 32);
            this.panel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(1242, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "航天亮丽电气有限责任公司";
            // 
            // LogOffLb
            // 
            this.LogOffLb.AutoSize = true;
            this.LogOffLb.BackColor = System.Drawing.Color.Transparent;
            this.LogOffLb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogOffLb.Font = new System.Drawing.Font("微软雅黑", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogOffLb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.LogOffLb.Location = new System.Drawing.Point(171, 6);
            this.LogOffLb.Name = "LogOffLb";
            this.LogOffLb.Size = new System.Drawing.Size(39, 19);
            this.LogOffLb.TabIndex = 3;
            this.LogOffLb.Text = "注销";
            this.LogOffLb.Visible = false;
            // 
            // userLoginBt
            // 
            this.userLoginBt.BackColor = System.Drawing.Color.Transparent;
            this.userLoginBt.BtnBackColor = System.Drawing.Color.Transparent;
            this.userLoginBt.BtnFont = new System.Drawing.Font("微软雅黑", 9F);
            this.userLoginBt.BtnForeColor = System.Drawing.Color.Black;
            this.userLoginBt.BtnText = "登陆";
            this.userLoginBt.ConerRadius = 5;
            this.userLoginBt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userLoginBt.EnabledMouseEffect = false;
            this.userLoginBt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.userLoginBt.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.userLoginBt.IsRadius = true;
            this.userLoginBt.IsShowRect = true;
            this.userLoginBt.IsShowTips = false;
            this.userLoginBt.Location = new System.Drawing.Point(219, 5);
            this.userLoginBt.Margin = new System.Windows.Forms.Padding(0);
            this.userLoginBt.Name = "userLoginBt";
            this.userLoginBt.RectColor = System.Drawing.Color.Transparent;
            this.userLoginBt.RectWidth = 1;
            this.userLoginBt.refreshColor = System.Drawing.Color.Empty;
            this.userLoginBt.Size = new System.Drawing.Size(65, 23);
            this.userLoginBt.TabIndex = 0;
            this.userLoginBt.TabStop = false;
            this.userLoginBt.TipsColor = System.Drawing.Color.Black;
            this.userLoginBt.TipsText = "";
            this.userLoginBt.BtnClick += new System.EventHandler(this.userLoginBt_BtnClick);
            this.userLoginBt.Click += new System.EventHandler(this.userLoginBt_Click);
            // 
            // UserTypeTx
            // 
            this.UserTypeTx.AutoSize = true;
            this.UserTypeTx.BackColor = System.Drawing.Color.Transparent;
            this.UserTypeTx.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.UserTypeTx.ForeColor = System.Drawing.SystemColors.Control;
            this.UserTypeTx.Location = new System.Drawing.Point(85, 6);
            this.UserTypeTx.Name = "UserTypeTx";
            this.UserTypeTx.Size = new System.Drawing.Size(84, 19);
            this.UserTypeTx.TabIndex = 2;
            this.UserTypeTx.Text = "超级管理员";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前用户:";
            // 
            // panel_ShowForm
            // 
            this.panel_ShowForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ShowForm.Location = new System.Drawing.Point(150, 46);
            this.panel_ShowForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_ShowForm.Name = "panel_ShowForm";
            this.panel_ShowForm.Size = new System.Drawing.Size(1290, 732);
            this.panel_ShowForm.TabIndex = 6;
            // 
            // treeViewEx_Navigate
            // 
            this.treeViewEx_Navigate.BackColor = System.Drawing.Color.Black;
            this.treeViewEx_Navigate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewEx_Navigate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewEx_Navigate.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeViewEx_Navigate.FullRowSelect = true;
            this.treeViewEx_Navigate.HideSelection = false;
            this.treeViewEx_Navigate.IsShowByCustomModel = true;
            this.treeViewEx_Navigate.IsShowTip = false;
            this.treeViewEx_Navigate.ItemHeight = 50;
            this.treeViewEx_Navigate.Location = new System.Drawing.Point(0, 0);
            this.treeViewEx_Navigate.LstTips = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("treeViewEx_Navigate.LstTips")));
            this.treeViewEx_Navigate.Margin = new System.Windows.Forms.Padding(2);
            this.treeViewEx_Navigate.Name = "treeViewEx_Navigate";
            this.treeViewEx_Navigate.NodeBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeViewEx_Navigate.NodeDownPic = ((System.Drawing.Image)(resources.GetObject("treeViewEx_Navigate.NodeDownPic")));
            this.treeViewEx_Navigate.NodeForeColor = System.Drawing.Color.White;
            this.treeViewEx_Navigate.NodeHeight = 50;
            this.treeViewEx_Navigate.NodeIsShowSplitLine = false;
            this.treeViewEx_Navigate.NodeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.treeViewEx_Navigate.NodeSelectedForeColor = System.Drawing.Color.White;
            this.treeViewEx_Navigate.NodeSplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.treeViewEx_Navigate.NodeUpPic = ((System.Drawing.Image)(resources.GetObject("treeViewEx_Navigate.NodeUpPic")));
            this.treeViewEx_Navigate.ParentNodeCanSelect = true;
            this.treeViewEx_Navigate.ShowLines = false;
            this.treeViewEx_Navigate.ShowPlusMinus = false;
            this.treeViewEx_Navigate.ShowRootLines = false;
            this.treeViewEx_Navigate.Size = new System.Drawing.Size(150, 732);
            this.treeViewEx_Navigate.TabIndex = 0;
            this.treeViewEx_Navigate.TipFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewEx_Navigate.TipImage = ((System.Drawing.Image)(resources.GetObject("treeViewEx_Navigate.TipImage")));
            this.treeViewEx_Navigate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewEx_Navigate_AfterSelect);
            // 
            // button_ExitForm
            // 
            this.button_ExitForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExitForm.BackColor = System.Drawing.Color.Transparent;
            this.button_ExitForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ExitForm.BackgroundImage")));
            this.button_ExitForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ExitForm.Location = new System.Drawing.Point(1367, 10);
            this.button_ExitForm.Margin = new System.Windows.Forms.Padding(2);
            this.button_ExitForm.Name = "button_ExitForm";
            this.button_ExitForm.Size = new System.Drawing.Size(33, 26);
            this.button_ExitForm.TabIndex = 7;
            this.button_ExitForm.UseVisualStyleBackColor = false;
            this.button_ExitForm.Click += new System.EventHandler(this.button_ExitForm_Click);
            // 
            // button_MinForm
            // 
            this.button_MinForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_MinForm.BackColor = System.Drawing.Color.Transparent;
            this.button_MinForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_MinForm.BackgroundImage")));
            this.button_MinForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_MinForm.Location = new System.Drawing.Point(1306, 10);
            this.button_MinForm.Margin = new System.Windows.Forms.Padding(2);
            this.button_MinForm.Name = "button_MinForm";
            this.button_MinForm.Size = new System.Drawing.Size(33, 26);
            this.button_MinForm.TabIndex = 6;
            this.button_MinForm.UseVisualStyleBackColor = false;
            this.button_MinForm.Click += new System.EventHandler(this.button_MinForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 810);
            this.Controls.Add(this.panel_ShowForm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private HZH_Controls.Controls.TreeViewEx treeViewEx_Navigate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LogOffLb;
        private HZH_Controls.Controls.UCBtnExt userLoginBt;
        private System.Windows.Forms.Label UserTypeTx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_ShowForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ExitForm;
        private System.Windows.Forms.Button button_MinForm;
    }
}

