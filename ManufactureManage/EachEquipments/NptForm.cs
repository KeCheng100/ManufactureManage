using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManufactureManage.EachEquipments
{
    public partial class NptForm : Form
    {
        public NptForm()
        {
            InitializeComponent();
            this.Deactivate += new EventHandler(NptForm_Deactivate);
        }

        private void NptForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
