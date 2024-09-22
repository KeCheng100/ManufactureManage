using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ManufactureManage.Config;
using ManufactureManage.DataBase;
using ManufactureManage.PublicCtrl;
using static ManufactureManage.StatisticsShowForm;

namespace ManufactureManage
{
    public partial class CellMonitorForm : Form
    {
        public CellMonitorForm()
        {
            InitializeComponent();
        }

        private int _selectedDeviceIndex = 0;//当前选择的设备
        DataSet DT;
        SystemConfig _systemConfig = new SystemConfig();
        private delegate void UpdateDataGridView(DataSet dt);

        private void CellMonitorForm_Load(object sender, EventArgs e)
        {
            _selectedDeviceIndex = tabControl1.TabIndex;

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        ZBplcSHOW(DT);
                    }
                    finally
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        public void ZBplcSHOW(DataSet DT)
        {
            QueryData(DeviceTypeEnum.CarrierEquipment, out DT);

            if (dgv_Show.InvokeRequired)
            {
                this.BeginInvoke(new UpdateDataGridView(ZBplcSHOW), new object[] { DT });
            }
            else
            {
                dgv_Show.AutoGenerateColumns = false;
                dgv_Show.DataSource = DT;
                dgv_Show.Refresh();

                List<string> xLabel = new List<string>();
                List<int> yLabel = new List<int>();
                for (int i = 0; i < DT.Tables[0].Rows.Count; i++)
                {
                    yLabel.Add(Convert.ToInt32(DT.Tables[0].Rows[i]["Count(*)"].ToString()));
                }
                for (int i = 0; i < DT.Tables[0].Rows.Count; i++)
                {
                    xLabel.Add((DT.Tables[0].Rows[i]["messageinfo"].ToString()));
                }
                RefreshChart(xLabel, yLabel);
                //RefreshPieChart(xLabel, yLabel);
            }
            if (_selectedDeviceIndex == 1)
            {
                if (Dgv_Npt.InvokeRequired)
                {
                    this.BeginInvoke(new UpdateDataGridView(ZBplcSHOW), new object[] { DT });
                }
                else
                {
                    Dgv_Npt.AutoGenerateColumns = false;
                    Dgv_Npt.DataSource = DT.Tables[1];
                    Dgv_Npt.Refresh();
                    List<string> xLabel = new List<string>();
                    List<int> yLabel = new List<int>();
                    for (int i = 0; i < DT.Tables[1].Rows.Count; i++)
                    {
                        yLabel.Add(Convert.ToInt32(DT.Tables[1].Rows[i]["Count(*)"].ToString()));
                    }
                    for (int i = 0; i < DT.Tables[1].Rows.Count; i++)
                    {
                        xLabel.Add((DT.Tables[1].Rows[i]["messageinfo"].ToString()));
                    }
                    RefreshChart(xLabel, yLabel);
                    //RefreshPieChart(xLabel, yLabel);
                }
            }
        }

