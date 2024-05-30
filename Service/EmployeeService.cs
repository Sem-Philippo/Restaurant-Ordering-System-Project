using DAL;
using Model;
namespace Service
{
    public class EmployeeService
    {
        EmployeeDAO employeeDAO;
        public EmployeeService()
        {
            employeeDAO = new EmployeeDAO();
        }

        public void GetAllEmployee()
        {
            employeeDAO.GetAllEmployees();
        }
        public void AddEmployee(Employee employee)
        {
            employeeDAO.AddEmployee(employee);
        }

        public void UpadateEmployee(Employee employee)
        {
            employeeDAO.UpdateEmployee(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employeeDAO.DeleteEmployee(employee);
        }

    }
}