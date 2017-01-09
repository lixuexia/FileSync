using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Home.ConfigUtility;

namespace Home.LogUtility
{
    public class UploadTrace
    {
        #region 记录任务文件列表
        /// <summary>
        /// 记录任务文件列表
        /// </summary>
        /// <param name="block"></param>
        /// <param name="AimSite"></param>
        /// <returns></returns>
        public static bool AddUploadTask(string block, TaskInfo AimSite)
        {
            if (Trans.Db.Data.NBlock_Info.Update("BlockCode=@BlockCode", "Status=@Status", new object[] { block, 1 }) < 1)
            {
                return false;
            }
            foreach (TaskFileInfo filePair in AimSite.FilePairList)
            {
                if (!Trans.Db.Data.NBlock_Task.insert(new Trans.Db.Model.NBlock_Task()
                {
                    BlockCode = block,
                    FilePath = filePair.AimFile,
                    Status = 0,
                    UploadLog = ""
                }))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 记录任务已失败
        /// <summary>
        /// 记录任务已失败
        /// </summary>
        /// <param name="block"></param>
        public static void TaskFailed(string block)
        {
            Trans.Db.Data.NBlock_Info.Update("BlockCode=@Block", "Status=@Status,ErrorFinishTime=@ErrorTime", new object[] { block, 3, DateTime.Now });
        }
        #endregion

        #region 记录任务覆盖成功
        /// <summary>
        /// 记录任务覆盖成功
        /// </summary>
        /// <param name="block"></param>
        public static void TaskSuccess(string block)
        {
            Trans.Db.Data.NBlock_Info.Update("BlockCode=@BlockCode", "Status=@Status,CoverSuccess=@ErrorTime", new object[] { block, 2, DateTime.Now });
        }
        #endregion

        #region 更新任务文件日志
        /// <summary>
        /// 更新任务文件日志
        /// </summary>
        /// <param name="file"></param>
        /// <param name="block"></param>
        /// <param name="log"></param>
        public static void AddLog(TaskFileInfo file, string block, string log)
        {
            Trans.Db.Data.NBlock_Task.Update("BlockCode=@BlockCode and FilePath=@filepath", "UploadLog=UploadLog+@UploadLog", new object[] { block, file.AimFile, "\r\n" + log.Replace("'", "''") });
        }
        #endregion

        #region 记录任务单文件上传失败
        /// <summary>
        /// 记录任务单文件上传失败
        /// </summary>
        /// <param name="file"></param>
        /// <param name="block"></param>
        /// <param name="errorServer"></param>
        public static void FileUploadFail(TaskFileInfo file, string block, string errorServer)
        {
            Trans.Db.Data.NBlock_Task.Update("BlockCode=@BlockCode and FilePath=@filepath", "Status=@Status,ErrorServer=@ErrorServer", new object[] { block, file.AimFile, -1, errorServer });
        }
        #endregion

        #region 记录任务单文件上传成功
        /// <summary>
        /// 记录任务单文件上传成功
        /// </summary>
        /// <param name="file"></param>
        /// <param name="block"></param>
        public static void FileUploadSuccess(TaskFileInfo file, string block)
        {
            Trans.Db.Data.NBlock_Task.Update("BlockCode=@BlockCode and FilePath=@filepath", "Status=@Status", new object[] { block, file.AimFile, 1 });
        }
        #endregion

        #region 记录任务单文件备份失败
        /// <summary>
        /// 记录任务单文件备份成功
        /// </summary>
        /// <param name="file"></param>
        /// <param name="block"></param>
        public static void FileBackupSuccess(TaskFileInfo file, string block)
        {
            Trans.Db.Data.NBlock_Task.Update("BlockCode=@block and FilePath=@filepath", "Status=@Status", new object[] { block, file.AimFile, 2 });
        }
        #endregion

        #region 记录任务单文件备份失败
        /// <summary>
        /// 记录任务单文件备份失败
        /// </summary>
        /// <param name="file"></param>
        /// <param name="block"></param>
        /// <param name="errorServer"></param>
        public static void FileBackupFail(TaskFileInfo file, string block, string errorServer)
        {
            Trans.Db.Data.NBlock_Task.Update("BlockCode=@block and FilePath=@filepath", "Status=@Status,ErrorServer=@ErrorServer", new object[] { block, file.AimFile, -2, errorServer });
        }
        #endregion

        #region 记录系统单文件覆盖成功
        /// <summary>
        /// 记录系统单文件覆盖成功
        /// </summary>
        /// <param name="file"></param>
        /// <param name="block"></param>
        /// <param name="coverStatus"></param>
        public static void FileCoverSuccess(TaskFileInfo file, string block, string coverStatus)
        {
            Trans.Db.Data.NBlock_Task.Update("BlockCode=@block and FilePath=@filepath", "Status=@Status,coverStatus=@coverStatus", new object[] { block, file.AimFile, 3, coverStatus });
        }
        #endregion

        #region 记录系统单文件覆盖失败
        /// <summary>
        /// 记录系统单文件覆盖失败
        /// </summary>
        /// <param name="file"></param>
        /// <param name="block"></param>
        /// <param name="errorServer"></param>
        /// <param name="coverStatus"></param>
        public static void FileCoverFail(TaskFileInfo file, string block, string errorServer, string coverStatus)
        {
            Trans.Db.Data.NBlock_Task.Update("BlockCode=@block and FilePath=@filepath", "Status=@Status,coverStatus=@coverStatus,ErrorServer=@ErrorServer", new object[] { block, file.AimFile, -3, coverStatus, errorServer });
        }
        #endregion

        #region 记录任务单文件回滚失败
        /// <summary>
        /// 记录任务单文件回滚失败
        /// </summary>
        /// <param name="file"></param>
        /// <param name="block"></param>
        /// <param name="errorServer"></param>
        /// <param name="coverStatus"></param>
        public static void FileRollBackFail(TaskFileInfo file, string block, string errorServer, string coverStatus)
        {
            Trans.Db.Data.NBlock_Info.Update("BlockCode=@block and FilePath=@filepath", "Status=@Status,coverStatus=@coverStatus,ErrorServer=@ErrorServer", new object[] { block, file.AimFile, -1, coverStatus, errorServer });
        }
        #endregion

        #region 记录任务单文件回滚成功
        /// <summary>
        /// 记录任务单文件回滚成功
        /// </summary>
        /// <param name="file"></param>
        /// <param name="block"></param>
        /// <param name="coverStatus"></param>
        public static void FileRollBackSuccess(TaskFileInfo file, string block, string coverStatus)
        {
            Trans.Db.Data.NBlock_Info.Update("BlockCode=@block and FilePath=@filepath", "Status=@Status,coverStatus=@coverStatus", new object[] { block, file.AimFile, 4, coverStatus });
        }
        #endregion

        #region 获取任务文件列表
        /// <summary>
        /// 获取任务文件列表
        /// </summary>
        /// <param name="block"></param>
        /// <param name="blockstatus"></param>
        /// <param name="starttime"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DataTable getTaskList(string block, out int blockstatus, out DateTime starttime, out string msg)
        {
            Trans.Db.Model.NBlock_Info BlockInfo = Trans.Db.Data.NBlock_Info.Get("BlockCode=@Block", "", new object[] { block }, true);
            if (BlockInfo.BlockCode != block)
            {
                starttime = new DateTime(1900, 1, 1);
                blockstatus = -1;
                msg = "";
                return null;
            }
            starttime = BlockInfo.StartTime;
            blockstatus = BlockInfo.Status;
            msg = "";
            if (BlockInfo.UploadSuccess.Year > 2000)
            {
                msg = msg + "上传完成于:" + BlockInfo.UploadSuccess.ToString("HH:mm:ss") + "<br/>";
            }
            if (BlockInfo.BackupSuccess.Year > 2000)
            {
                msg = msg + "备份完成于:" + BlockInfo.BackupSuccess.ToString("HH:mm:ss") + "<br/>";
            }
            if (BlockInfo.CoverSuccess.Year > 2000)
            {
                msg = msg + "覆盖完成于:" + BlockInfo.CoverSuccess.ToString("HH:mm:ss") + "<br/>";
            }
            if (BlockInfo.CancelTime.Year > 2000)
            {
                msg = msg + "用户取消于:" + BlockInfo.CancelTime.ToString("HH:mm:ss") + "<br/>";
            }
            if (BlockInfo.ErrorFinishTime.Year > 2000)
            {
                msg = msg + "出错取消于:" + BlockInfo.ErrorFinishTime.ToString("HH:mm:ss") + "<br/>";
            }
            return Trans.Db.Data.NBlock_Info.GetTable("BlockCode=@Block", "RowId ASC", "*", new object[] { block }, true);
        }
        #endregion

        #region 获取任务回滚文件列表
        /// <summary>
        /// 获取任务回滚文件列表
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public static DataTable getRollBackTaskList(string block)
        {
            return Trans.Db.Data.NBlock_Info.GetTable("BlockCode=@block and (status=3 or status=-3)", "RowID asc", "*", new object[] { block }, true);
        }
        #endregion

        #region 判定是否用户取消当前任务
        /// <summary>
        /// 判定是否用户取消当前任务
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public static bool IsTaskCancel(string block)
        {
            object StatusObj = Trans.Db.Data.NBlock_Info.GetSingle("Status", "BlockCode=@Block", "", new object[] { block }, true);
            if (StatusObj != null)
            {
                return StatusObj.ToString() == "4";
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 用户取消任务
        /// <summary>
        /// 用户取消任务
        /// </summary>
        /// <param name="block"></param>
        public static void TaskCancel(string block)
        {
            Trans.Db.Data.NBlock_Info.Update("BlockCode=@Block", "Status=@Status,CancelTime=@Time", new object[] { block, 4, DateTime.Now });
        }
        #endregion

        #region 记录任务上传成功
        /// <summary>
        /// 记录任务上传成功
        /// </summary>
        /// <param name="block"></param>
        public static void TaskBackuping(string block)
        {
            Trans.Db.Data.NBlock_Info.Update("BlockCode=@Block", "Status=@Status,UploadSuccess=@Time", new object[] { block, 5, DateTime.Now });
        }
        #endregion

        #region 记录任务备份成功
        /// <summary>
        /// 记录任务备份成功
        /// </summary>
        /// <param name="block"></param>
        public static void TaskCovering(string block)
        {
            Trans.Db.Data.NBlock_Info.Update("BlockCode=@Block", "Status=@Status,BackupSuccess=@Time", new object[] { block, 6, DateTime.Now });
        }
        #endregion

        #region 获取任务文件状态
        /// <summary>
        /// 获取任务文件状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string getFileStatus(int status)
        {
            string str = "未追踪";
            switch (status)
            {
                case -4:
                    str = "回滚失败";
                    break;
                case -3:
                    str = "覆盖失败";
                    break;
                case -2:
                    str = "备份失败";
                    break;
                case -1:
                    str = "上传失败";
                    break;
                case 0:
                    str = "未处理";
                    break;
                case 1:
                    str = "上传成功";
                    break;
                case 2:
                    str = "备份成功";
                    break;
                case 3:
                    str = "覆盖成功";
                    break;
                case 4:
                    str = "回滚成功";
                    break;
            }
            return str;
        }
        #endregion

        #region 获取任务状态
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetTaskStatus(int status)
        {
            string str = "未追踪";
            switch (status)
            {
                case 0:
                    str = "未处理";
                    break;
                case 1:
                    str = "上传中";
                    break;
                case 2:
                    str = "处理成功";
                    break;
                case 3:
                    str = "处理失败";
                    break;
                case 4:
                    str = "用户取消";
                    break;
                case 5:
                    str = "备份中";
                    break;
                case 6:
                    str = "覆盖中";
                    break;
            }
            return str;
        }
        #endregion
    }
}