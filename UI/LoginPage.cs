using System.Security.Cryptography.X509Certificates;
using Model;

namespace UI
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            //trst
            
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {


            Orders orders = new Orders(new Employee() { Id=3}, new Table(3, 2, true));   
            orders.Show();

        }
        
    }
}