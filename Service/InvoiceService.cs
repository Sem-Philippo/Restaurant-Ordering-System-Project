using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InvoiceService
    {
        private InvoiceDAO invoiceDAO {  get; set; }
        public InvoiceService()
        {
            invoiceDAO = new InvoiceDAO();
        }

        public List<Invoice> GetAllInvoices()
        {
            return invoiceDAO.GetAllInvoices();
        }
        public Invoice GetInvoiceByID(int id)
        {
            try
            {
                return invoiceDAO.GetInvoiceByID(id);
            }
            catch (Exception ex)
            {
                // Log or handle exception appropriately
                throw new Exception($"Error retrieving invoice with ID {id}: " + ex.Message);
            }
        }
        public void AddInvoice(Invoice invoice, int orderid)
        {
            try
            {
                invoiceDAO.AddInvoice(invoice, orderid);
            }
            catch (Exception ex)
            {
                // Optionally handle or log the exception
                throw new Exception("Error adding invoice: " + ex.Message);
            }
        }
        public void UpdateInvoiceStatus(Invoice invoice)
        {
            try
            {
                invoiceDAO.UpdateInvoiceStatus(invoice);
            }
            catch (Exception ex)
            {
                // Log or handle exception appropriately
                throw new Exception("Error updating invoice: " + ex.Message);
            }
        }

    }
}
