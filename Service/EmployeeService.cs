using ChapeauService;
using DAL;
using Model;
using Model.Enums;
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
        }

        public void GetAllEmployee()
        {
            employeeDAO.GetAllEmployees();
        }


        public void UpadateEmployee(Employee employee)
        {
            employeeDAO.UpdateEmployee(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employeeDAO.DeleteEmployee(employee);
        }
        public Employee GetEmployeeByName(string name)
        {
            DataRow employeeRow = employeeDAO.GetUserName(name);
            if (employeeRow == null) return null;

            // Assign the values to Employee
            Employee employee = new Employee
            {
                Id = (int)employeeRow["ID"],
                FirstName = employeeRow["Firstname"].ToString(),
                LastName = employeeRow["Lastname"].ToString(),
                Salt = employeeRow["Salt"].ToString(),
                Hash = employeeRow["Pin"].ToString(),
                Role = (Role)(int)employeeRow["Role"]

            };
            // Check if the value in the EmployeeRole column is a valid Role enum value
            if (Enum.TryParse(employeeRow["Role"].ToString(), out Role employeeRole)) employee.Role = employeeRole;


            return employee;
        }

        //creating a new user

        public void NewUser(string firstName, string lastName, int role, string password)
        {
            if (EmployeeExists(firstName)) throw new Exception("User already exists");

            string salt = saltAndHashService.GenerateSalt();
            string hash = saltAndHashService.HashPassword(password, salt);

            employeeDAO.AddEmployee(firstName, lastName, role, salt, hash);
        }
        public bool EmployeeExists(string firstName)
        {
            return employeeDAO.EmployeeExists(firstName);
        }

    }
}