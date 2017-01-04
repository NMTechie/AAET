using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using CAAAETCommon;
using CAAAETInfraStructure.Logging;

namespace CAAAETInfraStructure.DataBase
{
    class CAAAETSQLDataBase:ICAAAETDataBase
    {
        public DataSet ExecuteStoredProc(string procName, params DbParameter[] procParameterList)
        {
            DataSet retDS = null;
            using (var con = new SqlConnection())
            {
                try
                {

                    con.ConnectionString = ConfigurationManager.ConnectionStrings[CAAAETAppConstants.SQLConnString].ConnectionString;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand(procName, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (procParameterList != null && procParameterList.Length > 0)
                    {
                        foreach (DbParameter dbParam in procParameterList)
                        {
                            cmd.Parameters.Add(dbParam);
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(retDS);

                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger().WriteException(ex);
                }
                finally
                {
                    con.Close();
                }
            }
            return retDS;
        }
        public DbParameter CreateParameter(string name, DbType paramType, ParameterDirection paramDirection, int size = int.MaxValue)
        {
            return new SqlParameter() { SqlDbType = (SqlDbType)MapParameterType(paramType), ParameterName = name, Direction = paramDirection, Size = size };
        }

        private SqlDbType MapParameterType(DbType paramType)
        {
            SqlDbType retval=0;
            switch (paramType)
            {
                case DbType.Int16:
                case DbType.Int32:
                    retval = SqlDbType.Int;
                    break;
                case DbType.Int64:
                    retval = SqlDbType.BigInt;
                    break;
                case DbType.Binary:
                    retval = SqlDbType.Binary;
                    break;
                case DbType.Boolean:
                    retval = SqlDbType.Bit;
                    break;
                case DbType.AnsiStringFixedLength:                
                    retval = SqlDbType.Char;
                    break; 
                case DbType.Date:
                    retval = SqlDbType.Date;
                    break;
                case DbType.DateTime:
                    retval = SqlDbType.DateTime;
                    break;
                case DbType.DateTime2:
                    retval = SqlDbType.DateTime2;
                    break;
                case DbType.DateTimeOffset:
                    retval = SqlDbType.DateTimeOffset;
                    break;
                case DbType.Decimal:
                    retval = SqlDbType.Decimal;
                    break;                
                case DbType.Double:
                    retval = SqlDbType.Float;
                    break;
                case DbType.StringFixedLength:
                    retval = SqlDbType.NChar;
                    break;
                case DbType.String:
                    retval = SqlDbType.NText;
                    break;
                case DbType.Single:
                    retval = SqlDbType.Real;
                    break;
                case DbType.Object:
                    retval = SqlDbType.Variant;
                    break;
                case DbType.Time:
                    retval = SqlDbType.Time;
                    break;
                case DbType.Byte:
                    retval = SqlDbType.TinyInt;
                    break;
                case DbType.Guid:
                    retval = SqlDbType.UniqueIdentifier;
                    break; 
                case DbType.Xml:
                    retval = SqlDbType.Xml;
                    break;
                default:
                    retval = SqlDbType.NVarChar;
                    break;
                 
            }
            return retval;
        }
    }
}
