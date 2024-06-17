using System.Security.Cryptography.X509Certificates;

namespace UI
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();

            
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {


            Payment payment = new Payment();
            payment.Show();

        }
        
    }
}