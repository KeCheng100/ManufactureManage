namespace ManufactureManage
{
    partial class CreateTaskForm
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
            this.textBox_TaskID = new System.Windows.Forms.TextBox();
            this.comboBox_Province = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_PcbStart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_PcbEnd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_CptCnt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_AllCnt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_GroupPlans = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Sure = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(66, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务号：";
            // 
            // textBox_TaskID
            // 
            this.textBox_TaskID.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_TaskID.Location = new System.Drawing.Point(141, 24);
            this.textBox_TaskID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TaskID.Name = "textBox_TaskID";
            this.textBox_TaskID.Size = new System.Drawing.Size(138, 30);
            this.textBox_TaskID.TabIndex = 1;
            // 
            // comboBox_Province
            // 
            this.comboBox_Province.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_Province.FormattingEnabled = true;
            this.comboBox_Province.Items.AddRange(new object[] {
            "北京",
            "天津",
            "上海",
            "重庆",
            "河北",
            "山西",
            "辽宁",
            "吉林",
            "黑龙江",
            "江苏",
            "浙江",
            "安徽",
            "福建",
            "江西",
            "山东",
            "河南",
            "湖北",
            "湖南",
            "广东",
            "海南",
            "四川",
            "贵州",
            "云南",
            "陕西",
            "甘肃",
            "青海",
            "内蒙古",
            "广西",
            "西藏",
            "宁夏",
            "新疆",
            "台湾"});
            this.comboBox_Province.Location = new System.Drawing.Point(141, 79);
            this.comboBox_Province.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Province.Name = "comboBox_Province";
            this.comboBox_Province.Size = new System.Drawing.Size(138, 28);
            this.comboBox_Province.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(85, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "省份：";
            // 
            // textBox_PcbStart
            // 
            this.textBox_PcbStart.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_PcbStart.Location = new System.Drawing.Point(141, 131);
            this.textBox_PcbStart.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_PcbStart.Name = "textBox_PcbStart";
            this.textBox_PcbStart.Size = new System.Drawing.Size(138, 30);
            this.textBox_PcbStart.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(47, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "起始内码：";
            // 
            // textBox_PcbEnd
            // 
            this.textBox_PcbEnd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_PcbEnd.Location = new System.Drawing.Point(141, 185);
            this.textBox_PcbEnd.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_PcbEnd.Name = "textBox_PcbEnd";
            this.textBox_PcbEnd.Size = new System.Drawing.Size(138, 30);
            this.textBox_PcbEnd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(47, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "结束内码：";
            // 
            // textBox_CptCnt
            // 
            this.textBox_CptCnt.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CptCnt.Location = new System.Drawing.Point(399, 133);
            this.textBox_CptCnt.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CptCnt.Name = "textBox_CptCnt";
            this.textBox_CptCnt.Size = new System.Drawing.Size(138, 30);
            this.textBox_CptCnt.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(306, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "已完成数：";
            // 
            // textBox_AllCnt
            // 
            this.textBox_AllCnt.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_AllCnt.Location = new System.Drawing.Point(399, 79);
            this.textBox_AllCnt.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_AllCnt.Name = "textBox_AllCnt";
            this.textBox_AllCnt.Size = new System.Drawing.Size(138, 30);
            this.textBox_AllCnt.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(306, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "计划总数：";
            // 
            // comboBox_GroupPlans
            // 
            this.comboBox_GroupPlans.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_GroupPlans.FormattingEnabled = true;
            this.comboBox_GroupPlans.Location = new System.Drawing.Point(399, 187);
            this.comboBox_GroupPlans.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_GroupPlans.Name = "comboBox_GroupPlans";
            this.comboBox_GroupPlans.Size = new System.Drawing.Size(138, 28);
            this.comboBox_GroupPlans.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(306, 190);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "测试方案：";
            // 
            // button_Sure
            // 
            this.button_Sure.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Sure.Location = new System.Drawing.Point(164, 254);
            this.button_Sure.Margin = new System.Windows.Forms.Padding(2);
            this.button_Sure.Name = "button_Sure";
            this.button_Sure.Size = new System.Drawing.Size(100, 34);
            this.button_Sure.TabIndex = 14;
            this.button_Sure.Text = "确认";
            this.button_Sure.UseVisualStyleBackColor = true;
            this.button_Sure.Click += new System.EventHandler(this.button_Sure_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Cancel.Location = new System.Drawing.Point(334, 254);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 34);
            this.button_Cancel.TabIndex = 15;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // CreateTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 307);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Sure);
            this.Controls.Add(this.comboBox_GroupPlans);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_CptCnt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_AllCnt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_PcbEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_PcbStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_Province);
            this.Controls.Add(this.textBox_TaskID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建任务";
            this.Load += new System.EventHandler(this.CreateTaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_TaskID;
        private System.Windows.Forms.ComboBox comboBox_Province;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PcbStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_PcbEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_CptCnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_AllCnt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_GroupPlans;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Sure;
        private System.Windows.Forms.Button button_Cancel;
    }
}