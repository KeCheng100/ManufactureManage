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
    public partial class CreatePlanForm : Form
    {
        public CreatePlanForm()
        {
            InitializeComponent();
        }

        private readonly string ModuleTest = "1008";
        private readonly string InsertPlate = "1009";
        private readonly string ParamSet = "1010";
        private readonly string PackClr = "1011";
        private readonly string ParamCmp = "1012";
        private readonly string RfidDoor = "1019";

        private void CreatePlanForm_Load(object sender, EventArgs e)
        {
            SysMgr.GetMgr().sqlHelp.GetProcPlan(ModuleTest, out List<string> modulePlans);
            comboBox_ModulePlan.DataSource = modulePlans;
            SysMgr.GetMgr().sqlHelp.GetProcPlan(InsertPlate, out List<string> platePlans);
            comboBox_InsertPlatePlan.DataSource = platePlans;
            SysMgr.GetMgr().sqlHelp.GetProcPlan(ParamSet, out List<string> paramSetPlans);
            comboBox_ParamSetPlan.DataSource = paramSetPlans;
            SysMgr.GetMgr().sqlHelp.GetProcPlan(PackClr, out List<string> packClrPlans);
            comboBox_PackClrPlan.DataSource = packClrPlans;
            SysMgr.GetMgr().sqlHelp.GetProcPlan(ParamCmp, out List<string> paramCmpPlans);
            comboBox_ParamCmpPlan.DataSource = paramCmpPlans;
            SysMgr.GetMgr().sqlHelp.GetProcPlan(RfidDoor, out List<string> rfidDoorPlans);
            comboBox_RfidDoorPlan.DataSource = rfidDoorPlans;
        }

        private void button_Sure_Click(object sender, EventArgs e)
        {
            
            string linePlanName = textBox_LinePlanName.Text;
            string province = comboBox_Province.Text;
            string modulePlanName = comboBox_ModulePlan.Text;
            string insertPlatePlanName = comboBox_InsertPlatePlan.Text;
            string setParamPlanName = comboBox_ParamSetPlan.Text;
            string packClrPlanName = comboBox_PackClrPlan.Text;
            string cmpParamPlanName = comboBox_ParamCmpPlan.Text;
            string rfidDoorPlanName = comboBox_RfidDoorPlan.Text;

            //判断是否已存在相同的方案名称
            if (SysMgr.GetMgr().sqlHelp.IsPlanExit(linePlanName))
            {
                MessageBox.Show($"已存在方案名为：{linePlanName} 的线体方案！", "提示");
                return;
            }
          
            T_LinePlan t_LinePlan = new T_LinePlan()
            {
                PLAN_NAME = linePlanName,
                PROVINCE = province,
                CARRIER_PLAN_NAME = modulePlanName,
                INSERTPLATE_PLAN_NAME= insertPlatePlanName,
                SETPARAM_PLAN_NAME = setParamPlanName,
                PACK12_PLAN_NAME = packClrPlanName,
                CMPPARAM_PLAN_NAME = cmpParamPlanName,
                RFIDDOOR_PLAN_NAME= rfidDoorPlanName
            };
            SysMgr.GetMgr().sqlHelp.CreateLinePlane(t_LinePlan);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}
