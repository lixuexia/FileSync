﻿using System;

namespace Trans.Web.Display
{
    public partial class Monitor : System.Web.UI.Page
    {
        protected string block = "";
        private int status = -1;
        protected string mainContent = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["block"]))
            {
                block = Request["block"];
            }
        }
        protected string Status
        {
            get
            {
                string r = "未追踪";
                switch (status)
                {
                    case 0:
                        r = "未处理";
                        break;
                    case 1:
                        r = " 上传中";
                        break;
                    case 2:
                        r = "处理成功";
                        break;
                    case 3:
                        r = "处理失败";
                        break;
                    case 4:
                        r = "用户取消";
                        break;
                    case 5:
                        r = "备份中";
                        break;
                    case 6:
                        r = "覆盖中";
                        break;
                    default:
                        break;
                }
                return r;
            }
        }
        protected void lkcancel_Click(object sender, EventArgs e)
        {
            Home.LogUtility.UploadTrace.TaskCancel(block);
            Response.Redirect(Request.Url.ToString());
        }
    }
}