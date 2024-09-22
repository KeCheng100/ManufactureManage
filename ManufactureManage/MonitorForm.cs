using log4net;
using ManufactureManage.DataBase;
using ManufactureManage.PublicCtrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManufactureManage
{
    public partial class MonitorForm : Form
    {
        public MonitorForm()
        {
            InitializeComponent();
        }

        private readonly ILog _log = LogManager.GetLogger(nameof(MonitorForm));
        private CancellationTokenSource _cts;
        private void MonitorForm_Load(object sender, EventArgs e)
        {
            /*
            InitEquipment();


            _cts = new CancellationTokenSource();
            int timeInterval = 1000;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        if (_cts.IsCancellationRequested)
                            return;
                        if (!Visible)
                            return;

                        foreach (var itemCtrl in panel1.Controls)
                        {
                            if (itemCtrl is PublicCtrl.EquipControl equip)
                            {
                                equip.DoWork();
                            }
                        }
                        qw(out DataTable dataTable);
                        if (dataTable.Rows[0]["Value_1"].ToString()=="1")
                        {
                            equip_WithVolt.BackColor= Color.Red;
                        }
                       
                        if (dataTable != null)

                        for (int i = 0; i < timeInterval / 500; i++)
                        {
                            if (_cts.IsCancellationRequested)
                                return;
                            Thread.Sleep(500);
                        }
                    }
                    finally
                    {
                        Thread.Sleep(100);
                    }
                }
            });
            */


        }

        private void MonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_cts.Cancel();


        }

        /// <summary>
        /// 初始化设备
        /// </summary>
        private void InitEquipment()
        {
            equip_ParamSet.NetId = 0;
            equip_ParamSet.StandbyReg = 10;
            equip_ParamSet.RuningReg = 11;
            equip_ParamSet.AlarmReg = 12;
            equip_ParamSet.AlarmDict = new Dictionary<int, string>();

            equip_WithVolt.NetId = 1;
            equip_WithVolt.StandbyReg = 10;
            equip_WithVolt.RuningReg = 11;
            equip_WithVolt.AlarmReg = 12;
            equip_WithVolt.AlarmDict = new Dictionary<int, string>();



            equip_Battle.NetId = 3;
            equip_Battle.StandbyReg = 10;
            equip_Battle.RuningReg = 11;
            equip_Battle.AlarmReg = 12;
            equip_Battle.AlarmDict = new Dictionary<int, string>();
            //equip_ParamSet.AlarmDict.Add(32, "出口扫码异常");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _log.Info("日志测试");
            _log.Error("异常日志测试");
        }

        private void equip_WithVolt_MouseHover(object sender, EventArgs e)
        {
            qw(out DataTable dataTable);
            toolTip1.InitialDelay = 100;
            toolTip1.AutoPopDelay = 10000;//提示信息的可见时间
            toolTip1.BackColor = Color.Blue;
            string info = "PLCIP：" + equip_WithVolt.IP + "\r\n" +
                "设备位置：" + dataTable.Rows[0]["DeviceStation"].ToString();
            toolTip1.SetToolTip(equip_WithVolt, info);

        }
        private void qw(out DataTable dataTable)
        {
            string connectStr = string.Empty;
            string tableName = string.Empty;
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
            dataTable = new DataTable();
            connectStr = $"Server = 10.88.3.74; Port = 3306; database = htll_mtlinemgr; User = root; Password = 123456; SslMode=None; Allow User Variables=true;";
            tableName = $"plc_currentstate";
            queryCmd = $"SELECT *  FROM {tableName} " +
                $"WHERE  DeviceNO = 0009 " +
                $"order by PLCID;";
            resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);

        }

    }
}
