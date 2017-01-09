using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace Home.LogUtility
{
    public class DBLog
    {
        /// <summary>
        /// 批次编码
        /// </summary>
        public string BlockStr = string.Empty;

        public string VMARKTEXT = "";
        DateTime VDT = DateTime.Now;

        #region 记录回滚系统所需操作
        /// <summary>
        /// 记录回滚系统所需操作
        /// </summary>
        /// <param name="RBMark"></param>
        /// <param name="RBServerIP"></param>
        /// <param name="RBServerPort"></param>
        /// <param name="RBServerBakUri"></param>
        /// <param name="RBServerAimUri"></param>
        /// <param name="RBSiteName"></param>
        /// <param name="RBOp"></param>
        /// <param name="Block"></param>
        /// <returns></returns>
        public bool RollBakLog(string RBMark, string RBServerIP, int RBServerPort, string RBServerBakUri, string RBServerAimUri, string RBSiteName, string RBOp, string Block)
        {
            return Trans.Db.Data.NRoll_Action.insert(new Trans.Db.Model.NRoll_Action()
            {
                RollCode = RBMark,
                ServerIP = RBServerIP,
                ServerPort = RBServerPort,
                ServerBakUri = RBServerBakUri,
                ServerAimUri = RBServerAimUri,
                SiteName = RBSiteName,
                Op = RBOp,
                AutoRollBack = 0,
                IsUsed = 0,
                BlockCode = Block,
                YearVal = VDT.Year.ToString(),
                MonthVal = VDT.Month.ToString().PadLeft(2, '0'),
                DayVal = VDT.Day.ToString().PadLeft(2, '0')
            });
        }
        #endregion

        #region 记录自动回滚操作
        /// <summary>
        /// 记录自动回滚操作
        /// </summary>
        /// <param name="RBMark"></param>
        /// <param name="RBServerIP"></param>
        /// <param name="RBServerPort"></param>
        /// <param name="RBServerBakUri"></param>
        /// <param name="RBServerAimUri"></param>
        /// <param name="RBSiteName"></param>
        /// <param name="RBOp"></param>
        /// <param name="Block"></param>
        public void RollBakAutoSuccess(string RBMark, string RBServerIP, int RBServerPort, string RBServerBakUri, string RBServerAimUri, string RBSiteName, string RBOp, string Block)
        {
            Trans.Db.Data.NRoll_Action.Update("RollCode=@RollCode AND ServerIP=@ServerIP AND ServerPort=@ServerPort AND ServerBakUri=@ServerBakUri AND ServerAimUri=@ServerAimUri AND SiteName=@SiteName AND Op=@Op AND BlockCode=@BlockCode",
                "AutoRollBack=1", new object[] { RBMark, RBServerIP, RBServerPort, RBServerBakUri, RBServerAimUri, RBSiteName, RBOp, Block });
        }
        #endregion

        #region 获取有备份同步批次日期列表
        /// <summary>
        /// 获取有备份同步批次日期列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetBakDateList()
        {
            return Trans.Db.Data.NRoll_Action.GetTable("(AutoRollBack IS NULL OR AutoRollBack<>1)", "", "distinct YearVal+MonthVal+DayVal", null, true);
        }
        #endregion

        #region 获取备份回滚批次列表
        /// <summary>
        /// 获取备份回滚批次列表
        /// </summary>
        /// <param name="BakDateStr"></param>
        /// <returns></returns>
        public DataTable GetBakRollMark(string BakDateStr)
        {
            return Trans.Db.Data.NRoll_Action.GetTable("RollCode like '%'+@BakDate+'%' AND (AutoRollBack IS NULL OR AutoRollBack<>1)", "", "distinct RollCode,SiteName,IsUsed", new object[] { BakDateStr }, true);
        }
        #endregion

        #region 获取回滚操作列表
        /// <summary>
        /// 获取回滚操作列表
        /// </summary>
        /// <param name="RollBackMark"></param>
        /// <returns></returns>
        public DataTable GetBakUps(string RollCode)
        {
            return Trans.Db.Data.NRoll_Action.GetTable("RollCode=@RollCode AND (AutoRollBack IS NULL OR AutoRollBack<>1)", "", "*", new object[] { RollCode }, true);
        }
        #endregion

        public void UpdateBakUsedMark(string RollBackMark)
        {
            Trans.Db.Data.NRoll_Action.Update("RollCode=@RollCode", "IsUsed=1", new object[] { RollBackMark });
        }

        #region 通用日志
        /// <summary>
        /// 通用日志
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Site"></param>
        /// <param name="Description"></param>
        public void Trace(string Title, string Site, string Description)
        {
            Trans.Db.Data.NBlock_Trace.insert(new Trans.Db.Model.NBlock_Trace()
            {
                BlockCode = this.BlockStr,
                DayVal = VDT.Day.ToString().PadLeft(2, '0'),
                MonthVal = VDT.Month.ToString().PadLeft(2, '0'),
                YearVal = VDT.Year.ToString(),
                Title = Title,
                Site = Site,
                Description = Description
            });
        }
        #endregion

        #region 记录错误日志
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="CmdName"></param>
        /// <param name="CmdExcContent"></param>
        public void Error(string CmdName, string CmdExcContent)
        {
            Trans.Db.Data.NBlock_Error.insert(new Trans.Db.Model.NBlock_Error()
            {
                BlockCode = this.BlockStr,
                Command = CmdName,
                Action = CmdExcContent
            });
        }
        #endregion

        public void UpdateBlock(string SiteName)
        {
            VDT = DateTime.Now;
            VMARKTEXT = VDT.ToString("yyyyMMdd") + "/" + VDT.ToString("HH:mm:ss").Replace(":", "_");
            string BlockVMark = VDT.ToString("yyyy:MM:dd HH:mm:ss").Replace(':', '_').Replace(' ', '_');
            string str = SiteName.Replace('.', '_').ToUpper() + "_" + BlockVMark;
            if (Trans.Db.Data.NBlock_Info.Count("BlockCode=@BlockCode", new object[] { str }, true) > 0)//Trans.DataLayer.Data.DBOper.Block.Count("VAL=@Block", new object[] { str }, true) > 1)
            {
                Thread.Sleep(1000);
                UpdateBlock(SiteName);
            }
            else
            {
                Trans.Db.Data.NBlock_Info.insert(new Trans.Db.Model.NBlock_Info()
                {
                    BlockCode = str,
                    ActionMark = VMARKTEXT
                });
                this.BlockStr = str;
            }
        }

        public DataTable GetTraces(string BlockCode)
        {
            return Trans.Db.Data.NBlock_Trace.GetTable("BlockCode=@Block", "id asc", "*", new object[] { BlockCode }, true);
        }

        public DataTable GetBlockYearList()
        {
            return Trans.Db.Data.NBlock_Trace.GetTable("", "", "DISTINCT YearVal", null, true);
        }

        public List<string> GetBlockYears()
        {
            List<string> Years = new List<string>();
            DataTable DT = Trans.Db.Data.NBlock_Trace.GetTable("", "", "DISTINCT YearVal", null, true);
            foreach (DataRow dr in DT.Rows)
            {
                if (dr != null && dr["YearVal"] != null && !string.IsNullOrEmpty(dr["YearVal"].ToString()) && Years.Contains(dr["YearVal"].ToString()))
                {
                    Years.Add(dr["YearVal"].ToString());
                }
            }
            return Years;
        }

        public DataTable GetBlockMonthList(string Year)
        {
            return Trans.Db.Data.NBlock_Trace.GetTable("YearVal=@Year", "", "DISTINCT MonthVal", new object[] { Year }, true);
        }

        public DataTable GetBlockDayList(string Year, string Month)
        {
            return Trans.Db.Data.NBlock_Trace.GetTable("YearVal=@Year AND MonthVal=@Month", "", "DISTINCT DayVal", new object[] { Year, Month }, true);
        }
        
        public DataTable GetMarkBlocks(string Year, string Month, string Day)
        {
            return Trans.Db.Data.NBlock_Trace.GetTable("YearVal=@Year AND MonthVal=@Month AND DayVal=@Day", "", "DISTINCT BlockCode", new object[] { Year, Month, Day }, true);
        }
    }
}