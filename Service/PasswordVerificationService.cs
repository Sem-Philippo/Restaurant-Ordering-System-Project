using Model;
using Service;

namespace ChapeauService;

public class PasswordVerificationService
{
    private readonly EmployeeService employeeService;
    private readonly SaltAndHashService saltAndHashService;
    private Employee employee;

    public PasswordVerificationService()
    {
        employeeService = new EmployeeService();
        employee = new Employee();
        saltAndHashService = new SaltAndHashService();
    }

    public bool VerifyPassword(string username, string password)
    {
        //Gets employee from the given username
        employee = employeeService.GetEmployeeByName(username);
        //If no emplyee is found false is returned 
        if (employee == null) return false;

        //hash the password entered with employees salt
        string hashedPassword = saltAndHashService.HashPassword(password, employee.Salt);
        //Compares the hashed password with the stored hash
        return hashedPassword == employee.Hash;
    }
}