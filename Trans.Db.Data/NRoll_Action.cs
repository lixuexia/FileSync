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
	/// ���ݿ����:NRoll_Action
	/// </summary>
	public class NRoll_Action
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
			StringBuilder sql = new StringBuilder("SELECT " + sqlCols + " FROM [NRoll_Action](NOLOCK)");
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
		public static List<Trans.Db.Model.NRoll_Action> GetList(string sqlWhere = "", string sqlSort = "", object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			DataTable table = GetTable(sqlWhere, sqlSort, "*", ParamsList, ReadOnlyDataSource);
			List<Trans.Db.Model.NRoll_Action> rtnObjList = new List<Trans.Db.Model.NRoll_Action>();
			if (table != null && table.Rows.Count > 0)
			{
				foreach (DataRow dr in table.Rows)
				{
					rtnObjList.Add(new Trans.Db.Model.NRoll_Action(dr));
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
		public static List<Trans.Db.Model.NRoll_Action> GetList(string sqlWhere, string sqlSort, string sqlCols, int pageIndex, int pageSize, out int recordCount, object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			long LRecordCount = 0;
			DataTable table = GetTable(sqlWhere, sqlSort, sqlCols, pageIndex, pageSize, out LRecordCount, ParamsList, ReadOnlyDataSource);
			recordCount = Convert.ToInt32(LRecordCount);
			List<Trans.Db.Model.NRoll_Action> rtnObjList = new List<Trans.Db.Model.NRoll_Action>();
			if (table != null && table.Rows.Count > 0)
			{
				foreach (DataRow dr in table.Rows)
				{
					rtnObjList.Add(new Trans.Db.Model.NRoll_Action(dr));
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
		public static List<Trans.Db.Model.NRoll_Action> GetList(string sqlWhere, string sqlSort, string sqlCols, int pageIndex, int pageSize, out long recordCount, object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			long LRecordCount = 0;
			DataTable table = GetTable(sqlWhere, sqlSort, sqlCols, pageIndex, pageSize, out LRecordCount, ParamsList, ReadOnlyDataSource);
			recordCount = Convert.ToInt64(LRecordCount);
			List<Trans.Db.Model.NRoll_Action> rtnObjList = new List<Trans.Db.Model.NRoll_Action>();
			if (table != null && table.Rows.Count > 0)
			{
				foreach (DataRow dr in table.Rows)
				{
					rtnObjList.Add(new Trans.Db.Model.NRoll_Action(dr));
				}
			}
			return rtnObjList;
		}
		#endregion

		#region ��������:ID ��ѯ
		/// <summary>
		/// ��������:ID ��ѯ
		/// </summary>
		/// <param name="ID"></param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static DataTable GetTableByID(Int64 _ID, bool ReadOnlyDataSource = true)
		{
			DataTable table = new DataTable();
			string sql = "SELECT * FROM NRoll_Action(NOLOCK) WHERE [ID]=@ID";
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = sql;
			cmd.Parameters.Add("@ID", System.Data.SqlDbType.BigInt).Value = _ID;
			table = new Trans.Db.DBUtility.DBHelper(ReadOnlyDataSource).ExecDataTable(cmd);
			if (table == null)
			{
				table = new DataTable();
			}
			table.TableName = "table";
			return table;
		}
		#endregion

		#region ��������:ID ��ѯ�����ض����б�
		/// <summary>
		/// ��������:ID ��ѯ�����ض����б�
		/// </summary>
		/// <param name="ID"></param>
		/// <param name="ReadOnlyDataSource">�Ƿ�ʹ��ֻ������Դ</param>
		/// <returns></returns>
		public static List<Trans.Db.Model.NRoll_Action> GetListByID(Int64 _ID, bool ReadOnlyDataSource = true)
		{
			DataTable table = GetTableByID(_ID, ReadOnlyDataSource);
			List<Trans.Db.Model.NRoll_Action> objList = new List<Trans.Db.Model.NRoll_Action>();
			if (table != null && table.Rows.Count > 0)
			{
				foreach (DataRow dr in table.Rows)
				{
					objList.Add(new Trans.Db.Model.NRoll_Action(dr));
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
			StringBuilder sql = new StringBuilder("SELECT TOP 1 " + sqlCol + " FROM NRoll_Action(NOLOCK)");
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
			StringBuilder sql = new StringBuilder("SELECT COUNT(1) FROM NRoll_Action(NOLOCK) WHERE 1=1");
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
				sqlCols = "ID,RollCode,ServerIP,ServerPort,ServerBakUri,ServerAimUri,SiteName,Op,IsUsed,AutoRollBack,BlockCode,YearVal,MonthVal,DayVal,IsDel,CreateTime";
			}
			StringBuilder sql = new StringBuilder("WITH PST(RN," + sqlCols + ") AS");
			sql.Append("(");
			sql.Append("SELECT ROW_NUMBER() OVER(ORDER BY ").Append(sqlSort).Append(") RN,").Append(sqlCols).Append(" ");
			sql.Append("FROM NRoll_Action(NOLOCK)");
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
				sql.Append(";SELECT COUNT(1) FROM NRoll_Action(NOLOCK) WHERE ").Append(sqlWhere);
			}
			else
			{
				sql.Append(";SELECT COUNT(1) FROM NRoll_Action(NOLOCK)");
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
		public static Trans.Db.Model.NRoll_Action Get(string sqlWhere, string sqlSort = "", object[] ParamsList = null, bool ReadOnlyDataSource = true)
		{
			StringBuilder sql = new StringBuilder("SELECT TOP 1 * FROM NRoll_Action(NOLOCK)");
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
				return new Trans.Db.Model.NRoll_Action(DT.Rows[0]);
			}
			else
			{
				return new Trans.Db.Model.NRoll_Action();
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
				deleteSql = "DELETE FROM NRoll_Action WITH(ROWLOCK) WHERE ";
			}
			else
			{
				deleteSql = "DELETE FROM NRoll_Action WHERE ";
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
			StringBuilder sql = new StringBuilder("UPDATE NRoll_Action SET IsDel=1 WHERE ");
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
			StringBuilder sql = new StringBuilder("UPDATE NRoll_Action SET ");
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
		/// <param name="NRoll_Action_obj"></param>
		/// <returns></returns>
		public static int Update(Trans.Db.Model.NRoll_Action NRoll_Action_obj)
		{
			if(NRoll_Action_obj.ModifiedColumns.Count <= 0)
			{
				return -1;
			}
			StringBuilder sqlSet = new StringBuilder();
			StringBuilder sqlWhere = new StringBuilder();
			string sql = "UPDATE NRoll_Action SET {0} WHERE {1}";
			SqlCommand cmd = new SqlCommand();
			cmd.Parameters.AddWithValue("@ID", NRoll_Action_obj.ID);
			cmd.Parameters["@ID"].SqlDbType = System.Data.SqlDbType.BigInt;
			if (sqlWhere.Length > 0)
			{
				sqlWhere.Append(" AND ");
			}
			sqlWhere.Append("[ID]=@ID");
			if(NRoll_Action_obj.ModifiedColumns.Contains("[RollCode]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.RollCode))
				{
					NRoll_Action_obj.RollCode = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[RollCode]=@RollCode");
				cmd.Parameters.AddWithValue("@RollCode", NRoll_Action_obj.RollCode);
				cmd.Parameters["@RollCode"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[ServerIP]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.ServerIP))
				{
					NRoll_Action_obj.ServerIP = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[ServerIP]=@ServerIP");
				cmd.Parameters.AddWithValue("@ServerIP", NRoll_Action_obj.ServerIP);
				cmd.Parameters["@ServerIP"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[ServerPort]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[ServerPort]=@ServerPort");
				cmd.Parameters.AddWithValue("@ServerPort", NRoll_Action_obj.ServerPort);
				cmd.Parameters["@ServerPort"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[ServerBakUri]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.ServerBakUri))
				{
					NRoll_Action_obj.ServerBakUri = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[ServerBakUri]=@ServerBakUri");
				cmd.Parameters.AddWithValue("@ServerBakUri", NRoll_Action_obj.ServerBakUri);
				cmd.Parameters["@ServerBakUri"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[ServerAimUri]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.ServerAimUri))
				{
					NRoll_Action_obj.ServerAimUri = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[ServerAimUri]=@ServerAimUri");
				cmd.Parameters.AddWithValue("@ServerAimUri", NRoll_Action_obj.ServerAimUri);
				cmd.Parameters["@ServerAimUri"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[SiteName]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.SiteName))
				{
					NRoll_Action_obj.SiteName = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[SiteName]=@SiteName");
				cmd.Parameters.AddWithValue("@SiteName", NRoll_Action_obj.SiteName);
				cmd.Parameters["@SiteName"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[Op]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.Op))
				{
					NRoll_Action_obj.Op = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[Op]=@Op");
				cmd.Parameters.AddWithValue("@Op", NRoll_Action_obj.Op);
				cmd.Parameters["@Op"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[IsUsed]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[IsUsed]=@IsUsed");
				cmd.Parameters.AddWithValue("@IsUsed", NRoll_Action_obj.IsUsed);
				cmd.Parameters["@IsUsed"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[AutoRollBack]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[AutoRollBack]=@AutoRollBack");
				cmd.Parameters.AddWithValue("@AutoRollBack", NRoll_Action_obj.AutoRollBack);
				cmd.Parameters["@AutoRollBack"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[BlockCode]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.BlockCode))
				{
					NRoll_Action_obj.BlockCode = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[BlockCode]=@BlockCode");
				cmd.Parameters.AddWithValue("@BlockCode", NRoll_Action_obj.BlockCode);
				cmd.Parameters["@BlockCode"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[YearVal]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.YearVal))
				{
					NRoll_Action_obj.YearVal = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[YearVal]=@YearVal");
				cmd.Parameters.AddWithValue("@YearVal", NRoll_Action_obj.YearVal);
				cmd.Parameters["@YearVal"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[MonthVal]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.MonthVal))
				{
					NRoll_Action_obj.MonthVal = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[MonthVal]=@MonthVal");
				cmd.Parameters.AddWithValue("@MonthVal", NRoll_Action_obj.MonthVal);
				cmd.Parameters["@MonthVal"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[DayVal]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.DayVal))
				{
					NRoll_Action_obj.DayVal = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[DayVal]=@DayVal");
				cmd.Parameters.AddWithValue("@DayVal", NRoll_Action_obj.DayVal);
				cmd.Parameters["@DayVal"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[IsDel]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[IsDel]=@IsDel");
				cmd.Parameters.AddWithValue("@IsDel", NRoll_Action_obj.IsDel);
				cmd.Parameters["@IsDel"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if (NRoll_Action_obj.CreateTime != null && NRoll_Action_obj.CreateTime > DateTime.MinValue && NRoll_Action_obj.ModifiedColumns.Contains("[CreateTime]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[CreateTime]=@CreateTime");
				cmd.Parameters.AddWithValue("@CreateTime", NRoll_Action_obj.CreateTime);
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
		/// <param name="NRoll_Action_obj"></param>
		/// <param name="IsRowLock">�Ƿ�����</param>
		/// <returns></returns>
		public static int Update(Trans.Db.Model.NRoll_Action NRoll_Action_obj, bool IsRowLock)
		{
			if(NRoll_Action_obj.ModifiedColumns.Count <= 0)
			{
				return -1;
			}
			StringBuilder sqlSet = new StringBuilder();
			StringBuilder sqlWhere = new StringBuilder();
			string sql = string.Empty;
			if (IsRowLock)
			{
				sql = "UPDATE NRoll_Action WITH(ROWLOCK) SET {0} WHERE {1}";
			}
			else
			{
				sql = "UPDATE NRoll_Action SET {0} WHERE {1}";
			}
			SqlCommand cmd = new SqlCommand();
			cmd.Parameters.AddWithValue("@ID", NRoll_Action_obj.ID);
			cmd.Parameters["@ID"].SqlDbType = System.Data.SqlDbType.BigInt;
			if (sqlWhere.Length > 0)
			{
				sqlWhere.Append(" AND ");
			}
			sqlWhere.Append("[ID]=@ID");
			if(NRoll_Action_obj.ModifiedColumns.Contains("[RollCode]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.RollCode))
				{
					NRoll_Action_obj.RollCode = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[RollCode]=@RollCode");
				cmd.Parameters.AddWithValue("@RollCode", NRoll_Action_obj.RollCode);
				cmd.Parameters["@RollCode"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[ServerIP]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.ServerIP))
				{
					NRoll_Action_obj.ServerIP = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[ServerIP]=@ServerIP");
				cmd.Parameters.AddWithValue("@ServerIP", NRoll_Action_obj.ServerIP);
				cmd.Parameters["@ServerIP"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[ServerPort]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[ServerPort]=@ServerPort");
				cmd.Parameters.AddWithValue("@ServerPort", NRoll_Action_obj.ServerPort);
				cmd.Parameters["@ServerPort"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[ServerBakUri]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.ServerBakUri))
				{
					NRoll_Action_obj.ServerBakUri = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[ServerBakUri]=@ServerBakUri");
				cmd.Parameters.AddWithValue("@ServerBakUri", NRoll_Action_obj.ServerBakUri);
				cmd.Parameters["@ServerBakUri"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[ServerAimUri]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.ServerAimUri))
				{
					NRoll_Action_obj.ServerAimUri = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[ServerAimUri]=@ServerAimUri");
				cmd.Parameters.AddWithValue("@ServerAimUri", NRoll_Action_obj.ServerAimUri);
				cmd.Parameters["@ServerAimUri"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[SiteName]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.SiteName))
				{
					NRoll_Action_obj.SiteName = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[SiteName]=@SiteName");
				cmd.Parameters.AddWithValue("@SiteName", NRoll_Action_obj.SiteName);
				cmd.Parameters["@SiteName"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[Op]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.Op))
				{
					NRoll_Action_obj.Op = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[Op]=@Op");
				cmd.Parameters.AddWithValue("@Op", NRoll_Action_obj.Op);
				cmd.Parameters["@Op"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[IsUsed]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[IsUsed]=@IsUsed");
				cmd.Parameters.AddWithValue("@IsUsed", NRoll_Action_obj.IsUsed);
				cmd.Parameters["@IsUsed"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[AutoRollBack]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[AutoRollBack]=@AutoRollBack");
				cmd.Parameters.AddWithValue("@AutoRollBack", NRoll_Action_obj.AutoRollBack);
				cmd.Parameters["@AutoRollBack"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[BlockCode]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.BlockCode))
				{
					NRoll_Action_obj.BlockCode = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[BlockCode]=@BlockCode");
				cmd.Parameters.AddWithValue("@BlockCode", NRoll_Action_obj.BlockCode);
				cmd.Parameters["@BlockCode"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[YearVal]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.YearVal))
				{
					NRoll_Action_obj.YearVal = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[YearVal]=@YearVal");
				cmd.Parameters.AddWithValue("@YearVal", NRoll_Action_obj.YearVal);
				cmd.Parameters["@YearVal"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[MonthVal]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.MonthVal))
				{
					NRoll_Action_obj.MonthVal = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[MonthVal]=@MonthVal");
				cmd.Parameters.AddWithValue("@MonthVal", NRoll_Action_obj.MonthVal);
				cmd.Parameters["@MonthVal"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[DayVal]"))
			{
				if (string.IsNullOrEmpty(NRoll_Action_obj.DayVal))
				{
					NRoll_Action_obj.DayVal = "";
				}
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[DayVal]=@DayVal");
				cmd.Parameters.AddWithValue("@DayVal", NRoll_Action_obj.DayVal);
				cmd.Parameters["@DayVal"].SqlDbType = System.Data.SqlDbType.NVarChar;
			}
			if(NRoll_Action_obj.ModifiedColumns.Contains("[IsDel]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[IsDel]=@IsDel");
				cmd.Parameters.AddWithValue("@IsDel", NRoll_Action_obj.IsDel);
				cmd.Parameters["@IsDel"].SqlDbType = System.Data.SqlDbType.Int;
			}
			if (NRoll_Action_obj.CreateTime != null && NRoll_Action_obj.CreateTime > DateTime.MinValue && NRoll_Action_obj.ModifiedColumns.Contains("[CreateTime]"))
			{
				if (sqlSet.Length > 0)
				{
					sqlSet.Append(",");
				}
				sqlSet.Append("[CreateTime]=@CreateTime");
				cmd.Parameters.AddWithValue("@CreateTime", NRoll_Action_obj.CreateTime);
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
		public static bool insert( Trans.Db.Model.NRoll_Action NRoll_Action_obj)
		{
			SqlCommand cmd = new SqlCommand();
			StringBuilder cols = new StringBuilder();
			StringBuilder parameters = new StringBuilder();
			string sql = "INSERT INTO NRoll_Action({0}) values({1})";
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[RollCode]");
			parameters.Append("@RollCode");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.RollCode))
			{
				cmd.Parameters.AddWithValue("@RollCode", NRoll_Action_obj.RollCode);
			}
			else
			{
				cmd.Parameters.AddWithValue("@RollCode", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[ServerIP]");
			parameters.Append("@ServerIP");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.ServerIP))
			{
				cmd.Parameters.AddWithValue("@ServerIP", NRoll_Action_obj.ServerIP);
			}
			else
			{
				cmd.Parameters.AddWithValue("@ServerIP", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[ServerPort]");
			parameters.Append("@ServerPort");
			cmd.Parameters.AddWithValue("@ServerPort", NRoll_Action_obj.ServerPort);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[ServerBakUri]");
			parameters.Append("@ServerBakUri");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.ServerBakUri))
			{
				cmd.Parameters.AddWithValue("@ServerBakUri", NRoll_Action_obj.ServerBakUri);
			}
			else
			{
				cmd.Parameters.AddWithValue("@ServerBakUri", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[ServerAimUri]");
			parameters.Append("@ServerAimUri");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.ServerAimUri))
			{
				cmd.Parameters.AddWithValue("@ServerAimUri", NRoll_Action_obj.ServerAimUri);
			}
			else
			{
				cmd.Parameters.AddWithValue("@ServerAimUri", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[SiteName]");
			parameters.Append("@SiteName");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.SiteName))
			{
				cmd.Parameters.AddWithValue("@SiteName", NRoll_Action_obj.SiteName);
			}
			else
			{
				cmd.Parameters.AddWithValue("@SiteName", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[Op]");
			parameters.Append("@Op");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.Op))
			{
				cmd.Parameters.AddWithValue("@Op", NRoll_Action_obj.Op);
			}
			else
			{
				cmd.Parameters.AddWithValue("@Op", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[IsUsed]");
			parameters.Append("@IsUsed");
			cmd.Parameters.AddWithValue("@IsUsed", NRoll_Action_obj.IsUsed);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[AutoRollBack]");
			parameters.Append("@AutoRollBack");
			cmd.Parameters.AddWithValue("@AutoRollBack", NRoll_Action_obj.AutoRollBack);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[BlockCode]");
			parameters.Append("@BlockCode");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.BlockCode))
			{
				cmd.Parameters.AddWithValue("@BlockCode", NRoll_Action_obj.BlockCode);
			}
			else
			{
				cmd.Parameters.AddWithValue("@BlockCode", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[YearVal]");
			parameters.Append("@YearVal");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.YearVal))
			{
				cmd.Parameters.AddWithValue("@YearVal", NRoll_Action_obj.YearVal);
			}
			else
			{
				cmd.Parameters.AddWithValue("@YearVal", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[MonthVal]");
			parameters.Append("@MonthVal");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.MonthVal))
			{
				cmd.Parameters.AddWithValue("@MonthVal", NRoll_Action_obj.MonthVal);
			}
			else
			{
				cmd.Parameters.AddWithValue("@MonthVal", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[DayVal]");
			parameters.Append("@DayVal");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.DayVal))
			{
				cmd.Parameters.AddWithValue("@DayVal", NRoll_Action_obj.DayVal);
			}
			else
			{
				cmd.Parameters.AddWithValue("@DayVal", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[IsDel]");
			parameters.Append("@IsDel");
			cmd.Parameters.AddWithValue("@IsDel", NRoll_Action_obj.IsDel);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[CreateTime]");
			parameters.Append("@CreateTime");
			if(NRoll_Action_obj.CreateTime == null || NRoll_Action_obj.CreateTime == DateTime.MinValue)
			{
				cmd.Parameters.AddWithValue("@CreateTime", DateTime.Now);
			}
			else
			{
				cmd.Parameters.AddWithValue("@CreateTime", NRoll_Action_obj.CreateTime);
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
		public static bool Add( Trans.Db.Model.NRoll_Action NRoll_Action_obj, out Int64 ID)
		{
			ID = 0;
			SqlCommand cmd = new SqlCommand();
			StringBuilder cols = new StringBuilder();
			StringBuilder parameters = new StringBuilder();
			string sql = "INSERT INTO NRoll_Action({0}) values({1});SELECT @@IDENTITY;";
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[RollCode]");
			parameters.Append("@RollCode");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.RollCode))
			{
				cmd.Parameters.AddWithValue("@RollCode", NRoll_Action_obj.RollCode);
			}
			else
			{
				cmd.Parameters.AddWithValue("@RollCode", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[ServerIP]");
			parameters.Append("@ServerIP");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.ServerIP))
			{
				cmd.Parameters.AddWithValue("@ServerIP", NRoll_Action_obj.ServerIP);
			}
			else
			{
				cmd.Parameters.AddWithValue("@ServerIP", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[ServerPort]");
			parameters.Append("@ServerPort");
			cmd.Parameters.AddWithValue("@ServerPort", NRoll_Action_obj.ServerPort);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[ServerBakUri]");
			parameters.Append("@ServerBakUri");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.ServerBakUri))
			{
				cmd.Parameters.AddWithValue("@ServerBakUri", NRoll_Action_obj.ServerBakUri);
			}
			else
			{
				cmd.Parameters.AddWithValue("@ServerBakUri", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[ServerAimUri]");
			parameters.Append("@ServerAimUri");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.ServerAimUri))
			{
				cmd.Parameters.AddWithValue("@ServerAimUri", NRoll_Action_obj.ServerAimUri);
			}
			else
			{
				cmd.Parameters.AddWithValue("@ServerAimUri", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[SiteName]");
			parameters.Append("@SiteName");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.SiteName))
			{
				cmd.Parameters.AddWithValue("@SiteName", NRoll_Action_obj.SiteName);
			}
			else
			{
				cmd.Parameters.AddWithValue("@SiteName", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[Op]");
			parameters.Append("@Op");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.Op))
			{
				cmd.Parameters.AddWithValue("@Op", NRoll_Action_obj.Op);
			}
			else
			{
				cmd.Parameters.AddWithValue("@Op", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[IsUsed]");
			parameters.Append("@IsUsed");
			cmd.Parameters.AddWithValue("@IsUsed", NRoll_Action_obj.IsUsed);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[AutoRollBack]");
			parameters.Append("@AutoRollBack");
			cmd.Parameters.AddWithValue("@AutoRollBack", NRoll_Action_obj.AutoRollBack);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[BlockCode]");
			parameters.Append("@BlockCode");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.BlockCode))
			{
				cmd.Parameters.AddWithValue("@BlockCode", NRoll_Action_obj.BlockCode);
			}
			else
			{
				cmd.Parameters.AddWithValue("@BlockCode", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[YearVal]");
			parameters.Append("@YearVal");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.YearVal))
			{
				cmd.Parameters.AddWithValue("@YearVal", NRoll_Action_obj.YearVal);
			}
			else
			{
				cmd.Parameters.AddWithValue("@YearVal", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[MonthVal]");
			parameters.Append("@MonthVal");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.MonthVal))
			{
				cmd.Parameters.AddWithValue("@MonthVal", NRoll_Action_obj.MonthVal);
			}
			else
			{
				cmd.Parameters.AddWithValue("@MonthVal", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[DayVal]");
			parameters.Append("@DayVal");
			if (!string.IsNullOrEmpty(NRoll_Action_obj.DayVal))
			{
				cmd.Parameters.AddWithValue("@DayVal", NRoll_Action_obj.DayVal);
			}
			else
			{
				cmd.Parameters.AddWithValue("@DayVal", "");
			}
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[IsDel]");
			parameters.Append("@IsDel");
			cmd.Parameters.AddWithValue("@IsDel", NRoll_Action_obj.IsDel);
			if (cols.Length > 0)
			{
				cols.Append(",");
				parameters.Append(",");
			}
			cols.Append("[CreateTime]");
			parameters.Append("@CreateTime");
			if(NRoll_Action_obj.CreateTime == null || NRoll_Action_obj.CreateTime == DateTime.MinValue)
			{
				cmd.Parameters.AddWithValue("@CreateTime", DateTime.Now);
			}
			else
			{
				cmd.Parameters.AddWithValue("@CreateTime", NRoll_Action_obj.CreateTime);
			}
			sql = string.Format(sql, cols.ToString(), parameters.ToString());
			cmd.CommandText = sql;
			bool b = true;
			try
			{
				object idobj = new Trans.Db.DBUtility.DBHelper(false).ExecScalar(cmd);
				ID = Convert.ToInt64(idobj);
				if (ID == 0)
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
