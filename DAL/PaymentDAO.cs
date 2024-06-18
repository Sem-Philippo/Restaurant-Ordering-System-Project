using Model;

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
        public Payments GetPaymentByID(int id)
        {
            string query = "SELECT * FROM PAYMENT WHERE ID = @ID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
            return ReadPayments(ExecuteSelectQuery(query, sqlParameters))[0];
        }
        public void AddPayment(Payments payment)
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
    }
}
