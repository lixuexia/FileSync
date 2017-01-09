using System;
using System.Collections.Generic;
using System.Text;

namespace Trans.Web.Display
{
    public partial class Users : System.Web.UI.Page
    {
        protected string ListStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Trans.Db.Model.NUser_Info> users = Trans.Db.Data.NUser_Info.GetList("IsDel=0");
            StringBuilder txt = new StringBuilder();
            txt.Append("<table width='100%' cellspacing='0' cellpadding='0' border='1'>");
            txt.Append("<tr><td>编号</td><td>用户名</td><td>状态</td><td>创建时间</td><td>外部编码</td><td>操作</td></tr>");
            foreach (Trans.Db.Model.NUser_Info item in users)
            {
                txt.Append("<tr>");
                txt.Append("<td>" + item.UserId.ToString() + "</td>");
                txt.Append("<td>" + item.UserName.ToString() + "</td>");
                txt.Append("<td>" + (item.Status == 1 ? "有效" : "无效") + "</td>");
                txt.Append("<td>" + item.CreateTime.ToString() + "</td>");
                txt.Append("<td>" + item.RefUserId.ToString() + "</td>");
                txt.Append("<td><a href='Grant.aspx?UserId=" + item.UserId.ToString() + "'>授权</a></td>");
                txt.Append("</tr>");
            }
            this.ListStr = txt.ToString();
        }
    }
}