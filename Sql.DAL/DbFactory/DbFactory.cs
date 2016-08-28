using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Sql.DAL.DbFactory
{
    public abstract class DbFactory
    {
        public abstract DbConnection GetDbConnection();
        public abstract DbCommand GetDbCommand();
        public abstract DbParameter CreateInParameter(string name, DbType dbType, object value);
    }
    public class SqlFactory : DbFactory
    {
        string cs = null;
        public SqlFactory()
        {
            cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        }

        public override DbParameter CreateInParameter(string name,DbType dbType,object value)
        {
            return new SqlParameter
            {
                ParameterName = name,
                DbType = dbType,
                Direction = ParameterDirection.Input,
                Value = value                
            };
        }

        public override DbCommand GetDbCommand()
        {
            return new SqlCommand();
        }

        public override DbConnection GetDbConnection()
        {
            return new SqlConnection(cs);
        }
    }
}
