using ManufactureManage.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManufactureManage
{
    public partial class CreateTaskForm : Form
    {
        public CreateTaskForm()
        {
            InitializeComponent();
        }

        private void CreateTaskForm_Load(object sender, EventArgs e)
        {
            SysMgr.GetMgr().sqlHelp.GetGroupPlan(out List<string> planList);
            comboBox_GroupPlans.DataSource = planList;
        }

        private void button_Sure_Click(object sender, EventArgs e)
        {
            string task_id = textBox_TaskID.Text;
            string province = comboBox_Province.Text;
            string pcbStart = textBox_PcbStart.Text;
            string pcbEnd = textBox_PcbEnd.Text;
            int allCnt = Convert.ToInt32(textBox_AllCnt.Text);
            int cptCnt = Convert.ToInt32(textBox_CptCnt.Text);
            string planName = comboBox_GroupPlans.Text;
            T_Task t_Task = new T_Task()
            {
                TASK_STATE="未开始",
                PROVINCE = province,
                TASK_ID = task_id,
                PCB_START = pcbStart,
                PCB_END = pcbEnd,
                ALL_CNT = allCnt,
                CPT_CNT = cptCnt,
                PLAN_NAME = planName,
                CREATE_TIME=DateTime.Now
            };
            SysMgr.GetMgr().sqlHelp.CreateTask(t_Task);
            
            SysMgr.GetMgr().sqlHelp.CreateTaskDetail(t_Task);
            //以厂内PCB码填充TaskDetail


            //同时要建各工序该任务单下的结果库，命名规则：dtl+任务单号+工序号
            SysMgr.GetMgr().sqlHelp.CreateProcDetail(task_id);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
