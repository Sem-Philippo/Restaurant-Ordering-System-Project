using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TableService
    {
        private TableDAO tableDAO;
        public TableService()
        {
            tableDAO = new TableDAO();
        }
        public List<int> GetAllTableNUmbers()
        {
            return tableDAO.GetAllTableNumbers();
        }
        public void UpdateTable(Table table) { tableDAO.UpdateTable(table); }
    }
}
