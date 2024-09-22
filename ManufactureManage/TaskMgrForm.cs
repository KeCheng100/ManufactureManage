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
    public partial class TaskMgrForm : Form
    {
        public TaskMgrForm()
        {
            InitializeComponent();
        }

        

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_GreateTask_Click(object sender, EventArgs e)
        {
            CreateTaskForm createTaskForm = new CreateTaskForm();
            createTaskForm.ShowDialog();
            RefreshUi();
        }

       

        private void button_RefreshTask_Click(object sender, EventArgs e)
        {
            RefreshUi();
        }

        private void button_SendTask_Click(object sender, EventArgs e)
        {
            //任务下发时需要考虑当前是否存在已开始而未完成的任务
            //1、获得任务名称
            //2、获取该任务下的方案名称
            //3、获取方案名称下各工序的方案名称
            //4、使对应工序下的方案是唯一正在执行的方案
            //5、改动方案类型为进行中
            if (MessageBox.Show("请确认线体处于停线状态？", "请注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            string taskState= dgv_ShowTask.Rows[dgv_ShowTask.CurrentRow.Index].Cells["TaskState"].Value.ToString();
            if (taskState=="结束")
            {
                MessageBox.Show("改任务已结单，请勿重复开始！");
                return;
            }
            string taskId= dgv_ShowTask.Rows[dgv_ShowTask.CurrentRow.Index].Cells["TaskId"].Value.ToString();
            SysMgr.GetMgr().sqlHelp.SetTaskStart(taskId);

            string planName = dgv_ShowTask.Rows[dgv_ShowTask.CurrentRow.Index].Cells["PlanName"].Value.ToString();

            SysMgr.GetMgr().sqlHelp.GetTaskPlan(planName, out T_LinePlan t_LinePlan);
            SysMgr.GetMgr().sqlHelp.SelectProcPlan("1008", t_LinePlan.CARRIER_PLAN_NAME);
            SysMgr.GetMgr().sqlHelp.SelectProcPlan("1009", t_LinePlan.INSERTPLATE_PLAN_NAME);
            SysMgr.GetMgr().sqlHelp.SelectProcPlan("1010", t_LinePlan.SETPARAM_PLAN_NAME);
            SysMgr.GetMgr().sqlHelp.SelectProcPlan("1011", t_LinePlan.PACK12_PLAN_NAME);
            SysMgr.GetMgr().sqlHelp.SelectProcPlan("1012", t_LinePlan.CMPPARAM_PLAN_NAME);
            SysMgr.GetMgr().sqlHelp.SelectProcPlan("1016", t_LinePlan.PASTELABEL_PLAN_NAME);
            SysMgr.GetMgr().sqlHelp.SelectProcPlan("1019", t_LinePlan.RFIDDOOR_PLAN_NAME);

            RefreshUi();
        }


        private void RefreshUi()
        {
            dgv_ShowTask.Rows.Clear();
            SysMgr.GetMgr().sqlHelp.GetTaskList(out List<T_Task> tasks);
            foreach (var item in tasks)
            {
                dgv_ShowTask.Rows.Add(item.TASK_STATE, item.PROVINCE, item.TASK_ID, item.PCB_START, item.PCB_END, item.PLAN_NAME, item.ALL_CNT, item.CPT_CNT, item.CREATE_TIME);
            }
        }

       
    }
}
