using Guna.UI2.WinForms;
using Sawa_Store_Project.Controls;
using SawaStore_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmClientView : Form
    {
        private List<clsOrderItems> _ShoppingCart = new List<clsOrderItems>();

        private int _CustomerID = -1;
        private SortedSet<string> _SearchSuggestions = new SortedSet<string>();

        private int PageNumber = 1;
        private int PageSize = 10;
        private int TotalProducts = 0;
        private int TotalPages = 0;

        private static DataTable _dtAllProducts = clsProductCatalog.GetProductsInfo();
        private DataTable _dtProductsTable = _dtAllProducts.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryName", "Description", "Price", "QuantityInStock");


        public frmClientView(int CustomerID)
        {
            InitializeComponent();
            if(CustomerID != -1)
            {
                _CustomerID = CustomerID;
                clsGlobal.LoggedInCustomer = clsCustomers.Find(_CustomerID);
            }
        }

        private void OnProductAddedToCart(object sender, int ProductID)
        {
            clsProductCatalog product = clsProductCatalog.Find(ProductID);
            if(product.QuantityInStock == 0)
            {
                MessageBox.Show("This product is out of stock now, try later", "Out Of Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var existingItem = _ShoppingCart.FirstOrDefault(i => i.ProductID == ProductID);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.CalculateTotalPrice();
            }
            else
            {
                clsOrderItems orderItem = new clsOrderItems()
                {
                    ProductID = ProductID,
                    Quantity = 1,
                    Price = product.ProductPrice,
                };

                orderItem.CalculateTotalPrice();
                _ShoppingCart.Add(orderItem);

            }

            btnViewCart.Text = $"({_ShoppingCart.Count})";
            MessageBox.Show("Product added to cart successfully", "Added To Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _LoadProductsIntoFlowLayout()
        {
            flpProductsPanel.Controls.Clear();

            DataTable products = clsProductCatalog.GetProducts_Paging(PageNumber, PageSize);
            _dtProductsTable = products.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryName", "Description", "Price", "QuantityInStock");

            foreach (DataRow row in _dtProductsTable.Rows)
            {
                ctrlProduct product = new ctrlProduct();
                product.SetControlToClientMode();
                product.OnProductAddToCart += OnProductAddedToCart;
                product.LoadProductInfo((int)row["ProductID"]);
                flpProductsPanel.Controls.Add(product);
            }
            
        }
        private void _RefreshProductsAfterSearch(DataTable dtProducts)
        {
            flpProductsPanel.Controls.Clear();
            _dtProductsTable = dtProducts.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryName", "Description", "Price", "QuantityInStock");

            foreach (DataRow row in _dtProductsTable.Rows)
            {
                ctrlProduct product = new ctrlProduct();
                product.SetControlToClientMode();
                product.LoadProductInfo((int)row["ProductID"]);
                product.OnProductAddToCart += OnProductAddedToCart;
                flpProductsPanel.Controls.Add(product);
            }   
        }

        private void _AutoCompleteForSearch()
        {
            DataTable dtSuggestions = clsProductCatalog.GetAllProductsName();

            foreach(DataRow row in dtSuggestions.Rows)
            {
                _SearchSuggestions.Add(row["ProductName"].ToString());
            }

            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection autoCompleteSuggestions = new AutoCompleteStringCollection();
            autoCompleteSuggestions.AddRange(_SearchSuggestions.ToArray<string>());

            txtSearch.AutoCompleteCustomSource = autoCompleteSuggestions;
        }

        private void _InitializePaging()
        {
            TotalProducts = clsProductCatalog.GetTotalProducts();
            TotalPages = (int) Math.Ceiling((double)TotalProducts/ PageSize);
            btnCurrentPage.Text = PageNumber.ToString();
            _LoadProductsIntoFlowLayout();
        }

        private void frmClientView_Load(object sender, EventArgs e)
        {
            _InitializePaging();
            trbPriceRange.Value = 500;
            lblPriceRange.Text = "500 $";
            btnElectronics.Focus();
            _AutoCompleteForSearch();
        }

        private void tbPriceRange_Scroll(object sender, ScrollEventArgs e)
        {
            lblPriceRange.Text = trbPriceRange.Value.ToString() + " $";
            double trbValue = Convert.ToSingle(trbPriceRange.Value);

            //string FilterColumn = "Price";

            if (trbValue  ==  0)
            {
                _dtProductsTable.DefaultView.RowFilter = "";
                _LoadProductsIntoFlowLayout();
                return;
            }

            DataTable products = clsProductCatalog.GetProductsInfo();
            _dtProductsTable = products.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryName", "Description", "Price", "QuantityInStock");

            _dtProductsTable.DefaultView.RowFilter = string.Format("Price > 0 and Price < {0}", trbValue);
                //string.Format("[{0}] between 0 and {1}", FilterColumn, trbValue);
            _RefreshProductsAfterSearch(_dtProductsTable);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "ProductName";

            if (txtSearch.Text == "")
            {
                _dtProductsTable.DefaultView.RowFilter = "";
                _LoadProductsIntoFlowLayout();
                return;
            }

            DataTable products = clsProductCatalog.GetProductsInfo();
            _dtProductsTable = products.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryName", "Description", "Price", "QuantityInStock");

            _dtProductsTable.DefaultView.RowFilter =
                string.Format("[{0}] like '%{1}%'", FilterColumn, txtSearch.Text.Trim());
            _RefreshProductsAfterSearch(_dtProductsTable);
        }

        private void btnUploadImagePanel1_MouseHover(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.FromArgb(234, 130, 10);
        }

        private void btnUploadImagePanel1_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.White;
        }

        private void btnMoreProducts_Click(object sender, EventArgs e)
        {
            if(PageNumber < TotalPages)
            {
                PageNumber++;
                btnCurrentPage.Text = PageNumber.ToString();
                _LoadProductsIntoFlowLayout();
            }
        }

        private void btnPreviousProducts_Click(object sender, EventArgs e)
        {
            if(PageNumber > 1)
            {
                PageNumber--;
                btnCurrentPage.Text = PageNumber.ToString();
                _LoadProductsIntoFlowLayout();
            }
        }

        private void frmClientView_Click_1(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            string FilterColumn = "CategoryName";
            string SearchFor = button.Text.Trim();


            DataTable dtProducts = clsProductCatalog.GetProductsInfo();
            _dtProductsTable = dtProducts.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryName",
                "Description", "Price", "QuantityInStock");

            _dtProductsTable.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, SearchFor);

            if (_dtProductsTable.DefaultView.Count == 0)
            {
                MessageBox.Show($"There are no {button.Text} Products now, try later", "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _LoadProductsIntoFlowLayout();
                return;
            }
            _RefreshProductsAfterSearch(_dtProductsTable);
        }

        private void btnElectronics_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnViewCart_Click(object sender, EventArgs e)
        {

            if(_ShoppingCart.Count  == 0)
            {
                MessageBox.Show("There are no items inside your cart pick a product to add!", "Empty Cart", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            frmShoppingCart shoppingCart = new frmShoppingCart(_ShoppingCart);
            shoppingCart.ShowDialog();
            btnViewCart.Text = $"({_ShoppingCart.Count})";
        }
    }
}
