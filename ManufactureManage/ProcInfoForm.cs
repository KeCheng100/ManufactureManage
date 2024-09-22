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
    public partial class ProcInfoForm : Form
    {
        public ProcInfoForm()
        {
            InitializeComponent();
        }

       

        private void ProcInfoForm_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// 总查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Query_Click(object sender, EventArgs e)
        {
            string taskId = textBox_TaskCode.Text;
            string pcbCode = textBox_PcbCode.Text;
            string plateCode = textBox_NamePlateCode.Text;
            string moduleCode = textBox_ModuleCode.Text;
            string ofAddr = textBox_OfAddr.Text;
            string boxCode = textBox_BoxCode.Text;

            if (string.IsNullOrEmpty(taskId))
            {
                MessageBox.Show("请输入任务号！", "提示");
                return;
            }
            dgv_ShowLineData.Rows.Clear();
            SysMgr.GetMgr().sqlHelp.QueryLineData(taskId,pcbCode,plateCode,moduleCode,ofAddr,boxCode, out List<T_TaskDetail> t_TaskDetails);
            foreach (var item in t_TaskDetails)
            {
                dgv_ShowLineData.Rows.Add(item.TASK_ID, item.PCBCODE, item.NAMEPLATECODE, item.MODULE_CODE, item.OF_MAILADDRESS, item.RFID_CODE, item.BOX_CODE, item.MODULE_RESULT, item.MODULE_TIME, item.INPLATE_RESULT, item.INPLATE_TIME,
                    item.PARAMSET_RESULT, item.PARAMSET_TIME, item.PACKCLR_RESULT, item.PACKCLR_TIME, item.PARAMCMP_RESULT, item.PARAMCMP_TIME,
                    item.PASTELABEL_RESULT, item.PASTELABEL_TIME, item.RFIDDOOR_RESULT, item.RFIDDOOR_TIME);
            }

            
        }

        /// <summary>
        /// 载波查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ModuleQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_TaskCode.Text))
            {
                MessageBox.Show("请输入任务号！", "提示");
                return;
            }
            if (string.IsNullOrEmpty(textBox_ModuleInCode.Text))
            {
                string taskCode = textBox_TaskCode.Text;
               

                dgv_ShowModuleData.Rows.Clear();
                SysMgr.GetMgr().sqlHelp.QueryModuleData(taskCode,  out List<T_ModuleTest> t_ModuleTests);
                foreach (var item in t_ModuleTests)
                {
                    dgv_ShowModuleData.Rows.Add(item.UploadTime, item.DtbTime, item.TestCell, item.MailAddress, item.TestResult, item.FailItemName, item.FailItemDescribe);
                }
            }
            else
            {
                string taskCode = textBox_TaskCode.Text;
                string moduleInCode = textBox_ModuleInCode.Text;

                dgv_ShowModuleData.Rows.Clear();
                SysMgr.GetMgr().sqlHelp.QueryModuleData(taskCode, moduleInCode, out List<T_ModuleTest> t_ModuleTests);
                foreach (var item in t_ModuleTests)
                {
                    dgv_ShowModuleData.Rows.Add(item.UploadTime, item.DtbTime, item.TestCell, item.MailAddress, item.TestResult, item.FailItemName, item.FailItemDescribe);
                }
            }
            
        }

        /// <summary>
        /// 下铭牌查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PlateQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_TaskCode.Text))
            {
                MessageBox.Show("请输入任务号！", "提示");
                return;
            }
            if (string.IsNullOrEmpty(textBox_InsertPlate_PlateCode.Text))
            {
                string taskCode = textBox_TaskCode.Text;
                dgv_ShowInsertPlateCode.Rows.Clear();
                SysMgr.GetMgr().sqlHelp.QueryInsertPlateData(taskCode,  out List<T_InsertPlate> t_InsertPlates);
                foreach (var item in t_InsertPlates)
                {
                    dgv_ShowInsertPlateCode.Rows.Add(item.UploadTime, item.DtbTime, item.NamePlateCode, item.RfidCode);
                }
            }
            else
            {
                string taskCode = textBox_TaskCode.Text;
                string namePlateCode = textBox_InsertPlate_PlateCode.Text;
                dgv_ShowInsertPlateCode.Rows.Clear();
                SysMgr.GetMgr().sqlHelp.QueryInsertPlateData(taskCode, namePlateCode, out List<T_InsertPlate> t_InsertPlates);
                foreach (var item in t_InsertPlates)
                {
                    dgv_ShowInsertPlateCode.Rows.Add(item.UploadTime, item.DtbTime, item.NamePlateCode, item.RfidCode);
                }
            }
            
        }

        /// <summary>
        /// 参数设置查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SetParamQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_TaskCode.Text))
            {
                MessageBox.Show("请输入任务号！", "提示");
                return;
            }
            string taskCode = textBox_TaskCode.Text;
            string inCode = textBox_SP_InAddr.Text;
            string outCode = textBox_SP_OutAddr.Text;
            string plateCode = textBox_SP_PlateCode.Text;
            dgv_ShowSetParam.Rows.Clear();
            SysMgr.GetMgr().sqlHelp.QuerySetParamData(taskCode, inCode, outCode, plateCode, out List<T_SetParam> t_SetParams);
            foreach (var item in t_SetParams)
            {
                dgv_ShowSetParam.Rows.Add(item.UploadTime, item.DtbTime, item.TestCell, item.OldMailAddress, item.NewMailAddress, item.NamePlateCode);
            }

        }

        /// <summary>
        ///包装12表位查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PackClrQuery_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 参数比对查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CmpParamQuery_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 贴标查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PasteLabelQuery_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 射频门查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_RfidDoorQuery_Click(object sender, EventArgs e)
        {

        }
    }


    public class Connect
    {
        /// <summary>
        /// 连接字段
        /// </summary>
        public string ConnectStr { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
    }
}
