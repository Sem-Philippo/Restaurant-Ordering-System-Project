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
        public DataRow GetUserName(string name)
        {
            try
            {
                string query = "Select * from employee where firstName = @FirstName";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", name)

                };

                DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }
                return dataTable.Rows[0];
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured when getting the username" + e);
                throw;
            }
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
                Role = (Role)Enum.Parse(typeof(Role), dr["Role"].ToString()),
                Hash = dr["Pin"].ToString(),
                Salt = dr["Salt"].ToString()

            };
        }


        public void AddEmployee(string firstName, string lastName, int role, string salt, string hash)
        {
            string query = "insert into employee values(@FirstName, @LastName, @Role, @Pin, @Salt)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {

                new SqlParameter("@FirstName", SqlDbType.VarChar) {Value = firstName },
                new SqlParameter("@LastName", SqlDbType.VarChar) {Value = lastName},
                new SqlParameter("@Role", SqlDbType.VarChar) {Value = (int)role},
                new SqlParameter("@Pin", SqlDbType.VarChar) {Value = hash},
                new SqlParameter("@Salt", SqlDbType.VarChar) { Value = hash},

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

            string query = "update employee set FirstName = @FirstName, LastName = @LastName, Role = @Role, Hash = @Hash, Salt = @Salt where ID = @ID";


            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ID", SqlDbType.Int) {Value = employee.Id},
                new SqlParameter("@FirstName", SqlDbType.VarChar) {Value = employee.FirstName },
                new SqlParameter("@LastName", SqlDbType.VarChar) {Value =employee.LastName},
                new SqlParameter("@Role", SqlDbType.VarChar) {Value = (int)employee.Role},
                new SqlParameter("@Hash", SqlDbType.VarChar) {Value = employee.Hash},
                new SqlParameter("@Salt", SqlDbType.VarChar) {Value = employee.Salt}

            };
            ExecuteEditQuery(query, sqlParameters);
        }
        public bool EmployeeExists(string name)
        {
            try
            {
                string query = "Select count(*) from Employee where FisrtName = @FirstName";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", name)
                };
                DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
                int count = Convert.ToInt32(dataTable.Rows[0][0]);
                return count > 0;

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred when checking if employee exist" + e);
                throw;
            }
        }
    }
}