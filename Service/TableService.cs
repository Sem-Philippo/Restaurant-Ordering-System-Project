using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TableService
    {
        private TableDAO tableDao;

        public TableService()
        {
            tableDao = new();
        }
        public List<Table> GetAllTables()
        {
            return tableDao.GetAllTables();
        }

        //Change THE STATUS
        public void ChangeTableStatus(Table table)
        {
            tableDao.ChangeTableStatus(table);

        }
    }
}
