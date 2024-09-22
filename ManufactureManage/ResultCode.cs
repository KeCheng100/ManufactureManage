using System.ComponentModel;

namespace ManufactureManage
{
    public enum ResultCode
    {
        [Description("成功")]
        Success = 0,
        [Description("失败")]
        Failed = -1,
        [Description("系统错误")]
        SystemError = -2,
        [Description("用户取消操作")]
        UserCanceled = 1,
        [Description("设备没有准备好")]
        DeviceNotReady = 11,
        [Description("轴没有准备好")]
        AxisNotReady = 12,
        [Description("板卡已经关闭")]
        MCIsClosed = 13,
        [Description("配置文件异常")]
        ConfigFileError = 14,
        [Description("运控板卡枚举失败")]
        MCEnumError = 15,
        [Description("运控板卡打开失败")]
        MCOpenError = 16,
        [Description("运控板卡存在错误")]
        MCExistsError = 17,
        [Description("轴打开失败")]
        AxisOpenFailed = 20,
        [Description("轴伺服使能失败")]
        AxisSvOnOffFailed = 21,
        [Description("轴复位失败")]
        AxisResetFailed = 22,
        [Description("加载板卡配置文件失败")]
        MCConfigLoadingError = 23,
        [Description("加载轴配置文件失败")]
        AxisConfigLoadingError = 24,
        [Description("板卡配置文件不存在")]
        MCConfigFileNotExists = 25,
        [Description("板卡导入配置文件失败")]
        MCDownloadConfigFileError = 26,
        [Description("加载主站配置文件失败")]
        MasterConfigLoadingError = 27,
        [Description("加载从站数据地址失败")]
        SlaveAddressLoadError = 28,
        [Description("轴运动失败")]
        AxisMotionFailed = 100,
        [Description("轴停止失败")]
        AxisStopFailed = 101,
        [Description("轴回零失败")]
        AxisHomeFailed = 102,
        [Description("轴访问停止原因失败")]
        AxisAccessStopReasonFailed = 103,
        [Description("轴运动超时")]
        AxisMotionTimeout = 104,
        [Description("轴清除错误代码失败")]
        AxisClearErrCodeFailed = 105,
        [Description("轴回零失败, 需要重新加电才可回零")]
        AxisHomeFailedNeedReboot = 106,
        [Description("轴回零失败, 当前正在回零")]
        AxisHomeFailedForIsHoming = 107,
        [Description("轴设置使能失败")]
        AxisSetSevonFailed = 108,
        [Description("轴运动失败, 未移动到指定的位置")]
        AxisMotionFailedNotInTargetPosition = 109,
        [Description("设置命令位置失败")]
        AxisSetCmdPositionFailed = 110,
        [Description("设置实际位置(编码器位置)失败")]
        AxisSetEncoderPositionFailed = 111,
        [Description("GetNodeOdFailed")]
        GetNodeOdFailed = 112,
        [Description("获取命令位置失败")]
        GetPositionUnitFailed = 113,
        [Description("获取实际位置(编码器位置)失败")]
        GetEncoderUnitFailed = 114,
        [Description("轴配置失败")]
        AxisConfigFailed = 115,
        [Description("IO读写失败")]
        MCIOWRFailed = 200,
        [Description("IO配置读取失败")]
        MCIOConfigError = 201,
        [Description("IO观测超时")]
        IOObserveTimeout = 202,
        [Description("已存在任务")]
        ExecutionAlreadyExists = 300,
        [Description("任务正在执行中")]
        ExecutionIsRunning = 301,
        [Description("任务当前状态不允许")]
        ExecutionStatesNotAllowed = 302,
        [Description("未找到相机")]
        CameraNotFound = 401,
        [Description("枚举相机失败")]
        CameraEnumError = 402,
        [Description("打开相机失败")]
        CameraOpenFailed = 403,
        [Description("运动异常")]
        MotionException = 500,
        [Description("运动失败, 坐标超过允许的范围")]
        MotionFailedOutOfRange = 501,
        [Description("测量失败")]
        MeasuringFailed = 600,
        [Description("测量失败, 未找到有效的值")]
        MeasuringFailedWithoutResult = 601,
        [Description("图像匹配失败")]
        ImageMatchingFailed = 602,
        [Description("任务不存在")]
        JobIdNotExists = 603,
        [Description("任务尚未完成")]
        JobNotFinish = 604,
        [Description("图像匹配失败,目标不存在")]
        ImageMatchingFailededTargetNotExists = 605,
        [Description("图像匹配失败,匹配结果异常")]
        ImageMatchingFailedResultInvalid = 606,
        [Description("图像匹配失败, 存在缺陷")]
        ImageMatchingFailedExistsDefect = 607,
        [Description("目录或文件不存在")]
        DirectoryOrFileNotExists = 700,
        [Description("目录或文件创建失败")]
        DirectoryOrFileCreateFailed = 701,
        [Description("报告生成失败")]
        ReportGeneratingFailed = 702,
        [Description("串口打开失败")]
        SerialPortOpenFailed = 800,
        [Description("串口设置失败")]
        SerialPortSetupFailed = 801,
        [Description("串口读超时")]
        SerialPortReadingTimeout = 802,
        [Description("串口读写失败")]
        SerialPortReadWriteFailed = 803,
        [Description("扫码枪写超时")]
        CodeScanWritingTimeout = 804,


        [Description("主站打开失败")]
        MasterOpenFailed = 900,
        [Description("DO读写失败")]
        MasterDOWRFailed = 1000,
        [Description("DI读写失败")]
        MasterAOWRFailed = 1001,

        [Description("Tcp配置载入失败")]
        TcpConfigLoadFailed = 1100,
        [Description("Tcp侦听连接失败")]
        TcpListenFailed = 1101,

        [Description("数据库配置载入失败")]
        DbConfigLoadFail = 1200,
        [Description("数据库模块参数错误")]
        DbParaError = 1201,
        [Description("数据库初始化失败")]
        DbInitFail = 1202,
        [Description("数据库运行命令错误")]
        DbRunCmdErr = 1203,
        [Description("数据库运行读取命令错误")]
        DbRunReadCmdErr = 1204,
        [Description("表位测试结果存入数据库错误")]
        MeterTestResultSaveErr = 1205,
        

        [Description("测试表位初始化失败")]
        MeterCellInitFail = 1300,
        [Description("表位屏蔽，不初始化")]
        MeterInitShield = 1301,
        [Description("表位管理模块初始化失败")]
        CellMgrInitFail = 1303,

        [Description("汇川PLC初始化失败")]
        HcPlcInitFail = 1400,
        [Description("汇川PLC_M区写失败")]
        HcPlcWrMFail = 1401,
        [Description("汇川PLC_M区读失败")]
        HcPlcRdMFail = 1402,
        [Description("汇川PLC_D区写失败")]
        HcPlcWrDFail = 1403,
        [Description("汇川PLC_D区读失败")]
        HcPlcRdDFail = 1404,
        [Description("汇川PLC未初始化")]
        PlcNotInited = 1405,


        [Description("蓝牙端口初始化失败")]
        BlueToothPortInitFail = 1450,
        [Description("Socket返回字节数错误")]
        SocketReceiceCntErr = 1451,
        [Description("读取温度失败")]
        ReadTempErr = 1452,
        [Description("客户端为null")]
        ClientIsNull = 1453,
        [Description("客户端掉线")]
        ClientIsOffLine = 1454,


    }
}
