using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public abstract class BaseDao
    {
        private SqlDataAdapter adapter;
        private SqlConnection conn;
        public BaseDao()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChapeauDatabase"].ConnectionString);
            adapter = new SqlDataAdapter();
        }
        protected SqlConnection OpenConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return conn;
        }
        private void CloseConnection()
        {
            conn.Close();
        }
        protected void ExecuteEditTranQuery(string query, SqlParameter[] sqlParameters, SqlTransaction sqlTransaction)
        {
            SqlCommand command = new SqlCommand(query, conn, sqlTransaction);

            try
            {
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void ExecuteEditQuery(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        protected int ExecuteDeleteQuery(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                return command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        protected DataTable ExecuteSelectQuery(string query, params SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            DataTable dataTable;
            DataSet dataSet = new DataSet();
            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            catch (SqlException e)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }
    }
}
