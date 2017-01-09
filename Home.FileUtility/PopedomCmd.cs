using System.Collections.Generic;
using System.Data;

namespace Home.FileUtility
{
    /// <summary>
    /// 同步系统权限控制
    /// </summary>
    public class PopedomCmd
    {
        public static List<string> AllowCompleteListSite(int userid)
        {
            List<Trans.Db.Model.NUser_AuthSite> Sites = Trans.Db.Data.NUser_AuthSite.GetList("UserId=@UserId AND AllowList=1", "ID ASC", new object[] { userid }, true);
            List<string> list = new List<string>();
            foreach(var item in Sites)
            {
                list.Add(item.SiteName);
            }
            return list;
        }

        public static List<string> AllowListDetails(int userid, string sitename)
        {
            List<Trans.Db.Model.NUser_AuthDetail> Details = Trans.Db.Data.NUser_AuthDetail.GetList("UserId=@UserId AND SiteName=@SiteName AND AllowList=1", "ID ASC", new object[] { userid, sitename }, true);
            List<string> list = new List<string>();
            foreach (var item in Details)
            {
                list.Add(item.DetailName.Replace("http://" + sitename, ".."));
            }
            return list;
        }

        public static List<string> AllowListSite(int userid)
        {
            List<string> list = new List<string>();
            List<Trans.Db.Model.NUser_AuthSite> Sites = Trans.Db.Data.NUser_AuthSite.GetList("UserId=@UserId AND AllowList=1", "ID ASC", new object[] { userid }, true);            
            foreach (var item in Sites)
            {
                list.Add(item.SiteName);
            }
            List<Trans.Db.Model.NUser_AuthDetail> Details = Trans.Db.Data.NUser_AuthDetail.GetList<Trans.Db.Model.NUser_AuthDetail>("UserID=@UID AND AllowList=1", "ID ASC", "Distinct SiteName", new object[] { userid }, true);
            foreach (var item in Details)
            {
                if (!list.Contains(item.SiteName))
                {
                    list.Add(item.SiteName);
                }
            }
            return list;
        }

        #region 获取站点名称

        public static List<string> GetUserSiteNameList()
        {
            DataTable table = Trans.Db.Data.NUser_AuthSite.GetTable("IsDel=0", "SitName Desc", "Distinct SiteName", null, true);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return new List<string>();
            }
            List<string> list = new List<string>();
            foreach (DataRow item in table.Rows)
            {
                list.Add(item[0].ToString());
            }
            return list;
        }
        #endregion
    }
}