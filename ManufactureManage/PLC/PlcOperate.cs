
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ManufactureManage.PLC.HuiChuan;
using static System.Windows.Forms.AxHost;
using ManufactureManage.Config;

namespace ManufactureManage.PLC
{
    public class PlcOperate 
    {
        #region 成员和属性
        private readonly ILog _log = LogManager.GetLogger(nameof(PlcOperate));
        private readonly object _disposingLock = new object();
        private PlcConfig _plcConfig;
        private IPlcFunBase _hcFuncBase;
        private bool isInit = false;

        #endregion

        #region 初始化和析构
        public ResultCode Init(PlcConfig config,int netId)
        {
            try
            {
                _plcConfig = config;

                switch (_plcConfig.PlcType)
                {
                    case 1:
                        _hcFuncBase = new InovanceH3U();
                        break;
                    case 2:
                        _hcFuncBase = new InovanceH5U();
                        break;
                    default:
                        break;
                }

                var ret = _hcFuncBase.Init(_plcConfig.IpAddress,502, netId);
                if (ret==ResultCode.Success)
                    isInit = true;
                else
                    isInit = false;
                return ret;
            }
            catch (Exception ex)
            {
                _log.Error($"PLC操作实例初始化失败： {ex.Message}");
                isInit = false;
                return ResultCode.Failed;
            }
        }
        public bool IsInitSuccess()
        {
            return isInit;
        }

        ~PlcOperate()
        {
            Dispose();
        }
        public void Dispose()
        {
            lock (_disposingLock)
            {
                if (_hcFuncBase != null)
                    _hcFuncBase.Dispose();
            }
        }



        #endregion

        #region 接口函数
        public ResultCode ToPlc_AutoOrManual(bool state)
        {
            if (!isInit)
                return ResultCode.PlcNotInited;
            ResultCode result = _hcFuncBase.Write_M(100, state);
            if (result!=ResultCode.Success)
                return result;
            return _hcFuncBase.Write_M(101, !state);
        }

        public ResultCode Write_M(int address, bool state)
        {
            if (!isInit)
                return ResultCode.PlcNotInited;
            return _hcFuncBase.Write_M(address, state);
        }

        public ResultCode Read_M(int address, out bool state)
        {
            state = false;
            if (!isInit)
                return ResultCode.PlcNotInited;
            return _hcFuncBase.Read_M(address,out state);
        }

        public ResultCode Write_D(int address, short value)
        {
            if (!isInit)
                return ResultCode.PlcNotInited;
            return _hcFuncBase.Write_D(address, value);
        }

        public ResultCode Read_D(int address, out short value)
        {
            value = 0;
            if (!isInit)
                return ResultCode.PlcNotInited;
            return _hcFuncBase.Read_D(address, out value);
        }

        public ResultCode Write_D(int address, float value)
        {
            if (!isInit)
                return ResultCode.PlcNotInited;
            return _hcFuncBase.Write_D(address, value);
        }

        public ResultCode Read_D(int address, out float value)
        {
            value = 0;
            if (!isInit)
                return ResultCode.PlcNotInited;
            return _hcFuncBase.Read_D(address, out value);
        }

        public ResultCode Read_X(int Address, out bool value)
        {
            value = false;
            if (!isInit)
                return ResultCode.PlcNotInited;
            return _hcFuncBase.Read_X(Address, out value);
        }

        public ResultCode Read_Y(int Address, out bool value)
        {
            value = false;
            if (!isInit)
                return ResultCode.PlcNotInited;
            return _hcFuncBase.Read_Y(Address, out value);
        }


        #endregion







    }
}
