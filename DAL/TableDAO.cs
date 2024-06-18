using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model.Enums;

namespace DAL
{
    public class TableDAO : BaseDao
    {
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
        private List<Table> ReadTables(DataTable dataTable)
        {
            List<Table> tables = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                tables.Add(CreateTableFromDataRow(dr));

            }
            return tables;
        }
        private Table CreateTableFromDataRow(DataRow dr)
        {
            return new Table((int)dr["TableId"], (int)dr["Number"], (bool)dr["IsOccupied"]);
        }
    }
}
