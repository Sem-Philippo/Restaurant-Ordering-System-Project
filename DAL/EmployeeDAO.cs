using System.Data;
using Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeDAO : BaseDao
    {
        public List<Employee> GetAllDrinks()
        {
            string query = "SELECT * FROM EMPLOYEE";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //Don't forget to include sales amount once drink orders are implemented!
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Employee> ReadTables(DataTable dataTable)
        {
            List<Employee> employees = new List<Employee>();

            foreach (DataRow dr in dataTable.Rows)
            {
                employees.Add(CreateEmployeeFromDataRow(dr));

            }
            return employees;
        }
        private Employee CreateEmployeeFromDataRow(DataRow dr)
        {
            return new Employee()
            {
                FirstName = dr["FirstName"].ToString(),
            };
        }
    }
}