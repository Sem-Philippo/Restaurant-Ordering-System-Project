using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace DAL
{
    public class TableDAO : BaseDao
    {
        public List<int> GetAllTableNumbers()
        {
            List<int> tableNumbers = new List<int>();

            string query = "SELECT Number FROM Tables";
            DataTable dataTable = ExecuteSelectQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                tableNumbers.Add(Convert.ToInt32(row["Number"]));
            }

            return tableNumbers;
        }
        public Table GetOrderByID(int id)
        {
            string query = "SELECT * FROM Tables WHERE TableID = @TableID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TableID", id);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }
        private List<Table> ReadTables(DataTable dataTable)
        {
            var tables = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                tables.Add(CreateEmployeeFromDataRow(dr));
            }

            return tables;
        }

        private Table CreateEmployeeFromDataRow(DataRow dr)
        {
            return new Table()
            {
                TableId = Convert.ToInt32(dr["TableID"]),
                TableNumber = Convert.ToInt32(dr["Number"]),
                IsOccupied = Convert.ToBoolean(dr["IsOccupied"]),
            };
        }
        public Table GetTableByID(int id)
        {
            string query = "SELECT TableId, Number, IsOccupied FROM [Tables] WHERE TableId = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", id);
            try
            {
                return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
            }
            catch
            {
                return null;
            }
            
        }
        private Table CreateTableFromDataRow(DataRow dr)
        {
            return new Table((int)dr["TableId"], (int)dr["Number"], (bool)dr["IsOccupied"]);
        }
    }
}
