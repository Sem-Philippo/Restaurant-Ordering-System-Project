using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PaymentService
    {
        private PaymentDAO paymentDAO;
        public PaymentService()
        {
            paymentDAO = new PaymentDAO();
        }

        public decimal GetTipsAmount()
        {
            return paymentDAO.GetAllTipAmount();
        }
    }
}
