using Model;
using Model.Enums;

using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class PaymentDAO : BaseDao
    {
        public List<Payment> GetAllPayments()
        {
            string query = "SELECT * FROM PAYMENT";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        
        
        private List<Payment> ReadTables(DataTable dataTable)
        {
            List<Payment> payments = new List<Payment>();

            foreach (DataRow dr in dataTable.Rows)
            {
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
            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
            return Convert.ToDecimal(dataTable.Rows[0][0]);
        }
    }
}
