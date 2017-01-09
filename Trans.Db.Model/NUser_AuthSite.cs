using System;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Web.Script.Serialization;

namespace Trans.Db.Model
{
	/// <summary>
	/// ����ʵ����:NUser_AuthSite
	/// </summary>
	[Serializable]
	public class NUser_AuthSite : ORM.Base.ModelBase
	{
		#region ����
		private static string _tablename = "NUser_AuthSite";
		/// <summary>
		/// ����
		/// </summary>
		[JsonIgnore]
		[ScriptIgnore]
		public string TableName { get { return _tablename; } }
		#endregion

		#region ʵ������
		private static string _typeName = "Trans.Db.Model.NUser_AuthSite";
		#endregion

		#region �����б�
		private static List<string> _cols = new List<string>() { "ID", "USERID", "SITENAME", "ALLOWLIST", "ALLOWSYNC", "ALLOWROLL", "ISDEL", "CREATETIME" };
		/// <summary>
		/// �����б�
		/// </summary>
		[JsonIgnore]
		[ScriptIgnore]
		public List<string> ColList { get { return _cols; } }
		#endregion

		#region �ֶΡ�����
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		public Int32 ID
		{
			get{ return this._ID;}
			set{ this._ID = value; ModifiedColumns.Add("[ID]"); }
		}
		private Int32 _ID = 0;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		public Int32 UserID
		{
			get{ return this._UserID;}
			set{ this._UserID = value; ModifiedColumns.Add("[UserID]"); }
		}
		private Int32 _UserID = 0;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		public string SiteName
		{
			get{ return this._SiteName;}
			set{ this._SiteName = value; ModifiedColumns.Add("[SiteName]"); }
		}
		private string _SiteName = "";
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		public Int32 AllowList
		{
			get{ return this._AllowList;}
			set{ this._AllowList = value; ModifiedColumns.Add("[AllowList]"); }
		}
		private Int32 _AllowList = 0;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		public Int32 AllowSync
		{
			get{ return this._AllowSync;}
			set{ this._AllowSync = value; ModifiedColumns.Add("[AllowSync]"); }
		}
		private Int32 _AllowSync = 0;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		public Int32 AllowRoll
		{
			get{ return this._AllowRoll;}
			set{ this._AllowRoll = value; ModifiedColumns.Add("[AllowRoll]"); }
		}
		private Int32 _AllowRoll = 0;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[JsonIgnore]
		[ScriptIgnore]
		public Int32 IsDel
		{
			get{ return this._IsDel;}
			set{ this._IsDel = value; ModifiedColumns.Add("[IsDel]"); }
		}
		private Int32 _IsDel = 0;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		public DateTime CreateTime
		{
			get{ return this._CreateTime;}
			set{ this._CreateTime = value; ModifiedColumns.Add("[CreateTime]"); }
		}
		private DateTime _CreateTime = DateTime.Now;
		#endregion

		#region ���캯��
		/// <summary>
		/// ���캯��
		/// </summary>
		public NUser_AuthSite()
		{
			_ConnectionMark = "TRANS";
			_tabinfo = TableInfo;
			base.Init();
		}
		[ScriptIgnore]
		public static ORM.Base.TabInfo TableInfo = new ORM.Base.TabInfo()
		{
			TableName = _tablename,
			ColList = _cols,
			TypeName = _typeName,
			AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().Location
		};
		/// <summary>
		/// ���캯��,��ʼ��һ������
		/// </summary>
		public NUser_AuthSite(DataRow dr) : this()
		{
			if (dr != null && dr.Table.Columns.Contains("ID") && !(dr["ID"] is DBNull))
			{
				this._ID = Convert.ToInt32(dr["ID"]);
			}
			if (dr != null && dr.Table.Columns.Contains("UserID") && !(dr["UserID"] is DBNull))
			{
				this._UserID = Convert.ToInt32(dr["UserID"]);
			}
			if (dr != null && dr.Table.Columns.Contains("SiteName") && !(dr["SiteName"] is DBNull))
			{
				this._SiteName = Convert.ToString(dr["SiteName"]);
			}
			if (dr != null && dr.Table.Columns.Contains("AllowList") && !(dr["AllowList"] is DBNull))
			{
				this._AllowList = Convert.ToInt32(dr["AllowList"]);
			}
			if (dr != null && dr.Table.Columns.Contains("AllowSync") && !(dr["AllowSync"] is DBNull))
			{
				this._AllowSync = Convert.ToInt32(dr["AllowSync"]);
			}
			if (dr != null && dr.Table.Columns.Contains("AllowRoll") && !(dr["AllowRoll"] is DBNull))
			{
				this._AllowRoll = Convert.ToInt32(dr["AllowRoll"]);
			}
			if (dr != null && dr.Table.Columns.Contains("IsDel") && !(dr["IsDel"] is DBNull))
			{
				this._IsDel = Convert.ToInt32(dr["IsDel"]);
			}
			if (dr != null && dr.Table.Columns.Contains("CreateTime") && !(dr["CreateTime"] is DBNull))
			{
				this._CreateTime = Convert.ToDateTime(dr["CreateTime"]);
			}
		}
		#endregion
		#region ���޸��ֶ�����
		[ScriptIgnore]
		public HashSet<string> ModifiedColumns = new HashSet<string>();
		#endregion

	}
}
