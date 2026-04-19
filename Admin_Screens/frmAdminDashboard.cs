using Guna.UI2.WinForms;
using Sawa_Store_Project.Controls;
using SawaStore_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmAdminDashboard : Form
    {
        private static DataTable _dtUser = clsUsers.GetAllUsers();
        private DataTable _dtUsersTable = _dtUser.DefaultView.ToTable(false, "UserID", "Name", "UserName", "Email", "Phone", "IsActive");


        private static DataTable _dtCustomers = clsCustomers.GetAllCustomers();
        private DataTable _dtCustomersTable = _dtCustomers.DefaultView.ToTable(false, "CustomerID", "Name", "UserName", "Email", "Address", "Phone");

        private static DataTable _dtProducts  = clsProductCatalog.GetAllProducts();
        private DataTable _dtProductsTable = _dtProducts.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryID", "Description", "Price", "QuantityInStock");

        private static DataTable _dtOrders = clsOrders.GetAllOrders();
        private DataTable _dtOrdersTable = _dtOrders.DefaultView.ToTable(false, "OrderID", "Name", "TotalAmount", "OrderDate", "OrderStatus");

        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void _RefreshUsersDataGrid()
        {
            _dtUser = clsUsers.GetAllUsers();
            _dtUsersTable = _dtUser.DefaultView.ToTable(false, "UserID", "Name", "UserName", "Email", "Phone", "IsActive");
            dgvUsers.DataSource  = _dtUsersTable;
        }

        private void _RefreshOrdersDataGrid()
        {
            _dtOrders = clsOrders.GetAllOrders();
            _dtOrdersTable = _dtOrders.DefaultView.ToTable(false, "OrderID", "Name", "TotalAmount", "OrderDate", "OrderStatus");
            dgvOrders.DataSource = _dtOrdersTable;

            dgvOrders.Columns[0].HeaderText = "Order ID";
            dgvOrders.Columns[1].HeaderText = "Customer Name";
            dgvOrders.Columns[2].HeaderText = "Total Amount";
            dgvOrders.Columns[3].HeaderText = "Order Date";
            dgvOrders.Columns[4].HeaderText = "Order Status";

            lblNumberOfOrders.Text = _dtOrdersTable.Rows.Count.ToString();
        }
        private void _LoadProductsIntoFlowLayout(object sender, int ProductID)
        {
            _dtProducts = clsProductCatalog.GetAllProducts();
            _dtProductsTable = _dtProducts.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryID", "Description", "Price", "QuantityInStock");
            lblNumberOfProducts.Text = _dtProducts.Rows.Count.ToString();

            flpProductsPanel.Controls.Clear();

            foreach (DataRow row in _dtProductsTable.Rows)
            {
                ctrlProduct product = new ctrlProduct();
                product.OnProductChanged += _LoadProductsIntoFlowLayout;
                product.SetAdminMode();

                product.LoadProductInfo((int)row["ProductID"]);
                flpProductsPanel.Controls.Add(product);
            }

            txtProductSearch.Text = "";
            txtProductSearch.Focus();
        }

        private void _RefreshProductsAfterSearch(DataTable dtProducts)
        {
            _dtProductsTable = dtProducts.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryID", "Description", "Price", "QuantityInStock");
            lblNumberOfProducts.Text = dtProducts.Rows.Count.ToString();

            flpProductsPanel.Controls.Clear();
            foreach (DataRow row in _dtProductsTable.Rows)
            {
                ctrlProduct product = new ctrlProduct();
                product.OnProductChanged += _LoadProductsIntoFlowLayout;
                product.SetAdminMode();

                product.LoadProductInfo((int)row["ProductID"]);
                flpProductsPanel.Controls.Add(product);
            }
        }

        private void btnFashion_Click(object sender, EventArgs e)
        {
            tcAdminButtons.SelectedIndex = 1;
            MessageBox.Show("Reposts Tab is Not Implemented Yet", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            tcAdminButtons.SelectedIndex = 0;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            tcAdminButtons.SelectedIndex = 2;
            _RefreshUsersDataGrid();
        }

        private void btnBeauty_Click(object sender, EventArgs e)
        {
            tcAdminButtons.SelectedIndex = 3;
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            tcAdminButtons.SelectedIndex = 2;
            _RefreshUsersDataGrid();
        }
        private void _LoadCategoriesInComboBox()
        {
            DataTable dtCategories = clsProductCategory.GetAllCategories();

            foreach (DataRow row in dtCategories.Rows)
            {
                cbCategories.Items.Add(row["CategoryName"].ToString());
            }
            cbCategories.SelectedIndex = 0;
        }
        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = clsUsers.GetAllUsers();

            dgvUsers.Columns["IsActive"].HeaderText = "Activation";
            _RefreshUsersDataGrid();

            _LoadCategoriesInComboBox();
            _LoadProductsIntoFlowLayout(null, -1);
            _AutoCompleteForSearchTextBox();
            _RefreshOrdersDataGrid();
        }

        private void _AutoCompleteForSearchTextBox()
        {
            string[] suggestions = {"Customers", "Products", "Manage Customers", "Users", "Manage Users",
            "Orders", "Orders Tracking", "Reports", "Manage products", "Manage orders", "Statistics", "Low Stock Products"};

            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection autoCompleteSuggestions = new AutoCompleteStringCollection();
            autoCompleteSuggestions.AddRange(suggestions);

            txtSearch.AutoCompleteCustomSource = autoCompleteSuggestions;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser addNewUser = new frmAddNewUser(-1);
            addNewUser.ShowDialog();
            _RefreshUsersDataGrid();
        }
        private void tsmEditUserInfo_Click(object sender, EventArgs e)
        {
            frmAddNewUser addNewUser = new frmAddNewUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            addNewUser.ShowDialog();
            _RefreshUsersDataGrid();
        }
        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Name";

            if (txtSearchUser.Text.Trim() == "")
            {
                _dtUsersTable.DefaultView.RowFilter = "";
                _RefreshUsersDataGrid();
                return;
            }

            _dtUsersTable.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtSearchUser.Text.Trim());
        }

        private void tsmDeleteUser_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this person?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsUsers.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully !", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersDataGrid();
                    return;
                }
                else
                    MessageBox.Show("User Deleted Failed !", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void viewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewUserInfo viewUserInfo = new frmViewUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            viewUserInfo.ShowDialog();
        }
        private void sendAnEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet", "InComplete", MessageBoxButtons.OK, MessageBoxIcon.Hand) ;
        }
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet", "InComplete", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            tcAdminButtons.SelectedIndex = 4;
            _RefreshCustomersDataGrid();
        }
        private void tpManageCustomers_Click(object sender, EventArgs e)
        {
        }
        private void _RefreshCustomersDataGrid()
        {
            _dtCustomers = clsCustomers.GetAllCustomers();
            _dtCustomersTable = _dtCustomers.DefaultView.ToTable(false, "CustomerID", "Name", "UserName", "Email", "Address", "Phone");
            dgvCustomers.DataSource = _dtCustomersTable;
            lblTotalCustomers.Text = _dtCustomersTable.Rows.Count.ToString();
        }
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomers addEditCustomer = new frmAddEditCustomers(-1);
            addEditCustomer.ShowDialog();
            _RefreshCustomersDataGrid();
        }
        private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditCustomers editCustomer = new frmAddEditCustomers((int)dgvCustomers.CurrentRow.Cells[0].Value);
            editCustomer.ShowDialog();
            _RefreshCustomersDataGrid();
        }
        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this customer ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(clsCustomers.DeleteCustomer((int)dgvCustomers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Customer deleted successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshCustomersDataGrid();
                    return;
                }
                else
                {
                    MessageBox.Show("Delete customer failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void viewCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature not implemented yet","Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
        private void sendAnEmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature not implemented yet", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void callByPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature not implemented yet", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtCustomersSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Name";

            if (txtCustomersSearch.Text.Trim() == "")
            {
                _dtCustomersTable.DefaultView.RowFilter = "";
                _RefreshCustomersDataGrid();
                return;
            }
            _dtCustomersTable.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtCustomersSearch.Text.Trim());
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            tcAdminButtons.SelectedIndex = 3;
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            frmAddEditProduct addNewProduct = new frmAddEditProduct(-1);
            addNewProduct.ShowDialog();
            _LoadProductsIntoFlowLayout(null, -1);
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "ProductName";

            if (txtProductSearch.Text.Trim() == "")
            {
                _dtProductsTable.DefaultView.RowFilter = "";
                _LoadProductsIntoFlowLayout(null, -1);
                return;
            }

            _dtProductsTable.DefaultView.RowFilter =
                string.Format("[{0}] Like '%{1}%'", FilterColumn, txtProductSearch.Text.Trim());
            _RefreshProductsAfterSearch(_dtProductsTable);
        }

        private void addNewCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature isn't implemented yet", "Not Implemented", MessageBoxButtons.OK);
        }
        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature isn't implemented yet", "Not Implemented", MessageBoxButtons.OK);
        }


        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (txtSearch.Text.Trim().ToLower() == "customers" || txtSearch.Text.Trim().ToLower() == "manage customers")
                {
                    tcAdminButtons.SelectedIndex = 4;
                    _RefreshCustomersDataGrid();

                }
                if (txtSearch.Text.Trim().ToLower() == "users" || txtSearch.Text.Trim().ToLower() == "manage users")
                {
                    tcAdminButtons.SelectedIndex = 2;
                    _RefreshUsersDataGrid();
                }
                if (txtSearch.Text.Trim().ToLower() == "products" || txtSearch.Text.Trim().ToLower() == "manage products")
                {
                    tcAdminButtons.SelectedIndex = 3;
                }
                if (txtSearch.Text.Trim().ToLower() == "orders" || txtSearch.Text.Trim().ToLower() == "manage orders")
                {
                    tcAdminButtons.SelectedIndex = 5;
                }
                if (txtSearch.Text.Trim().ToLower() == "reports" || txtSearch.Text.Trim().ToLower() == "statistics")
                {
                    tcAdminButtons.SelectedIndex = 1;
                }
                if (txtSearch.Text.Trim().ToLower() == "low stock products" )
                {
                    tcAdminButtons.SelectedIndex = 7;
                }
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            tcAdminButtons.SelectedIndex = 5;
        }
        private void btnOrderTracking_Click(object sender, EventArgs e)
        {
            tcAdminButtons.SelectedIndex = 5;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature isn't implemented yet", "Not Implemented", MessageBoxButtons.OK);
        }

        private void btnPoliciesAndTerms_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature isn't implemented yet", "Not Implemented", MessageBoxButtons.OK);
        }

        private void btnViewPendingOrders_MouseHover(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.FromArgb(234, 123, 10);
        }

        private void btnViewPendingOrders_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.White;
        }

        private void tpUsers_MouseHover(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.FromArgb(234, 123, 10);
        }

        private void tpUsers_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.White;
        }

        private void btnAddNewProduct_MouseHover(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.FromArgb(234, 123, 10);
        }

        private void btnAddNewProduct_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.White;
        }
    }
}
