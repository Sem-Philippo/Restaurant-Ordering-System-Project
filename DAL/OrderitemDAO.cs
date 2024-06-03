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
    public class OrderitemDAO : BaseDao
    {
        public List<OrderItem> GetOrderItemsByOrderID()
        {
            string query = "SELECT * FROM ORDERITEM";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //Don't forget to include sales amount once drink orders are implemented!
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<OrderItem> ReadTables(DataTable dataTable)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                orderItems.Add(CreateOrderItemFromDataRow(dr));

            }
            return orderItems;
        }
        private OrderItem CreateOrderItemFromDataRow(DataRow dr)
        {
            MenuItemDAO menuItemDao = new MenuItemDAO();
            return new OrderItem(
                menuItemDao.GetMenuItemByID((int)dr["MenuItemID"]),
                (int)dr["Quanitity"],
                (Status)(int)dr["Status"],
                dr["Comment"].ToString(),
                (TimeSpan)dr["StatusTime"]
                );
        }
    }
}
