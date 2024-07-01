using Model;
using Model.Enums;
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
            string query = "SELECT m.Name, o.Comment, m.Price, o.Quantity, o.orderID FROM Orderitem AS o JOIN Menuitem AS m ON m.MenuitemID = o.OrderitemID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadInvoices(ExecuteSelectQuery(query, sqlParameters));
        }

        public Invoice GetInvoiceByID(int id)
        {
            string query = "SELECT * FROM INVOICE WHERE InvoiceID = @ID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
            return ReadInvoices(ExecuteSelectQuery(query, sqlParameters))[0];
        }

        public void AddInvoice(Invoice invoice, int orderid)
        {
            string query = @"
                        INSERT INTO Invoice (OrderDateTime, OrderID, LowVat, HighVat, TotalAmount, IsPaid, EmployeeName)
                        VALUES (@OrderDateTime, @OrderID, @LowVat, @HighVat, @TotalAmount, @IsPaid, @EmployeeName);SELECT SCOPE_IDENTITY();
                    ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                        new SqlParameter("@OrderDateTime", SqlDbType.DateTime) { Value = DateTime.Now },
                        new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderid},
                        new SqlParameter("@LowVat", SqlDbType.Decimal) { Value = invoice.LowVat },
                        new SqlParameter("@HighVat", SqlDbType.Decimal) { Value = invoice.HighVat },
                        new SqlParameter("@TotalAmount",SqlDbType.Decimal){Value = invoice.TotalAmount},
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

        private List<Invoice> ReadInvoices(DataTable dataTable)
        {
            List<Invoice> invoices = new List<Invoice>();

            foreach (DataRow dr in dataTable.Rows)
            {
                invoices.Add(CreateInvoiceFromDataRow(dr));
            }
            return invoices;
        }

        private Invoice CreateInvoiceFromDataRow(DataRow dr)
        {
            OrderDAO orderDAO = new OrderDAO();

            DateTime orderDateTime = (DateTime)dr["OrderDateTime"];
            int orderId = (int)dr["OrderID"];
            decimal lowVat = (decimal)dr["LowVat"];
            decimal highVat = (decimal)dr["HighVat"];
            decimal totalAmount = (decimal)dr["TotalAmount"];
            bool isPaid = (bool)dr["IsPaid"];
            string employeeName = (string)dr["EmployeeName"];

            Order order = orderDAO.GetOrderByID(orderId);

            Invoice invoice = new Invoice(orderDateTime, order, lowVat, highVat, totalAmount, isPaid, employeeName);
            return invoice;
        }

        public void UpdateInvoiceStatus(Invoice invoice)
        {
            string query = @"
            UPDATE Invoice
            SET 
                IsPaid = @IsPaid
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
                    Invoice invoice = new Invoice
                    {
                        OrderDateTime = DateTime.Now,
                        Order = orderDAO.GetOrderByID(Convert.ToInt32(row["OrderID"])),
                        LowVat = Convert.ToDecimal(row["LowVat"]),
                        HighVat = Convert.ToDecimal(row["HighVat"]),
                        TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                        IsPaid = Convert.ToBoolean(row["IsPaid"]),
                        EmployeeName = row["EmployeeName"].ToString()
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

        public decimal GetTotalIncome()
        {
            return new decimal(0);
        }
        public List<Payments> GetAllPayments()
        {
            string query = "SELECT * FROM PAYMENT";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadPayments(ExecuteSelectQuery(query, sqlParameters));
        }

        public Payments GetPaymentByID(int id)
        {
            string query = "SELECT * FROM PAYMENT WHERE ID = @ID";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
            return ReadPayments(ExecuteSelectQuery(query, sqlParameters))[0];
        }

        public Payments AddPayment(Payments payment)
        {
            string query = @"
            INSERT INTO Payment (PaymentType, PaymentAmount, InvoiceID, Tip, Feedback, PaymentDateTime)
            VALUES (@PaymentType, @PaymentAmount, @InvoiceID, @Tip, @Feedback, @PaymentDateTime);
            SELECT SCOPE_IDENTITY();
                                    ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@PaymentType", payment.PaymentType),
                new SqlParameter("@PaymentAmount", payment.PaymentAmount),
                new SqlParameter("@InvoiceID", payment.BillInvoice.InvoiceId),
                new SqlParameter("@Tip", payment.Tip),
                new SqlParameter("@Feedback", payment.Feedback),
                new SqlParameter("@PaymentDateTime", payment.PaymentDateTime) {Value =DateTime.Now}
            };

            try
            {
                int generatedPaymentID = Convert.ToInt32(ExecuteScalar(query, sqlParameters));
                payment.PaymentId = generatedPaymentID;
                return payment;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding payment: " + ex.Message);
            }
        }

        public void UpdatePayment(Payments payment)
        {
            string query = @"
            UPDATE Payment
            SET PaymentType = @PaymentType, PaymentAmount = @PaymentAmount, 
                InvoiceID = @InvoiceID, Tip = @Tip, Feedback = @Feedback, PaymentDateTime = @PaymentDateTime
            WHERE PaymentID = @PaymentID;";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@PaymentID", payment.PaymentId),
                new SqlParameter("@PaymentType", payment.PaymentType),
                new SqlParameter("@PaymentAmount", payment.PaymentAmount),
                new SqlParameter("@InvoiceID", payment.BillInvoice.InvoiceId),
                new SqlParameter("@Tip", payment.Tip),
                new SqlParameter("@Feedback", payment.Feedback),
                new SqlParameter("@PaymentDateTime", payment.PaymentDateTime)
            };

            try
            {
                ExecuteEditQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating payment: " + ex.Message);
            }
        }

        private List<Payments> ReadPayments(DataTable dataTable)
        {
            List<Payments> payments = new List<Payments>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Payments payment = new Payments(
                    (PaymentTypes)dr["PaymentType"],
                    (decimal)dr["PaymentAmount"],
                    new InvoiceDAO().GetInvoiceByID((int)dr["InvoiceID"]),
                    (decimal)dr["Tip"],
                    dr["Feedback"] != DBNull.Value ? (string)dr["Feedback"] : string.Empty,
                    (DateTime)dr["PaymentDateTime"]
                );
                payment.PaymentId = (int)dr["PaymentID"];
                payments.Add(payment);
            }
            return payments;
        }
        private Payments CreatePaymentFromDataRow(DataRow dr)
        {
            InvoiceDAO invoiceDAO = new InvoiceDAO();
            return new Payments(
                (PaymentTypes)dr["PaymentType"],
                (decimal)dr["PaymentAmount"],
                invoiceDAO.GetInvoiceByID((int)dr["InvoiceID"]),
                (decimal)dr["Tip"],
                dr["Feedback"] != DBNull.Value ? (string)dr["Feedback"] : string.Empty,
                (DateTime)dr["PaymentDateTime"]
            );
        }
        public decimal GetAllTipAmount()
        {
            string query = "SELECT SUM(Tip) FROM Payment";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            object result = ExecuteSelectQuery(query, sqlParameters).Rows[0][0];
            return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
        }
    }
}