using System;
using System.Collections.Generic;
using System.Text;
using Home.ConfigUtility;

namespace Home.ConfigUtility
{
    /// <summary>
    /// 同步任务信息
    /// </summary>
    public class TaskInfo
    {
        /// <summary>
        /// 需要同步的文件列表
        /// </summary>
        public List<TaskFileInfo> FilePairList { get; set; }
        /// <summary>
        /// 站点基本信息
        /// </summary>
        public Home.ConfigUtility.WebSiteInfo SiteBaseInfo { get; set; }
    }
}