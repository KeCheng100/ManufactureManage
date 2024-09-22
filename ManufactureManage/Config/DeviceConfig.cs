using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufactureManage.Config
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SystemConfig
    {
        public string _ConnectStr { get; set; } = "Server=192.168.1.50; Port=3306; User=mtmgruser; Password=htll1234; database= mtlinemgr; SslMode=None; Allow User Variables=true;";

        public string _ConnectStrWithoutDb { get; set; } = "Server=192.168.1.50; Port=3306; User=mtmgruser; Password=htll1234; SslMode=None; Allow User Variables=true;";

        public string _DatabaseName { get; set; } = "mtlinemgr";

        public string _ConnectStrHistory { get; set; } = "Server=localhost; Port=3306; User=root; Password=admin123; database= htll_mtlinemgr; SslMode=None; Allow User Variables=true;";
        public string _TableNameHistory { get; set; } = "plc_historicstate";
        public string _TableNameCurrent { get; set; } = "plc_currentstate";
    }
}
