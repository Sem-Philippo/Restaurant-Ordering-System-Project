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
            string query = "SELECT [Time], [EmployeeId], [TableId], [Id] FROM [ORDER] WHERE ID = @id";
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
        public Order GetLastOrderForTableID(int id)
        {
            string query = "SELECT [Time], [EmployeeId], [TableId], [Id] FROM [ORDER] WHERE TableID = @id ORDER by ID DESC";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", id);
            List<Order> results = ReadTables(ExecuteSelectQuery(query, sqlParameters));
            if (results.Count > 0)
            {
                return results[0];
            }
            else
            {
                return null;
            }
        }
        public List<Order> GetAllOrders()
        {
            string query = "SELECT [Time], [EmployeeId], [TableId], [Id] FROM [ORDER]";
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
            //Get Order ID for order items
            order.Id = Convert.ToInt32(ExecuteScalar(query, sqlParameters));

            foreach (OrderItem item in order.OrderItems)
            {
                SaveOrderItem(item, order.Id);
            }
        }
        public bool AddToExistingOrder(Order order)
        {
            //Check if an order for the current table already exists
            Order storedOrder = GetLastOrderForTableID(order.Table.TableId);
            if (storedOrder != null && storedOrder.Id != 0) 
            {
                //An order already exists, so add to it instead
                //Get Order Id for order items
                order.Id = storedOrder.Id;
                foreach (OrderItem item in order.OrderItems)
                {
                    SaveOrderItem(item, order.Id);
                }
                return true;
            }
            else
            {
                //No earlier order for table, so return false for messagebox
                return false;
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
                tableDAO.GetTableByID((int)dr["TableID"])
                //Add a method to the tableDAO to get a table by its id and finish rest of the constructor
                )
            { Id = (int)dr["ID"] };
        }

        //orderitem related DAL methods
        public List<OrderItem> GetOrderItemsByOrderID(int orderId)
        {
            string query = "SELECT [MenuItemID], [Quantity], [Status], [Comment], [StatusTime] FROM ORDERITEM WHERE orderId = @orderId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@orderId", orderId);
            //Don't forget to include sales amount once drink orders are implemented!
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
            sqlParameters[3] = new SqlParameter("@Comment", item.Comment ?? (object)DBNull.Value);
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
            return new OrderItem
                (
                menuItemDao.GetMenuItemByID((int)dr["MenuItemID"]),
                (int)dr["Quantity"],
                (Status)(int)dr["Status"],
                dr["Comment"].ToString(),
                (TimeSpan)dr["StatusTime"]
                );
        }
        public Order GetServedItemsByTableNumber(int tableNumber, out string employeeName, out int orderId)
        {
            string query = @"SELECT o.ID AS OrderID, o.Time, e.ID AS EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName,
                            t.TableID, t.Number AS TableNumber, oi.MenuItemID, oi.Quantity, oi.Status, oi.Comment, oi.StatusTime,
                            mi.Name AS ItemName, mi.Tax AS VAT, mi.Price AS ItemPrice
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
                return null;
            }

            return CreateOrderDetailsFromDataTable(dataTable);
        }

        private Order CreateOrderDetailsFromDataTable(DataTable dataTable)
        {
            EmployeeDAO employeeDao = new EmployeeDAO();
            TableDAO tableDAO = new TableDAO();

            DataRow firstRow = dataTable.Rows[0];
            int orderId = Convert.ToInt32(firstRow["OrderID"]);
            DateTime orderTime = Convert.ToDateTime(firstRow["Time"]);
            Employee employee = employeeDao.GetEmployeeByID(Convert.ToInt32(firstRow["EmployeeID"]));
            Table table = tableDAO.GetTableByID(Convert.ToInt32(firstRow["TableID"]));

            Order order = new Order(orderTime, employee, table)
            {
                Id = orderId
            };

            foreach (DataRow row in dataTable.Rows)
            {
                MenuItem menuItem = new MenuItem
                {
                    MenuItemId = Convert.ToInt32(row["MenuItemID"]),
                    Name = row["ItemName"].ToString(),
                    Price = Convert.ToDecimal(row["ItemPrice"]),
                    Tax = Convert.ToDecimal(row["VAT"])
                };
                OrderItem orderItem = new OrderItem(
                    menuItem,
                    Convert.ToInt32(row["Quantity"]),
                    (Status)Convert.ToInt32(row["Status"]),
                    row["Comment"].ToString(),
                    (TimeSpan)row["StatusTime"]
                );
                order.AddOrderItem(orderItem);
            }

            return order;
        }
        private Order CreateOrderFromDataTable(DataTable dataTable)
        {
            EmployeeDAO employeeDao = new EmployeeDAO();
            TableDAO tableDAO = new TableDAO();

            DataRow firstRow = dataTable.Rows[0];
            int orderId = Convert.ToInt32(firstRow["OrderID"]);
            DateTime orderTime = Convert.ToDateTime(firstRow["Time"]);
            Employee employee = employeeDao.GetEmployeeByID(Convert.ToInt32(firstRow["EmployeeID"]));
            Table table = tableDAO.GetTableByID(Convert.ToInt32(firstRow["TableID"]));

            Order order = new Order(orderTime, employee, table)
            {
                Id = orderId
            };

            foreach (DataRow row in dataTable.Rows)
            {
                MenuItem menuItem = new MenuItem
                {
                    MenuItemId = Convert.ToInt32(row["MenuItemID"]),
                    Name = row["ItemName"].ToString(),
                    Price = Convert.ToDecimal(row["ItemPrice"]),
                    Tax = Convert.ToDecimal(row["VAT"])
                };
                OrderItem orderItem = new OrderItem(
                    menuItem,
                    Convert.ToInt32(row["Quantity"]),
                    (Status)Convert.ToInt32(row["Status"]),
                    row["Comment"].ToString(),
                    (TimeSpan)row["StatusTime"]
                );
                order.AddOrderItem(orderItem);
            }

            return order;
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