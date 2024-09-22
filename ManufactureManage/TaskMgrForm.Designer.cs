namespace ManufactureManage
{
    partial class TaskMgrForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_ShowTask = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_RefreshTask = new System.Windows.Forms.Button();
            this.button_SendTask = new System.Windows.Forms.Button();
            this.button_GreateTask = new System.Windows.Forms.Button();
            this.TaskState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.省份 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.值类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.值DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.计划总数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.已完成数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.创建时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowTask)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1290, 54);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "生 产 任 务 总 览";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.dgv_ShowTask);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1290, 576);
            this.panel2.TabIndex = 1;
            // 
            // dgv_ShowTask
            // 
            this.dgv_ShowTask.AllowUserToAddRows = false;
            this.dgv_ShowTask.AllowUserToDeleteRows = false;
            this.dgv_ShowTask.AllowUserToResizeRows = false;
            this.dgv_ShowTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ShowTask.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_ShowTask.ColumnHeadersHeight = 29;
            this.dgv_ShowTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskState,
            this.省份,
            this.TaskId,
            this.值类型,
            this.值DataGridViewTextBoxColumn,
            this.PlanName,
            this.计划总数,
            this.已完成数,
            this.创建时间});
            this.dgv_ShowTask.DataMember = "Table_Items";
            this.dgv_ShowTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ShowTask.Location = new System.Drawing.Point(0, 0);
            this.dgv_ShowTask.Name = "dgv_ShowTask";
            this.dgv_ShowTask.RowHeadersVisible = false;
            this.dgv_ShowTask.RowHeadersWidth = 51;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_ShowTask.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_ShowTask.RowTemplate.Height = 23;
            this.dgv_ShowTask.Size = new System.Drawing.Size(1290, 576);
            this.dgv_ShowTask.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.button_RefreshTask);
            this.panel3.Controls.Add(this.button_SendTask);
            this.panel3.Controls.Add(this.button_GreateTask);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 630);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1290, 102);
            this.panel3.TabIndex = 2;
            // 
            // button_RefreshTask
            // 
            this.button_RefreshTask.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_RefreshTask.Location = new System.Drawing.Point(22, 26);
            this.button_RefreshTask.Margin = new System.Windows.Forms.Padding(2);
            this.button_RefreshTask.Name = "button_RefreshTask";
            this.button_RefreshTask.Size = new System.Drawing.Size(185, 53);
            this.button_RefreshTask.TabIndex = 3;
            this.button_RefreshTask.Text = "任务列表刷新";
            this.button_RefreshTask.UseVisualStyleBackColor = true;
            this.button_RefreshTask.Click += new System.EventHandler(this.button_RefreshTask_Click);
            // 
            // button_SendTask
            // 
            this.button_SendTask.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SendTask.Location = new System.Drawing.Point(468, 26);
            this.button_SendTask.Margin = new System.Windows.Forms.Padding(2);
            this.button_SendTask.Name = "button_SendTask";
            this.button_SendTask.Size = new System.Drawing.Size(133, 53);
            this.button_SendTask.TabIndex = 1;
            this.button_SendTask.Text = "下发任务";
            this.button_SendTask.UseVisualStyleBackColor = true;
            this.button_SendTask.Click += new System.EventHandler(this.button_SendTask_Click);
            // 
            // button_GreateTask
            // 
            this.button_GreateTask.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_GreateTask.Location = new System.Drawing.Point(271, 26);
            this.button_GreateTask.Margin = new System.Windows.Forms.Padding(2);
            this.button_GreateTask.Name = "button_GreateTask";
            this.button_GreateTask.Size = new System.Drawing.Size(133, 53);
            this.button_GreateTask.TabIndex = 0;
            this.button_GreateTask.Text = "新建任务";
            this.button_GreateTask.UseVisualStyleBackColor = true;
            this.button_GreateTask.Click += new System.EventHandler(this.button_GreateTask_Click);
            // 
            // TaskState
            // 
            this.TaskState.DataPropertyName = "TaskState";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TaskState.DefaultCellStyle = dataGridViewCellStyle8;
            this.TaskState.HeaderText = "任务状态";
            this.TaskState.MinimumWidth = 6;
            this.TaskState.Name = "TaskState";
            this.TaskState.ReadOnly = true;
            this.TaskState.Width = 160;
            // 
            // 省份
            // 
            this.省份.DataPropertyName = "省份";
            this.省份.HeaderText = "省份";
            this.省份.MinimumWidth = 6;
            this.省份.Name = "省份";
            this.省份.ReadOnly = true;
            this.省份.Width = 125;
            // 
            // TaskId
            // 
            this.TaskId.DataPropertyName = "任务号";
            this.TaskId.HeaderText = "任务号";
            this.TaskId.MinimumWidth = 6;
            this.TaskId.Name = "TaskId";
            this.TaskId.ReadOnly = true;
            this.TaskId.Width = 150;
            // 
            // 值类型
            // 
            this.值类型.DataPropertyName = "值类型";
            this.值类型.HeaderText = "内码起始";
            this.值类型.MinimumWidth = 6;
            this.值类型.Name = "值类型";
            this.值类型.ReadOnly = true;
            this.值类型.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.值类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.值类型.Width = 140;
            // 
            // 值DataGridViewTextBoxColumn
            // 
            this.值DataGridViewTextBoxColumn.DataPropertyName = "值";
            this.值DataGridViewTextBoxColumn.HeaderText = "内码结束";
            this.值DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.值DataGridViewTextBoxColumn.Name = "值DataGridViewTextBoxColumn";
            this.值DataGridViewTextBoxColumn.ReadOnly = true;
            this.值DataGridViewTextBoxColumn.Width = 140;
            // 
            // PlanName
            // 
            this.PlanName.HeaderText = "方案名称";
            this.PlanName.MinimumWidth = 6;
            this.PlanName.Name = "PlanName";
            this.PlanName.Width = 150;
            // 
            // 计划总数
            // 
            this.计划总数.HeaderText = "计划总数";
            this.计划总数.MinimumWidth = 6;
            this.计划总数.Name = "计划总数";
            this.计划总数.Width = 125;
            // 
            // 已完成数
            // 
            this.已完成数.HeaderText = "已完成数";
            this.已完成数.MinimumWidth = 6;
            this.已完成数.Name = "已完成数";
            this.已完成数.Width = 125;
            // 
            // 创建时间
            // 
            this.创建时间.HeaderText = "创建时间";
            this.创建时间.MinimumWidth = 6;
            this.创建时间.Name = "创建时间";
            this.创建时间.Width = 170;
            // 
            // TaskMgrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 732);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TaskMgrForm";
            this.Text = "任务管理界面";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowTask)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_ShowTask;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_SendTask;
        private System.Windows.Forms.Button button_GreateTask;
        private System.Windows.Forms.Button button_RefreshTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskState;
        private System.Windows.Forms.DataGridViewTextBoxColumn 省份;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskId;
        private System.Windows.Forms.DataGridViewTextBoxColumn 值类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 值DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanName;
        private System.Windows.Forms.DataGridViewTextBoxColumn 计划总数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 已完成数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创建时间;
    }
}