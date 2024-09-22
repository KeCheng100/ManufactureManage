using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using System.Threading;
using ManufactureManage.PLC;

namespace ManufactureManage.PublicCtrl
{
    public partial class PlcMonitor : UserControl
    {
        public PlcMonitor()
        {
            InitializeComponent();
        }
        #region 成员和属性
        private readonly ILog _log = LogManager.GetLogger(nameof(PlcMonitor));
        private readonly string _configDirPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Config\monitorConfig\";
        private PlcOperate plcOperator;
        private readonly object _signalRoot = new object();

        private int _failedCnt = 0;
        private bool _plcON = false;

        private int _getInterval = 1000;

        private int GetInterval
        {
            get { lock (_signalRoot) { return _getInterval; } }
            set { lock (_signalRoot) { _getInterval = value; } }
        }
        #endregion


        public bool Init()
        {
            try
            {
                //plcOperator = new PlcOperate();
                //PlcConfig plcConfig = new PlcConfig() { IpAddress = _monitorInfo.ipAddress, Port = _monitorInfo.port, plcType = _monitorInfo.plcType };
                //var plcRet = plcOperator.Init(plcConfig);
                //if (plcRet != ResultCode.Success)
                //{
                //    _log.Error($"{_monitorInfo.name}连接失败! {plcRet}");
                //}

                //comboBox_DevicePlcType.DataSource = Enum.GetNames(typeof(PlcType));
                //comboBox_ValueType.DataSource = Enum.GetNames(typeof(PlcValueType));

                //textBox_DeviceName.Text = _monitorInfo.name;
                //textBox_DeviceIp.Text = _monitorInfo.ipAddress;
                //textBox_DevicePort.Text = _monitorInfo.port.ToString();
                //textBox_DeviceOverTime.Text = _monitorInfo.overTime.ToString();
                //comboBox_DevicePlcType.SelectedIndex = (int)_monitorInfo.plcType;
                //_failedCnt = 0;
                //_plcON = false;
               
                return true;
            }
            catch (Exception ex)
            {
                _log.Error($"监控界面初始化失败");
                return false;
            }
        }

        public void InitUi()
        {
            RefreshShow();
            MonitorTask();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Visible)
                return;
            //if (_monitorInfo==null)
            //    return;

            ResultCode result = ResultCode.Failed;
            //for (int i = 0; i < _monitorInfo.blocks.Count; i++)
            //{
            //    Thread.Sleep(1);
            //    var cellItem = _monitorInfo.blocks[i];

            //    string valueStr = string.Empty;
            //    switch (cellItem.plcValueType)
            //    {
            //        case PlcValueType.BOOL:
            //            {
            //                result=plcOperator.Read_bool(cellItem.address, out bool value);
            //                valueStr = value ? "true" : "false";
            //            }
            //            break;
            //        case PlcValueType.SHORT:
            //            {
            //                result=plcOperator.Read_short(cellItem.address, out short value);
            //                valueStr = value.ToString();
            //            }
            //            break;
            //        case PlcValueType.INT:
            //            {
            //                result=plcOperator.Read_int(cellItem.address, out int value);
            //                valueStr = value.ToString();
            //            }
            //            break;
            //        //case PlcValueType.FLOAT:
            //        //    {
            //        //        plcOperator.Read_long(cellItem.address, out long value);
            //        //        valueStr = value.ToString();
            //        //    }
            //        //    break;
            //        //case PlcValueType.DOUBLE:
            //        //    {

            //        //    }
            //            break;
            //        default:
            //            break;
            //    }
            
            //    if (result==ResultCode.Success)
            //    {
            //        dgv_Show[4, i].Value = valueStr;
            //        _failedCnt = 0;
                    
            //        if (_plcON == false)
            //        {
            //            panel_State.BackColor = Color.Green;
            //            label_state.Text = "在线";
            //            _plcON = true;
            //        }
            //    }
            //    else
            //    {
            //        _failedCnt++;
            //        if (_failedCnt>10&&(_plcON==true))
            //        {
            //            _failedCnt = 0;
            //            _plcON = false ;
            //            panel_State.BackColor = Color.DarkRed;
            //            label_state.Text = "离线";
            //        }
            //    }

                
            //}
        }

