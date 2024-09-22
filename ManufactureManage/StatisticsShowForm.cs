using log4net;
using ManufactureManage.Config;
using ManufactureManage.DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ManufactureManage
{
    public partial class StatisticsShowForm : Form
    {
        public StatisticsShowForm()
        {
            InitializeComponent();
        }

        #region 成员及属性
        private readonly ILog _log = LogManager.GetLogger(nameof(StatisticsShowForm));

        #endregion

        #region PrivateFuncs
        private void RefreshData(string taskNum, DataTypeEnum dataTypeEnum)
        {
            try
            {
                QueryData(dataTypeEnum, taskNum, out DataTable dataTable);

                //数据库查询 按季度查询//测试
                //List<int> quarterX = new List<int>() { 1, 2, 3, 4 };
                //List<int> quarterY = new List<int>() { 54321, 78945, 12313, 45645 };
                //Random ra = new Random();
                //quarterY = new List<int>() {
                //ra.Next(1, 10000),
                //ra.Next(1, 10000),
                //ra.Next(1, 10000),
                //ra.Next(1, 10000)
                //};

                List<string> xLabel = new List<string>();
                List<int> yLabel = new List<int>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    yLabel.Add(Convert.ToInt32(dataTable.Rows[i]["cnt"].ToString()));
                }
                switch (dataTypeEnum)
                {
                    case DataTypeEnum.Quarter:
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            xLabel.Add($"第{i + 1}季度");
                        }
                        RefreshChart(xLabel, yLabel, dataTypeEnum);
                        break;
                    //case DataTypeEnum.BadStatistics:
                    //    xLabel.Add("合格");
                    //    xLabel.Add("不合格");
                    //    RefreshPieChart(xLabel, yLabel, dataTypeEnum);
                    //    break;
                    default:
                        xLabel = dataTable.AsEnumerable().Select(d => d.Field<string>("date")).ToList();//真实数据
                        RefreshChart(xLabel, yLabel, dataTypeEnum);
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 查询出指定范围内生产数量
        /// </summary>
        /// <param name="dataTypeEnum"></param>
        /// <param name="taskNum"></param>
        /// <param name="dataTable"></param>
        private void QueryData(DataTypeEnum dataTypeEnum, string taskNum, out DataTable dataTable)
        {
            try
            {
                //数据库连接字段
                string connectStr = string.Empty;
                string tableName = string.Empty;
                string queryCmd = string.Empty;
                ResultCode resultCode = ResultCode.Failed;
                //时间格式
                string timeFormat = string.Empty;
                //结果格式
                string queryCondition = string.Empty;//查所有合格的结果
                //默认截取时间
                DateTime startTime = Convert.ToDateTime(dateTimePicker_StartTime.Text);
                DateTime endTime = Convert.ToDateTime(dateTimePicker_EndTime.Text);
                if (endTime - startTime > TimeSpan.FromHours(24))//大于24小时按天显示 
                {
                    timeFormat = "%y年%m月%d日";
                }
                else
                {
                    timeFormat = "%m-%d %H";
                }
                dataTable = new DataTable();
                switch (dataTypeEnum)
                {
                    case DataTypeEnum.Quarter:
                        connectStr = $"Server = 10.88.8.47; Database = mtlinemgr; Port = 3306; User = mtmgruser; password = htll1234; Connect Timeout = 20; SslMode = None; Allow User Variables = true;";
                        tableName = $"productiontarget_tb";
                        queryCondition = $"";
                        queryCmd = $"SELECT FLOOR((MONTH(Time) - 1) / 3) + 1 AS date, SUM(ProductionTarget) as cnt " +
                                   $"FROM {tableName} " +
                                   $"GROUP BY date";
                        resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);
                        //xLabel = dataTable.AsEnumerable().Select(d => d.Field<string>("quarter")).ToList();
                        //yLabel = new List<int>();
                        //for (int i = 0; i < dataTable.Rows.Count; i++)
                        //{
                        //    yLabel.Add(Convert.ToInt32(dataTable.Rows[i]["total_sum"].ToString()));
                        //}
                        break;
                    case DataTypeEnum.ProductionTargets:
                        connectStr = $"Server = 10.88.8.47; Port = 3306; User = mtmgruser; password = htll1234; Connect Timeout = 20; SslMode = None; Allow User Variables = true;";
                        tableName = $"productiontarget_tb";//表名拼接
                        queryCondition = $"";
                        queryCmd = $"SELECT DATE_FORMAT(Time,'{timeFormat}') as date,productiontarget as cnt " +
                                   $"FROM {tableName} " +
                                   $"WHERE {queryCondition} Time BETWEEN '{startTime}' AND '{endTime.AddDays(1)}' " +
                                   $"ORDER BY date asc;";
                        resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);

                        break;
                    case DataTypeEnum.CarrierEquipment:
                        connectStr = $"Server = 10.88.8.47; Database = mtlinemgr; Port = 3306; User = mtmgruser; password = htll1234; Connect Timeout = 20; SslMode = None; Allow User Variables = true;";
                        tableName = $"dtl{taskNum}1008";//表名拼接
                        queryCondition = $"";
                        queryCmd = $"SELECT DATE_FORMAT(UploadTime,'{timeFormat}') as date,count(1) as cnt " +
                                   $"FROM {tableName} " +
                                   $"WHERE {queryCondition} UploadTime BETWEEN '{startTime}' AND '{endTime}' " +
                                   $"GROUP BY DATE_FORMAT(UploadTime,'{timeFormat}') " +
                                   $"ORDER BY date asc;";
                        resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);
                        break;
                    case DataTypeEnum.NameplateEquipment:
                        connectStr = $"Server = 10.88.8.47; Database = mtlinemgr; Port = 3306; User = mtmgruser; password = htll1234; Connect Timeout = 20; SslMode = None; Allow User Variables = true;";
                        //$"Server = localhost; Port = 3306; User = root; password =admin123; database = labelingdata; Connect Timeout=30; SslMode=None; Allow User Variables=true;";
                        tableName = $"dtl{taskNum}1009";//表名拼接
                        queryCondition = $"";
                        queryCmd = $"SELECT DATE_FORMAT(UploadTime,'{timeFormat}') as date,count(1) as cnt " +
                                   $"FROM {tableName} " +
                                   $"WHERE {queryCondition} UploadTime BETWEEN '{startTime}' AND '{endTime.AddDays(1)}' " +
                                   $"GROUP BY DATE_FORMAT(UploadTime,'{timeFormat}') " +
                                   $"ORDER BY date asc;";
                        resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);
                        break;
                    case DataTypeEnum.ParameterSetEquipment:

                        break;
                    case DataTypeEnum.WarpTwlveMeters:

                        break;
                    case DataTypeEnum.ParameterCompare:

                        break;
                    case DataTypeEnum.LabelingEquipment:

                        break;
                    case DataTypeEnum.AutoSorting:
                        connectStr = $"Server = localhost; Port = 3306; User = root; password =admin123; database = autosortpack_db; Connect Timeout=30; SslMode=None; Allow User Variables=true;";
                        tableName = $"metersinfo_tb";//表名拼接
                        queryCondition = $"";
                        queryCmd = $"SELECT DATE_FORMAT(Check_Time,'{timeFormat}') as date,count(1) as cnt " +
                                   $"FROM {tableName} " +
                                   $"WHERE {queryCondition} Check_Time BETWEEN '{startTime:yyyy-MM-dd}' AND '{endTime.AddDays(1):yyyy-MM-dd}' " +
                                   $"GROUP BY DATE_FORMAT(Check_Time,'{timeFormat}') " +
                                   $"ORDER BY date asc;";
                        resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);
                        break;
                    case DataTypeEnum.RfidTestEquipment:
                        connectStr = $"Server = localhost; Port = 3306; User = root; password =admin123; database = rftest_db; Connect Timeout=30; SslMode=None; Allow User Variables=true;";
                        tableName = $"rftest_tb";//表名拼接
                        queryCmd = $"SELECT DATE_FORMAT(Check_Time,'{timeFormat}') as date,count(1) as cnt " +
                                   $"FROM {tableName} " +
                                   $"WHERE {queryCondition} Check_Time BETWEEN '{startTime:yyyy-MM-dd}' AND '{endTime.AddDays(1):yyyy-MM-dd}' " +
                                   $"GROUP BY DATE_FORMAT(Check_Time,'{timeFormat}') " +
                                   $"ORDER BY date asc;";
                        resultCode = MySqlHelp.RunReadCmd(connectStr, queryCmd, out dataTable);
                        break;
                    default:
                        break;
                }
                if(resultCode != ResultCode.Success)
                {

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void RefreshQuarter()
        {

        }

        private void RefreshPieData(string taskNum, DataTypeEnum dataTypeEnum)
        {
            try
            {
                QueryPieData(dataTypeEnum, taskNum, out DataTable dtOK, out DataTable dtNG);
                List<string> xLabel = new List<string>();
                xLabel.Add("合格");
                xLabel.Add("不合格");
                List<int> yLabel = new List<int>();

                if (dtOK.Rows.Count > 0)
                {
                    yLabel.Add(dtOK.Rows.Count);
                }
                else
                {
                    yLabel.Add(0);
                }
                if (dtNG.Rows.Count > 0)
                {
                    yLabel.Add(dtNG.Rows.Count);
                }
                else
                {
                    yLabel.Add(0);
                }
                lbl_OKPercent.Text = $"{(double)dtOK.Rows.Count / (dtOK.Rows.Count + dtNG.Rows.Count):P}";
                RefreshPieChart(xLabel, yLabel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// 查询合格/不合格饼状图
        /// </summary>
        /// <param name="dataTypeEnum"></param>
        /// <param name="taskNum"></param>
        /// <param name="dataTable"></param>
        public void QueryPieData(DataTypeEnum dataTypeEnum, string taskNum, out DataTable dtOK, out DataTable dtNG)
        {
            try
            {
                //数据库连接字段
                string connectStr = string.Empty, tableName = string.Empty, queryCmdOK = string.Empty, queryCmdNG = string.Empty;
                ResultCode resOK = ResultCode.Failed, resNG = ResultCode.Failed;
                //时间格式
                string timeFormat = string.Empty;
                //结果格式
                string queryCondition = string.Empty;//查所有合格的结果
                //默认截取时间
                DateTime startTime = Convert.ToDateTime(dateTimePicker_StartTime.Text);
                DateTime endTime = Convert.ToDateTime(dateTimePicker_EndTime.Text);
                if (endTime - startTime > TimeSpan.FromHours(24))//大于24小时按天显示 
                {
                    timeFormat = "%y年%m月%d日";
                }
                else
                {
                    timeFormat = "%m-%d %H";
                }
                dtOK = new DataTable(); dtNG = new DataTable();
                connectStr = $"Server = 10.88.8.47; Database = mtlinemgr; Port = 3306; User = mtmgruser; password = htll1234; Connect Timeout = 20; SslMode = None; Allow User Variables = true;";
                switch (dataTypeEnum)
                {
                    case DataTypeEnum.CarrierEquipment:
                        tableName = $"dtl{taskNum}1008";//拼接
                        queryCmdOK = $"SELECT TestResult " +
                            $"FROM {tableName} WHERE UploadTime BETWEEN '{startTime:yyyy-MM-dd}' AND '{endTime.AddDays(1):yyyy-MM-dd}' AND TestResult = '合格'";
                        resOK = MySqlHelp.RunReadCmd(connectStr, queryCmdOK, out dtOK);

                        queryCmdNG = $"SELECT TestResult " +
                            $"FROM {tableName} WHERE UploadTime BETWEEN '{startTime:yyyy-MM-dd}' AND '{endTime.AddDays(1):yyyy-MM-dd}' AND TestResult = '不合格'";
                        resNG = MySqlHelp.RunReadCmd(connectStr, queryCmdNG, out dtNG);
                        break;
                    case DataTypeEnum.NameplateEquipment:
                        tableName = $"dtl{taskNum}1009";//拼接
                        queryCmdOK = $"SELECT Result " +
                            $"FROM {tableName} WHERE UploadTime BETWEEN '{startTime:yyyy-MM-dd}' AND '{endTime.AddDays(1):yyyy-MM-dd}' AND Result = '合格'";
                        resOK = MySqlHelp.RunReadCmd(connectStr, queryCmdOK, out dtOK);

                        queryCmdNG = $"SELECT Result " +
                            $"FROM {tableName} WHERE UploadTime BETWEEN '{startTime:yyyy-MM-dd}' AND '{endTime.AddDays(1):yyyy-MM-dd}' AND Result = '不合格'";
                        resNG = MySqlHelp.RunReadCmd(connectStr, queryCmdNG, out dtNG);
                        break;
                    case DataTypeEnum.ParameterSetEquipment:

                        break;
                    case DataTypeEnum.WarpTwlveMeters:

                        break;
                    case DataTypeEnum.ParameterCompare:

                        break;
                    case DataTypeEnum.LabelingEquipment:

                        break;
                    case DataTypeEnum.AutoSorting:

                        break;
                    case DataTypeEnum.RfidTestEquipment:

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public delegate void RefreshChartDelegate(List<string> x, List<int> y, DataTypeEnum dataTypeEnum);
        private void RefreshChart(List<string> x, List<int> y, DataTypeEnum dataTypeEnum)
        {
            try
            {
                switch (dataTypeEnum)
                {
                    case DataTypeEnum.Quarter:
                        if (this.chart_Quarter.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_Quarter.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    //case DataTypeEnum.BadStatistics:
                    //    if (this.chart_BadStatistics.InvokeRequired)
                    //    {
                    //        RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    //        this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                    //    }
                    //    else
                    //    {
                    //        chart_BadStatistics.Series[0].Points.DataBindXY(x, y);
                    //    }
                    //    break;
                    case DataTypeEnum.ProductionTargets:
                        if (this.chart_ProductionTargets.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_ProductionTargets.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    case DataTypeEnum.CarrierEquipment:
                        if (this.chart_ShowCarrier.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_ShowCarrier.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    case DataTypeEnum.NameplateEquipment:
                        if (this.chart_ShowNameplate.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_ShowNameplate.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    case DataTypeEnum.ParameterSetEquipment:
                        if (this.chart_ParameterSet.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_ParameterSet.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    case DataTypeEnum.WarpTwlveMeters:
                        if (this.chart_WarpTwlveMeters.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_WarpTwlveMeters.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    case DataTypeEnum.ParameterCompare:
                        if (this.chart_ParameterCmp.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_ParameterCmp.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    case DataTypeEnum.LabelingEquipment:
                        if (this.chart_Labeling.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_Labeling.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    case DataTypeEnum.AutoSorting:
                        if (this.chart_AutoSorting.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_AutoSorting.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    case DataTypeEnum.RfidTestEquipment:
                        if (this.chart_RfidTest.InvokeRequired)
                        {
                            RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                            this.Invoke(stcb, new object[] { x, y, dataTypeEnum });
                        }
                        else
                        {
                            chart_RfidTest.Series[0].Points.DataBindXY(x, y);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void RefreshPieChart(List<string> x, List<int> y)
        {
            try
            {
                chart_BadStatistics.Series[0].Points.DataBindXY(x, y);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        private void StatisticsShowForm_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker_EndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                dateTimePicker_StartTime.Text = DateTime.Now.AddDays(-7).ToString(); //日期选择前七天 或其它时间段

                //chart_Quarter.Series.Clear();
                //chart_Quarter.Titles.Clear();
                //ChartHelper.AddSeries(chart_Quarter, "季度总计", SeriesChartType.Bar, Color.DodgerBlue, Color.White, true);
                //ChartHelper.SetTitle(chart_Quarter, "按季度统计", Color.SteelBlue, GradientStyle.LeftRight, ContentAlignment.MiddleLeft, new Font("幼圆", 10.8f), Docking.Top, Color.White);
                //ChartHelper.SetStyle(chart_Quarter, Color.White, Color.Black);
                ////ChartHelper.SetLegend(chart_Quarter, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
                //ChartHelper.SetXY(chart_Quarter, "季度", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.SharpTriangle, 0, 0);
                //ChartHelper.SetMajorGrid(chart_Quarter, Color.Black, 0, 0);
                //RefreshData(DataTypeEnum.Quarter);

                //chart_ProductionTargets.Series.Clear();//波形图示意
                //chart_ProductionTargets.Titles.Clear();
                //ChartHelper.AddSeries(chart_ProductionTargets, "生产目标", SeriesChartType.SplineRange, Color.DodgerBlue, Color.White, true);
                //ChartHelper.SetTitle(chart_ProductionTargets, "生产目标", Color.SteelBlue, GradientStyle.LeftRight, ContentAlignment.MiddleLeft, new Font("幼圆", 10.8f), Docking.Top, Color.White);
                //ChartHelper.SetStyle(chart_ProductionTargets, Color.White, Color.Black);
                //ChartHelper.SetXY(chart_ProductionTargets, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                //ChartHelper.SetMajorGrid(chart_ProductionTargets, Color.Black, 0, 0);
                //RefreshData(DataTypeEnum.ProductionTargets);

                //chart_ShowCarrier.Series.Clear();//各设备柱状图示意
                //ChartHelper.AddSeries(chart_ShowCarrier, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                //ChartHelper.SetStyle(chart_ShowCarrier, Color.White, Color.Black);
                //ChartHelper.SetXY(chart_ShowCarrier, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                //ChartHelper.SetMajorGrid(chart_ShowCarrier, Color.Black, 0, 0);
                //RefreshData(DataTypeEnum.CarrierEquipment);
                //chart_BadStatistics.Series.Clear();//饼状图示意
                //ChartHelper.AddSeries(chart_BadStatistics, "合格率", SeriesChartType.Pie, Color.Black, Color.White, true);
                //ChartHelper.SetStyle(chart_BadStatistics, Color.White, Color.Black);
                //RefreshPieData(DataTypeEnum.CarrierEquipment);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Btn_Fresh_Click(object sender, EventArgs e)
        {
            try
            {
                //StatisticsShowForm_Load(sender, e);
                if (string.IsNullOrEmpty(textBox_TaskCode.Text))
                {
                    MessageBox.Show("请输入要查询的任务号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string taskNum = textBox_TaskCode.Text;//任务号
                TabControl_Equipment.SelectedIndex = 0;//点击刷新定位到第一个载波上
                chart_Quarter.Series.Clear();
                chart_Quarter.Titles.Clear();
                ChartHelper.AddSeries(chart_Quarter, "季度总计", SeriesChartType.Bar, Color.DodgerBlue, Color.White, true);
                ChartHelper.SetTitle(chart_Quarter, "按季度统计", Color.SteelBlue, GradientStyle.LeftRight, ContentAlignment.MiddleLeft, new Font("幼圆", 10.8f), Docking.Top, Color.White);
                ChartHelper.SetStyle(chart_Quarter, Color.White, Color.Black);
                //ChartHelper.SetLegend(chart_Quarter, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
                ChartHelper.SetXY(chart_Quarter, "季度", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.SharpTriangle, 0, 0);
                ChartHelper.SetMajorGrid(chart_Quarter, Color.Black, 0, 0);
                RefreshData(taskNum, DataTypeEnum.Quarter);

                chart_ProductionTargets.Series.Clear();//波形图示意
                chart_ProductionTargets.Titles.Clear();
                ChartHelper.AddSeries(chart_ProductionTargets, "生产目标", SeriesChartType.SplineRange, Color.DodgerBlue, Color.White, true);
                ChartHelper.SetTitle(chart_ProductionTargets, "生产目标", Color.SteelBlue, GradientStyle.LeftRight, ContentAlignment.MiddleLeft, new Font("幼圆", 10.8f), Docking.Top, Color.White);
                ChartHelper.SetStyle(chart_ProductionTargets, Color.White, Color.Black);
                ChartHelper.SetXY(chart_ProductionTargets, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                ChartHelper.SetMajorGrid(chart_ProductionTargets, Color.Black, 0, 0);
                RefreshData(taskNum, DataTypeEnum.ProductionTargets);

                chart_ShowCarrier.Series.Clear();//各设备柱状图示意
                ChartHelper.AddSeries(chart_ShowCarrier, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                ChartHelper.SetStyle(chart_ShowCarrier, Color.White, Color.Black);
                ChartHelper.SetXY(chart_ShowCarrier, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                ChartHelper.SetMajorGrid(chart_ShowCarrier, Color.Black, 0, 0);
                RefreshData(taskNum, DataTypeEnum.CarrierEquipment);
                chart_BadStatistics.Series.Clear();//饼状图示意
                ChartHelper.AddSeries(chart_BadStatistics, "合格率", SeriesChartType.Pie, Color.Black, Color.White, true);
                ChartHelper.SetStyle(chart_BadStatistics, Color.White, Color.Black);
                RefreshPieData(taskNum, DataTypeEnum.CarrierEquipment);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void TabControl_Equipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_TaskCode.Text))
                {
                    MessageBox.Show("请输入要查询的任务号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string taskNum = textBox_TaskCode.Text;//任务号
                chart_BadStatistics.Series.Clear();//饼状图示意
                ChartHelper.AddSeries(chart_BadStatistics, "合格率", SeriesChartType.Pie, Color.Black, Color.White, true);
                ChartHelper.SetStyle(chart_BadStatistics, Color.White, Color.Black);
                switch (TabControl_Equipment.SelectedIndex)
                {
                    //载波测试 刷新图表及不良统计
                    case 0:
                        chart_ShowCarrier.Series.Clear();//载波测试
                        ChartHelper.AddSeries(chart_ShowCarrier, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                        ChartHelper.SetStyle(chart_ShowCarrier, Color.White, Color.Black);
                        ChartHelper.SetXY(chart_ShowCarrier, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                        ChartHelper.SetMajorGrid(chart_ShowCarrier, Color.Black, 0, 0);
                        RefreshData(taskNum, DataTypeEnum.CarrierEquipment);
                        RefreshPieData(taskNum, DataTypeEnum.CarrierEquipment);
                        break;
                    //下铭牌及电子标签贴检
                    case 1:
                        chart_ShowNameplate.Series.Clear();//下铭牌设备
                        ChartHelper.AddSeries(chart_ShowNameplate, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                        ChartHelper.SetStyle(chart_ShowNameplate, Color.White, Color.Black);
                        ChartHelper.SetXY(chart_ShowNameplate, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                        ChartHelper.SetMajorGrid(chart_ShowNameplate, Color.Black, 0, 0);
                        RefreshData(taskNum, DataTypeEnum.NameplateEquipment);
                        RefreshPieData(taskNum, DataTypeEnum.NameplateEquipment);
                        break;
                    //参数设置
                    case 2:
                        chart_ParameterSet.Series.Clear();//参数设置
                        ChartHelper.AddSeries(chart_ParameterSet, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                        ChartHelper.SetStyle(chart_ParameterSet, Color.White, Color.Black);
                        ChartHelper.SetXY(chart_ParameterSet, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                        ChartHelper.SetMajorGrid(chart_ParameterSet, Color.Black, 0, 0);
                        RefreshData(taskNum, DataTypeEnum.ParameterSetEquipment);
                        RefreshPieData(taskNum, DataTypeEnum.ParameterSetEquipment);
                        break;
                    //包装12表位
                    case 3:
                        chart_WarpTwlveMeters.Series.Clear();
                        ChartHelper.AddSeries(chart_WarpTwlveMeters, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                        ChartHelper.SetStyle(chart_WarpTwlveMeters, Color.White, Color.Black);
                        ChartHelper.SetXY(chart_WarpTwlveMeters, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                        ChartHelper.SetMajorGrid(chart_WarpTwlveMeters, Color.Black, 0, 0);
                        RefreshData(taskNum, DataTypeEnum.WarpTwlveMeters);
                        RefreshPieData(taskNum, DataTypeEnum.WarpTwlveMeters);
                        break;
                    //参数比对
                    case 4:
                        chart_ParameterCmp.Series.Clear();
                        ChartHelper.AddSeries(chart_ParameterCmp, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                        ChartHelper.SetStyle(chart_ParameterCmp, Color.White, Color.Black);
                        ChartHelper.SetXY(chart_ParameterCmp, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                        ChartHelper.SetMajorGrid(chart_ParameterCmp, Color.Black, 0, 0);
                        RefreshData(taskNum, DataTypeEnum.ParameterCompare);
                        RefreshPieData(taskNum, DataTypeEnum.ParameterCompare);
                        break;
                    //贴标机
                    case 5:
                        chart_Labeling.Series.Clear();
                        ChartHelper.AddSeries(chart_Labeling, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                        ChartHelper.SetStyle(chart_Labeling, Color.White, Color.Black);
                        ChartHelper.SetXY(chart_Labeling, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                        ChartHelper.SetMajorGrid(chart_Labeling, Color.Black, 0, 0);
                        RefreshData(taskNum, DataTypeEnum.LabelingEquipment);
                        RefreshPieData(taskNum, DataTypeEnum.LabelingEquipment);
                        break;
                    //排序机
                    case 6:
                        chart_AutoSorting.Series.Clear();
                        ChartHelper.AddSeries(chart_AutoSorting, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                        ChartHelper.SetStyle(chart_AutoSorting, Color.White, Color.Black);
                        ChartHelper.SetXY(chart_AutoSorting, "时间", "数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                        ChartHelper.SetMajorGrid(chart_AutoSorting, Color.Black, 0, 0);
                        RefreshData(taskNum, DataTypeEnum.AutoSorting);
                        RefreshPieData(taskNum, DataTypeEnum.AutoSorting);
                        break;
                    //射频检测
                    case 7:
                        chart_RfidTest.Series.Clear();
                        ChartHelper.AddSeries(chart_RfidTest, "载波测试生产数据", SeriesChartType.Column, Color.DodgerBlue, Color.White, true);
                        ChartHelper.SetStyle(chart_RfidTest, Color.White, Color.Black);
                        ChartHelper.SetXY(chart_RfidTest, "时间", "装箱数量", StringAlignment.Far, Color.Black, Color.Black, AxisArrowStyle.None, 0, 0);
                        ChartHelper.SetMajorGrid(chart_RfidTest, Color.Black, 0, 0);
                        RefreshData(taskNum, DataTypeEnum.RfidTestEquipment);
                        RefreshPieData(taskNum, DataTypeEnum.RfidTestEquipment);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
