using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace AutomaçãoTEL
{
    public class DataBaseAutentificator
    {
        private FbConnection CreateConnection()
        {
            var dir = Directory.GetCurrentDirectory();
            if (dir == null)
                return null;
            dir = Path.Combine(dir, "entrypoint\\BancoDeDados\\AUTOMACAOTEL.fdb");
            return new FbConnection($"User=SYSDBA;Password=pafuncio;Database={dir};DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0;");
        }

        private FbParameterCollection sqlParameterCollection = new FbCommand().Parameters;

        public void AddParameters(string nameParameter, string valueParameter)
        {
            sqlParameterCollection.Add(new FbParameter(nameParameter, valueParameter));
        }

        public void ExecuteCommand(CommandType commandType, string nameStoredProcedureOrTextSql) 
        {
            using (FbConnection sqlConnection = CreateConnection())
            {

                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                FbTransaction OrderTrans = sqlConnection.BeginTransaction();

                FbCommand cmd = new FbCommand();
                cmd.Connection = sqlConnection;
                cmd.Transaction = OrderTrans;
                try
                {
                    cmd = sqlConnection.CreateCommand();
                    cmd.CommandType = commandType;
                    cmd.CommandText = nameStoredProcedureOrTextSql;
                    cmd.CommandTimeout = 500;

                    OrderTrans.Commit();

                    cmd.ExecuteScalar(); ;

                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
                finally
                {
                    cmd.Dispose();
                    OrderTrans.Dispose();
                    sqlConnection.Close();
                }
            }
        }

        public DataTable ExecuteQuery(CommandType commandType, string nameStoredProcedureOrTextSql)
        {
            using (FbConnection sqlConnection = CreateConnection())
            {

                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                FbTransaction OrderTrans = sqlConnection.BeginTransaction();

                FbCommand cmd = new FbCommand();
                cmd.Connection = sqlConnection;
                cmd.Transaction = OrderTrans;
                try
                {

                    cmd = sqlConnection.CreateCommand();
                    cmd.CommandType = commandType;
                    cmd.CommandText = nameStoredProcedureOrTextSql;
                    cmd.CommandTimeout = 500;


                    foreach (FbParameter sqlParameter in sqlParameterCollection)
                    {
                        cmd.Parameters.Add(new FbParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }

                    OrderTrans.Commit();

                    FbDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable = GetTable(reader);


                    return dataTable;
                }
                catch (Exception e)
                {
                    OrderTrans.Rollback();
                    throw new Exception(e.Message);
                }
                finally
                {
                    cmd.Dispose();
                    OrderTrans.Dispose();
                    sqlConnection.Close();
                }

            }
            


        }

        public DataTable GetTable(FbDataReader reader)
        {
            DataTable tbSchema = reader.GetSchemaTable();
            DataTable tbReturn = new DataTable();

            foreach (DataRow r in tbSchema.Rows)
            {
                if (!tbReturn.Columns.Contains(r["ColumnName"].ToString()))
                {
                    DataColumn col = new DataColumn()
                    {
                        ColumnName = r["ColumnName"].ToString(),
                        Unique = Convert.ToBoolean(r["IsUnique"]),
                        AllowDBNull = Convert.ToBoolean(r["AllowDBNull"]),
                        ReadOnly = Convert.ToBoolean(r["IsReadOnly"])

                    };
                    tbReturn.Columns.Add(col);
                }
            }
            while (reader.Read())
            {
                DataRow newRow = tbReturn.NewRow();
                for (int i = 0; i < tbReturn.Columns.Count; i++)
                {
                    newRow[i] = reader.GetValue(i);
                }
                tbReturn.Rows.Add(newRow);
            }
            return tbReturn;
        }
    }
}
