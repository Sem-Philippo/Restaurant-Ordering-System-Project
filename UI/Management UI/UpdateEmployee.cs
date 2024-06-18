using Model;
using Model.Enums;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Stocks_UI
{
    public partial class UpdateEmployee : Form
    {
        private EmployeeService employeeService;

        public UpdateEmployee()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            roleComboBox.DataSource = Enum.GetValues(typeof(Role));
            RefreshEmployeeItems();
            employeeBox.SelectedIndexChanged += new EventHandler(FillInEmployeeDetails);
        }
        private void RefreshEmployeeItems()
        {
            employeeBox.Items.Clear();
            List<Employee> employees = employeeService.GetAllEmployee();
            foreach (Employee employee in employees)
            {
                employeeBox.Items.Add(employee);
            }
            employeeBox.DisplayMember = "DisplayName";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (employeeBox.SelectedIndex == null)
            {
                MessageBox.Show("Please select an employee to update");
                return;
            }
            Employee employee = employeeBox.SelectedItem as Employee;
            
            Employee newEmployee = new Employee()
            {
                Id = employee.Id,
                FirstName = firstNameTxt.Text,
                LastName = lastNameTxt.Text,
                Role = (Role)roleComboBox.SelectedItem,
                Hash = employee.Hash,
                Salt = employee.Salt,
            };
            int role = (int)roleComboBox.SelectedItem;
            try
            {
                employeeService.UpadateEmployee(newEmployee);
                MessageBox.Show("Employee has been updates");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened updating employee" +ex.Message);
            }
        }
        private void FillInEmployeeDetails(object sender, EventArgs e)
        {
            if (employeeBox != null)
            {
                Employee employee = (Employee)employeeBox.SelectedItem;
                if (employee != null)
                {
                    firstNameTxt.Text = employee.FirstName;
                    lastNameTxt.Text = employee.LastName;
                    roleComboBox.SelectedItem = employee.Role;
                }
            }
        }
    }
}
