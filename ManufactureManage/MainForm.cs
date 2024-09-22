using ManufactureManage.PublicCtrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZH_Controls;
using HZH_Controls.Controls;

namespace ManufactureManage
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        public static MonitorForm3 _MonitorForm3 = new MonitorForm3();
        private static RunLogForm _runLogForm = new RunLogForm();
        private static CellMonitorForm _cellMonitorForm = new CellMonitorForm();
        private static TaskMgrForm _taskMgrForm = new TaskMgrForm();
        private static SelectPlanEditForm _selectPlanEditForm = new SelectPlanEditForm();
        private static ProcInfoForm _procInfoForm = new ProcInfoForm();
        private static PgrMgrForm _pgrMgrForm = new PgrMgrForm();
        private static PlanMgrForm _planMgrForm = new PlanMgrForm();

        private static StatisticsShowForm _statisticsShowForm = new StatisticsShowForm();

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region 初始化侧栏界面
            try
            {
                ControlHelper.FreezeControl(this, true);
                TreeNode main = new TreeNode("  运行监控");
                main.Nodes.Add("线体监控");
                main.Nodes.Add("单元监控");
                treeViewEx_Navigate.Nodes.Add(main);

                TreeNode logInfo = new TreeNode("  运行日志");
                treeViewEx_Navigate.Nodes.Add(logInfo);

                TreeNode taskMgr = new TreeNode("  生产管理");
                taskMgr.Nodes.Add("任务管理");
                taskMgr.Nodes.Add("方案管理");
                treeViewEx_Navigate.Nodes.Add(taskMgr);

                TreeNode procinfo = new TreeNode("  查询统计");
                procinfo.Nodes.Add("整体查询");
                procinfo.Nodes.Add("图形显示");
               
                treeViewEx_Navigate.Nodes.Add(procinfo);

                TreeNode systemSetIp = new TreeNode("  系统设置");
                systemSetIp.Nodes.Add("系统参数");
                systemSetIp.Nodes.Add("厂家参数");
                treeViewEx_Navigate.Nodes.Add(systemSetIp);


                TreeNode systemSetUser = new TreeNode("  用户管理");
                treeViewEx_Navigate.Nodes.Add(systemSetUser);

                TreeNode pgrMgr = new TreeNode("  程序管理");
                treeViewEx_Navigate.Nodes.Add(pgrMgr);
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
            #endregion

            #region 管理类初始化
            var sysMgr =SysMgr.GetMgr();
            var result = sysMgr.Init();
            if (result != ResultCode.Success)
            {
                MessageBox.Show($"程序初始化失败,错误代码: {result}, 详细原因请查看日志！", "注意");
                return;
            }
            #endregion

        }

        private void treeViewEx_Navigate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panel_ShowForm.Controls.Clear();
            string strName = e.Node.Text.Trim();
            this.IsMdiContainer = true;
            switch (strName)
            {
                case "线体监控":
                    _MonitorForm3.MdiParent = this;
                    _MonitorForm3.Parent = this.panel_ShowForm;
                    _MonitorForm3.Dock = DockStyle.Fill;
                    _MonitorForm3.Show();
                    break;
                case "单元监控":
                    _cellMonitorForm.MdiParent = this;
                    _cellMonitorForm.Parent = this.panel_ShowForm;
                    _cellMonitorForm.Dock = DockStyle.Fill;
                    _cellMonitorForm.Show();
                    break;
                case "运行日志":
                    _runLogForm.MdiParent = this;
                    _runLogForm.Parent = this.panel_ShowForm;
                    _runLogForm.Dock = DockStyle.Fill;
                    _runLogForm.Show();
                    break;
                case "任务管理":
                    _taskMgrForm.MdiParent = this;
                    _taskMgrForm.Parent = this.panel_ShowForm;
                    _taskMgrForm.Dock = DockStyle.Fill;
                    _taskMgrForm.Show();
                    break;
                case "方案管理":
                    _planMgrForm.MdiParent = this;
                    _planMgrForm.Parent = this.panel_ShowForm;
                    _planMgrForm.Dock = DockStyle.Fill;
                    _planMgrForm.Show();
                    break;
                case "整体查询":
                    _procInfoForm.MdiParent = this;
                    _procInfoForm.Parent = this.panel_ShowForm;
                    _procInfoForm.Dock = DockStyle.Fill;
                    _procInfoForm.Show();
                    break;
                case "图形显示":
                    _statisticsShowForm.MdiParent = this;
                    _statisticsShowForm.Parent = this.panel_ShowForm;
                    _statisticsShowForm.Dock = DockStyle.Fill;
                    _statisticsShowForm.Show();
                    break;
                case "程序管理":
                    _pgrMgrForm.MdiParent = this;
                    _pgrMgrForm.Parent = this.panel_ShowForm;
                    _pgrMgrForm.Dock = DockStyle.Fill;
                    _pgrMgrForm.Show();
                    break;
                default:
                    break;
            }
        }


        private void button_MinForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_ExitForm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要退出当前程序吗？", "请注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            this.Close();
        }

        /// <summary>
        /// 权限检查
        /// </summary>
        private void PowerCheck()
        {

        }

        private void userLoginBt_Click(object sender, EventArgs e)
        {

        }

        private void userLoginBt_BtnClick(object sender, EventArgs e)
        {

        }
    }
}
