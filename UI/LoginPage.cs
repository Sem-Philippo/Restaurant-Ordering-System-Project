using ChapeauService;
using Model;
using Model.Enums;
using Service;
using System.Security.Cryptography.X509Certificates;

namespace UI
{
    public partial class LoginPage : Form
    {
        //test comment
        private Employee employee;
        private int loginAttempts;

        // Instances of services used
        private readonly EmployeeService employeeService;
        private readonly OrderService orderService;
        private readonly PasswordVerificationService passwordVerificationService;

        public LoginPage()
        {
            InitializeComponent();
            HideInput();
            loginAttempts = 0;

            // Initializing services
            employeeService = new EmployeeService();
            passwordVerificationService = new PasswordVerificationService();
            orderService = new OrderService();
        }

        private void HideInput()
        {
            // Set to no text.
            txtpassword.Text = "";

            // The password character is an asterisk.
            txtpassword.PasswordChar = '*';

            // The control will allow no more than 20 characters.
            txtpassword.MaxLength = 20;
        }

        private bool TextOnly(string text)
        {
            foreach (char c in text)
                if (!char.IsLetter(c))
                    return false;
            return true;
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            // Updates the label with contact manager message
            string message = "Please contact the manager.";
            MessageBox.Show(message, "Forgot Password");
        }

        private void OpenUI(Form newForm)
        {
            // Define active form and hide it
            Form activeForm = ActiveForm;
            activeForm.Hide();

            // Show new form, which needs to be open
            newForm.ShowDialog();

            // Close previous form , so it's not running in the background
            activeForm.Close();
        }
        private void OpenForm()
        {
            // I'm passing the employee who logged in data to the home form.
            overview newForm = new overview();
            OpenUI(newForm);
        }


        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            string username = txtfirstName.Text;
            string password = txtpassword.Text;

            if (loginAttempts >= 3)
            {
                MessageBox.Show("Maximum login attempts reached. The application will now close.", "Error");
                Close();
                return;
            }

            if (!TextOnly(username))
            {
                MessageBox.Show("Invalid username. Please enter only letters.", "Invalid Username");
                return;
            }

            // Checks the credentials from employee service
            if (passwordVerificationService.VerifyPassword(username, password))
            {
                employee = employeeService.GetEmployeeByName(username);

                MessageBox.Show("Congrats, you have successfully logged in", "Login Successful");
                OpenForm();
                // Hides login UI after new view is opened
                Hide();
            }
            else
            {
                loginAttempts++;
                int remainingAttempts = 3 - loginAttempts;
                // Shows an error message if the entered credentials are incorrect
                MessageBox.Show($"Invalid credentials, number of attempts left: {remainingAttempts}", "Invalid Credentials");
            }
        }
    }
}
