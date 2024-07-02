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

namespace UI
{
    public partial class BarKitchen : Form
    {
        OrderService orderService;
        TableService tableService;
        public BarKitchen()
        {
            InitializeComponent();
            orderService = new OrderService();
            tableService = new TableService();
            DisplayOrders();

            PopulateBarTableComboBox();
            PopulateSortComboBox();
            PopulateKitchenTableComboBox();
            PopulateSortComboBoxKitchen();
            AddCoulmnsToListView();
        }
        private void AddCoulmnsToListView()
        {
            listViewBar.Clear();

            listViewBar.Columns.Add("Name", 350);
            listViewBar.Columns.Add("Quantity", 100);
            listViewBar.Columns.Add("Order Time", 100);
            listViewBar.Columns.Add("Category", 100);
            listViewBar.Columns.Add("Status", 100);
            listViewBar.Columns.Add("Comment", 300);

            listViewKitchen.Clear();

            listViewKitchen.Columns.Add("Name", 350);
            listViewKitchen.Columns.Add("Quantity", 100);
            listViewKitchen.Columns.Add("Order Time", 100);
            listViewKitchen.Columns.Add("Category", 100);
            listViewKitchen.Columns.Add("Status", 100);
            listViewKitchen.Columns.Add("Comment", 300);
        }
        private bool IsBarCategory(Categories category)
        {
            return category == Categories.Beers ||
                   category == Categories.Wine_Glass ||
                   category == Categories.Wine_Bottle ||
                   category == Categories.Spirits ||
                   category == Categories.Coffee_Tea ||
                   category == Categories.Soft;
        }

        private bool IsKitchenCategory(Categories category)
        {
            return category == Categories.Entrees ||
                   category == Categories.Le_Plat_Principle ||
                   category == Categories.Les_Desserts ||
                   category == Categories.Entrements;
        }
        private void DisplayOrders()
        {
            listViewBar.Items.Clear();
            listViewKitchen.Items.Clear();

            List<Order> orders = GetOrders();

            foreach (Order order in orders)
            {
                ListViewItem li = new ListViewItem(order.menuItem.Name);
                li.SubItems.Add(order.orderItem.Quantity.ToString());
                li.SubItems.Add(order.Time.ToString("HH:mm:ss"));
                li.SubItems.Add(Enum.GetName(typeof(Categories), order.menuItem.Category));
                li.SubItems.Add(Enum.GetName(typeof(Status), order.orderItem.Status));
                li.SubItems.Add(order.orderItem.Comment);
                li.Tag = order;

                if (barTableComboBox.Text.Equals(order.Table.TableId.ToString()) && IsBarCategory(order.menuItem.Category))
                {
                    listViewBar.Items.Add(li);
                }
                else if (kitchenTableComboBox.Text.Equals(order.Table.TableId.ToString()) && IsKitchenCategory(order.menuItem.Category))
                {
                    listViewKitchen.Items.Add(li);
                }
                else if (sortBarComboBox.Text.Equals(Enum.GetName(typeof(Status), order.orderItem.Status)) && IsBarCategory(order.menuItem.Category))
                {
                    listViewBar.Items.Add(li);
                }
                else if (sortKitchenComboBox.Text.Equals(Enum.GetName(typeof(Status), order.orderItem.Status)) && IsKitchenCategory(order.menuItem.Category))
                {
                    listViewKitchen.Items.Add(li);
                }
            }
        }

        private List<Order> GetOrders()
        {
            List<Order> orders = orderService.GetOrderItemsForBarKitchen();
            return orders;
        }

        
        private void barkitchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlKitchen.Hide();
            pnlBar.Show();
        }

        private List<int> GetTables()
        {
            List<int> tables = tableService.GetAllTableNUmbers();
            return tables;
        }
        void PopulateBarTableComboBox()
        {
            barTableComboBox.Items.Clear();

            foreach (int table in GetTables())
            {
                barTableComboBox.Items.Add(table);
            }

            barTableComboBox.DisplayMember = "TableNumber";
        }
        void PopulateSortComboBox()
        {
            sortBarComboBox.Items.Clear();

            foreach (var status in Enum.GetValues(typeof(Status)))
            {
                sortBarComboBox.Items.Add(status);
            }
            sortBarComboBox.DisplayMember = "Status";
        }

