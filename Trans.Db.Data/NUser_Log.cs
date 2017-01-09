using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using System.Xml;
using Trans.Db.Model;
using Trans.Db.DBUtility;

namespace Trans.Db.Data
{
	/// <summary>
	/// ���ݿ����:NUser_Log
	/// </summary>
	public class NUser_Log
	{
		/// <summary>
		/// Ĭ�ϲ�ѯ�Ƿ���ֻ����
		/// </summary>
		public static bool ReadOnlyDataSource = true;
		#region ��ѯ
		#region ��ѯ���������ݱ�
		/// <summary>
		/// ��ѯ���������ݱ�
		/// </summary>
		/// <param name="sqlWhere">��ѯ�������ɴ���������username='123' and usertype=@usertype</param>
		/// <param name="sqlSort">������ date desc,id asc</param>
		/// <param name="sqlCols">��Ҫ��ѯ���ֶ��б�,��:ID,Name,CreateTime,Ĭ��*��ձ�ʶȫ���ֶ�</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static DataTable GetTable(string sqlWhere = "", string sqlSort = "", string sqlCols = "*", object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			DataTable table = new DataTable();
			string txtCols = sqlCols;
			if (string.IsNullOrEmpty(sqlCols))
			{
				txtCols = "*";
			}
			StringBuilder sql = new StringBuilder("SELECT " + sqlCols + " FROM [NUser_Log](NOLOCK)");
			if (!string.IsNullOrEmpty(sqlWhere))
			{
				sql.Append(" WHERE ").Append(sqlWhere);
			}
			if (!string.IsNullOrEmpty(sqlSort))
			{
				sql.Append(" ORDER BY ").Append(sqlSort);
			}
			SqlCommand cmd = BuildCommand(sql.ToString(), ParamsList);
			table = new Trans.Db.DBUtility.DBHelper(ReadOnlyDataSource).ExecDataTable(cmd);
			if (table == null)
			{
				table = new DataTable();
			}
			table.TableName = "table";
			return table;
		}
		#endregion

