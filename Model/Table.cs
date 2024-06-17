using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Table
    {
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public bool IsOccupied { get; set; }
        public Table(int tableId, int tableNumber, bool isOccupied)
        {
            TableId = tableId;
            TableNumber = tableNumber;
            IsOccupied = isOccupied;
        }

        public Table()
        {

        }
    }
}
