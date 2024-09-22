using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufactureManage.PLC
{
    interface IPlcFunBase:IDisposable
    {
        ResultCode Init(string Ip, int Port,int netID);

        ResultCode Write_M(int Address, bool value);

        ResultCode Read_M(int Address, out bool value);

        ResultCode Write_D(int Address, short value);

        ResultCode Read_D(int Address, out short value);

        ResultCode Write_D(int Address, float value);

        ResultCode Read_D(int Address, out float value);
        ResultCode Read_X(int Address, out bool value);
        ResultCode Read_Y(int Address, out bool value);


    }
}
