using System;
using System.Collections.Generic;
using System.Text;

namespace Home.ConfigUtility
{
    /// <summary>
    /// 任务站点信息
    /// </summary>
    public class WebSiteInfo
    {
        /// <summary>
        /// 本地传输路径
        /// </summary>
        public string LOCALBAKTRANSFOLDER{get;set;}
        /// <summary>
        /// 文件源地址
        /// </summary>
        public string LOCALPATH { get; set; }
        /// <summary>
        /// 站点名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 任务包含服务器数量
        /// </summary>
        public int SERVERCOUNT { get; set; }
        /// <summary>
        /// 任务包含服务器列表
        /// </summary>
        public List<WebSiteServer> SERVLIST { get; set; }
    }
}