        public delegate void RefreshChartDelegate(List<string> x, List<int> y);
        private void RefreshChart(List<string> x, List<int> y)// DataTypeEnum dataTypeEnum)
        {
            try
            {
                if (this.chart1.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y });
                }
                else
                {
                    chart1.Series[0].Points.DataBindXY(x, y);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void QueryData(DeviceTypeEnum A, out DataSet dataTable)
        {
            try
            {
                //数据库连接字段
                // char de = (char)0009;
                string connectStr = _systemConfig._ConnectStrHistory;
                string tableName = _systemConfig._TableNameHistory;
                string queryCmd = string.Empty;
                ResultCode resultCode = ResultCode.Failed;
                //时间格式
                string timeFormat = string.Empty;
                //结果格式
                string queryCondition = string.Empty;//查所有合格的结果
                                                     //默认截取时间

                DateTime startTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:01"));
                DateTime endTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string startTime1 = startTime.ToString("yyyy-MM-dd 00:00:01");
                string endTime1 = endTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (endTime - startTime > TimeSpan.FromHours(24))//大于24小时按天显示 
                {
                    timeFormat = "%y年%m月%d日";
                }
                else
                {
                    timeFormat = "%m-%d %H";
                }
                dataTable = new DataSet();
                switch (A)
                {
                    case DeviceTypeEnum.CarrierEquipment:
                        //connectStr = $"Server = 10.88.3.74; Port = 3306; database = htll_mtlinemgr; User = root; Password = 123456; SslMode=None; Allow User Variables=true;";
                        //tableName = $"plc_historicstate";
                        queryCmd = $"SELECT * , Count(*),MAX(LastTime),MAX(ID) FROM {tableName} " +
                                   $"WHERE  DeviceNO = 00013 AND Value_1 = 1 AND LastTime BETWEEN '{startTime1}' AND '{endTime1}' " +
                                   $"GROUP BY PLCID order by PLCID;";
                        resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out DataTable dataTable1);
                        dataTable.Tables.Add(dataTable1.Copy());
                        goto case DeviceTypeEnum.NameplateEquipment;
                    case DeviceTypeEnum.NameplateEquipment:
                        //connectStr = $"Server = localhost; Port = 3306; User = root; password =admin123; database = labelingdata; Connect Timeout=30; SslMode=None; Allow User Variables=true;";
                        //tableName = $"comparecode_tb";
                        queryCmd = $"SELECT * , Count(*),MAX(LastTime),MAX(ID) FROM {tableName} " +
                                   $"WHERE  DeviceNO = 00014 AND Value_1 = 1 AND LastTime BETWEEN '{startTime1}' AND '{endTime1}' " +
                                   $"GROUP BY PLCID order by PLCID;";
                        resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out DataTable dataTable2);
                        dataTable.Tables.Add(dataTable2.Copy());
                        break;
                    case DeviceTypeEnum.ParameterSetEquipment:

                        break;
                    case DeviceTypeEnum.WarpTwlveMeters:

                        break;
                    case DeviceTypeEnum.ParameterCompare:

                        break;
                    case DeviceTypeEnum.LabelingEquipment:

                        break;
                    case DeviceTypeEnum.AutoSorting:
                        //connectStr = $"Server = localhost; Port = 3306; User = root; password =admin123; database = autosortpack_db; Connect Timeout=30; SslMode=None; Allow User Variables=true;";
                        //tableName = $"metersinfo_tb";
                        //queryCmd = $"SELECT DATE_FORMAT(Check_Time,'{timeFormat}') as date,count(1) as cnt " +
                        //           $"FROM {tableName} " +
                        //           $"WHERE {queryCondition} Check_Time BETWEEN '{startTime:yyyy-MM-dd}' AND '{endTime.AddDays(1):yyyy-MM-dd}' " +
                        //           $"GROUP BY DATE_FORMAT(Check_Time,'{timeFormat}') " +
                        //           $"ORDER BY date asc;";
                        //resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);

                        break;
                    case DeviceTypeEnum.RfidTestEquipment:
                        //connectStr = $"Server = localhost; Port = 3306; User = root; password =admin123; database = rftest_db; Connect Timeout=30; SslMode=None; Allow User Variables=true;";
                        //tableName = $"rftest_tb";
                        //queryCmd = $"SELECT DATE_FORMAT(Check_Time,'{timeFormat}') as date,count(1) as cnt " +
                        //           $"FROM {tableName} " +
                        //           $"WHERE {queryCondition} Check_Time BETWEEN '{startTime:yyyy-MM-dd}' AND '{endTime.AddDays(1):yyyy-MM-dd}' " +
                        //           $"GROUP BY DATE_FORMAT(Check_Time,'{timeFormat}') " +
                        //           $"ORDER BY date asc;";
                        //resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                _selectedDeviceIndex = 0;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            { 
                _selectedDeviceIndex = 1; 
            }
        }

    }
    /// <summary>
    /// 绑定数据的设备类型
    /// </summary>
    public enum DeviceTypeEnum
    {
        /// <summary>
        /// 载波测试设备
        /// </summary>
        CarrierEquipment,
        /// <summary>
        /// 下铭牌及电子标签贴检设备
        /// </summary>
        NameplateEquipment,
        /// <summary>
        /// 参数设置设备
        /// </summary>
        ParameterSetEquipment,
        /// <summary>
        /// 包装12表位设备
        /// </summary>
        WarpTwlveMeters,
        /// <summary>
        /// 参数比对设备
        /// </summary>
        ParameterCompare,
        /// <summary>
        /// 贴标设备
        /// </summary>
        LabelingEquipment,
        /// <summary>
        /// 排序机
        /// </summary>
        AutoSorting,
        /// <summary>
        /// 射频检测设备
        /// </summary>
        RfidTestEquipment
    }
}
