using Model;
using Model.Enums;

using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;


namespace DAL
{
    public class PaymentDAO : BaseDao
    {
        public List<Payments> GetAllPayments()
        {
            string query = "SELECT * FROM PAYMENT";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadPayments(ExecuteSelectQuery(query, sqlParameters));
        }
<<<<<<< HEAD
        public Payments GetPaymentByID(int id)
=======

        

        public Payment GetPaymentByID(int id)
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
        {
            string query = "SELECT * FROM PAYMENT WHERE ID = @ID";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
<<<<<<< HEAD
            return ReadPayments(ExecuteSelectQuery(query, sqlParameters))[0];
        }
        public void AddPayment(Payments payment)
=======


            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];

        }

        
        private List<Payment> ReadTables(DataTable dataTable)
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
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
            new SqlParameter("@PaymentDateTime", payment.PaymentDateTime)
            };

            try
            {
                int generatedPaymentID = Convert.ToInt32(ExecuteScalar(query, sqlParameters));
                payment.PaymentId = generatedPaymentID;
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
            InvoiceDAO invoiceDAO = new InvoiceDAO();

            foreach (DataRow dr in dataTable.Rows)
            {
<<<<<<< HEAD
                Payments payment = new Payments(
                    (PaymentTypes)dr["PaymentType"],
                    (decimal)dr["PaymentAmount"],
                    invoiceDAO.GetInvoiceByID((int)dr["InvoiceID"]),
                    (decimal)dr["Tip"],
                    dr["Feedback"] != DBNull.Value ? (string)dr["Feedback"] : string.Empty,
                    (DateTime)dr["PaymentDateTime"]
                );
                payment.PaymentId = (int)dr["PaymentID"]; // Set PaymentID separately
                payments.Add(payment);
            }
            return payments;
        }
=======
                payments.Add(CreatePaymentFromDataRow(dr));

            }
            return payments;
        }
        private Payment CreatePaymentFromDataRow(DataRow dr)
        {
            InvoiceDAO invoiceDAO = new InvoiceDAO();
            return new Payment(
                (PaymentTypes)dr["PaymentType"],
                (decimal)dr["Paymentamount"],
                invoiceDAO.GetInvoiceByID((int)dr["InvoiceID"]),
                (decimal)dr["Tip"]
            );
        }
        public decimal GetAllTipAmount()
        {
            string query = "select Sum(Tip)\r\nfrom Payment";
            
            SqlParameter[] sqlParameters = new SqlParameter[0];


            object result = ExecuteSelectQuery(query, sqlParameters).Rows[0][0];
            return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
        }
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
    }
}
