using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ManufactureManage.PLC.HuiChuan.HcType;

namespace ManufactureManage.PLC.HuiChuan
{
    

    public class InovanceH3U : IPlcFunBase
    {
        #region 成员和属性
        private readonly ILog _log = LogManager.GetLogger(nameof(InovanceH3U));
        private readonly int NetID = 0;
        #endregion


        public ResultCode Init(string Ip, int Port,int netId)
        {
            bool result = HCdll.Init_ETH_String(Ip, NetID, Port);
            if (result)
                return ResultCode.Success;
            else
                return ResultCode.HcPlcInitFail;
        }

        public void Dispose()
        {
            HCdll.Exit_ETH(NetID);
        }

        public ResultCode Write_M(int Address, bool value)
        {
            _log.Fatal($"写地址(M区)：{Address}  值：{value}");
            byte[] pValue = new byte[1] { (byte)(value ? 1 : 0) };
            int ret = HCdll.H3u_Write_Soft_Elem(HcType.SoftElemType.REGI_H3U_M, Address, 1, pValue, NetID);
            if (ret == 1)
                return ResultCode.Success;
            else
            {
                _log.Error($"汇川PLC写 M 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcWrMFail;
            }
        }

        public ResultCode Read_M(int Address, out bool value)
        {

            byte[] pValue = new byte[8];
            int ret = HCdll.H3u_Read_Soft_Elem(HcType.SoftElemType.REGI_H3U_M, Address, 1, pValue, NetID);
            if (ret == 1)
            {
                value = (pValue[0] == 1 ? true : false);
                return ResultCode.Success;
            }
            else
            {
                value = false;
                _log.Error($"汇川PLC读 M 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcRdMFail;
            }
        }

        public ResultCode Write_D(int Address, short value)
        {
            _log.Fatal($"写地址(D区)：{Address}  值：{value}");
            byte[] pValue = BitConverter.GetBytes(value);

            int ret = HCdll.H3u_Write_Soft_Elem(SoftElemType.REGI_H3U_DW, Address, 1, pValue, NetID);
            if (ret == 1)
                return ResultCode.Success;
            else
            {
                _log.Error($"汇川PLC写 D 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcWrDFail;
            }

        }

        public ResultCode Read_D(int Address, out short value)
        {
            byte[] pValue = new byte[4];//缓冲区
            int ret = HCdll.H3u_Read_Soft_Elem(SoftElemType.REGI_H3U_DW, Address, 2, pValue, NetID);
            if (ret == 1)
            {
                value = BitConverter.ToInt16(pValue, 0);
                return ResultCode.Success;
            }
            else
            {
                value = 0;
                _log.Error($"汇川PLC读 D 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcRdDFail;
            }
        }

        public ResultCode Write_D(int Address, float value)
        {
            _log.Fatal($"写地址(D区)：{Address}  值：{value}");
            byte[] pValue = BitConverter.GetBytes(value);
            int ret = HCdll.H3u_Write_Soft_Elem(SoftElemType.REGI_H3U_DW, Address, 2, pValue, NetID);
            if (ret == 1)
                return ResultCode.Success;
            else
            {
                _log.Error($"汇川PLC写 D 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcWrDFail;
            }
        }

        public ResultCode Read_D(int Address, out float value)
        {
            byte[] pValue = new byte[4];//缓冲区
            int ret = HCdll.H3u_Read_Soft_Elem(SoftElemType.REGI_H3U_DW, Address, 2, pValue, NetID);
            if (ret == 1)
            {
                value = BitConverter.ToSingle(pValue, 0);
                return ResultCode.Success;
            }
            else
            {
                value = 0;
                _log.Error($"汇川PLC读 D 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcRdDFail;
            }
        }

        public ResultCode Read_X(int Address, out bool value)
        {
            byte[] pValue = new byte[8];
            int ret = HCdll.H3u_Read_Soft_Elem(HcType.SoftElemType.REGI_H3U_X, Address, 1, pValue, NetID);
            if (ret == 1)
            {
                value = (pValue[0] == 1 ? true : false);
                return ResultCode.Success;
            }
            else
            {
                value = false;
                _log.Error($"汇川PLC读 X 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcRdMFail;
            }
        }

        public ResultCode Read_Y(int Address, out bool value)
        {
            byte[] pValue = new byte[8];
            int ret = HCdll.H3u_Read_Soft_Elem(HcType.SoftElemType.REGI_H3U_Y, Address, 1, pValue, NetID);
            if (ret == 1)
            {
                value = (pValue[0] == 1 ? true : false);
                return ResultCode.Success;
            }
            else
            {
                value = false;
                _log.Error($"汇川PLC读 Y 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcRdMFail;
            }
        }
    }

    public class InovanceH5U : IPlcFunBase
    {
        #region 成员和属性
        private readonly ILog _log = LogManager.GetLogger(nameof(InovanceH5U));
        private  int NetID = 0;
        #endregion


        public ResultCode Init(string Ip, int Port, int netId)
        {
            NetID = netId;
            bool result = HCdll.Init_ETH_String(Ip, NetID, Port);
            if (result)
                return ResultCode.Success;
            else
            {
                Thread.Sleep(50);
                result = HCdll.Init_ETH_String(Ip, NetID, Port);
                if (result)
                    return ResultCode.Success;
                else
                    return ResultCode.HcPlcInitFail;
            }

        }

        public void Dispose()
        {
            HCdll.Exit_ETH(NetID);
        }


        public ResultCode Write_M(int Address, bool value)
        {
            _log.Fatal($"写地址(M区)：{Address}  值：{value}");
            byte[] pValue = new byte[1] { (byte)(value ? 1 : 0) };
            int ret = HCdll.H5u_Write_Soft_Elem(HcType.SoftElemType.REGI_H5U_M, Address, 1, pValue, NetID);
            if (ret == 1)
                return ResultCode.Success;
            else
            {
                _log.Error($"汇川PLC写 M 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcWrMFail;
            }
        }

        public ResultCode Read_M(int Address, out bool value)
        {

            byte[] pValue = new byte[8];
            int ret = HCdll.H5u_Read_Soft_Elem(HcType.SoftElemType.REGI_H5U_M, Address, 1, pValue, NetID);
            if (ret == 1)
            {
                value = (pValue[0] == 1 ? true : false);
                return ResultCode.Success;
            }
            else
            {
                value = false;
                _log.Error($"汇川PLC读 M 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcRdMFail;
            }
        }

        public ResultCode Write_D(int Address, float value)
        {
            _log.Fatal($"写地址(D区)：{Address}  值：{value}");
            byte[] pValue = BitConverter.GetBytes(value);
            int ret = HCdll.H5u_Write_Soft_Elem(SoftElemType.REGI_H5U_D, Address, 2, pValue, NetID);
            if (ret == 1)
                return ResultCode.Success;
            else
            {
                _log.Error($"汇川PLC写 D 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcWrDFail;
            }

        }

        public ResultCode Read_D(int Address, out float value)
        {
            byte[] pValue = new byte[4];//缓冲区
            int ret = HCdll.H5u_Read_Soft_Elem(SoftElemType.REGI_H5U_D, Address, 2, pValue, NetID);
            if (ret == 1)
            {
                value = BitConverter.ToSingle(pValue, 0);
                return ResultCode.Success;
            }
            else
            {
                value = 0;
                _log.Error($"汇川PLC读 D 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcRdDFail;
            }
        }

        public ResultCode Write_D(int Address, short value)
        {
            throw new NotImplementedException();
        }

        public ResultCode Read_D(int Address, out short value)
        {
            throw new NotImplementedException();
        }

        public ResultCode Read_X(int Address,out bool value)
        {
            byte[] pValue = new byte[8];
            int ret = HCdll.H5u_Read_Soft_Elem(HcType.SoftElemType.REGI_H5U_X, Address, 1, pValue, NetID);
            if (ret == 1)
            {
                value = (pValue[0] == 1 ? true : false);
                return ResultCode.Success;
            }
            else
            {
                value = false;
                _log.Error($"汇川PLC读 X 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcRdMFail;
            }
        }
        public ResultCode Read_Y(int Address, out bool value)
        {
            byte[] pValue = new byte[8];
            int ret = HCdll.H5u_Read_Soft_Elem(HcType.SoftElemType.REGI_H5U_Y, Address, 1, pValue, NetID);
            if (ret == 1)
            {
                value = (pValue[0] == 1 ? true : false);
                return ResultCode.Success;
            }
            else
            {
                value = false;
                _log.Error($"汇川PLC读 Y 区失败，错误代码：{(HcErrorCode)(ret)}");
                return ResultCode.HcPlcRdMFail;
            }
        }
    }
}
