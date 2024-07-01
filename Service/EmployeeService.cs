using ChapeauService;
using DAL;
using Model;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Data;

namespace Service
{
    public class EmployeeService
    {
        private readonly EmployeeDAO employeeDAO;
        private readonly SaltAndHashService saltAndHashService;

        public EmployeeService()
        {
            employeeDAO = new EmployeeDAO();
            saltAndHashService = new SaltAndHashService();
        }

        public List<Employee> GetAllEmployee()
        {
            try
            {
                return employeeDAO.GetAllEmployees();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching all employees: " + ex.Message);
                throw;
            }
        }

        public void UpadateEmployee(Employee employee)
        {
            try
            {
                employeeDAO.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the employee: " + ex.Message);
                throw;
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            try
            {
                employeeDAO.DeleteEmployee(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the employee: " + ex.Message);
                throw;
            }
        }

        public Employee GetEmployeeByName(string name)
        {
            try
            {
                DataRow employeeRow = employeeDAO.GetUserName(name);
                if (employeeRow == null) return null;
                Employee employee = new Employee
                {
                    Id = (int)employeeRow["ID"],
                    FirstName = employeeRow["FirstName"].ToString(),
                    LastName = employeeRow["LastName"].ToString(),
                    Salt = employeeRow["Salt"].ToString(),
                    Hash = employeeRow["Hash"].ToString(),
                    Role = (Role)(int)employeeRow["Role"]
                };

                if (Enum.TryParse(employeeRow["Role"].ToString(), out Role employeeRole))
                {
                    employee.Role = employeeRole;
                }

                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching the employee by name: " + ex.Message);
                throw;
            }
        }

        public void NewUser(int id, string firstName, string lastName, int role, string password)
        {
            try
            {
                if (EmployeeExists(firstName))
                {
                    throw new Exception("User already exists");
                }

                string salt = saltAndHashService.GenerateSalt();
                string hash = saltAndHashService.HashPassword(password, salt);

                employeeDAO.AddEmployee(id, firstName, lastName, role, salt, hash);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating a new user: " + ex.Message);
                throw;
            }
        }

        public bool EmployeeExists(string firstName)
        {
            try
            {
                return employeeDAO.EmployeeExists(firstName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while checking if the employee exists: " + ex.Message);
                throw;
            }
        }
    }
}
