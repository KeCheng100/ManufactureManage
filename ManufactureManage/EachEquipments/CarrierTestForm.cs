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
    public partial class CarrierTestForm : Form
    {
        public CarrierTestForm()
        {
            InitializeComponent();
            this.Deactivate += new EventHandler(CarrierTestForm_Deactivate);
        }

        private void CarrierTestForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