        private void MonitorTask()
        {
            //Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        try
            //        {
            //            //if (!Visible)
            //            //    return;
            //            if (_monitorInfo == null)
            //                return;

            //            ResultCode result = ResultCode.Failed;
            //            for (int i = 0; i < _monitorInfo.blocks.Count; i++)
            //            {
            //                Thread.Sleep(1);
            //                if (i > dgv_Show.Rows.Count)
            //                    continue;

            //                var cellItem = _monitorInfo.blocks[i];

            //                string valueStr = string.Empty;
            //                switch (cellItem.plcValueType)
            //                {
            //                    case PlcValueType.BOOL:
            //                        {
            //                            result = plcOperator.Read_bool(cellItem.address, out bool value);
            //                            valueStr = value ? "true" : "false";
            //                        }
            //                        break;
            //                    case PlcValueType.SHORT:
            //                        {
            //                            result = plcOperator.Read_short(cellItem.address, out short value);
            //                            valueStr = value.ToString();
            //                        }
            //                        break;
            //                    case PlcValueType.INT:
            //                        {
            //                            result = plcOperator.Read_int(cellItem.address, out int value);
            //                            valueStr = value.ToString();
            //                        }
            //                        break;
            //                    default:
            //                        break;
            //                }

            //                if (result == ResultCode.Success)
            //                {
            //                    if (i > dgv_Show.Rows.Count)
            //                        continue;
            //                    dgv_Show[4, i].Value = valueStr;
            //                    if (valueStr=="true")
            //                    {
            //                        dgv_Show[4, i].Style.BackColor = Color.Green;
            //                    }
            //                    else
            //                    {
            //                        dgv_Show[4, i].Style.BackColor= SystemColors.Control;
            //                    }
            //                    _failedCnt = 0;

            //                    if (_plcON == false)
            //                    {
            //                        _log.Info($"{_monitorInfo.name} 上线");
            //                        BeginInvoke(new Action(() => {
            //                            this.panel_State.BackColor = Color.Green;
            //                            this.label_state.Text = "在线";
            //                            _log.Info($"{_monitorInfo.name} 上线1");

            //                        }));
            //                        _plcON = true;
            //                        _monitorInfo.IsPlcOn = true;

            //                    }
            //                }
            //                else
            //                {
            //                    _failedCnt++;
            //                    if (_failedCnt > 3 && (_plcON == true))
            //                    {
            //                        _failedCnt = 0;
            //                        _plcON = false;
            //                        _monitorInfo.IsPlcOn = false;
            //                        _log.Info($"{_monitorInfo.name} 离线");
            //                        BeginInvoke(new Action(() => {
            //                            this.panel_State.BackColor = Color.DarkRed;
            //                            this.label_state.Text = "离线";
            //                        }));
            //                    }
            //                }

            //                _monitorInfo.blocks[i].value = valueStr;
            //            }

            //            string jsonStr = ConfigUtility.ToJsonStr(_monitorInfo);
            //            string savetime = DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss.fff");
            //            string tableName = "mes_yuan" + DateTime.Now.ToString("yyMM");

            //            string cmdStr = $"INSERT INTO {tableName} VALUES(null,'{jsonStr}','{savetime}','{_monitorInfo.name}','{_monitorInfo.deviceNumber}','{_monitorInfo.ipAddress}')";
            //            //_log.Info(cmdStr);
            //            dynamic entity = new System.Dynamic.ExpandoObject();
            //            entity.CmdStr = cmdStr;
            //            DbMgrInst.GetDbMgr().PostLocalDataMessage(LocalDataMessageCode.InsertData, entity);
            //        }
            //        finally
            //        {
            //            Thread.Sleep(GetInterval);
            //        }
            //    }
            //});
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            //string address = textBox_Address.Text;
            //PlcValueType valueType = (PlcValueType)comboBox_ValueType.SelectedIndex;
            //string name = textBox_Name.Text;

            //MonitorBlock monitorBlock = new MonitorBlock()
            //{
            //    address = address,
            //    plcValueType = valueType,
            //    name = name
            //};
            //_monitorInfo.blocks.Add(monitorBlock);
            //RefreshShow();
            //SaveMonitorInfo();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            int index = dgv_Show.SelectedCells[0].RowIndex;
            string address = Convert.ToString(dgv_Show[1,index].Value);
            if (MessageBox.Show($"确认要删除监视 {address} 吗？", "请注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            //_monitorInfo.blocks.RemoveAll(t => t.address == address);
            RefreshShow();
            SaveMonitorInfo();
        }

        private void RefreshShow()
        {
            
            dgv_Show.Rows.Clear();
            int index = 0;
            //foreach (var item in _monitorInfo.blocks)
            //{
            //    dgv_Show.Rows.Add(index, item.address, item.name, item.plcValueType.ToString());
            //    index++;
            //}
        }

        private void SaveMonitorInfo()
        {
            //ConfigUtility.Save(_monitorInfo, _configDirPath + _monitorInfo.name + ".json");
        }

        private void dgv_Show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = this.dgv_Show.CurrentRow.Index;

        }

        private void button_SetInterval_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_GetInterval.Text))
            {
                MessageBox.Show("请输入采集间隔", "提示");
                return;
            }
            if (!int.TryParse(textBox_GetInterval.Text,out int interval))
            {
                MessageBox.Show("请输入正确的采集间隔", "提示");
                return;
            }
            if (interval<500)
            {
                MessageBox.Show("采集间隔不能小于500毫秒", "提示");
                return;
            }
            GetInterval = interval;
        }
    }
}
