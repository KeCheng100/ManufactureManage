using HZH_Controls;
using log4net;
using ManufactureManage.Config;
using ManufactureManage.DataBase;
using ManufactureManage.EachEquipments;
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
    public partial class MonitorForm3 : Form
    {
        public MonitorForm3()
        {
            InitializeComponent();
            x = this.Width;
            y = this.Height;
            SetTag(this);
        }

        private readonly ILog _log = LogManager.GetLogger(nameof(MonitorForm3));
        private CancellationTokenSource _cts;
        SystemConfig _systemConfig = new SystemConfig();

        #region privatefuncs

        private void qw(int deviceNo)
        {
            int[] PLCID = new int[3];
            string connectStr = _systemConfig._ConnectStr;
            string tableName = _systemConfig._TableNameCurrent;
            string queryCmd = string.Empty;

            ResultCode resultCode = ResultCode.Failed;
            DataTable dataTable = new DataTable();
            queryCmd = $"SELECT * FROM {tableName} " +
                       $"WHERE DeviceNO = 00013 and PLCID BETWEEN '17' AND '20' " +
                       $"ORDER BY PLCID;";
            resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);

            for (int i = 0; i < 3; i++)
            {
                if (dataTable.Rows[i]["Value_1"].ToString() == "1;")
                {
                    PLCID[i] = dataTable.Rows[i]["PLCID"].ToInt();
                }
                else
                    PLCID[i] = 0;
            }
            for (int i = 3; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["Value_1"].ToString() == "1;")
                {
                    //MessageBox.Show("提示","报警明细："+ dataTable.Rows[i]["messageinfo"].ToString()) ;
                }
            }

            //if (PLCID[0] == 17)
            //{
            //    label1.BackColor = Color.Yellow;
            //}
            //else
            //{
            //    label1.BackColor = Color.Gray;
            //}
            //if (PLCID[1] == 18)
            //{
            //    label2.BackColor = Color.Green;
            //}
            //else
            //{
            //    label2.BackColor = Color.Gray;
            //}
            //if (PLCID[2] == 19)
            //{
            //    label3.BackColor = Color.Red;
            //}
            //else
            //{
            //    label3.BackColor = Color.Gray;
            //}
        }
        #endregion

        #region 控件大小随窗体大小等比例缩放
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度
        private void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    SetTag(con);
                }
            }
        }
        private void SetControls(float newx, float newy, Control cons)
        {
            try
            {
                //遍历窗体中的控件，重新设置控件的值
                foreach (Control con in cons.Controls)
                {
                    //获取控件的Tag属性值，并分割后存储字符串数组
                    if (con.Tag != null)
                    {
                        string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                        //根据窗体缩放的比例确定控件的值
                        con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                        con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                        con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                        con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                        Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                        if(currentSize <= 0)
                        {
                            continue;                      
                        }
                        con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                        if (con.Controls.Count > 0)
                        {
                            SetControls(newx, newy, con);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void MonitorForm3_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            SetControls(newx, newy, this);
        }
        #endregion

        #region Hover
        private void Panel_CarrierTest_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_CarrierTest, "载波测试设备");
        }

        private void Panel_Nanmeplate_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_Nanmeplate, "下铭牌及电子标签贴检设备");
        }
        private void Panel_AutoSort_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_AutoSort, "自动排序设备");
        }

        private void Panel_ParaSet_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_ParaSet, "6表位参数设置设备");
        }

        private void Panel_Pack12_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_Pack12, "12表位功能测试设备");
        }

        private void Panel_ParaCmp_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_ParaCmp, "6表位出厂参数比对设备");
        }

        private void Panel_HitScrew_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_HitScrew, "打螺丝设备");
        }

        private void Panel_InstallSeal_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_InstallSeal, "铅封安装雕刻设备");
        }

        private void Panel_Labeling_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_Labeling, "贴标设备");
        }

        private void Panel_CCD_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(Panel_CCD, "CCD外观检测设备");
        }
        #endregion

        #region Click
        private void Panel_CarrierTest_MouseClick(object sender, MouseEventArgs e)
        {
            CarrierTestForm form = new CarrierTestForm();
            form.Show();
        }

        private void Panel_Nanmeplate_MouseClick(object sender, MouseEventArgs e)
        {
            NptForm form = new NptForm();
            form.Show();
        }

        #endregion


    }
}
