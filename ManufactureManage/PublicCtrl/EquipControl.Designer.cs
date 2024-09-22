namespace ManufactureManage.PublicCtrl
{
    partial class EquipControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_State = new System.Windows.Forms.PictureBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_RunInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_State)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_State
            // 
            this.pictureBox_State.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox_State.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox_State.Location = new System.Drawing.Point(0, 40);
            this.pictureBox_State.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox_State.Name = "pictureBox_State";
            this.pictureBox_State.Size = new System.Drawing.Size(118, 42);
            this.pictureBox_State.TabIndex = 0;
            this.pictureBox_State.TabStop = false;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Name.Location = new System.Drawing.Point(19, 11);
            this.label_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(85, 19);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "设备名称";
            // 
            // label_RunInfo
            // 
            this.label_RunInfo.AutoSize = true;
            this.label_RunInfo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_RunInfo.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_RunInfo.Location = new System.Drawing.Point(2, 52);
            this.label_RunInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_RunInfo.Name = "label_RunInfo";
            this.label_RunInfo.Size = new System.Drawing.Size(47, 19);
            this.label_RunInfo.TabIndex = 2;
            this.label_RunInfo.Text = "离线";
            // 
            // EquipControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.label_RunInfo);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.pictureBox_State);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EquipControl";
            this.Size = new System.Drawing.Size(118, 82);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_State)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_State;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_RunInfo;
    }
}
