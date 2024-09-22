using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufactureManage.Config
{
    public class PlcConfig
    {
        /// <summary>
        /// PLC类型 1：汇川3U;2：汇川5U
        /// </summary>
        public int PlcType { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string IpAddress { get; set; } = "192.168.100.1";
    }
}
