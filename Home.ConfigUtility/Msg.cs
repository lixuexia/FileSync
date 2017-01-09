using System;
using System.Collections.Generic;
using System.Text;

namespace Home.ConfigUtility
{
    public class Msg
    {
        private string msgContent;
        private string msgName;
        private bool msgResult;
        private DateTime msgTime;

        public Msg()
        {
            this.msgName = string.Empty;
            this.msgContent = string.Empty;
        }

        public Msg(string Name, string Content, DateTime Time, bool Result)
        {
            this.msgName = string.Empty;
            this.msgContent = string.Empty;
            this.msgName = Name;
            this.msgContent = Content;
            this.msgTime = Time;
            this.msgResult = Result;
        }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string MsgContent
        {
            get { return this.msgContent; }
            set { this.msgContent = value; }
        }
        /// <summary>
        /// 消息名称
        /// </summary>
        public string MsgName
        {
            get { return this.msgName; }
            set { this.msgName = value; }
        }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool MsgResult
        {
            get { return this.msgResult; }
            set { this.msgResult = value; }
        }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime MsgTime
        {
            get { return this.msgTime; }
            set { this.msgTime = value; }
        }
    }
}