using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManufactureManage
{
    public partial class SelectPlanEditForm : Form
    {
        public SelectPlanEditForm()
        {
            InitializeComponent();
        }

        private void button_ParamSet_Click(object sender, EventArgs e)
        {
            string[] arg = new string[1];
            arg[0] = "10088";//工序标志
            StartProcess(@"C:\Users\lenovo\Desktop\临时文件程序\数据库方案测试\ElectricityMeterTest\ElectricityMeterTest\bin\Debug\ElectricityMeterTest.exe", arg);
        }

        public bool StartProcess(string filename, string[] args)
        {
            try
            {
                string s = "";
                foreach (string arg in args)
                {
                    s = s + arg + " ";
                }
                s = s.Trim();
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(filename, s);
                myprocess.StartInfo = startInfo;

                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("启动应用程序时出错！原因：" + ex.Message);
            }
            return false;
        }
    }
}
