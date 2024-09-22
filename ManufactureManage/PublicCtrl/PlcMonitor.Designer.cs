namespace ManufactureManage.PublicCtrl
{
    partial class PlcMonitor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_Show = new System.Windows.Forms.DataGridView();
            this.序号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.值类型 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.值DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.button_SetInterval = new System.Windows.Forms.Button();
            this.textBox_GetInterval = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.comboBox_ValueType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Show)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_Show);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 861);
            this.panel1.TabIndex = 0;
            // 
            // dgv_Show
            // 
            this.dgv_Show.AllowUserToAddRows = false;
            this.dgv_Show.AllowUserToDeleteRows = false;
            this.dgv_Show.AllowUserToResizeRows = false;
            this.dgv_Show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Show.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Show.ColumnHeadersHeight = 29;
            this.dgv_Show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号DataGridViewTextBoxColumn,
            this.地址,
            this.名称DataGridViewTextBoxColumn,
            this.值类型,
            this.值DataGridViewTextBoxColumn});
            this.dgv_Show.DataMember = "Table_Items";
            this.dgv_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Show.Location = new System.Drawing.Point(0, 132);
            this.dgv_Show.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_Show.Name = "dgv_Show";
            this.dgv_Show.RowHeadersVisible = false;
            this.dgv_Show.RowHeadersWidth = 51;
            this.dgv_Show.RowTemplate.Height = 23;
            this.dgv_Show.Size = new System.Drawing.Size(1212, 729);
            this.dgv_Show.TabIndex = 1;
            this.dgv_Show.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Show_CellContentClick);
            // 
            // 序号DataGridViewTextBoxColumn
            // 
            this.序号DataGridViewTextBoxColumn.DataPropertyName = "序号";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.序号DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.序号DataGridViewTextBoxColumn.HeaderText = "序号";
            this.序号DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.序号DataGridViewTextBoxColumn.Name = "序号DataGridViewTextBoxColumn";
            this.序号DataGridViewTextBoxColumn.ReadOnly = true;
            this.序号DataGridViewTextBoxColumn.Width = 80;
            // 
            // 地址
            // 
            this.地址.DataPropertyName = "地址";
            this.地址.HeaderText = "地址";
            this.地址.MinimumWidth = 6;
            this.地址.Name = "地址";
            this.地址.ReadOnly = true;
            this.地址.Width = 125;
            // 
            // 名称DataGridViewTextBoxColumn
            // 
            this.名称DataGridViewTextBoxColumn.DataPropertyName = "名称";
            this.名称DataGridViewTextBoxColumn.HeaderText = "名称";
            this.名称DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.名称DataGridViewTextBoxColumn.Name = "名称DataGridViewTextBoxColumn";
            this.名称DataGridViewTextBoxColumn.ReadOnly = true;
            this.名称DataGridViewTextBoxColumn.Width = 500;
            // 
            // 值类型
            // 
            this.值类型.DataPropertyName = "值类型";
            this.值类型.HeaderText = "值类型";
            this.值类型.Items.AddRange(new object[] {
            "BOOL",
            "SHORT",
            "INT"});
            this.值类型.MinimumWidth = 6;
            this.值类型.Name = "值类型";
            this.值类型.ReadOnly = true;
            this.值类型.Width = 125;
            // 
            // 值DataGridViewTextBoxColumn
            // 
            this.值DataGridViewTextBoxColumn.DataPropertyName = "值";
            this.值DataGridViewTextBoxColumn.HeaderText = "值";
            this.值DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.值DataGridViewTextBoxColumn.Name = "值DataGridViewTextBoxColumn";
            this.值DataGridViewTextBoxColumn.ReadOnly = true;
            this.值DataGridViewTextBoxColumn.Width = 120;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.button_SetInterval);
            this.panel2.Controls.Add(this.textBox_GetInterval);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.button_Remove);
            this.panel2.Controls.Add(this.button_Add);
            this.panel2.Controls.Add(this.comboBox_ValueType);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox_Name);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox_Address);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1212, 132);
            this.panel2.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(250, 26);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "ms";
            // 
            // button_SetInterval
            // 
            this.button_SetInterval.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button_SetInterval.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SetInterval.Location = new System.Drawing.Point(322, 15);
            this.button_SetInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SetInterval.Name = "button_SetInterval";
            this.button_SetInterval.Size = new System.Drawing.Size(115, 40);
            this.button_SetInterval.TabIndex = 17;
            this.button_SetInterval.Text = "设置";
            this.button_SetInterval.UseVisualStyleBackColor = false;
            this.button_SetInterval.Click += new System.EventHandler(this.button_SetInterval_Click);
            // 
            // textBox_GetInterval
            // 
            this.textBox_GetInterval.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_GetInterval.Location = new System.Drawing.Point(134, 21);
            this.textBox_GetInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_GetInterval.Name = "textBox_GetInterval";
            this.textBox_GetInterval.Size = new System.Drawing.Size(107, 27);
            this.textBox_GetInterval.TabIndex = 16;
            this.textBox_GetInterval.Text = "1000";
            this.textBox_GetInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(28, 26);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "采集间隔：";
            // 
            // button_Remove
            // 
            this.button_Remove.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button_Remove.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Remove.Location = new System.Drawing.Point(1052, 51);
            this.button_Remove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(115, 49);
            this.button_Remove.TabIndex = 9;
            this.button_Remove.Text = "移除";
            this.button_Remove.UseVisualStyleBackColor = false;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Add
            // 
            this.button_Add.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button_Add.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Add.Location = new System.Drawing.Point(918, 51);
            this.button_Add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(115, 49);
            this.button_Add.TabIndex = 8;
            this.button_Add.Text = "添加";
            this.button_Add.UseVisualStyleBackColor = false;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // comboBox_ValueType
            // 
            this.comboBox_ValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ValueType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_ValueType.FormattingEnabled = true;
            this.comboBox_ValueType.Location = new System.Drawing.Point(320, 62);
            this.comboBox_ValueType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_ValueType.Name = "comboBox_ValueType";
            this.comboBox_ValueType.Size = new System.Drawing.Size(113, 25);
            this.comboBox_ValueType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(235, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "值类型：";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Name.Location = new System.Drawing.Point(510, 62);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(347, 27);
            this.textBox_Name.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(448, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "名称：";
            // 
            // textBox_Address
            // 
            this.textBox_Address.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Address.Location = new System.Drawing.Point(94, 62);
            this.textBox_Address.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(132, 27);
            this.textBox_Address.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址：";
            // 
            // timer1
            // 
            this.timer1.Interval = 350;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PlcMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PlcMonitor";
            this.Size = new System.Drawing.Size(1212, 861);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Show)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_Show;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.ComboBox comboBox_ValueType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn 值类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 值DataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button_SetInterval;
        private System.Windows.Forms.TextBox textBox_GetInterval;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}
