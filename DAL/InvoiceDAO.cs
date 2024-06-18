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
    public class InvoiceDAO : BaseDao
    {
        public List<Invoice> GetAllInvoices()
        {
            string query = "select m.Name,o.Comment,m.Price,o.Quantity, o.orderID" +
                "from Orderitem as o join Menuitem as m on m.MenuitemID = o.OrderitemID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //Don't forget to include sales amount once drink orders are implemented!
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public Invoice GetInvoiceByID(int id)
        {
            string query = "SELECT * FROM INVOICE WHERE ID = @ID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }
        private List<Invoice> ReadTables(DataTable dataTable)
        {
            List<Invoice> invoices = new List<Invoice>();

            foreach (DataRow dr in dataTable.Rows)
            {
                invoices.Add(CreateInvoiceFromDataRow(dr));
            }
            return invoices;
        }
        public void AddInvoice(Invoice invoice, int orderid)
        {
            string query = @"
                INSERT INTO Invoice (OrderDateTime, OrderID, LowVat, HighVat, IsPaid, EmployeeName)
                VALUES (@OrderDateTime, @OrderID, @LowVat, @HighVat, @IsPaid, @EmployeeName);
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@OrderDateTime", SqlDbType.DateTime) { Value = invoice.OrderDateTime },
                new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderid},
                new SqlParameter("@LowVat", SqlDbType.Decimal) { Value = invoice.LowVat },
                new SqlParameter("@HighVat", SqlDbType.Decimal) { Value = invoice.HighVat },
                new SqlParameter("@IsPaid", SqlDbType.Bit) { Value = false},
                new SqlParameter("@EmployeeName", SqlDbType.VarChar) { Value = invoice.EmployeeName }
            };
            try
            {
                int generatedInvoiceID = Convert.ToInt32(ExecuteScalar(query, sqlParameters));
                invoice.InvoiceId = generatedInvoiceID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding invoice: " + ex.Message);
            }
        }
        private Invoice CreateInvoiceFromDataRow(DataRow dr)
        {
            OrderDAO orderDAO = new OrderDAO();

            // Extract values from the DataRow
            DateTime orderDateTime = (DateTime)dr["OrderDateTime"];
            int orderId = (int)dr["OrderID"];
            decimal lowVat = (decimal)dr["LowVat"];
            decimal highVat = (decimal)dr["HighVat"];
            decimal totalAmount = (decimal)dr["TotalAmount"];
            bool isPaid = (bool)dr["IsPaid"];
            string employeeName = (string)dr["EmployeeName"];

            // Retrieve the Order associated with this Invoice
            Order order = orderDAO.GetOrderByID(orderId);

            // Create and return the Invoice object
            Invoice invoice = new Invoice(orderDateTime, order, lowVat, highVat, totalAmount, isPaid, employeeName);
            return invoice;
        }
        public void UpdateInvoiceStatus(Invoice invoice)
        {
            string query = @"
            UPDATE Invoice
            SET 
                IsPaid = @IsPaid,
            WHERE InvoiceID = @InvoiceID;";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@IsPaid", SqlDbType.Bit) { Value = 1 },
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoice.InvoiceId }
            };

            try
            {
                ExecuteEditQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating invoice: " + ex.Message);
            }
        }
        public Invoice GetInvoiceByOrder(int orderID)
        {
            OrderDAO orderDAO = new OrderDAO();
            try
            {
                string query = "SELECT * FROM [invoice] WHERE OrderID = @OrderID";
                SqlParameter parameter = new SqlParameter("@OrderID", orderID);
                DataTable result = ExecuteSelectQuery(query, parameter);

                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    Invoice invoice = new Invoice();
                    {
                        invoice.OrderDateTime = DateTime.Now;
                        invoice.Order = orderDAO.GetOrderByID(Convert.ToInt32(row["OrderID"]));
                        invoice.LowVat = Convert.ToDecimal(row["LowVat"]);
                        invoice.HighVat = Convert.ToDecimal(row["HighVat"]);
                        invoice.TotalAmount = Convert.ToDecimal(row["TotalAmount"]);
                        invoice.IsPaid = Convert.ToBoolean(row["IsPaid"]);
                        invoice.EmployeeName = row["EmployeeName"].ToString();

                    };
                    return invoice;
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

        internal Invoice GetInvoiceByID(int v)
        {
            throw new NotImplementedException();
        }
        public decimal GetTotalIncome()
        {
            //nothing, just to get rid of warning
            return new decimal(0);
        }
    }
}
