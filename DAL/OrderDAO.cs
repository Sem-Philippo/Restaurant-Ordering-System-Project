using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class OrderDAO
    {
<<<<<<< HEAD

        public Order GetOrderByID(int id)
        {
            string query = "SELECT * FROM ORDER WHERE ID = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", id);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }
=======
>>>>>>> bb12d16c44f5cdd7d58b72aa6344e3593947f73b

    }
}