        void PopulateKitchenTableComboBox()
        {
            kitchenTableComboBox.Items.Clear();

            foreach (int table in GetTables())
            {
                kitchenTableComboBox.Items.Add(table);
            }

            kitchenTableComboBox.DisplayMember = "TableNumber";
        }

        void PopulateSortComboBoxKitchen()
        {
            sortKitchenComboBox.Items.Clear();

            foreach (var status in Enum.GetValues(typeof(Status)))
            {
                sortKitchenComboBox.Items.Add(status);
            }
            sortKitchenComboBox.DisplayMember = "Status";
        }

        private void UpdateOrder(ListView listView, Status newStatus)
        {
            ListViewItem selectedItem = listView.SelectedItems[0];
            Order selectedOrder = (Order)selectedItem.Tag;
            selectedOrder.orderItem.Status = (Status)newStatus;

            try
            {
                orderService.UpdateStatus(selectedOrder);
                DisplayOrders();
                MessageBox.Show("Order Status Updated!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}");
            }
        }



        private void kitchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlBar.Hide();
            pnlKitchen.Show();
        }

        private void btnServedKitchen_Click(object sender, EventArgs e)
        {
            if (listViewKitchen.SelectedItems.Count > 0)
            {
                UpdateOrder(listViewKitchen, Status.Served);
            }
            else
            {
                MessageBox.Show("Please select an order to mark as served.");
            }
        }

        private void btnPreparingKitchen_Click(object sender, EventArgs e)
        {
            if (listViewKitchen.SelectedItems.Count > 0)
            {
                UpdateOrder(listViewKitchen, Status.Preparing);
            }
            else
            {
                MessageBox.Show("Please select an order to mark as served.");
            }
        }
        private void btnReadyToServeKitchen_Click(object sender, EventArgs e)
        {
            if (listViewKitchen.SelectedItems.Count > 0)
            {
                UpdateOrder(listViewKitchen, Status.ReadyToServe);
            }
            else
            {
                MessageBox.Show("Please select an order to mark as served.");
            }
        }
        private void btnservedBar_Click(object sender, EventArgs e)
        {
            if (listViewBar.SelectedItems.Count > 0)
            {
                UpdateOrder(listViewBar, Status.Served);
            }
            else
            {
                MessageBox.Show("Please select an order to mark as served.");
            }
        }

        private void btnReadyToServeBar_Click(object sender, EventArgs e)
        {
            if (listViewBar.SelectedItems.Count > 0)
            {
                UpdateOrder(listViewBar, Status.ReadyToServe);
            }
            else
            {
                MessageBox.Show("Please select an order to mark as served.");
            }
        }

        private void btnPreparingBar_Click(object sender, EventArgs e)
        {
            if (listViewKitchen.SelectedItems.Count > 0)
            {
                UpdateOrder(listViewKitchen, Status.Preparing);
            }
            else
            {
                MessageBox.Show("Please select an order to mark as served.");
            }
        }
        private void barTableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            kitchenTableComboBox.Text = "Select Table";
            sortBarComboBox.Text = "Sort";
            sortKitchenComboBox.Text = "Sort";
            DisplayOrders();
        }
        private void sortBarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            barTableComboBox.Text = "Select Table";
            kitchenTableComboBox.Text = "Select table";
            sortKitchenComboBox.Text = "Sort";
            DisplayOrders();
        }
        private void kitchenTableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortKitchenComboBox.Text = "Sort";
            barTableComboBox.Text = "Select Table";
            sortBarComboBox.Text = "Sort";
            DisplayOrders();
        }

        private void sortKitchenComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            kitchenTableComboBox.Text = "Select Table";
            barTableComboBox.Text = "Select Table";
            sortBarComboBox.Text = "Sort";
            DisplayOrders();
        }
        private void BarKitchen_Load(object sender, EventArgs e)
        {
            pnlBar.Show();
        }
    }
}
