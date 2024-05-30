using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
<<<<<<< HEAD
    public class InvoiceDAO : BaseDao
    {
        public List<Invoice> GetAllInvoices()
        {
            string query = "SELECT * FROM INVOICE";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public Invoice GetInvoiceByID(int id)
        {
            string query = "SELECT * FROM iNVOICE WHERE ID = @ID";
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
        private Invoice CreateInvoiceFromDataRow(DataRow dr)
        {
            OrderDAO orderDAO = new OrderDAO();
            return new Invoice(

                (DateTime)dr["Orderdate"],
                orderDAO.GetOrderByID((int)dr["OrderID"]),
                (decimal)dr["LowVat"],
                (decimal)dr["HighVat"]

            );
        }
        
    }
=======
  public class InvoiceDAO
    {

    }
}
>>>>>>> bb12d16c44f5cdd7d58b72aa6344e3593947f73b
