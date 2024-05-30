using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Enums;

namespace DAL
{
    public class MenuItemDAO : BaseDao
    {
        public MenuItem GetMenuItemByID(int id)
        {
            string query = "SELECT * FROM MENUITEM WHERE MenuitemID = @ID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }
        public List<MenuItem> GetAllMenuItems()
        {
            string query = "SELECT * FROM MENUITEM";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<MenuItem> ReadTables(DataTable dataTable)
        {
            List<MenuItem> orderItems = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                orderItems.Add(CreateMenuItemFromDataRow(dr));

            }
            return orderItems;
        }
        private MenuItem CreateMenuItemFromDataRow(DataRow dr)
        {
            return new MenuItem(
                (int)dr["MenuitemID"],
                dr["Name"].ToString(),
                (Categories)(int)dr["Category"],
                (decimal)dr["Price"],
                (decimal)dr["Tax"],
                (int)dr["Stock"],
                (MenuTypes)(int)dr["Type"],
                (bool)dr["IsAlcoholic"]
                );
        }
    }
}
