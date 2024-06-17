using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InvoiceService
    {
        private InvoiceDAO dao;
        public InvoiceService()
        {
            dao = new InvoiceDAO();
        }
        public decimal GetTotalIncome()
        {
            return dao.GetTotalIncome();
        }
    }
}
