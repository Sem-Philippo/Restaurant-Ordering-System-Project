﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Model.Enums;

namespace DAL
{
    public class OrderDAO : BaseDao
    {


        public Order GetOrderByID(int id)
        {
            string query = "SELECT * FROM ORDER WHERE ID = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", id);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }
        public List<Order> GetAllOrders()
        {
            string query = "SELECT * FROM ORDER";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public void SaveOrder(Order order)
        {

            string query = "INSERT INTO [Order] ([Time], EmployeeID, TableID, Total) VALUES(@Time, @EmployeeID, @TableID, @Total); SELECT SCOPE_IDENTITY();";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@Time", DateTime.Now);
            sqlParameters[1] = new SqlParameter("@EmployeeID", order.Employee.Id);
            sqlParameters[2] = new SqlParameter("@TableID", order.Table.TableId);
            sqlParameters[3] = new SqlParameter("@Total", order.Total);
            order.Id = Convert.ToInt32(ExecuteScalar(query, sqlParameters));

            foreach (OrderItem item in order.OrderItems)
            {
                SaveOrderItem(item, order.Id);
            }
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
            TableDAO tableDAO = new TableDAO();
            return new Order(
                (DateTime)dr["Time"],
                employeeDao.GetEmployeeByID((int)dr["EmployeeID"]),
                new Table(3, 4, true),

                (decimal)dr["Total"]
                );
        }


        public List<OrderItem> GetOrderItemsByOrderID()
        {
            string query = "SELECT * FROM ORDERITEM";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadOrderItemTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public void SaveOrderItem(OrderItem item, int orderId)
        {
            //orderId is the ID of the order the item is linked to
            string query = "INSERT INTO [OrderItem] (MenuItemID, Quantity, [Status], Comment, StatusTime, OrderID) VALUES(@MenuItemID, @Quantity, @Status, @Comment, @StatusTime, @OrderID)";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@MenuItemID", item.MenuItem.MenuItemId);
            sqlParameters[1] = new SqlParameter("@Quantity", item.Quantity);
            sqlParameters[2] = new SqlParameter("@Status", item.Status);
            sqlParameters[3] = new SqlParameter("@Comment", item.Comment);
            sqlParameters[4] = new SqlParameter("@StatusTime", item.StatusTime);
            sqlParameters[5] = new SqlParameter("@OrderID", orderId);
            ExecuteEditQuery(query, sqlParameters);
        }
        private List<OrderItem> ReadOrderItemTables(DataTable dataTable)
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
        public List<PaymentOverview> GetServedItemsByTableNumber(int tableNumber, out string employeeName, out int orderId)
        {
            string query = @"SELECT o.ID AS OrderID, mi.Name AS ItemName, mi.Tax AS VAT, mi.Price AS ItemPrice, 
                             oi.Comment AS Description, oi.Quantity, (oi.Quantity * mi.Price) AS TotalPrice,
                             (e.Firstname + e.Lastname) AS EmployeeName
                      FROM [Order] o
                      JOIN OrderItem oi ON o.ID = oi.OrderID
                      JOIN MenuItem mi ON oi.MenuItemID = mi.MenuItemID
                      JOIN Tables t ON o.TableID = t.TableID
                      JOIN Employee e ON o.EmployeeID = e.ID
                      WHERE t.Number = @TableNumber AND oi.Status = 4;";

            SqlParameter[] parameters = {
        new SqlParameter("@TableNumber", SqlDbType.Int) { Value = tableNumber }
    };

            DataTable dataTable = ExecuteSelectQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                employeeName = dataTable.Rows[0]["EmployeeName"].ToString();
                orderId = Convert.ToInt32(dataTable.Rows[0]["OrderID"]);
            }
            else
            {
                employeeName = string.Empty;
                orderId = 0; 
            }

            return ReadPaymentOverviewTable(dataTable);
        }
        private List<PaymentOverview> ReadPaymentOverviewTable(DataTable dataTable)
        {
            List<PaymentOverview> items = new List<PaymentOverview>();

            foreach (DataRow dr in dataTable.Rows)
            {
                items.Add(CreatePaymentOverviewFromDataRow(dr));
            }
            return items;
        }

        private PaymentOverview CreatePaymentOverviewFromDataRow(DataRow dr)
        {
            return new PaymentOverview(
                dr["ItemName"].ToString(),
                Convert.ToDecimal(dr["VAT"]),
                Convert.ToDecimal(dr["ItemPrice"]),
                dr["Description"].ToString(),
                Convert.ToInt32(dr["Quantity"]),
                Convert.ToDecimal(dr["TotalPrice"])
            );
        }
        public Order GetOrderByTableNumber(int TableID)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            TableDAO tableDAO = new TableDAO();
            try
            {
                string query = "SELECT * FROM [Order] WHERE TableID = @TableID";
                SqlParameter parameter = new SqlParameter("@TableID", TableID);
                DataTable result = ExecuteSelectQuery(query, parameter);

                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    Order order = new Order();
                    {
                        order.Id = Convert.ToInt32(row["ID"]);
                        order.Time = DateTime.Now;
                        order.Employee = employeeDAO.GetEmployeeByID(Convert.ToInt32(row["EmployeeID"]));
                        order.Total = Convert.ToDecimal(row["Total"]);
                        order.Table = tableDAO.GetOrderByID(Convert.ToInt32(row["TableID"]));

                    };
                    return order;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching the employee by ID: " + ex.Message);
                throw;
            }
        }

    }
}
