using System;
using System.Data;
using Home.LogUtility;
using Home.FileUtility;

namespace Trans.Web.Display
{
    public partial class Rolls : System.Web.UI.Page
    {
        protected string RBLOG = string.Empty;
        protected string RBOP = string.Empty;
        protected string RBMARK = string.Empty;
        protected string RBAC = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Data_Bind();
        }
        private void Data_Bind()
        {
            if (Request["RID"] != null && Request["RID"] != "")
            {
                this.RBMARK = Request["RID"].Trim();
            }
            if (Request["RB"] != null && Request["RB"].Trim() != "")
            {
                this.RBAC = Request["RB"].Trim();
            }
            if (!string.IsNullOrEmpty(this.RBMARK))
            {
                DataTable DT = new DBLog().GetBakUps(RBMARK);
                if (DT != null && DT.Rows.Count > 0)
                {
                    this.RBLOG += "<table width='100%' border='1' cellspacing='0' cellpadding='0'><caption>预览回滚操作</caption>";
                    this.RBLOG += "<tr><td width='20%'>站点</td><td width='30%'>源文件</td><td width='30%'>目标文件</td><td width='20%'>操作类型</td></tr>";

                    foreach (DataRow dr in DT.Rows)
                    {
                        this.RBLOG += "<tr onmouseover=\"this.style.background='#ccc'\" onmouseout=\"this.style.background='#fff'\">";
                        this.RBLOG += "<td style='white-space:normal; word-break:break-all;word-wrap:break-word'>" + dr["RBSiteName"].ToString() + "</td>";
                        if (dr["RBServerBakUri"].ToString().Trim() == "")
                        {
                            this.RBLOG += "<td style='white-space:normal; word-break:break-all;word-wrap:break-word'>没有源文件</td>";
                        }
                        else
                        {
                            this.RBLOG += "<td style='white-space:normal; word-break:break-all;word-wrap:break-word'>" + dr["RBServerBakUri"].ToString() + "</td>";
                        }
                        this.RBLOG += "<td style='white-space:normal; word-break:break-all;word-wrap:break-word'>" + dr["RBServerAimUri"].ToString() + "</td>";
                        if (dr["RBOP"].ToString().Trim() == "DELETE")
                        {
                            this.RBLOG += "<td>删除</td>";
                        }
                        else
                        {
                            this.RBLOG += "<td>覆盖</td>";
                        }
                        this.RBLOG += "</tr>";
                    }
                    this.RBLOG += "</table>";
                    if (Convert.ToInt32(DT.Rows[0]["IsUsed"]) == 0)
                    {
                        this.RBOP += "<input type='button' onclick=\"javascript:RollBak('" + this.RBMARK + "')\" value=\"执行回滚\"/>";
                    }
                    else
                    {
                        this.RBOP += "<input type='button' onclick=\"javascript:alert('回滚号" + this.RBMARK + "的操作已经被回滚过！')\" value=\"已经回滚\"/>";
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.RBAC))
            {
                DataTable DT = new DBLog().GetBakUps(this.RBAC);
                string sitename = string.Empty;
                string BlockCode = "";
                if (DT != null && DT.Rows.Count > 0)
                {
                    sitename = DT.Rows[0]["RBSiteName"].ToString();
                    BlockCode = DT.Rows[0]["Block"].ToString();
                }
                //执行回滚
                string msg = "";
                Home.ConfigUtility.TaskInfo taskinfo = new Home.ConfigUtility.TaskInfo();
                taskinfo.SiteBaseInfo = Home.ConfigUtility.Config.GetSiteInfo(sitename);
                DBLog loginfo = new DBLog();
                loginfo.BlockStr = BlockCode;

                if (new TaskWorker(taskinfo, loginfo).RollBackSite())
                {
                    //修改回滚记录使用标记
                    new DBLog().UpdateBakUsedMark(this.RBAC);
                    this.RBOP = "<input type='button' onclick=\"javascript:alert('回滚号" + this.RBMARK + "的操作已经被回滚过！')\" value=\"已经回滚\"/>";
                    Response.Write("<script>alert('回滚成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('回滚失败!!\\r\\n\\r\\n" + msg + "')</script>");
                }
            }
        }
    }
}