using System;
using System.Data;
using Home.LogUtility;
using Home.FileUtility;
using System.Collections.Generic;
using Home.ConfigUtility;

namespace Trans.Web.Display
{
    public partial class Roll : System.Web.UI.Page
    {
        protected string BakDateLab = string.Empty;
        protected string SelBakDate = string.Empty;
        protected string BakMarkLab = string.Empty;
        protected string RollBackMark = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetParameters();
            this.Data_Bind();
        }
        private void Data_Bind()
        {
            DataTable DT = new DBLog().GetBakDateList();
            this.BakDateLab += "<select id='BakDateList' name='BakDateList' onchange=\"javascript:SelBakDate()\"><option value='-1'>---请选择备份时间---</option>";
            if (DT != null && DT.Rows.Count > 0)
            {
                DateTime[] TimeArray = null;
                List<int> TimeList = new List<int>();

                foreach (DataRow dr in DT.Rows)
                {
                    if (!string.IsNullOrEmpty(dr[0].ToString()))
                    {
                        TimeList.Add(Convert.ToInt32(dr[0].ToString()));
                    }
                }
                TimeList.Sort();
                foreach (int TimeS in TimeList)
                {
                    string BakDate = TimeS.ToString().Insert(4, "年").Insert(7, "月") + "日";
                    if (SelBakDate == BakDate)
                    {
                        this.BakDateLab += "<option value='" + BakDate + "' selected='selected'>" + BakDate + "</option>";
                    }
                    else
                    {
                        this.BakDateLab += "<option value='" + BakDate + "'>" + BakDate + "</option>";
                    }
                }
            }
            this.BakDateLab += "</select>";

            if (!string.IsNullOrEmpty(this.SelBakDate))
            {
                DataTable MarkDt = new DBLog().GetBakRollMark(Convert.ToDateTime(this.SelBakDate).ToString("yyyyMMdd"));
                this.BakMarkLab += "<table width='100%' border='1' cellspacing='0' cellpadding='0'>";
                this.BakMarkLab += "<tr><td width='20%'>站点</td><td width='20%'>备份号</td><td width='20%'>时间</td><td>是否已用</td><td width='20%'>操作</td></tr>";
                if (MarkDt != null && MarkDt.Rows.Count > 0)
                {
                    foreach (DataRow dr in MarkDt.Rows)
                    {
                        this.BakMarkLab += "<tr onmouseover=\"this.style.background='#ccc'\" onmouseout=\"this.style.background='#fff'\">";
                        this.BakMarkLab += "<td style='white-space:normal; word-break:break-all;word-wrap:break-word'>" + dr[1].ToString() + "</td>";
                        this.BakMarkLab += "<td style='white-space:normal; word-break:break-all;word-wrap:break-word'>" + dr[0].ToString() + "</td>";
                        this.BakMarkLab += "<td style='white-space:normal; word-break:break-all;word-wrap:break-word'>" + dr[0].ToString().Substring(dr[0].ToString().IndexOf('/') + 1).Replace('_', ':') + "</td>";
                        if (Convert.ToInt32(dr[2].ToString()) == 1)
                        {
                            this.BakMarkLab += "<td>已回滚</td><td>已回滚  |  <a href='#' onclick=\"javascript:ViewRBOp('" + dr[0].ToString() + "')\">察看回滚日志</a></td></tr>";
                        }
                        else
                        {
                            this.BakMarkLab += "<td>未回滚</td><td><a href='#' onclick=\"javascript:RollBack('" + dr[0].ToString() + "')\">未回滚</a>  |  <a href='#' onclick=\"javascript:ViewRBOp('" + dr[0].ToString() + "')\">察看回滚日志</a></td></tr>";
                        }
                    }
                }
                this.BakMarkLab += "</table>";
            }
        }
        /// <summary>
        /// 获取回传参数
        /// </summary>
        private void GetParameters()
        {
            if (Request["BakDateList"] != null && Request["BakDateList"].Trim() != "" && Request["BakDateList"].Trim() != "-1")
            {
                this.SelBakDate = Request["BakDateList"].Trim();
            }
            if (Request["RollBackMark"] != null && Request["RollBackMark"].Trim() != "")
            {
                this.RollBackMark = Request["RollBackMark"].Trim();
                this.RollBackOp();
            }
        }
        private void RollBackOp()
        {
            if ((!string.IsNullOrEmpty(this.RollBackMark)) && this.RollBackMark != "-1")
            {
                DBLog dbl = new DBLog();
                DataTable DT = dbl.GetBakUps(this.RollBackMark);
                string sitename = string.Empty;

                if (DT != null && DT.Rows.Count > 0)
                {
                    sitename = DT.Rows[0]["RBSiteName"].ToString();
                }
                TaskInfo SiteObj = new TaskInfo();

                if (Convert.ToInt32(DT.Rows[0]["IsUsed"]) == 0)
                {
                    string msg = "";
                    TaskWorker SyncAction = new TaskWorker(SiteObj, dbl);
                    if (SyncAction.RollBackSite())
                    {
                        new DBLog().UpdateBakUsedMark(this.RollBackMark);
                        Response.Write("<script>alert('回滚成功');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('回滚失败!\\r\\n\\r\\n" + msg + "');</script>");
                    }
                }
                else
                {
                    this.Data_Bind();
                    Response.End();
                }
            }
        }
    }
}