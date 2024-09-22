namespace ManufactureManage
{
    partial class CreatePlanForm
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Sure = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Province = new System.Windows.Forms.ComboBox();
            this.textBox_LinePlanName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_ModulePlan = new System.Windows.Forms.ComboBox();
            this.comboBox_ParamSetPlan = new System.Windows.Forms.ComboBox();
            this.comboBox_ParamCmpPlan = new System.Windows.Forms.ComboBox();
            this.comboBox_PackClrPlan = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_InsertPlatePlan = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_RfidDoorPlan = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Cancel.Location = new System.Drawing.Point(377, 298);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(120, 48);
            this.button_Cancel.TabIndex = 31;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Sure
            // 
            this.button_Sure.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Sure.Location = new System.Drawing.Point(206, 298);
            this.button_Sure.Margin = new System.Windows.Forms.Padding(2);
            this.button_Sure.Name = "button_Sure";
            this.button_Sure.Size = new System.Drawing.Size(120, 48);
            this.button_Sure.TabIndex = 30;
            this.button_Sure.Text = "确认";
            this.button_Sure.UseVisualStyleBackColor = true;
            this.button_Sure.Click += new System.EventHandler(this.button_Sure_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(42, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "设参方案：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(42, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "载波方案：";
            // 
            // comboBox_Province
            // 
            this.comboBox_Province.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Province.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.comboBox_Province.Location = new System.Drawing.Point(488, 40);
            this.comboBox_Province.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Province.Name = "comboBox_Province";
            this.comboBox_Province.Size = new System.Drawing.Size(179, 29);
            this.comboBox_Province.TabIndex = 18;
            // 
            // textBox_LinePlanName
            // 
            this.textBox_LinePlanName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_LinePlanName.Location = new System.Drawing.Point(147, 36);
            this.textBox_LinePlanName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_LinePlanName.Name = "textBox_LinePlanName";
            this.textBox_LinePlanName.Size = new System.Drawing.Size(179, 31);
            this.textBox_LinePlanName.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "方案名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(426, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "省份：";
            // 
            // comboBox_ModulePlan
            // 
            this.comboBox_ModulePlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ModulePlan.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_ModulePlan.FormattingEnabled = true;
            this.comboBox_ModulePlan.Location = new System.Drawing.Point(147, 111);
            this.comboBox_ModulePlan.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_ModulePlan.Name = "comboBox_ModulePlan";
            this.comboBox_ModulePlan.Size = new System.Drawing.Size(179, 29);
            this.comboBox_ModulePlan.TabIndex = 32;
            // 
            // comboBox_ParamSetPlan
            // 
            this.comboBox_ParamSetPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ParamSetPlan.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_ParamSetPlan.FormattingEnabled = true;
            this.comboBox_ParamSetPlan.Location = new System.Drawing.Point(147, 163);
            this.comboBox_ParamSetPlan.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_ParamSetPlan.Name = "comboBox_ParamSetPlan";
            this.comboBox_ParamSetPlan.Size = new System.Drawing.Size(179, 29);
            this.comboBox_ParamSetPlan.TabIndex = 33;
            // 
            // comboBox_ParamCmpPlan
            // 
            this.comboBox_ParamCmpPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ParamCmpPlan.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_ParamCmpPlan.FormattingEnabled = true;
            this.comboBox_ParamCmpPlan.Location = new System.Drawing.Point(147, 214);
            this.comboBox_ParamCmpPlan.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_ParamCmpPlan.Name = "comboBox_ParamCmpPlan";
            this.comboBox_ParamCmpPlan.Size = new System.Drawing.Size(179, 29);
            this.comboBox_ParamCmpPlan.TabIndex = 37;
            // 
            // comboBox_PackClrPlan
            // 
            this.comboBox_PackClrPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PackClrPlan.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_PackClrPlan.FormattingEnabled = true;
            this.comboBox_PackClrPlan.Location = new System.Drawing.Point(488, 165);
            this.comboBox_PackClrPlan.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_PackClrPlan.Name = "comboBox_PackClrPlan";
            this.comboBox_PackClrPlan.Size = new System.Drawing.Size(179, 29);
            this.comboBox_PackClrPlan.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(42, 218);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 21);
            this.label5.TabIndex = 35;
            this.label5.Text = "比参方案：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(362, 167);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 21);
            this.label6.TabIndex = 34;
            this.label6.Text = "12表位方案：";
            // 
            // comboBox_InsertPlatePlan
            // 
            this.comboBox_InsertPlatePlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_InsertPlatePlan.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_InsertPlatePlan.FormattingEnabled = true;
            this.comboBox_InsertPlatePlan.Location = new System.Drawing.Point(488, 113);
            this.comboBox_InsertPlatePlan.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_InsertPlatePlan.Name = "comboBox_InsertPlatePlan";
            this.comboBox_InsertPlatePlan.Size = new System.Drawing.Size(179, 29);
            this.comboBox_InsertPlatePlan.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(363, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 21);
            this.label7.TabIndex = 38;
            this.label7.Text = "下铭牌方案：";
            // 
            // comboBox_RfidDoorPlan
            // 
            this.comboBox_RfidDoorPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RfidDoorPlan.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_RfidDoorPlan.FormattingEnabled = true;
            this.comboBox_RfidDoorPlan.Location = new System.Drawing.Point(488, 214);
            this.comboBox_RfidDoorPlan.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_RfidDoorPlan.Name = "comboBox_RfidDoorPlan";
            this.comboBox_RfidDoorPlan.Size = new System.Drawing.Size(179, 29);
            this.comboBox_RfidDoorPlan.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(362, 216);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 21);
            this.label8.TabIndex = 40;
            this.label8.Text = "射频门方案：";
            // 
            // CreatePlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 371);
            this.Controls.Add(this.comboBox_RfidDoorPlan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox_InsertPlatePlan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_ParamCmpPlan);
            this.Controls.Add(this.comboBox_PackClrPlan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_ParamSetPlan);
            this.Controls.Add(this.comboBox_ModulePlan);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Sure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_Province);
            this.Controls.Add(this.textBox_LinePlanName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreatePlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建方案";
            this.Load += new System.EventHandler(this.CreatePlanForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Sure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Province;
        private System.Windows.Forms.TextBox textBox_LinePlanName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_ModulePlan;
        private System.Windows.Forms.ComboBox comboBox_ParamSetPlan;
        private System.Windows.Forms.ComboBox comboBox_ParamCmpPlan;
        private System.Windows.Forms.ComboBox comboBox_PackClrPlan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_InsertPlatePlan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_RfidDoorPlan;
        private System.Windows.Forms.Label label8;
    }
}