using Service;
using Model;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UI.Stocks_UI;

namespace UI
{
    public partial class Stocks : Form
    {
        private MenuItemService menuItemService;
        private MenuTypes selectedType;
        private bool buttonState;
        private InvoiceService invoiceService;
        private PaymentService paymentService;
        private EmployeeService employeeService;

        public Stocks()
        {
            InitializeComponent();
            menuItemService = new MenuItemService();
            invoiceService = new InvoiceService();
            paymentService = new PaymentService();
            buttonState = false;
            employeeService = new EmployeeService();

            InitializeUI();
        }

        private void InitializeUI()
        {
            
            stocksPanel.Hide();
            employeesPanel.Hide();
            overviewPanel.Show(); 
            
            RefreshLowStockList();
            RefreshEmployeeList();
            RefreshOverviewData();
        }

        private void ShowPanel(Panel panelToShow)
        {
            overviewPanel.Hide();
            stocksPanel.Hide();
            employeesPanel.Hide();
            panelToShow.Show();
        }

        private void ShowStocksPanel()
        {
            ShowPanel(stocksPanel);
        }

        private void ShowEmployeesPanel()
        {
            ShowPanel(employeesPanel);
            RefreshEmployeeList();
        }

        private void ShowOverviewPanel()
        {
            ShowPanel(overviewPanel);
            RefreshOverviewData();
        }

        private void RefreshOverviewData()
        {
            try
            {
                revenuelabel.Text = $"{invoiceService.GetTotalIncome()} €";
                tipsLabel.Text = $"{paymentService.GetTipsAmount()}"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred loading overview page: " + ex.Message);
            }
        }

        private void RefreshEmployeeList()
        {
            try
            {
                List<Employee> employees = employeeService.GetAllEmployee();
                DisplayEmployees(employeesList, employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred viewing employees: " + ex.Message);
            }
        }

        private void RefreshMenuList()
        {
            try
            {
                List<MenuItem> menuItems = menuItemService.GetAllMenuItems();
                DisplayMenuItems(stocksList, menuItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while loading the stocks: " + ex.Message);
            }
        }

        private void RefreshLowStockList()
        {
            try
            {
                List<MenuItem> menuItems = menuItemService.GetAllLowStockItems();
                DisplayMenuItems(lowStockList, menuItems);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occurred viewing low stock items: " + e.Message);
            }
        }

        private void RefreshItemsByCategory(MenuTypes type)
        {
            try
            {
                buttonState = true;
                List<MenuItem> filteredItems = menuItemService.RefreshItemsByCategory(type);
                DisplayMenuItems(stocksList, filteredItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayMenuItems(ListView listView, List<MenuItem> items)
        {
            listView.Items.Clear();
            foreach (MenuItem item in items)
            {
                ListViewItem listViewItem = new ListViewItem(item.MenuItemId.ToString("000000"))
                {
                    SubItems = {
                        item.Name,
                        item.Category.ToString(),
                        item.Stock.ToString(),
                        item.Price.ToString(),
                        menuItemService.DisplayVatAsPercantage(item.Tax),
                        item.Type.ToString(),
                        item.IsAlchoholic ? "Yes" : "No"
                    }
                };

                if (item.Stock > 10)
                {
                    listViewItem.BackColor = Color.White;
                }
                else if (item.Stock > 0)
                {
                    listViewItem.BackColor = Color.Orange;
                }
                else
                {
                    listViewItem.BackColor = Color.Red;
                }

                listView.Items.Add(listViewItem);
            }
        }

        private void DisplayEmployees(ListView listView, List<Employee> employees)
        {
            listView.Items.Clear();
            foreach (Employee employee in employees)
            {
                ListViewItem listViewItem = new ListViewItem(employee.Id.ToString("000000"))
                {
                    SubItems = {
                        employee.FirstName,
                        employee.LastName,
                        employee.Role.ToString()
                    }
                };
                listView.Items.Add(listViewItem);
            }
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            ShowOverviewPanel();
        }

        private void lunchDinner_Click_1(object sender, EventArgs e)
        {
            selectedType = MenuTypes.Lunch;
            RefreshItemsByCategory(selectedType);
        }

        private void drinkButton_Click_1(object sender, EventArgs e)
        {
            selectedType = MenuTypes.Drinks;
            RefreshItemsByCategory(selectedType);
        }

        private void dinnerButton_Click_1(object sender, EventArgs e)
        {
            selectedType = MenuTypes.Dinner;
            RefreshItemsByCategory(selectedType);
        }

        private void updateMenuItem_Click(object sender, EventArgs e)
        {
            AddMenuItem updateMenuItem = new AddMenuItem();
            updateMenuItem.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!buttonState)
            {
                MessageBox.Show("Please select a category first.");
                return;
            }
            this.Enabled = false;
            DeleteMenuItem deleteMenuItem = new DeleteMenuItem(selectedType);
            deleteMenuItem.FormClosed += EnableStockUI;
            deleteMenuItem.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!buttonState)
            {
                MessageBox.Show("Please select a category first.");
                return;
            }
            this.Enabled = false;
            UpdateMenuItem updateMenuItem = new UpdateMenuItem(selectedType);
            updateMenuItem.FormClosed += EnableStockUI;
            updateMenuItem.Show();
        }

        private void stockAmountButton_Click(object sender, EventArgs e)
        {
            if (!buttonState)
            {
                MessageBox.Show("Please select a category first.");
                return;
            }
            this.Enabled = false;
            AdjustStock adjustStock = new AdjustStock(selectedType);
            adjustStock.FormClosed += EnableStockUI;
            adjustStock.Show();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (this.Enabled)
            {
                RefreshItemsByCategory(selectedType);
            }
        }

        private void EnableStockUI(object sender, EventArgs e)
        {
            this.Enabled = true;
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStocksPanel();
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOverviewPanel();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEmployeesPanel();
            RefreshEmployeeList();
        }

        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            AddEmployee employee = new AddEmployee();
            employee.Show();
        }

        private void removeEmployeeBtn_Click(object sender, EventArgs e)
        {
            DeleteEmployee deleteEmployee = new DeleteEmployee();
            deleteEmployee.Show();
        }

        private void updateEmployeeBtn_Click(object sender, EventArgs e)
        {
            UpdateEmployee updateEmployee = new UpdateEmployee();
            updateEmployee.Show();
        }
    }
}
