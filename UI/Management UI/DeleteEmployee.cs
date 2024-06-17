using Model;
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
    public partial class DeleteEmployee : Form
    {
        private EmployeeService service;
        public DeleteEmployee()
        {
            InitializeComponent();
            service = new EmployeeService();
            LoadEmployees();
        }
        private void LoadEmployees()
        {
            List<Employee> employees = service.GetAllEmployee();
            deleteCombo.Items.Clear();
            deleteCombo.DisplayMember = "DisplayName"; 
            foreach (Employee employee in employees)
            {
                deleteCombo.Items.Add(employee);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (deleteCombo.SelectedIndex != -1) 
            {
                Employee selectedEmployee = deleteCombo.SelectedItem as Employee;

                // Display confirmation dialog
                var confirmMessage = MessageBox.Show($"Are you sure you want to delete '{selectedEmployee.DisplayName}'?",
                                             "Confirm Deletion",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);
                if (confirmMessage == DialogResult.Yes)
                {
                    try
                    {
                        service.DeleteEmployee(selectedEmployee);
                        MessageBox.Show("Employee deleted successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error occurred deleting employee: {ex.Message}");
                    }
                }
            }
        }
    }
}
