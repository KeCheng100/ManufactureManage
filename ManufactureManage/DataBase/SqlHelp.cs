using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufactureManage.DataBase
{
    public class SqlHelp
    {
        private readonly ILog _log = LogManager.GetLogger(nameof(SqlHelp));

        /// <summary>
        /// 连接字段
        /// </summary>
        public string _ConnectStr { get; set; } = "Server=192.168.1.50; Port=3306; User=mtmgruser; Password=htll1234; database= mtlinemgr; SslMode=None; Allow User Variables=true;";

        public string _ConnectStrWithoutDb { get; set; } = "Server=192.168.1.50; Port=3306; User=mtmgruser; Password=htll1234; SslMode=None; Allow User Variables=true;";

        public string _DatabaseName { get; set; } = "mtlinemgr";

        /// <summary>
        /// 获取组方案列表
        /// </summary>
        /// <param name="planList"></param>
        /// <returns></returns>
        public ResultCode GetGroupPlan(out List<string> planList)
        {
            string cmd = "select * from lineplanmgr";
            MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            planList= dataTable.AsEnumerable().Select(d => d.Field<string>("PLAN_NAME")).ToList();
            return ResultCode.Success;
        }

        /// <summary>
        /// 创建一个方案
        /// </summary>
        /// <param name="t_Task"></param>
        /// <returns></returns>
        public ResultCode CreateTask(T_Task t_Task)
        {
            string cmd = "insert into taskmgr(" +
                "TASK_STATE,"+
                "PROVINCE," +
                "TASK_ID," +
                "PCB_START," +
                "PCB_END," +
                "PLAN_NAME," +
                "ALL_CNT," +
                $"CPT_CNT," +
                $"CREATE_TIME) values(" +
                $"'{t_Task.TASK_STATE}'," +
                $"'{t_Task.PROVINCE}'," +
                $"'{t_Task.TASK_ID}'," +
                $"'{t_Task.PCB_START}'," +
                $"'{t_Task.PCB_END}'," +
                $"'{t_Task.PLAN_NAME}'," +
                $"{t_Task.ALL_CNT}," +
                $"{t_Task.CPT_CNT}," +
                $"'{t_Task.CREATE_TIME}');";

            ResultCode resultCode= MySqlHelp.RunCmd(_ConnectStr, cmd);
            return resultCode;
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="t_Tasks"></param>
        /// <returns></returns>
        public ResultCode GetTaskList(out List<T_Task> t_Tasks)
        {
            t_Tasks = new List<T_Task>();
            string cmd = "select * from taskmgr;";
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T_Task t_Task = new T_Task()
                {
                    TASK_STATE = dataTable.Rows[i]["TASK_STATE"].ToString(),
                    PROVINCE = dataTable.Rows[i]["PROVINCE"].ToString(),
                    TASK_ID = dataTable.Rows[i]["TASK_ID"].ToString(),
                    PCB_START = dataTable.Rows[i]["PCB_START"].ToString(),
                    PCB_END = dataTable.Rows[i]["PCB_END"].ToString(),
                    PLAN_NAME = dataTable.Rows[i]["PLAN_NAME"].ToString(),
                    ALL_CNT = Convert.ToInt32(dataTable.Rows[i]["ALL_CNT"].ToString()),
                    CPT_CNT = Convert.ToInt32(dataTable.Rows[i]["CPT_CNT"].ToString()),
                    CREATE_TIME = Convert.ToDateTime(dataTable.Rows[i]["CREATE_TIME"].ToString())
                };
                t_Tasks.Add(t_Task);
            }
            return ResultCode.Success;
        }

        /// <summary>
        /// 获取方案列表
        /// </summary>
        /// <param name="t_LinePlans"></param>
        /// <returns></returns>
        public ResultCode GetPlanList(out List<T_LinePlan> t_LinePlans)
        {
            t_LinePlans = new List<T_LinePlan>();
            string cmd = "select * from lineplanmgr;";
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T_LinePlan t_LinePlan = new T_LinePlan()
                {
                    PROVINCE = dataTable.Rows[i]["PROVINCE"].ToString(),
                    PLAN_NAME = dataTable.Rows[i]["PLAN_NAME"].ToString(),
                    CARRIER_PLAN_NAME = dataTable.Rows[i]["CARRIER_PLAN_NAME"].ToString(),
                    INSERTPLATE_PLAN_NAME= dataTable.Rows[i]["INSERTPLATE_PLAN_NAME"].ToString(),
                    SETPARAM_PLAN_NAME = dataTable.Rows[i]["SETPARAM_PLAN_NAME"].ToString(),
                    PACK12_PLAN_NAME = dataTable.Rows[i]["PACK12_PLAN_NAME"].ToString(),
                    CMPPARAM_PLAN_NAME = dataTable.Rows[i]["CMPPARAM_PLAN_NAME"].ToString(),
                    SORT_PLAN_NAME = dataTable.Rows[i]["SORT_PLAN_NAME"].ToString(),
                    MANUALPACK_PLAN_NAME = dataTable.Rows[i]["MANUALPACK_PLAN_NAME"].ToString(),
                    RFIDDOOR_PLAN_NAME = dataTable.Rows[i]["RFIDDOOR_PLAN_NAME"].ToString()
                };

                t_LinePlans.Add(t_LinePlan);
            }
            return ResultCode.Success;
        }

        /// <summary>
        /// 创建一个与任务相关的工序详细信息表
        /// </summary>
        /// <param name="t_Task"></param>
        /// <returns></returns>
        public ResultCode CreateTaskDetail(T_Task t_Task)
        {
            //创建一个任务的同时，需要创建一个任务明细总表，同时根据内码起始内码结束，填充该表：Province+_+Task_id
            ResultCode resultCode = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"detail{t_Task.TASK_ID}", new T_TaskDetail());
            if (resultCode != ResultCode.Success)
                return resultCode;
            return MySqlHelp.TransInsertPcbCode(_ConnectStr, $"detail{t_Task.TASK_ID}", t_Task.TASK_ID, t_Task.PCB_START, t_Task.PCB_END);
        }

        /// <summary>
        /// 创建各工序对应任务单号下的明细表
        /// </summary>
        /// <returns></returns>
        public ResultCode CreateProcDetail(string taskCode)
        {
            ResultCode result1 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl{taskCode}1008", new T_ModuleTest());
            ResultCode result2 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl{taskCode}1009", new T_InsertPlate());
            ResultCode result3 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl{taskCode}1010", new T_SetParam());
            ResultCode result4 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl{taskCode}1011", new T_Pack12());
            ResultCode result5 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl{taskCode}1012", new T_CmpParam());
            ResultCode result6 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl{taskCode}1016", new T_PasteLabel());
            ResultCode result7 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl{taskCode}1019", new T_RfidDoor());
            ResultCode[] resultCodes = new ResultCode[7] { result1, result2, result3, result4, result5, result6, result7 };
            if (resultCodes.Any(t => t != ResultCode.Success))
            {
                return ResultCode.Failed;
            }
            else
                return ResultCode.Success;
        }

        /// <summary>
        /// 创建各工序的中间表
        /// </summary>
        /// <returns></returns>
        public ResultCode CreateBtnTbs()
        {
            ResultCode result1 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl1008", new T_ModuleTest());
            ResultCode result2 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl1009", new T_InsertPlate());
            ResultCode result3 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl1010", new T_SetParam());
            ResultCode result4 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl1011", new T_Pack12());
            ResultCode result5 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl1012", new T_CmpParam());
            ResultCode result6 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl1016", new T_PasteLabel());
            ResultCode result7 = MySqlHelp.CreateTable(_ConnectStrWithoutDb, _DatabaseName, $"dtl1019", new T_RfidDoor());
            ResultCode[] resultCodes = new ResultCode[7] { result1, result2, result3, result4, result5, result6, result7 };
            if (resultCodes.Any(t => t != ResultCode.Success))
            {
                return ResultCode.Failed;
            }
            else
                return ResultCode.Success;
        }

        /// <summary>
        /// 获取各工序方案列表
        /// </summary>
        /// <param name="procCode"></param>
        /// <param name="planList"></param>
        /// <returns></returns>
        public ResultCode GetProcPlan(string procCode,out List<string> planList)
        {
            planList = new List<string>();
            //先查询任务表名
            string queryCmd = $"select * from proc_plan_crl where PROC_CODE = '{procCode}'";
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, queryCmd, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;

            if (dataTable.Rows.Count != 1)
                return ResultCode.Failed;

            string tName = dataTable.Rows[0]["PLAN_TABLE_NAME"].ToString();

            //查询方案
            string queryPlanCmd = $"select * from {tName} where PROC_IDENTIFIER = '{procCode}'";
            resultCode = MySqlHelp.RunReadCmd(_ConnectStr, queryPlanCmd, out DataTable dataTable1);
            if (resultCode != ResultCode.Success)
                return resultCode;
            planList=dataTable1.AsEnumerable().Select(d => d.Field<string>("PLAN_NAME")).ToList();
            return ResultCode.Success;
        }

        /// <summary>
        /// 使procCode工序名为planName的方案的使用状态为true，其它方案为false
        /// </summary>
        /// <param name="procCode"></param>
        /// <param name="planName"></param>
        /// <returns></returns>
        public ResultCode SelectProcPlan(string procCode,string planName)
        {
            string cmd = $"update usingplan set PLAN_NAME = '{planName}' where PROC_IDENTIFIER = '{procCode}';";
            ResultCode resultCode = MySqlHelp.RunCmd(_ConnectStr, cmd);
            return resultCode;
        }

        //未开始/进行中/暂停中/结束
        public ResultCode SetTaskStart(string taskID)
        {
            string cmd1 = $"select * from taskmgr where TASK_ID = '{taskID}';";
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, cmd1, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;

            if (dataTable.Rows.Count != 1)
                return ResultCode.Failed;

            string cmd3 = $"update taskmgr set TASK_STATE = '暂停中' where TASK_STATE = '进行中';";
            resultCode = MySqlHelp.RunCmd(_ConnectStr, cmd3);
            if (resultCode != ResultCode.Success)
                return resultCode;

            string cmd2 = $"update taskmgr set TASK_STATE = '进行中' where TASK_ID = '{taskID}';";
            resultCode = MySqlHelp.RunCmd(_ConnectStr, cmd2);
            return resultCode;

        }

        /// <summary>
        /// 判断某个线体方案是否存在
        /// </summary>
        /// <param name="planName"></param>
        /// <returns></returns>
        public bool IsPlanExit(string planName)
        {
            string cmd = $"select * from lineplanmgr where PLAN_NAME = '{planName}';";
            MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            if (dataTable.Rows.Count == 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 创建一条线体方案
        /// </summary>
        /// <param name="t_LinePlan"></param>
        /// <returns></returns>
        public ResultCode CreateLinePlane(T_LinePlan t_LinePlan)
        {
            string cmd = "insert into lineplanmgr(" +
                "PROVINCE," +
                "PLAN_NAME," +
                "CARRIER_PLAN_NAME," +
                "INSERTPLATE_PLAN_NAME," +
                "SETPARAM_PLAN_NAME," +
                "PACK12_PLAN_NAME," +
                "CMPPARAM_PLAN_NAME," +
                "SORT_PLAN_NAME," +
                "MANUALPACK_PLAN_NAME," +
                $"RFIDDOOR_PLAN_NAME) values(" +
                $"'{t_LinePlan.PROVINCE}'," +
                $"'{t_LinePlan.PLAN_NAME}'," +
                $"'{t_LinePlan.CARRIER_PLAN_NAME}'," +
                $"'{t_LinePlan.INSERTPLATE_PLAN_NAME}'," +
                $"'{t_LinePlan.SETPARAM_PLAN_NAME}'," +
                $"'{t_LinePlan.PACK12_PLAN_NAME}'," +
                $"'{t_LinePlan.CMPPARAM_PLAN_NAME}'," +
                $"'{t_LinePlan.SORT_PLAN_NAME}'," +
                $"'{t_LinePlan.MANUALPACK_PLAN_NAME}'," +
                $"'{t_LinePlan.RFIDDOOR_PLAN_NAME}');";
            ResultCode resultCode = MySqlHelp.RunCmd(_ConnectStr, cmd);
            return resultCode;
        }

        /// <summary>
        /// 根据系统总方案名称，查询线体方案
        /// </summary>
        /// <param name="planName"></param>
        /// <param name="t_LinePlan"></param>
        /// <returns></returns>
        public ResultCode GetTaskPlan(string planName,out T_LinePlan t_LinePlan)
        {
            t_LinePlan = new T_LinePlan();
            string cmd = $"select * from lineplanmgr where PLAN_NAME = '{planName}';";
            MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            if (dataTable.Rows.Count != 1)
                return ResultCode.Failed;
            t_LinePlan = new T_LinePlan()
            {
                PROVINCE = dataTable.Rows[0]["PROVINCE"].ToString(),
                PLAN_NAME = dataTable.Rows[0]["PLAN_NAME"].ToString(),
                CARRIER_PLAN_NAME = dataTable.Rows[0]["CARRIER_PLAN_NAME"].ToString(),
                INSERTPLATE_PLAN_NAME = dataTable.Rows[0]["INSERTPLATE_PLAN_NAME"].ToString(),
                SETPARAM_PLAN_NAME = dataTable.Rows[0]["SETPARAM_PLAN_NAME"].ToString(),
                PACK12_PLAN_NAME = dataTable.Rows[0]["PACK12_PLAN_NAME"].ToString(),
                CMPPARAM_PLAN_NAME = dataTable.Rows[0]["CMPPARAM_PLAN_NAME"].ToString(),
                SORT_PLAN_NAME = dataTable.Rows[0]["SORT_PLAN_NAME"].ToString(),
                MANUALPACK_PLAN_NAME = dataTable.Rows[0]["MANUALPACK_PLAN_NAME"].ToString(),
                RFIDDOOR_PLAN_NAME = dataTable.Rows[0]["RFIDDOOR_PLAN_NAME"].ToString(),
            };
            return ResultCode.Success;
        }



        /*
         * string taskId = textBox_TaskCode.Text;
            string pcbCode = textBox_PcbCode.Text;
            string plateCode = textBox_NamePlateCode.Text;
            string moduleCode = textBox_ModuleCode.Text;
            string ofAddr = textBox_OfAddr.Text;
            string boxCode = textBox_BoxCode.Text;
         */
        /// <summary>
        /// 根据任务号查询该任务号下线体表
        /// </summary>
        /// <param name="taskCode"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public ResultCode QueryLineData(string taskCode,string pcbCode,string plateCode,string moduleCode,string ofAddr,string boxCode, out List<T_TaskDetail> t_TaskDetails)
        {
            t_TaskDetails = new List<T_TaskDetail>();
            string tableName = $"detail{taskCode}";
            string sPCBCODE = string.IsNullOrEmpty(pcbCode) ? "" : $" and PCBCODE = '{pcbCode}'";
            string sNAMEPLATECODE = string.IsNullOrEmpty(plateCode) ? "" : $" and NAMEPLATECODE = '{plateCode}'";
            string sOF_MAILADDRESS = string.IsNullOrEmpty(ofAddr) ? "" : $" and OF_MAILADDRESS = '{ofAddr}'";
            string sBOX_CODE = string.IsNullOrEmpty(boxCode) ? "" : $" and BOX_CODE = '{boxCode}'";

            string cmdQuery = $"select * from {tableName} where TASK_ID = '{taskCode}'" + sPCBCODE + sNAMEPLATECODE + sOF_MAILADDRESS + sBOX_CODE;
            //string cmd = $"select * from {tableName} limit 2000;";
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, cmdQuery, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T_TaskDetail t_TaskDetail = new T_TaskDetail()
                {
                    TASK_ID = dataTable.Rows[i]["TASK_ID"].ToString(),
                    PCBCODE = dataTable.Rows[i]["PCBCODE"].ToString(),
                    NAMEPLATECODE = dataTable.Rows[i]["NAMEPLATECODE"].ToString(),
                    OF_MAILADDRESS = dataTable.Rows[i]["OF_MAILADDRESS"].ToString(),
                    MODULE_CODE = dataTable.Rows[i]["MODULE_CODE"].ToString(),
                    RFID_CODE = dataTable.Rows[i]["RFID_CODE"].ToString(),
                    BOX_CODE = dataTable.Rows[i]["BOX_CODE"].ToString(),
                    MODULE_RESULT = dataTable.Rows[i]["MODULE_RESULT"].ToString(),
                    MODULE_TIME = dataTable.Rows[i]["MODULE_TIME"].ToString(),
                    INPLATE_RESULT= dataTable.Rows[i]["INPLATE_RESULT"].ToString(),
                    INPLATE_TIME= dataTable.Rows[i]["INPLATE_TIME"].ToString(),
                    PARAMSET_RESULT = dataTable.Rows[i]["PARAMSET_RESULT"].ToString(),
                    PARAMSET_TIME = dataTable.Rows[i]["PARAMSET_TIME"].ToString(),
                    PACKCLR_RESULT = dataTable.Rows[i]["PACKCLR_RESULT"].ToString(),
                    PACKCLR_TIME = dataTable.Rows[i]["PACKCLR_TIME"].ToString(),
                    PARAMCMP_RESULT = dataTable.Rows[i]["PARAMCMP_RESULT"].ToString(),
                    PARAMCMP_TIME = dataTable.Rows[i]["PARAMCMP_TIME"].ToString(),
                    PASTELABEL_RESULT = dataTable.Rows[i]["PASTELABEL_RESULT"].ToString(),
                    PASTELABEL_TIME = dataTable.Rows[i]["PASTELABEL_TIME"].ToString(),
                    RFIDDOOR_RESULT= dataTable.Rows[i]["RFIDDOOR_RESULT"].ToString(),
                    RFIDDOOR_TIME= dataTable.Rows[i]["RFIDDOOR_TIME"].ToString()
                };
                t_TaskDetails.Add(t_TaskDetail);
            }
            return ResultCode.Success;
        }

        /// <summary>
        /// 载波查询数据
        /// </summary>
        /// <param name="taskCode"></param>
        /// <param name="inCode"></param>
        /// <param name="t_ModuleTests"></param>
        /// <returns></returns>
        public ResultCode QueryModuleData(string taskCode,string inCode,out List<T_ModuleTest> t_ModuleTests)
        {
            t_ModuleTests = new List<T_ModuleTest>();
            string tableName = $"dtl{taskCode}1008";
            string cmd = $"select * from {tableName} where MailAddress = '{inCode}'";
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T_ModuleTest t_ModuleTest = new T_ModuleTest()
                {
                    UploadTime= dataTable.Rows[i]["UploadTime"].ToString(),
                    DtbTime= dataTable.Rows[i]["DtbTime"].ToString(),
                    TestCell=dataTable.Rows[i]["TestCell"].ToString(),
                    MailAddress=dataTable.Rows[i]["MailAddress"].ToString(),
                    TestResult=dataTable.Rows[i]["TestResult"].ToString(),
                    FailItemName=dataTable.Rows[i]["FailItemName"].ToString(),
                    FailItemDescribe=dataTable.Rows[i]["FailItemDescribe"].ToString()
                };
                t_ModuleTests.Add(t_ModuleTest);
            }
            return ResultCode.Success;
        }

        public ResultCode QueryModuleData(string taskCode,  out List<T_ModuleTest> t_ModuleTests)
        {
            t_ModuleTests = new List<T_ModuleTest>();
            string tableName = $"dtl{taskCode}1008";
            string cmd = $"select * from {tableName};";
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T_ModuleTest t_ModuleTest = new T_ModuleTest()
                {
                    UploadTime = dataTable.Rows[i]["UploadTime"].ToString(),
                    DtbTime = dataTable.Rows[i]["DtbTime"].ToString(),
                    TestCell = dataTable.Rows[i]["TestCell"].ToString(),
                    MailAddress = dataTable.Rows[i]["MailAddress"].ToString(),
                    TestResult = dataTable.Rows[i]["TestResult"].ToString(),
                    FailItemName = dataTable.Rows[i]["FailItemName"].ToString(),
                    FailItemDescribe = dataTable.Rows[i]["FailItemDescribe"].ToString()
                };
                t_ModuleTests.Add(t_ModuleTest);
            }
            return ResultCode.Success;
        }

        /// <summary>
        /// 下铭牌查询数据
        /// </summary>
        /// <param name="taskCode"></param>
        /// <param name="nameplateCode"></param>
        /// <param name="t_InsertPlates"></param>
        /// <returns></returns>
        public ResultCode QueryInsertPlateData(string taskCode,string nameplateCode,out List<T_InsertPlate> t_InsertPlates)
        {
            t_InsertPlates = new List<T_InsertPlate>();
            string tableName = $"dtl{taskCode}1009";
            string cmd = $"select * from {tableName} where NamePlateCode = '{nameplateCode}'";
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T_InsertPlate t_InsertPlate = new T_InsertPlate()
                {
                    UploadTime = dataTable.Rows[i]["UploadTime"].ToString(),
                    DtbTime = dataTable.Rows[i]["DtbTime"].ToString(),
                    NamePlateCode = dataTable.Rows[i]["NamePlateCode"].ToString(),
                    RfidCode = dataTable.Rows[i]["RfidCode"].ToString()
                };
                t_InsertPlates.Add(t_InsertPlate);
            }
            return ResultCode.Success;
        }

        public ResultCode QueryInsertPlateData(string taskCode, out List<T_InsertPlate> t_InsertPlates)
        {
            t_InsertPlates = new List<T_InsertPlate>();
            string tableName = $"dtl{taskCode}1009";
            string cmd = $"select * from {tableName};";
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T_InsertPlate t_InsertPlate = new T_InsertPlate()
                {
                    UploadTime = dataTable.Rows[i]["UploadTime"].ToString(),
                    DtbTime = dataTable.Rows[i]["DtbTime"].ToString(),
                    NamePlateCode = dataTable.Rows[i]["NamePlateCode"].ToString(),
                    RfidCode = dataTable.Rows[i]["RfidCode"].ToString()
                };
                t_InsertPlates.Add(t_InsertPlate);
            }
            return ResultCode.Success;
        }



        /// <summary>
        /// 设参查询数据
        /// </summary>
        /// <param name="taskCode"></param>
        /// <param name="inAddr"></param>
        /// <param name="outAddr"></param>
        /// <param name="PlateCode"></param>
        /// <param name="t_SetParams"></param>
        /// <returns></returns>
        public ResultCode QuerySetParamData(string taskCode,string inAddr,string outAddr,string PlateCode,out List<T_SetParam> t_SetParams)
        {
            t_SetParams = new List<T_SetParam>();
            string tableName = $"dtl{taskCode}1010";
            string sInAddr = string.IsNullOrEmpty(inAddr) ? "" : $" OldMailAddress = '{inAddr}' and";
            string sOutAddr = string.IsNullOrEmpty(outAddr) ? "" : $" NewMailAddress = '{outAddr}' and";
            string sPlateCode = string.IsNullOrEmpty(PlateCode) ? "" : $" NamePlateCode = '{PlateCode}' and";

            string cmd = $"select * from {tableName} where{sInAddr}{sOutAddr}{sPlateCode}";
            cmd = cmd.Substring(0, cmd.Length - 4);
            ResultCode resultCode = MySqlHelp.RunReadCmd(_ConnectStr, cmd, out DataTable dataTable);
            if (resultCode != ResultCode.Success)
                return resultCode;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T_SetParam t_SetParam = new T_SetParam()
                {
                    UploadTime=dataTable.Rows[i]["UploadTime"].ToString(),
                    DtbTime= dataTable.Rows[i]["DtbTime"].ToString(),
                    TestCell= dataTable.Rows[i]["TestCell"].ToString(),
                    OldMailAddress= dataTable.Rows[i]["OldMailAddress"].ToString(),
                    NewMailAddress = dataTable.Rows[i]["NewMailAddress"].ToString(),
                    NamePlateCode = dataTable.Rows[i]["NamePlateCode"].ToString(),
                    SoftwareVersion = dataTable.Rows[i]["SoftwareVersion"].ToString(),
                    MeterNo = dataTable.Rows[i]["MeterNo"].ToString(),
                    AssertCode = dataTable.Rows[i]["AssertCode"].ToString(),
                    TestResult = dataTable.Rows[i]["TestResult"].ToString(),
                    FailItemName = dataTable.Rows[i]["FailItemName"].ToString(),
                    FailItemDescribe = dataTable.Rows[i]["FailItemDescribe"].ToString()
                };
                t_SetParams.Add(t_SetParam);
            }
            return ResultCode.Success;
        }


        

        #region 数据统计分析公共方法

        #endregion

    }
}
