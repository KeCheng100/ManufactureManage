using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufactureManage.PLC
{
    public interface IPlcCommOperate:IDisposable
    {
        ResultCode Write_M(int address, bool state);

        ResultCode Read_M(int address, out bool state);

        ResultCode Write_D(int address, short value);

        ResultCode Read_D(int address, out short value);

        ResultCode Write_D(int address, float value);

        ResultCode Read_D(int address, out float value);

        ResultCode Read_X(int Address, out bool value);
        ResultCode Read_Y(int Address, out bool value);
    }
}
