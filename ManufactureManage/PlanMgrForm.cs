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
    public partial class PlanMgrForm : Form
    {
        public PlanMgrForm()
        {
            InitializeComponent();
        }

        private void button_RefreshPlan_Click(object sender, EventArgs e)
        {
            dgv_showPlans.Rows.Clear();
            SysMgr.GetMgr().sqlHelp.GetPlanList(out List<T_LinePlan> plans);
            foreach (var item in plans)
            {
                dgv_showPlans.Rows.Add(item.PROVINCE, item.PLAN_NAME, item.CARRIER_PLAN_NAME,item.INSERTPLATE_PLAN_NAME, item.SETPARAM_PLAN_NAME, item.PACK12_PLAN_NAME, item.CMPPARAM_PLAN_NAME,item.PASTELABEL_PLAN_NAME,item.SORT_PLAN_NAME,item.MANUALPACK_PLAN_NAME,item.RFIDDOOR_PLAN_NAME);
            }
        }

        private void button_GreatePlan_Click(object sender, EventArgs e)
        {
            CreatePlanForm createPlanForm = new CreatePlanForm();
            createPlanForm.ShowDialog();
        }
    }
}