		#region ��ѯ�����ض����б�
		/// <summary>
		/// ��ѯ�����ض����б�
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and usertype=@usertype��distinct userid,username</param>
		/// <param name="sqlSort">������ date desc,id asc</param>
		/// <param name="sqlCols">��Ҫ��ѯ���ֶ��б�,��:ID,Name,CreateTime,Ĭ��*��ձ�ʶȫ���ֶ�</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static List<T> GetList<T>(string sqlWhere = "", string sqlSort = "", string sqlCols = "*", object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			DataTable table = GetTable(sqlWhere, sqlSort, sqlCols, ParamsList, ReadOnlyDataSource);
			List<T> rtnObjList = new List<T>();
			if (table != null && table.Rows.Count > 0)
			{
				foreach (DataRow dr in table.Rows)
				{
					rtnObjList.Add((T)System.Activator.CreateInstance(typeof(T), dr));
				}
			}
			return rtnObjList;
		}
		#endregion

		#region ��ѯ�����ض����б�
		/// <summary>
		/// ��ѯ�����ض����б�
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and usertype=@usertype</param>
		/// <param name="sqlSort">������ date desc,id asc</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static List<Trans.Db.Model.NUser_Log> GetList(string sqlWhere = "", string sqlSort = "", object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			DataTable table = GetTable(sqlWhere, sqlSort, "*", ParamsList, ReadOnlyDataSource);
			List<Trans.Db.Model.NUser_Log> rtnObjList = new List<Trans.Db.Model.NUser_Log>();
			if (table != null && table.Rows.Count > 0)
			{
				foreach (DataRow dr in table.Rows)
				{
					rtnObjList.Add(new Trans.Db.Model.NUser_Log(dr));
				}
			}
			return rtnObjList;
		}
		#endregion

		#region ��ҳ��ѯ
		/// <summary>
		/// ��ҳ��ѯ
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123'</param>
		/// <param name="sqlSort">��������,��username desc</param>
		/// <param name="sqlCols">���ݿ��ֶ�����,�ö��ŷָ�,����:username,userpwd,userid</param>
		/// <param name="pageIndex">ҳ��</param>
		/// <param name="pageSize">ҳ��С</param>
		/// <param name="recordCount">��¼����</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static List<Trans.Db.Model.NUser_Log> GetList(string sqlWhere, string sqlSort, string sqlCols, int pageIndex, int pageSize, out int recordCount, object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			long LRecordCount = 0;
			DataTable table = GetTable(sqlWhere, sqlSort, sqlCols, pageIndex, pageSize, out LRecordCount, ParamsList, ReadOnlyDataSource);
			recordCount = Convert.ToInt32(LRecordCount);
			List<Trans.Db.Model.NUser_Log> rtnObjList = new List<Trans.Db.Model.NUser_Log>();
			if (table != null && table.Rows.Count > 0)
			{
				foreach (DataRow dr in table.Rows)
				{
					rtnObjList.Add(new Trans.Db.Model.NUser_Log(dr));
				}
			}
			return rtnObjList;
		}
		#endregion

		#region ��ҳ��ѯ
		/// <summary>
		/// ��ҳ��ѯ
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123'</param>
		/// <param name="sqlSort">��������,��username desc</param>
		/// <param name="sqlCols">���ݿ��ֶ�����,�ö��ŷָ�,����:username,userpwd,userid</param>
		/// <param name="pageIndex">ҳ��</param>
		/// <param name="pageSize">ҳ��С</param>
		/// <param name="recordCount">��¼����</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static List<Trans.Db.Model.NUser_Log> GetList(string sqlWhere, string sqlSort, string sqlCols, int pageIndex, int pageSize, out long recordCount, object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			long LRecordCount = 0;
			DataTable table = GetTable(sqlWhere, sqlSort, sqlCols, pageIndex, pageSize, out LRecordCount, ParamsList, ReadOnlyDataSource);
			recordCount = Convert.ToInt64(LRecordCount);
			List<Trans.Db.Model.NUser_Log> rtnObjList = new List<Trans.Db.Model.NUser_Log>();
			if (table != null && table.Rows.Count > 0)
			{
				foreach (DataRow dr in table.Rows)
				{
					rtnObjList.Add(new Trans.Db.Model.NUser_Log(dr));
				}
			}
			return rtnObjList;
		}
		#endregion

		#region ��������:LogId ��ѯ
		/// <summary>
		/// ��������:LogId ��ѯ
		/// </summary>
		/// <param name="LogId"></param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static DataTable GetTableByLogId(Int64 _LogId, bool ReadOnlyDataSource = true)
		{
			DataTable table = new DataTable();
			string sql = "SELECT * FROM NUser_Log(NOLOCK) WHERE [LogId]=@LogId";
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = sql;
			cmd.Parameters.Add("@LogId", System.Data.SqlDbType.BigInt).Value = _LogId;
			table = new Trans.Db.DBUtility.DBHelper(ReadOnlyDataSource).ExecDataTable(cmd);
			if (table == null)
			{
				table = new DataTable();
			}
			table.TableName = "table";
			return table;
		}
		#endregion

		#region ��������:LogId ��ѯ�����ض����б�
		/// <summary>
		/// ��������:LogId ��ѯ�����ض����б�
		/// </summary>
		/// <param name="LogId"></param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static List<Trans.Db.Model.NUser_Log> GetListByLogId(Int64 _LogId, bool ReadOnlyDataSource = true)
		{
			DataTable table = GetTableByLogId(_LogId, ReadOnlyDataSource);
			List<Trans.Db.Model.NUser_Log> objList = new List<Trans.Db.Model.NUser_Log>();
			if (table != null && table.Rows.Count > 0)
			{
				foreach (DataRow dr in table.Rows)
				{
					objList.Add(new Trans.Db.Model.NUser_Log(dr));
				}
			}
			return objList;
		}
		#endregion

		#region ��ѯĳ�ֶ����ݵ�һ�е�һ������
		/// <summary>
		/// ������ѯ,��ѯĳ�ֶ����ݵ�һ�е�һ������
		/// </summary>
		/// <param name="sqlCol">���ݿ��ֶ���,Ҳ����ΪCOUNT(),TOP 1 ����</param>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123' and usertype=@usertype</param>
		/// <param name="sqlSort">������ date desc,id asc</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static object GetSingle(string sqlCol, string sqlWhere = "", string sqlSort = "", object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			StringBuilder sql = new StringBuilder("SELECT TOP 1 " + sqlCol + " FROM NUser_Log(NOLOCK)");
			if (!string.IsNullOrEmpty(sqlWhere))
			{
				sql.Append(" WHERE ").Append(sqlWhere);
			}
			if (!string.IsNullOrEmpty(sqlSort))
			{
				sql.Append(" ORDER BY ").Append(sqlSort);
			}
			SqlCommand cmd = BuildCommand(sql.ToString(), ParamsList);
			return new Trans.Db.DBUtility.DBHelper(ReadOnlyDataSource).ExecScalar(cmd);
		}
		#endregion

		#region ������ѯ,��ѯ��¼����
		/// <summary>
		/// ��ѯ��¼����
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123',���ɴ���������</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static long CountOutLong(string sqlWhere, object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			StringBuilder sql = new StringBuilder("SELECT COUNT(1) FROM NUser_Log(NOLOCK) WHERE 1=1");
			if (!string.IsNullOrEmpty(sqlWhere))
			{
				sql.Append(" AND ").Append(sqlWhere);
			}
			SqlCommand cmd = BuildCommand(sql.ToString(), ParamsList);
			object CountObj = new Trans.Db.DBUtility.DBHelper(ReadOnlyDataSource).ExecScalar(cmd);
			long RtnCount = 0;
			if (CountObj != null && CountObj != DBNull.Value && !string.IsNullOrEmpty(CountObj.ToString()))
			{
				long.TryParse(CountObj.ToString(), out RtnCount);
			}
			return RtnCount;
		}
		#endregion

		#region ������ѯ,��ѯ��¼����
		/// <summary>
		/// ������ѯ,��ѯ��¼����
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123',���ɴ���������</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static int Count(string sqlWhere, object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			long rtnInt= CountOutLong(sqlWhere, ParamsList, ReadOnlyDataSource);
			return Convert.ToInt32(rtnInt);
		}
		#endregion

		#region ��ҳ��ѯ
		/// <summary>
		/// ��ҳ��ѯ
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123'</param>
		/// <param name="sqlSort">��������,��username desc</param>
		/// <param name="sqlCols">���ݿ��ֶ�����,�ö��ŷָ�,����:username,userpwd,userid</param>
		/// <param name="pageIndex">ҳ��</param>
		/// <param name="pageSize">ҳ��С</param>
		/// <param name="recordCount">��¼����</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static DataTable GetTable(string sqlWhere, string sqlSort, string sqlCols, int pageIndex, int pageSize, out int recordCount, object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			long LRecordCount = 0;
			DataTable table = GetTable(sqlWhere, sqlSort, sqlCols, pageIndex, pageSize, out LRecordCount, ParamsList, ReadOnlyDataSource);
			recordCount = Convert.ToInt32(LRecordCount);
			return table;
		}
		#endregion

		#region ��ҳ��ѯ
		/// <summary>
		/// ��ҳ��ѯ
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123'</param>
		/// <param name="sqlSort">��������,��username desc</param>
		/// <param name="sqlCols">���ݿ��ֶ�����,�ö��ŷָ�,����:username,userpwd,userid</param>
		/// <param name="pageIndex">ҳ��</param>
		/// <param name="pageSize">ҳ��С</param>
		/// <param name="recordCount">��¼����</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static DataTable GetTable(string sqlWhere, string sqlSort, string sqlCols, int pageIndex, int pageSize, out long recordCount, object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			int SI = pageIndex * pageSize - pageSize + 1;
			int EI = pageIndex * pageSize;
			DataSet ds = new DataSet();
			if (string.IsNullOrEmpty(sqlCols) || sqlCols == "*")
			{
				sqlCols = "LogId,UserId,Action,Content,IsDel,CreateTime";
			}
			StringBuilder sql = new StringBuilder("WITH PST(RN," + sqlCols + ") AS");
			sql.Append("(");
			sql.Append("SELECT ROW_NUMBER() OVER(ORDER BY ").Append(sqlSort).Append(") RN,").Append(sqlCols).Append(" ");
			sql.Append("FROM NUser_Log(NOLOCK)");
			if (!string.IsNullOrEmpty(sqlWhere))
			{
				sql.Append(" WHERE ").Append(sqlWhere);
			}
			sql.Append(")");
			sql.Append("SELECT RN,").Append(sqlCols).Append(" FROM PST WHERE RN BETWEEN @SI AND @EI");
			object[] NewParamsList;
			if (ParamsList != null)
			{
				NewParamsList = new object[ParamsList.Length + 2];
				for (int i = 0;i < ParamsList.Length; i++)
				{
					NewParamsList[i] = ParamsList[i];
				}
				NewParamsList[ParamsList.Length] = SI;
				NewParamsList[ParamsList.Length + 1] = EI;
			}
			else
			{
				NewParamsList = new object[2];
				NewParamsList[0] = SI;
				NewParamsList[1] = EI;
			}
			if (!string.IsNullOrEmpty(sqlWhere))
			{
				sql.Append(";SELECT COUNT(1) FROM NUser_Log(NOLOCK) WHERE ").Append(sqlWhere);
			}
			else
			{
				sql.Append(";SELECT COUNT(1) FROM NUser_Log(NOLOCK)");
			}
			SqlCommand cmd = BuildCommand(sql.ToString(), NewParamsList);
			ds = new Trans.Db.DBUtility.DBHelper(ReadOnlyDataSource).ExecDataSet(cmd);
			if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count >0)
			{
				recordCount = Convert.ToInt64(ds.Tables[1].Rows[0][0]);
			}
			else
			{
				recordCount = 0;
			}
			if (ds != null && ds.Tables.Count >1)
			{
				return ds.Tables[0];
			}
			else
			{
				return new DataTable();
			}
		}
		#endregion

		#region ��ѯ����������,���ص�һ������
		/// <summary>
		/// ��ѯ����������,���ص�һ������
		/// </summary>
		/// <param name="sqlWhere">��ѯ����</param>
		/// <param name="sqlSort">��������</param>
		/// <param name="ParamsList">����ֵ�б�����sqlWhere��˳���Ӧ����ͬ����ֻ�ṩһ�Σ��� {"123",1}</param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static Trans.Db.Model.NUser_Log Get(string sqlWhere, string sqlSort = "", object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			StringBuilder sql = new StringBuilder("SELECT TOP 1 * FROM NUser_Log(NOLOCK)");
			if (!string.IsNullOrEmpty(sqlWhere))
			{
				sql.Append(" WHERE ").Append(sqlWhere);
			}
			if (!string.IsNullOrEmpty(sqlSort))
			{
				sql.Append(" ORDER BY ").Append(sqlSort);
			}
			SqlCommand cmd = BuildCommand(sql.ToString(), ParamsList);
			DataTable DT = new Trans.Db.DBUtility.DBHelper(ReadOnlyDataSource).ExecDataTable(cmd);
			if(DT != null && DT.Rows.Count > 0)
			{
				return new Trans.Db.Model.NUser_Log(DT.Rows[0]);
			}
			else
			{
				return new Trans.Db.Model.NUser_Log();
			}
		}
		#endregion
		#endregion

		#region ɾ��
		/// <summary>
		/// ɾ�����ݣ�����ɾ����Delete
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123'</param>
		/// <returns></returns>
		public static int DBDelete(string sqlWhere, object[] ParamsList = null, bool IsRowLock = true)
		{
			string deleteSql = string.Empty;
			if (IsRowLock)
			{
				deleteSql = "DELETE FROM NUser_Log WITH(ROWLOCK) WHERE ";
			}
			else
			{
				deleteSql = "DELETE FROM NUser_Log WHERE ";
			}
			StringBuilder sql = new StringBuilder(deleteSql);
			sql.Append(sqlWhere);
			SqlCommand cmd = BuildCommand(sql.ToString(), ParamsList);
			return new Trans.Db.DBUtility.DBHelper(false).ExecNonQuery(cmd);
		}

		/// <summary>
		/// ɾ�����ݣ��߼�ɾ����IsDel=1
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123'</param>
		/// <returns></returns>
		public static int Delete(string sqlWhere, object[] ParamsList = null)
		{
			StringBuilder sql = new StringBuilder("UPDATE NUser_Log SET IsDel=1 WHERE ");
			sql.Append(sqlWhere);
			SqlCommand cmd = BuildCommand(sql.ToString(), ParamsList);
			return new Trans.Db.DBUtility.DBHelper(false).ExecNonQuery(cmd);
		}
		#endregion

		#region ����
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="sqlWhere">��ѯ��������username='123' and password='123'</param>
		/// <param name="sqlSet">�������ã���username='123',password='123'</param>
		/// <returns></returns>
		public static int Update(string sqlWhere, string sqlSet, object[] ParamsList = null)
		{
			StringBuilder sql = new StringBuilder("UPDATE NUser_Log SET ");
			sql.Append(sqlSet).Append(" WHERE ").Append(sqlWhere);
			SqlCommand cmd = BuildCommand(sqlWhere + " " + sqlSet, ParamsList);
			cmd.CommandText = sql.ToString();
			return new Trans.Db.DBUtility.DBHelper(false).ExecNonQuery(cmd);
		}

		/// <summary>
		/// �������ݣ�����ָ��XML��
		/// </summary>
		/// <param name="sqlWhere">����</param>
		/// <param name="whereParamsList">��������</param>
		/// <param name="xmlCol">XML������</param>
		/// <param name="XmlContent">XML����</param>
		/// <returns></returns>
		public static int UpdateXml(string sqlWhere, object[] whereParamsList, string xmlCol, string XmlContent)
		{
			StringBuilder sql = new StringBuilder("UPDATE Product_Info SET {0} ");
			sql.Append(" WHERE ").Append(sqlWhere);
			SqlCommand cmd = BuildCommand(sql.ToString(), whereParamsList);
			if (xmlCol.Contains("["))
			{
				cmd.CommandText = string.Format(sql.ToString(), xmlCol + "=@" + xmlCol);
			}
			else
			{
				cmd.CommandText = string.Format(sql.ToString(), "[" + xmlCol + "]=@" + xmlCol);
			}
			cmd.Parameters.Add("@" + xmlCol, SqlDbType.Xml).Value = new SqlXml(new XmlTextReader(XmlContent, XmlNodeType.Document, null));
			return new Trans.Db.DBUtility.DBHelper(false).ExecNonQuery(cmd);
		}
		/// <summary>
		/// ��������
		/// ���أ�����Ӱ���¼����-1��ʾû����Ҫ���µ���
		/// </summary>
		/// <param name="NUser_Log_obj"></param>
		/// <returns></returns>
		public static int Update(Trans.Db.Model.NUser_Log NUser_Log_obj)
		{
			if(NUser_Log_obj.ModifiedColumns.Count <= 0)
			{
				return -1;
			}
			StringBuilder sqlSet = new StringBuilder();
			StringBuilder sqlWhere = new StringBuilder();
			string sql = "UPDATE NUser_Log SET {0} WHERE {1}";
			SqlCommand cmd = new SqlCommand();
			cmd.Parameters.AddWithValue("@LogId", NUser_Log_obj.LogId);
			cmd.Parameters["@LogId"].SqlDbType = System.Data.SqlDbType.BigInt;
			if (sqlWhere.Length > 0)
			{
				sqlWhere.Append(" AND ");
			}
			sqlWhere.Append("[LogId]=@LogId");
			if(NUser_Log_obj.ModifiedColumns.Contains("[UserId]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[UserId]=@UserId");
				cmd.Parameters.AddWithValue("@UserId", NUser_Log_obj.UserId);
				cmd.Parameters["@UserId"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if(NUser_Log_obj.ModifiedColumns.Contains("[Action]"))
			{
				if (string.IsNullOrEmpty(NUser_Log_obj.Action))
				{
					NUser_Log_obj.Action = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[Action]=@Action");
				cmd.Parameters.AddWithValue("@Action", NUser_Log_obj.Action);
				cmd.Parameters["@Action"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NUser_Log_obj.ModifiedColumns.Contains("[Content]"))
			{
				if (string.IsNullOrEmpty(NUser_Log_obj.Content))
				{
					NUser_Log_obj.Content = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[Content]=@Content");
				cmd.Parameters.AddWithValue("@Content", NUser_Log_obj.Content);
				cmd.Parameters["@Content"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NUser_Log_obj.ModifiedColumns.Contains("[IsDel]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[IsDel]=@IsDel");
				cmd.Parameters.AddWithValue("@IsDel", NUser_Log_obj.IsDel);
				cmd.Parameters["@IsDel"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if (NUser_Log_obj.CreateTime != null && NUser_Log_obj.CreateTime > DateTime.MinValue && NUser_Log_obj.ModifiedColumns.Contains("[CreateTime]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[CreateTime]=@CreateTime");
				cmd.Parameters.AddWithValue("@CreateTime", NUser_Log_obj.CreateTime);
				cmd.Parameters["@CreateTime"].SqlDbType = System.Data.SqlDbType.DateTime2;
			}
			sql = string.Format(sql, sqlSet.ToString(), sqlWhere.ToString());
			cmd.CommandText = sql;
			try
			{
				return new Trans.Db.DBUtility.DBHelper(false).ExecNonQuery(cmd);
			}
			catch { return -1; }
		}

		/// <summary>
		/// �������ݣ��м���������
		/// ���أ�����Ӱ���¼����-1��ʾû����Ҫ���µ���
		/// </summary>
		/// <param name="NUser_Log_obj"></param>
		/// <param name="IsRowLock">�Ƿ�����</param>
		/// <returns></returns>
		public static int Update(Trans.Db.Model.NUser_Log NUser_Log_obj, bool IsRowLock)
		{
			if(NUser_Log_obj.ModifiedColumns.Count <= 0)
			{
				return -1;
			}
			StringBuilder sqlSet = new StringBuilder();
			StringBuilder sqlWhere = new StringBuilder();
			string sql = string.Empty;
			if (IsRowLock)
			{
				sql = "UPDATE NUser_Log WITH(ROWLOCK) SET {0} WHERE {1}";
			}
			else
			{
				sql = "UPDATE NUser_Log SET {0} WHERE {1}";
			}
			SqlCommand cmd = new SqlCommand();
			cmd.Parameters.AddWithValue("@LogId", NUser_Log_obj.LogId);
			cmd.Parameters["@LogId"].SqlDbType = System.Data.SqlDbType.BigInt;
			if (sqlWhere.Length > 0)
			{
				sqlWhere.Append(" AND ");
			}
			sqlWhere.Append("[LogId]=@LogId");
			if(NUser_Log_obj.ModifiedColumns.Contains("[UserId]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[UserId]=@UserId");
				cmd.Parameters.AddWithValue("@UserId", NUser_Log_obj.UserId);
				cmd.Parameters["@UserId"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if(NUser_Log_obj.ModifiedColumns.Contains("[Action]"))
			{
				if (string.IsNullOrEmpty(NUser_Log_obj.Action))
				{
					NUser_Log_obj.Action = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[Action]=@Action");
				cmd.Parameters.AddWithValue("@Action", NUser_Log_obj.Action);
				cmd.Parameters["@Action"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NUser_Log_obj.ModifiedColumns.Contains("[Content]"))
			{
				if (string.IsNullOrEmpty(NUser_Log_obj.Content))
				{
					NUser_Log_obj.Content = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[Content]=@Content");
				cmd.Parameters.AddWithValue("@Content", NUser_Log_obj.Content);
				cmd.Parameters["@Content"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NUser_Log_obj.ModifiedColumns.Contains("[IsDel]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[IsDel]=@IsDel");
				cmd.Parameters.AddWithValue("@IsDel", NUser_Log_obj.IsDel);
				cmd.Parameters["@IsDel"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if (NUser_Log_obj.CreateTime != null && NUser_Log_obj.CreateTime > DateTime.MinValue && NUser_Log_obj.ModifiedColumns.Contains("[CreateTime]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[CreateTime]=@CreateTime");
				cmd.Parameters.AddWithValue("@CreateTime", NUser_Log_obj.CreateTime);
				cmd.Parameters["@CreateTime"].SqlDbType = System.Data.SqlDbType.DateTime2;
			}
			sql = string.Format(sql, sqlSet.ToString(), sqlWhere.ToString());
			cmd.CommandText = sql;
			try
			{
				return new Trans.Db.DBUtility.DBHelper(false).ExecNonQuery(cmd);
			}
			catch { return -1; }
		}
		#endregion

		#region ����
		/// <summary>
		/// ��������
		/// </summary>
		/// <returns></returns>
		public static bool insert( Trans.Db.Model.NUser_Log NUser_Log_obj)
		{
			SqlCommand cmd = new SqlCommand();
			StringBuilder cols = new StringBuilder();
			StringBuilder parameters = new StringBuilder();
			string sql = "INSERT INTO NUser_Log({0}) values({1})";
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[UserId]");
			parameters.Append("@UserId");
			cmd.Parameters.AddWithValue("@UserId", NUser_Log_obj.UserId);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[Action]");
			parameters.Append("@Action");
			if (!string.IsNullOrEmpty(NUser_Log_obj.Action))
			{
				cmd.Parameters.AddWithValue("@Action", NUser_Log_obj.Action);
			}
			else
			{
				cmd.Parameters.AddWithValue("@Action", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[Content]");
			parameters.Append("@Content");
			if (!string.IsNullOrEmpty(NUser_Log_obj.Content))
			{
				cmd.Parameters.AddWithValue("@Content", NUser_Log_obj.Content);
			}
			else
			{
				cmd.Parameters.AddWithValue("@Content", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[IsDel]");
			parameters.Append("@IsDel");
			cmd.Parameters.AddWithValue("@IsDel", NUser_Log_obj.IsDel);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[CreateTime]");
			parameters.Append("@CreateTime");
			if(NUser_Log_obj.CreateTime == null || NUser_Log_obj.CreateTime == DateTime.MinValue)
			{
				cmd.Parameters.AddWithValue("@CreateTime", DateTime.Now);
			}
			else
			{
				cmd.Parameters.AddWithValue("@CreateTime", NUser_Log_obj.CreateTime);
			}
			sql = string.Format(sql, cols.ToString(), parameters.ToString());
			cmd.CommandText = sql;
			bool b = true;
			try
			{
				int QueryCount = new Trans.Db.DBUtility.DBHelper(false).ExecNonQuery(cmd);
				if (QueryCount < 1)
				{
					b = false;
				}
			}
			catch { b = false; }
			return b;
		}

		/// <summary>
		/// ��������,����������ID
		/// </summary>
		/// <returns></returns>
		public static bool Add( Trans.Db.Model.NUser_Log NUser_Log_obj, out Int64 LogId)
		{
			LogId = 0;
			SqlCommand cmd = new SqlCommand();
			StringBuilder cols = new StringBuilder();
			StringBuilder parameters = new StringBuilder();
			string sql = "INSERT INTO NUser_Log({0}) values({1});SELECT @@IDENTITY;";
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[UserId]");
			parameters.Append("@UserId");
			cmd.Parameters.AddWithValue("@UserId", NUser_Log_obj.UserId);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[Action]");
			parameters.Append("@Action");
			if (!string.IsNullOrEmpty(NUser_Log_obj.Action))
			{
				cmd.Parameters.AddWithValue("@Action", NUser_Log_obj.Action);
			}
			else
			{
				cmd.Parameters.AddWithValue("@Action", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[Content]");
			parameters.Append("@Content");
			if (!string.IsNullOrEmpty(NUser_Log_obj.Content))
			{
				cmd.Parameters.AddWithValue("@Content", NUser_Log_obj.Content);
			}
			else
			{
				cmd.Parameters.AddWithValue("@Content", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[IsDel]");
			parameters.Append("@IsDel");
			cmd.Parameters.AddWithValue("@IsDel", NUser_Log_obj.IsDel);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[CreateTime]");
			parameters.Append("@CreateTime");
			if(NUser_Log_obj.CreateTime == null || NUser_Log_obj.CreateTime == DateTime.MinValue)
			{
				cmd.Parameters.AddWithValue("@CreateTime", DateTime.Now);
			}
			else
			{
				cmd.Parameters.AddWithValue("@CreateTime", NUser_Log_obj.CreateTime);
			}
			sql = string.Format(sql, cols.ToString(), parameters.ToString());
			cmd.CommandText = sql;
			bool b = true;
			try
			{
				object idobj = new Trans.Db.DBUtility.DBHelper(false).ExecScalar(cmd);
				LogId = Convert.ToInt64(idobj);
				if (LogId == 0)
				{
					b = false;
				}
			}
			catch { b = false; }
			return b;
		}
		#endregion

		#region ��ѯִ��������
		/// <summary>
		/// ��ѯִ��������
		/// </summary>
		/// <param name="sql">����SQL���</param>
		/// <param name="ParamsList">��ѡ�����б�</param>
		/// <returns></returns>
		private static SqlCommand BuildCommand(string sql, object[] ParamsList = null)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = sql;
			if (!string.IsNullOrEmpty(sql))
			{
				List<string> ParameterList = new List<string>();
				Regex reg = new Regex("(@[0-9a-zA-Z_]{1,30})", RegexOptions.IgnoreCase);
				MatchCollection mc = reg.Matches(sql);
				if (mc != null && mc.Count > 0)
				{
					foreach (Match m in mc)
					{
						if (!ParameterList.Contains(m.Groups[1].Value))
						{
							ParameterList.Add(m.Groups[1].Value);
						}
					}
				}
				if (ParameterList.Count > 0)
				{
					int i = 0;
					foreach (string ParameterName in ParameterList)
					{
						cmd.Parameters.AddWithValue(ParameterName, ParamsList[i]);
						i++;
					}
				}
			}
			return cmd;
		}
		#endregion

	}
}
