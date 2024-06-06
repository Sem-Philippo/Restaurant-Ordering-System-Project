using System.Security.Cryptography.X509Certificates;

namespace UI
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            Payment payment = new Payment();
            payment.Show();
        }
        
    }
}