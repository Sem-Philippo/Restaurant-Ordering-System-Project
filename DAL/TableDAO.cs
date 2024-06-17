using Model;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TableDAO : BaseDao
    {
        public List<Table> GetAllTables()
        {
            string query = "SELECT * FROM Tables";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public Table GetTableByID(int id)
        {
            string query = "SELECT * FROM Tables WHERE TableID = @ID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TableID", id);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
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
            return new Table()
            {
                TableId = int.Parse(dr["TableID"].ToString()),
                TableNumber = int.Parse(dr["Number"].ToString()), 
                IsOccupied = (bool)dr["IsOccupied"]
            };
        }

        public void ChangeTableStatus(Table table)
        {
            string query = "UPDATE [Tables] SET IsOccupied = @Status WHERE TableId = @Id;";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id", table.TableId),
                new SqlParameter("@Status", table.IsOccupied)
            };
            ExecuteEditQuery(query, sqlParameters);
        }


    }
}
