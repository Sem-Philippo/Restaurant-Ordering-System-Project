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
            string query = "SELECT * FROM Invoice";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //Don't forget to include sales amount once drink orders are implemented!
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
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
        private Invoice CreateInvoiceFromDataRow(DataRow dr)
        {
            OrderDAO orderDAO = new OrderDAO();
            return new Invoice(
                (DateTime)dr["Orderdate"],
                orderDAO.GetOrderByID((int)dr["OrderID"]),  //change to get orders by ID
                (decimal)0.5,
                (decimal)0.5
            );
        }

        internal Invoice GetInvoiceByID(int v)
        {
            throw new NotImplementedException();
        }
    }
}
