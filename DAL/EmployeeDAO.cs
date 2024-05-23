using System.Data;
using Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeDAO : BaseDao
    {
        public List<Employee> GetAllEmployees()
        {
            string query = "SELECT * FROM EMPLOYEE";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public Employee GetEmployeeByID(int id)
        {
            string query = "SELECT * FROM EMPLOYEE WHERE ID = @ID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
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
                LastName = dr["LastName"].ToString(),
                Role = (Model.Enums.Role)dr["Role"],
            };
        }

    }
}