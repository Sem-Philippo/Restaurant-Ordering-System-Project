using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace UI.UserControls
{
    public partial class MenuItemUserControl : UserControl
    {
        public int quantity;
        public MenuItem menuItem;
        public MenuItemUserControl(MenuItem menuItem)
        {
            InitializeComponent();
            this.menuItem = menuItem;
            quantity = 0;
        }

        private void MenuItemUserControl_Load(object sender, EventArgs e)
        {
            UpdateLabels();
        }
        private void UpdateLabels()
        {
            lblDishName.Text = menuItem.Name;
            lblAmount.Text = 0.ToString();
        }

        private void btnAmountIncrease_Click(object sender, EventArgs e)
        {
            quantity += 1;
            lblAmount.Text = quantity.ToString();
        }

        private void btnAmountDecrease_Click(object sender, EventArgs e)
        {
            if (quantity > 0)
            {
                quantity -= 1;
                lblAmount.Text = quantity.ToString();
            }
        }
    }
}
