using ManufactureManage.LogSys;
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
    public partial class RunLogForm : Form
    {
        public RunLogForm()
        {
            InitializeComponent();
        }
        private LogMgr _logMgr;

        private void RunLogForm_Load(object sender, EventArgs e)
        {
            try
            {
                _logMgr = new LogMgr();
                _logMgr.Init();
                _logMgr.LogEvent += str =>
                {
                    BeginInvoke(new Action<string>(txt =>
                    {
                        string headerString = txt.Substring(0, 18);
                        if (headerString.Contains("INFO"))
                        {
                            richTextBox_RunLog.AppendText(txt, Color.Blue);
                            
                        }
                        else if (headerString.Contains("FATAL"))
                        {
                            richTextBox_RunLog.AppendText(txt, Color.Black);
                        }
                        else
                        {
                            richTextBox_RunLog.AppendText(txt, Color.Red);
                        }

                    }), str);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("日志组件初始化异常：" + ex.ToString(), "注意");
            }
        }
    }
}
