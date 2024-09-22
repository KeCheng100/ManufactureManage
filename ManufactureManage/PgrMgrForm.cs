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
    public partial class PgrMgrForm : Form
    {
        public PgrMgrForm()
        {
            InitializeComponent();
        }

        private void button_CratBtnTb_Click(object sender, EventArgs e)
        {
            SysMgr.GetMgr().sqlHelp.CreateBtnTbs();
        }

        private void Btn_SqlSet_Click(object sender, EventArgs e)
        {

        }
    }
}
