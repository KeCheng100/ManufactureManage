using log4net;
using ManufactureManage.Config;
using ManufactureManage.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufactureManage
{
    public class SysMgr:IDisposable
    {
        #region 成员和属性
        private readonly ILog _logger = LogManager.GetLogger(nameof(SysMgr));
        private readonly object _disposingLock = new object();
        private static readonly object _syncRoot = new object();
        private bool _isDisposed = false;
        private readonly string _configDirPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Config\";

        public static SysMgr _sysMgr;

        /// <summary>
        /// 系统配置
        /// </summary>
        public SystemConfig systemConfig { get; set; }
        /// <summary>
        /// 数据库
        /// </summary>
        public SqlHelp sqlHelp { get; private set; }


        public FactorySettings SystemSettings { get; set; }
        #endregion

        #region 构造函数与析构函数
        public static SysMgr GetMgr()
        {
            lock (_syncRoot)
            {
                if (_sysMgr == null)
                    _sysMgr = new SysMgr();

                return _sysMgr;
            }
        }

        ~SysMgr()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (_disposingLock)
            {
                if (_isDisposed)
                    return;


                if (disposing)
                {

                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region 初始化
        public ResultCode Init()
        {
            try
            {

                sqlHelp = new SqlHelp();

                return ResultCode.Success;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return ResultCode.SystemError;
            }
        }
        #endregion

    }
}
