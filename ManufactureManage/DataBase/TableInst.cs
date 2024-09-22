using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufactureManage.DataBase
{
    /// <summary>
    /// 任务类
    /// </summary>
    public class T_Task
    {
        /// <summary>
        /// 任务状态  待下发/生产中/换线中
        /// </summary>
        public string TASK_STATE { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string PROVINCE { get; set; }
        /// <summary>
        /// 任务号
        /// </summary>
        public string TASK_ID { get; set; }
        /// <summary>
        /// PCB起始编号
        /// </summary>
        public string PCB_START { get; set; }
        /// <summary>
        /// PCB结束编号
        /// </summary>
        public string PCB_END { get; set; }

        /// <summary>
        /// 铭牌起始编号
        /// </summary>
        public string PLATE_START { get; set; }
        /// <summary>
        /// 铭牌结束编号
        /// </summary>
        public string PLATE_END { get; set; }

        /// <summary>
        /// 方案名称
        /// </summary>
        public string PLAN_NAME { get; set; }
        /// <summary>
        /// 目标生产总数
        /// </summary>
        public int ALL_CNT { get; set; }
        /// <summary>
        /// 已生产总数
        /// </summary>
        public int CPT_CNT { get; set; }
        /// <summary>
        /// 任务创建时间
        /// </summary>
        public DateTime CREATE_TIME { get; set; }
    }

   

    /// <summary>
    /// 线体方案类
    /// </summary>
    public class T_LinePlan
    {
        /// <summary>
        /// 省份
        /// </summary>
        public string PROVINCE { get; set; }
        /// <summary>
        /// 线体方案名称
        /// </summary>
        public string PLAN_NAME { get; set; }
        /// <summary>
        /// 载波方案名称
        /// </summary>
        public string CARRIER_PLAN_NAME { get; set; }
        /// <summary>
        /// 下铭牌方案名称
        /// </summary>
        public string INSERTPLATE_PLAN_NAME { get; set; }
        /// <summary>
        /// 设参方案名称
        /// </summary>
        public string SETPARAM_PLAN_NAME { get; set; }
        /// <summary>
        /// 包装12表位方案名称
        /// </summary>
        public string PACK12_PLAN_NAME { get; set; }
        /// <summary>
        /// 比参方案名称
        /// </summary>
        public string CMPPARAM_PLAN_NAME { get; set; }
        /// <summary>
        /// 贴标方案名称
        /// </summary>
        public string PASTELABEL_PLAN_NAME { get; set; }
        /// <summary>
        /// 排序方案名称
        /// </summary>
        public string SORT_PLAN_NAME { get; set; }
        /// <summary>
        /// 手动装箱方案名称
        /// </summary>
        public string MANUALPACK_PLAN_NAME { get; set; }
        /// <summary>
        /// 射频门方案名称
        /// </summary>
        public string RFIDDOOR_PLAN_NAME { get; set; }

    }

    /// <summary>
    /// 绑定关系
    /// </summary>
    public class T_BindRelation
    {
        /// <summary>
        /// PCB条码
        /// </summary>
        public string PCBCODE { get; set; }
        /// <summary>
        /// 铭牌条码
        /// </summary>
        public string NAMEPLATECODE { get; set; }
        /// <summary>
        /// 模块条码
        /// </summary>
        public string MODULECODE { get; set; }
        /// <summary>
        /// 箱条码
        /// </summary>
        public string BOXNO { get; set; }
    }


    /// <summary>
    /// 任务明细类
    /// </summary>
    public class T_TaskDetail
    {
        public string TASK_ID { get; set; }

        public string PCBCODE { get; set; }

        public string NAMEPLATECODE { get; set; }

        public string OF_MAILADDRESS { get; set; }

        public string MODULE_CODE { get; set; }

        public string RFID_CODE { get; set; }

        public string BOX_CODE { get; set; }

        public string MODULE_RESULT { get; set; }

        public string MODULE_TIME { get; set; }

        public string INPLATE_RESULT { get; set; }

        public string INPLATE_TIME { get; set; }

        public string PARAMSET_RESULT { get; set; }

        public string PARAMSET_TIME { get; set; }

        public string PACKCLR_RESULT { get; set; }

        public string PACKCLR_TIME { get; set; }

        public string PARAMCMP_RESULT { get; set; }

        public string PARAMCMP_TIME { get; set; }

        public string PASTELABEL_RESULT { get; set; }

        public string PASTELABEL_TIME { get; set; }

        public string RFIDDOOR_RESULT { get; set; }

        public string RFIDDOOR_TIME { get; set; }
    }

    /// <summary>
    /// 载波测试
    /// </summary>
    public class T_ModuleTest
    {
        /// <summary>
        /// 上传时间
        /// </summary>
        public string UploadTime { get; set; }
        /// <summary>
        /// 分发时间，从中间数据库传到管理库的时间
        /// </summary>
        public string DtbTime { get; set; }
        /// <summary>
        /// 测试表位
        /// </summary>
        public string TestCell { get; set; }
        /// <summary>
        /// 通信地址
        /// </summary>
        public string MailAddress { get; set; }
        /// <summary>
        /// 测试结果 OK/NG
        /// </summary>
        public string TestResult { get; set; }
        /// <summary>
        /// 测试小项名称
        /// </summary>
        public string FailItemName { get; set; }
        /// <summary>
        /// 测试小项结果
        /// </summary>
        public string FailItemDescribe { get; set; }

        
    }

    /// <summary>
    /// 下铭牌
    /// </summary>
    public class T_InsertPlate
    {
        /// <summary>
        /// 上传时间
        /// </summary>
        public string UploadTime { get; set; }
        /// <summary>
        /// 分发时间，从中间数据库传到管理库的时间
        /// </summary>
        public string DtbTime { get; set; }
        /// <summary>
        /// 铭牌条码
        /// </summary>
        public string NamePlateCode { get; set; }
        /// <summary>
        /// 射频码
        /// </summary>
        public string RfidCode { get; set; }
    }

    /// <summary>
    /// 参数设置
    /// </summary>
    public class T_SetParam
    {
        /// <summary>
        /// 上传时间
        /// </summary>
        public string UploadTime { get; set; }
        /// <summary>
        /// 分发时间，从中间数据库传到管理库的时间
        /// </summary>
        public string DtbTime { get; set; }
        /// <summary>
        /// 测试表位
        /// </summary>
        public string TestCell { get; set; }
        /// <summary>
        /// 通信地址
        /// </summary>
        public string OldMailAddress { get; set; }
        /// <summary>
        /// 通信地址
        /// </summary>
        public string NewMailAddress { get; set; }
        /// <summary>
        /// 铭牌条码
        /// </summary>
        public string NamePlateCode { get; set; }
        /// <summary>
        /// 软件备案号
        /// </summary>
        public string SoftwareVersion { get; set; }
        /// <summary>
        /// 表号
        /// </summary>
        public string MeterNo { get; set; }
        /// <summary>
        /// 资产管理编码
        /// </summary>
        public string AssertCode { get; set; }
        /// <summary>
        /// 测试结果 OK/NG
        /// </summary>
        public string TestResult { get; set; }
        /// <summary>
        /// 测试小项名称
        /// </summary>
        public string FailItemName { get; set; }
        /// <summary>
        /// 测试小项结果
        /// </summary>
        public string FailItemDescribe { get; set; }
    }

    /// <summary>
    /// 包装12表位
    /// </summary>
    public class T_Pack12
    {
        /// <summary>
        /// 上传时间
        /// </summary>
        public string UploadTime { get; set; }
        /// <summary>
        /// 分发时间，从中间数据库传到管理库的时间
        /// </summary>
        public string DtbTime { get; set; }
        /// <summary>
        /// 测试表位
        /// </summary>
        public string TestCell { get; set; }
        /// <summary>
        /// 通信地址
        /// </summary>
        public string MailAddress { get; set; }
        /// <summary>
        /// 测试结果 OK/NG
        /// </summary>
        public string TestResult { get; set; }
        /// <summary>
        /// 测试小项名称
        /// </summary>
        public string FailItemName { get; set; }
        /// <summary>
        /// 测试小项结果
        /// </summary>
        public string FailItemDescribe { get; set; }
    }

    /// <summary>
    /// 参数比对
    /// </summary>
    public class T_CmpParam
    {
        /// <summary>
        /// 上传时间
        /// </summary>
        public string UploadTime { get; set; }
        /// <summary>
        /// 分发时间，从中间数据库传到管理库的时间
        /// </summary>
        public string DtbTime { get; set; }
        /// <summary>
        /// 测试表位
        /// </summary>
        public string TestCell { get; set; }
        /// <summary>
        /// 通信地址
        /// </summary>
        public string MailAddress { get; set; }
        /// <summary>
        /// 铭牌条码
        /// </summary>
        public string NamePlateCode { get; set; }
        /// <summary>
        /// 模块条码
        /// </summary>
        public string ModuleCode { get; set; }
        /// <summary>
        /// 测试结果 OK/NG
        /// </summary>
        public string TestResult { get; set; }
        /// <summary>
        /// 测试小项名称
        /// </summary>
        public string FailItemName { get; set; }
        /// <summary>
        /// 测试小项结果
        /// </summary>
        public string FailItemDescribe { get; set; }
    }

    /// <summary>
    /// 包装贴标，贴合格证
    /// </summary>
    public class T_PasteLabel
    {
        /// <summary>
        /// 上传时间
        /// </summary>
        public string UploadTime { get; set; }
        /// <summary>
        /// 分发时间，从中间数据库传到管理库的时间
        /// </summary>
        public string DtbTime { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string NamePlateCode { get; set; }
    }

    /// <summary>
    /// 射频门
    /// </summary>
    public class T_RfidDoor
    {
        /// <summary>
        /// 上传时间
        /// </summary>
        public string UploadTime { get; set; }
        /// <summary>
        /// 分发时间，从中间数据库传到管理库的时间
        /// </summary>
        public string DtbTime { get; set; }
        /// <summary>
        /// 箱条码
        /// </summary>
        public string BoxCode { get; set; }
        /// <summary>
        /// 箱号，属于第几箱
        /// </summary>
        public string BoxNumber { get; set; }
        /// <summary>
        /// 箱内射频码
        /// </summary>
        public string InnerRfidCodes { get; set; }
    }

}
