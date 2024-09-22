using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManufactureManage.DataBase
{
    public class MySqlHelp
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(MySqlHelp));

        /// <summary>
        /// 运行一个读取命令
        /// </summary>
        /// <param name="connectStr"></param>
        /// <param name="cmdStr"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static ResultCode RunReadCmd(string connectStr, string cmdStr, out DataTable dataTable)
        {
            try
            {
                using (MySqlConnection mysqlcon = new MySqlConnection())
                {
                    mysqlcon.ConnectionString = connectStr;
                    mysqlcon.Open();
                    using (MySqlDataAdapter cmd = new MySqlDataAdapter(cmdStr, mysqlcon))
                    {
                        dataTable = new DataTable();
                        try
                        {
                            cmd.Fill(dataTable);
                            mysqlcon.Close();
                            return ResultCode.Success;
                        }
                        catch (Exception ex)
                        {
                            _log.Error($"数据库运行读取命令错误:  {ex.Message}");
                            mysqlcon.Close();
                            return ResultCode.DbRunReadCmdErr;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dataTable = new DataTable();
                _log.Error($"数据库运行读取命令错误:  {ex.Message}");
                return ResultCode.DbRunReadCmdErr;
            }
        }

        /// <summary>
        /// 运行一条插入、删除、更新语句
        /// </summary>
        /// <param name="connectStr"></param>
        /// <param name="cmdStr"></param>
        /// <returns></returns>
        public static ResultCode RunCmd(string connectStr, string cmdStr)
        {
            try
            {
                using (MySqlConnection mysqlcon = new MySqlConnection())
                {
                    mysqlcon.ConnectionString = connectStr;
                    mysqlcon.Open();
                    using (MySqlCommand cmd = new MySqlCommand(cmdStr, mysqlcon))
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            mysqlcon.Close();
                            return ResultCode.Success;
                        }
                        catch (Exception ex)
                        {
                            _log.Error($"数据库运行命令错误: {ex.Message}");
                            mysqlcon.Close();
                            return ResultCode.DbRunCmdErr;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error($"数据库运行命令错误: {ex.Message}");
                return ResultCode.DbRunCmdErr;
            }
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="connectStr"></param>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public static ResultCode CreateDataBase(string connectStr, string dataBaseName)
        {
            try
            {
                if (!IsDbExist(connectStr, dataBaseName))
                {
                    CreatNewMysqlDataBase(connectStr, dataBaseName);
                }
                return ResultCode.Success;
            }
            catch (Exception ex)
            {
                _log.Error($"数据库 {dataBaseName} 创建失败： {ex.Message}");
                return ResultCode.DbInitFail;
            }
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="connectStr"></param>
        /// <param name="dataBaseName"></param>
        /// <param name="tableName"></param>
        /// <param name="tableItem"></param>
        /// <returns></returns>
        public static ResultCode CreateTable(string connectStr, string dataBaseName, string tableName, object tableItem)
        {
            try
            {
                string dbConnectStr = connectStr + "database=" + dataBaseName + ";";
                if (!IsTableExist(connectStr, dataBaseName, tableName))
                {
                    CreatNewMysqlTable(dbConnectStr, tableName, tableItem);
                }
                return ResultCode.Success;
            }
            catch (Exception ex)
            {
                _log.Error($"数据表 {tableName} 创建失败： {ex.Message}");
                return ResultCode.DbInitFail;
            }
        }

        /// <summary>
        /// 创建表时插入taskID和pcbCode
        /// </summary>
        /// <param name="connectStr"></param>
        /// <param name="tableName"></param>
        /// <param name="taskId"></param>
        /// <param name="startPCB"></param>
        /// <param name="endPCB"></param>
        /// <returns></returns>
        public static ResultCode TransInsertPcbCode(string connectStr,string tableName,string taskId,string startPCB,string endPCB)
        {
            try
            {
                using (MySqlConnection mysqlcon = new MySqlConnection())
                {
                    mysqlcon.ConnectionString = connectStr;
                    mysqlcon.Open();
                    MySqlTransaction mySqlTransaction = mysqlcon.BeginTransaction();
                    int sCode = int.Parse(startPCB.Substring(6));
                    int eCode = int.Parse(endPCB.Substring(6));
                    for (int i = sCode; i <= eCode; i++)
                    {
                        string code = i.ToString().PadLeft(6, '0');
                        string insertStrCmd = $"insert into {tableName} (TASK_ID,PCBCODE) values ('{taskId}','{startPCB.Substring(0,6)}{code}');";
                        MySqlCommand cmd = new MySqlCommand(insertStrCmd, mysqlcon, mySqlTransaction);
                        cmd.ExecuteNonQuery();
                    }
                    mySqlTransaction.Commit();
                }
                return ResultCode.Success;
            }
            catch (Exception ex)
            {
                _log.Error($"数据库运行命令错误: {ex.Message}");
                return ResultCode.DbRunCmdErr;
            }
        }


        #region 数据库初始化
        /// <summary>
        /// 判断数据库是否存在
        /// </summary>
        /// <param name="DbName"></param>
        /// <returns></returns>
        private static bool IsDbExist(string CntStr, string DbName)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection())
            {
                bool isExist;
                mysqlcon.ConnectionString = CntStr;
                mysqlcon.Open();
                string strSql = string.Format("SELECT * FROM information_schema.SCHEMATA where SCHEMA_NAME='{0}'; ", DbName);
                MySqlDataAdapter adp = new MySqlDataAdapter(strSql, mysqlcon);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    isExist = true;
                else
                    isExist = false;
                mysqlcon.Close();
                return isExist;
            }
        }
        /// <summary>
        /// 新建一个数据库
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        private static bool CreatNewMysqlDataBase(string CntStr, string databaseName)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection())
            {

                mysqlcon.ConnectionString = CntStr;
                mysqlcon.Open();
                string createStatement = "create database " + databaseName + " charset utf8";
                using (MySqlCommand cmd = new MySqlCommand(createStatement, mysqlcon))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex);
                        return false;
                    }
                }

            }
        }
        /// <summary>
        /// 判断某个表是否存在
        /// </summary>
        /// <param name="dbname"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        private static bool IsTableExist(string CntStr, string dbname, string tablename)
        {

            using (MySqlConnection mysqlcon = new MySqlConnection())
            {
                bool isExist;
                mysqlcon.ConnectionString = CntStr;
                mysqlcon.Open();
                string strSql = string.Format("SELECT * FROM information_schema.TABLES where table_name='{0}' and TABLE_SCHEMA ='{1}';", tablename, dbname);
                MySqlDataAdapter adp = new MySqlDataAdapter(strSql, mysqlcon);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    isExist = true;
                else
                    isExist = false;
                mysqlcon.Close();
                return isExist;

            }
        }
        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="CntStr"></param>
        /// <param name="TBname"></param>
        /// <param name="Db"></param>
        /// <returns></returns>
        public static bool CreatNewMysqlTable(string CntStr, string TBname, object Db)
        {
            string tableElement = "";
            Type type = Db.GetType();
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance); //获取类中属性
            foreach (PropertyInfo p in props)
            {
                tableElement += (p.Name + " " + "CHAR(140)" + ", ");
            }
            tableElement = tableElement.Substring(0, tableElement.Length - 2);
            string creatTable = $"create table {TBname}(id INT PRIMARY KEY AUTO_INCREMENT,{tableElement});";
            using (MySqlConnection mysqlcon = new MySqlConnection())
            {
                mysqlcon.ConnectionString = CntStr;
                mysqlcon.Open();
                using (MySqlCommand cmd = new MySqlCommand(creatTable, mysqlcon))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex);
                        return false;
                    }
                }

            }
        }
        #endregion

    }
}
