using ChapeauService;
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
    public partial class AddEmployee : Form
    {
        private EmployeeService employeeService;
        private SaltAndHashService saltAndHashService;
        private PasswordVerificationService passwordVerificationService;
        public AddEmployee()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            saltAndHashService = new SaltAndHashService();
            passwordVerificationService = new PasswordVerificationService();
            roleComboBox.DataSource = Enum.GetValues(typeof(Role));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = firstNameTxt.Text;
                string lastName = lastNameTxt.Text;
                string pin = pinTxt.Text;

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(pin) || string.IsNullOrEmpty(idTxt.Text))
                {
                    MessageBox.Show("All fields are required.");
                    return;
                }

                if (!int.TryParse(idTxt.Text, out int id))
                {
                    MessageBox.Show("Please enter a valid ID.");
                    return;
                }

                int role = (int)roleComboBox.SelectedItem;

                employeeService.NewUser(id, firstName, lastName, role, pin);
                MessageBox.Show("Employee added successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while adding employee: " + ex.Message);
            }
        }
    }
}
