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
            //First, store the Order in the database
            string query = "INSERT INTO [Order] ([Time], EmployeeID, TableID, Total) VALUES(@Time, @EmployeeID, @TableID, @Total); SELECT SCOPE_IDENTITY();";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@Time", DateTime.Now);
            sqlParameters[1] = new SqlParameter("@EmployeeID", order.Employee.Id);
            sqlParameters[2] = new SqlParameter("@TableID", order.Table.TableId);
            sqlParameters[3] = new SqlParameter("@Total", order.Total);
            order.Id = Convert.ToInt32(ExecuteScalar(query, sqlParameters));
            //Cycle through all order items in the order
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
                //tableDAO.GetTableByID((int)dr["TableID"]),
                //Add a method to the tableDAO to get a table by its id and finish rest of the constructor
                (decimal)dr["Total"]
                );
        }

        //orderitem related DAL methods
        public List<OrderItem> GetOrderItemsByOrderID()
        {
            string query = "SELECT * FROM ORDERITEM";
            SqlParameter[] sqlParameters = new SqlParameter[0];
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
    }
}
