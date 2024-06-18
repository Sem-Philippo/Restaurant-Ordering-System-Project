using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;
using Model.Enums;

namespace DAL
{
    public class EmployeeDAO : BaseDao
    {
        public List<Employee> GetAllEmployees()
        {
            try
            {
                string query = "SELECT * FROM EMPLOYEE";
                SqlParameter[] sqlParameters = new SqlParameter[0];
                return ReadTables(ExecuteSelectQuery(query, sqlParameters));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching all employees: " + ex.Message);
                throw;
            }
        }


        public Employee GetEmployeeByID(int id)
        {
            try
            {
                string query = "SELECT * FROM EMPLOYEE WHERE ID = @ID";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", id)
                };
                var employees = ReadTables(ExecuteSelectQuery(query, sqlParameters));
                return employees.Count > 0 ? employees[0] : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching the employee by ID: " + ex.Message);
                throw;
            }
        }

        public DataRow GetUserName(string name)
        {
            try
            {
                string query = "SELECT * FROM EMPLOYEE WHERE FirstName = @FirstName";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", name)
                };

                DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching the username: " + ex.Message);
                throw;
            }
        }


        private List<Employee> ReadTables(DataTable dataTable)
        {
            var employees = new List<Employee>();

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
                Id = Convert.ToInt32(dr["ID"]),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Role = (Role)Enum.Parse(typeof(Role), dr["Role"].ToString()),
                Hash = dr["Pin"].ToString(),
                Salt = dr["Salt"].ToString()
            };
        }

        public void AddEmployee(int id, string firstName, string lastName, int role, string salt, string hash)
        {
            try
            {

                string query = "INSERT INTO EMPLOYEE (ID, FirstName, LastName, Role, Pin, Salt) VALUES (@ID, @FirstName, @LastName, @Role, @Pin, @Salt)";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) { Value = id },
                    new SqlParameter("@FirstName", SqlDbType.VarChar) { Value = firstName },
                    new SqlParameter("@LastName", SqlDbType.VarChar) { Value = lastName },
                    new SqlParameter("@Role", SqlDbType.Int) { Value = role },
                    new SqlParameter("@Pin", SqlDbType.VarChar) { Value = hash },
                    new SqlParameter("@Salt", SqlDbType.VarChar) { Value = salt }
                };

                ExecuteEditQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding an employee: " + ex.Message);
                throw;
            }

        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Employee cannot be null");

            try
            {
                string query = "DELETE FROM EMPLOYEE WHERE ID = @ID";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) { Value = employee.Id }
                };

                ExecuteDeleteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting an employee: " + ex.Message);
                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Employee cannot be null");

            try
            {
                string query = "UPDATE EMPLOYEE SET FirstName = @FirstName, LastName = @LastName, Role = @Role, Pin = @Hash, Salt = @Salt WHERE ID = @ID";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) { Value = employee.Id },
                    new SqlParameter("@FirstName", SqlDbType.VarChar) { Value = employee.FirstName },
                    new SqlParameter("@LastName", SqlDbType.VarChar) { Value = employee.LastName },
                    new SqlParameter("@Role", SqlDbType.Int) { Value = (int)employee.Role },
                    new SqlParameter("@Hash", SqlDbType.VarChar) { Value = employee.Hash },
                    new SqlParameter("@Salt", SqlDbType.VarChar) { Value = employee.Salt }
                };

                ExecuteEditQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating an employee: " + ex.Message);
                throw;
            }
        }


        public bool EmployeeExists(string name)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM EMPLOYEE WHERE FirstName = @FirstName";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", name)
                };

                DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
                int count = Convert.ToInt32(dataTable.Rows[0][0]);
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while checking if the employee exists: " + ex.Message);
                throw;
            }

        }
    }
}