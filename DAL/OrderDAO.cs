using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class OrderDAO : BaseDao
    {
        //public Order GetOrderByID()
        //{
        //    string query = "SELECT * FROM ORDER";
        //    SqlParameter[] sqlParameters = new SqlParameter[0];
        //    return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        //}

        public List<Order> GetAllOrders()
        {
            string query = "SELECT * FROM ORDER";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                orders.Add(CreateOrderFromDataRow(dr));

            }
            return orders;
        }
        private Order CreateOrderFromDataRow(DataRow dr)
        {
            EmployeeDAO employeeDao = new EmployeeDAO();
            return new Order(
                (DateTime)dr["Time"],
                employeeDao.GetEmployeeByID((int)dr["EmployeeID"]),

                );
        }
    }
}
