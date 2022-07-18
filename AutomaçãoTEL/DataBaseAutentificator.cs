using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace AutomaçãoTEL
{
    public class DataBaseAutentificator
    {
        private FbConnection CreateConnection()
        {
            return new FbConnection("User=SYSDBA;Password=pafuncio;Database=C:\\Users\\10088365\\source\\repos\\AutomaçãoTEL\\BancoDeDados\\AUTOMACAOTEL.fdb;DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0;");
        }

        private FbParameterCollection sqlParameterCollection = new FbCommand().Parameters;

        public void AddParameters(string nameParameter, string valueParameter)
        {
            sqlParameterCollection.Add(new FbParameter(nameParameter, valueParameter));
        }

        public Object ExecuteManipulation(CommandType commandType, string nameStoredProcedureOrTextSql) 
        {
            try
            {
                FbConnection sqlConnection = CreateConnection();
                sqlConnection.Open();

                var transaction = sqlConnection.BeginTransaction();


                FbCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nameStoredProcedureOrTextSql;
                sqlCommand.CommandTimeout = 500;

                foreach (FbParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new FbParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                transaction.Commit();

                return sqlCommand.ExecuteScalar();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public DataTable ExecuteQuery(CommandType commandType, string nameStoredProcedureOrTextSql)
        {

            try
            {
                FbConnection sqlConnection = CreateConnection();
                sqlConnection.Open();

                FbCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nameStoredProcedureOrTextSql;
                sqlCommand.CommandTimeout = 500;


                foreach (FbParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new FbParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                FbDataReader reader = sqlCommand.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable = GetTable(reader);

                return dataTable;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
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
