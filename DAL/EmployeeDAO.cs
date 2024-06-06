using System.Data;
using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Enums;

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
                Id = int.Parse(dr["ID"].ToString()),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Role = (Role)Enum.Parse(typeof (Role), dr["Role"].ToString()),
                Pin = int.Parse(dr["Pin"].ToString())
            };
        }


        public void AddEmployee(Employee employee)
        {
            string query = "insert into employee values(@ID, @FirstName, @LastName, @Role, @Pin)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ID", SqlDbType.Int) {Value = employee.Id},
                new SqlParameter("@FirstName", SqlDbType.VarChar) {Value = employee.FirstName },
                new SqlParameter("@LastName", SqlDbType.VarChar) {Value =employee.LastName},
                new SqlParameter("@Role", SqlDbType.VarChar) {Value = (int)employee.Role},
                new SqlParameter("@Pin", SqlDbType.VarChar) {Value = employee.Pin}

            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException("Drink object cannot be null");

            string query = "Delete from MenuItem where ID = @ID";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter ("@ID", SqlDbType.Int) {Value = employee.Id}
            };

        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException("Drink object cannot be null");

            string query = "update employee set FirstName = @FirstName, LastName = @LastName, Role = @Role, Pin = @Pin where ID = @ID";


            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ID", SqlDbType.Int) {Value = employee.Id},
                new SqlParameter("@FirstName", SqlDbType.VarChar) {Value = employee.FirstName },
                new SqlParameter("@LastName", SqlDbType.VarChar) {Value =employee.LastName},
                new SqlParameter("@Role", SqlDbType.VarChar) {Value = (int)employee.Role},
                new SqlParameter("@Pin", SqlDbType.VarChar) {Value = employee.Pin}

            };
            ExecuteEditQuery (query, sqlParameters);
        }
    }
}