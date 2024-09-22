using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManufactureManage.PLC;
using ManufactureManage.Config;

namespace ManufactureManage.PublicCtrl
{
    /// <summary>
    /// 设备状态
    /// </summary>
    public enum MachineState
    {
        Standby,
        Runing,
        Alarm,
        OffLine
    }

    public partial class EquipControl : UserControl
    {
        public EquipControl()
        {
            InitializeComponent();
        }


        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取当前设备的名称")]
        public string MachineName
        {
            get { return label_Name.Text; }
            set { label_Name.Text = value; }
        }

        private string ip = "192.168.1.88";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取PLC的IP")]
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private int port = 502;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取PLC的端口")]
        public int Port
        {
            get { return port; }
            set
            {
                if (value <= 0) return;
                port = value;
            }
        }

        private MachineState machineState = MachineState.OffLine;
        [Browsable(false)]
        [Category("自定义属性")]
        [Description("设置或获取PLC的状态")]
        public MachineState MachineState
        {
            get { return machineState; }
            private set
            {
                machineState = value;
                BeginInvoke(new Action(() =>
                {
                    switch (machineState)
                    {
                        case MachineState.Standby:
                            if (pictureBox_State.BackColor != Color.Yellow)
                            {
                                pictureBox_State.BackColor = Color.Yellow;
                                label_RunInfo.BackColor = Color.Yellow;
                                label_RunInfo.Text = "待机中...";
                            }

                            break;
                        case MachineState.Runing:
                            if (pictureBox_State.BackColor != Color.Green)
                            {
                                pictureBox_State.BackColor = Color.Green;
                                label_RunInfo.BackColor = Color.Green;
                                label_RunInfo.Text = "运行中...";
                            }
                            break;
                        case MachineState.Alarm:
                            if (pictureBox_State.BackColor != Color.Red)
                            {
                                pictureBox_State.BackColor = Color.Red;
                                label_RunInfo.BackColor = Color.Red;
                            }
                            break;
                        case MachineState.OffLine:
                            if (pictureBox_State.BackColor != SystemColors.ActiveBorder)
                            {
                                pictureBox_State.BackColor = SystemColors.ActiveBorder;
                                label_RunInfo.BackColor = SystemColors.ActiveBorder;
                                label_RunInfo.Text = "离线...";
                            }
                            break;
                        default:
                            break;
                    }
                }));
                
            }
        }

        [Description("通信标志")]
        public int NetId { get; set; } = 0;

        [Description("待机地址-黄灯")]
        public int StandbyReg { get; set; } = 10;

        [Description("运行地址-绿灯")]
        public int RuningReg { get; set; } = 11;

        [Description("告警地址-红灯")]
        public int AlarmReg { get; set; } = 12;

        [Description("告警字典")]
        public Dictionary<int, string> AlarmDict { get; set; } = new Dictionary<int, string>();

        [Description("生产总数地址")]
        public int AllCntReg { get; set; }

        [Description("合格总数地址")]
        public int OkCntReg { get; set; }

        [Description("不合格总数地址")]
        public int NgCntReg { get; set; }



        private PlcOperate plcOperator;

        //连不上PLC表示离线
        /// <summary>
        /// 三次失败就判离线
        /// </summary>
        private int disConnectCnt = 0;


        /// <summary>
        /// 同步方法，主界面顺序调用
        /// </summary>
        public void DoWork()
        {
            if (plcOperator != null)
            {
                if (disConnectCnt <= 3)
                {
                    //查询本机状态
                    ResultCode resultCode1 = plcOperator.Read_Y(AlarmReg, out bool state);
                    if (resultCode1 == ResultCode.Success)
                    {
                        if (state)
                        {
                            if (MachineState != MachineState.Alarm)
                            {
                                MachineState = MachineState.Alarm;
                                //查询具体报警原因
                                foreach (var item in AlarmDict)
                                {
                                    resultCode1 = plcOperator.Read_M(item.Key, out bool alarmState);
                                    if (resultCode1 == ResultCode.Success)
                                    {
                                        if (alarmState)
                                        {
                                            string alarmContent = item.Value;
                                            MachineName += $" {alarmContent}";
                                        }
                                    }
                                    else
                                    {
                                        disConnectCnt++;
                                    }
                                }
                            }
                            
                        }
                        else
                        {
                            resultCode1 = plcOperator.Read_Y(RuningReg, out state);
                            if (resultCode1 == ResultCode.Success)
                            {
                                if (state)
                                {
                                    if (MachineState != MachineState.Runing)
                                    {
                                        MachineState = MachineState.Runing;
                                    }
                                }
                                else
                                {
                                    resultCode1 = plcOperator.Read_Y(StandbyReg, out state);
                                    if (resultCode1 == ResultCode.Success)
                                    {
                                        if (state)
                                        {
                                            if (MachineState != MachineState.Standby)
                                            {
                                                MachineState = MachineState.Standby;
                                            } 
                                        }
                                        else
                                        {
                                            MachineState = MachineState.OffLine;
                                        }
                                    }
                                    else
                                    {
                                        disConnectCnt++;
                                    }
                                }
                            }
                            else
                            {
                                disConnectCnt++;
                            }
                        }

                        ////查询附属线体状态
                        //foreach (var item in FlowControls)
                        //{
                        //    int stateAddress = Convert.ToInt32(item.StateAddress);
                        //    ResultCode resultCode = plcOperator.Read_M(stateAddress, out bool lineState);
                        //    if (resultCode == ResultCode.Success)
                        //    {
                        //        if (item.IsActive != lineState)
                        //        {
                        //            item.IsActive = lineState;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        disConnectCnt++;
                        //    }
                        //}
                    }
                    else
                    {
                        disConnectCnt++;
                    }
                }
                else
                {
                    plcOperator.Dispose();
                    plcOperator = null;
                    plcOperator = new PlcOperate();
                    ResultCode resultCode = plcOperator.Init(new PlcConfig() { PlcType = 2, IpAddress = IP },NetId);
                    if (resultCode == ResultCode.Success)
                    {
                        disConnectCnt = 0;
                    }
                    MachineState = MachineState.OffLine;
                }
            }
            else
            {
                plcOperator = new PlcOperate();
                ResultCode resultCode = plcOperator.Init(new PlcConfig() { PlcType = 2, IpAddress = IP },NetId);
                disConnectCnt = resultCode == ResultCode.Success ? 0 : 4;
            }

        }



    }
}
