using Guna.UI2.WinForms;
using SawaStore_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sawa_Store_Project.Controls
{
    public partial class ctrlProduct : UserControl
    {
        enum enMode { Client  = 1, Admin = 2};
        enMode _Mode = enMode.Client;
        private int SwitchImagesCounter = 1;

        public delegate void Change(object sender, int ProductID);
        public event Change OnProductChanged;
        //
        public delegate void AddToCart(object sender, int ProductID);
        public event AddToCart OnProductAddToCart;
        public int ProductID { get; set; }

        private clsProductCatalog _Product;
        private clsProductImages ProductImage;
        private List<string> _ImageURLs;

        public ctrlProduct()
        {
            InitializeComponent();
        }

        public void SetAdminMode()
        {
            _Mode = enMode.Admin; 
            btnEditProduct.Visible = true;
            deleteProductToolStripMenuItem.Visible = true;
            btnAddToCart.Visible = false;
        }
        public void SetControlToClientMode()
        {
            _Mode = enMode.Client;
            btnEditProduct.Visible = false;
            deleteProductToolStripMenuItem.Visible = false;
        }

        private void guna2Button1_MouseHover(object sender, EventArgs e)
        {
            Color foreColor = Color.FromArgb(254, 105, 1);
            btnAddToCart.FillColor = foreColor;
        }
        private void btnAddToCart_MouseLeave(object sender, EventArgs e)
        {
            Color foreColor = Color.FromArgb(255, 255, 255);
            btnAddToCart.FillColor = foreColor;
        }
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            OnProductAddToCart?.Invoke(this, ProductID);
        }
        private void ctrlProduct_Load(object sender, EventArgs e)
        {
            //pbProductImage.Image = Properties.Resources.a2414e0d209394565244ccffd1b08017;
        }

        public void LoadProductInfo(int productID)
        {
            if(productID != -1)
            {
                ProductID = productID;

                _Product = clsProductCatalog.Find(ProductID);
                lblProductName.Text = _Product.ProductName;
                lblProductPrice.Text = _Product.ProductPrice.ToString() + " $";
                lblProductType.Text = _Product.ProductCategoryInfo.CategoryName;

                if(_Product.ProductImagesURLs.Count > 0)
                {
                    pbProductImage.ImageLocation = _Product.ProductImagesURLs.First();
                }
                else
                {
                    pbProductImage.Image = Properties.Resources.a2414e0d209394565244ccffd1b08017;
                }
                _ImageURLs = _Product.ProductImagesURLs;
            }
        }
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            frmAddEditProduct editProduct = new frmAddEditProduct(ProductID);
            editProduct.ShowDialog();
            OnProductChanged(this, ProductID);
        }
        private void btnEditProduct_MouseHover(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.FromArgb(254, 105, 1);
        }
        private void btnEditProduct_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.White;
        }
        private void deleteProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsProductCatalog.Delete(ProductID))
            {
                MessageBox.Show("Product deleted successfully!", "Done", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                OnProductChanged?.Invoke(this, ProductID);
            }
            else
            {
                MessageBox.Show("Product deleted failed!", "Error", MessageBoxButtons.OK,
    MessageBoxIcon.Error);
            }
        }
        private void productDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductDetails productDetails = new frmProductDetails(_Product.ProductID);
            productDetails.ShowDialog();
        }
        private void switchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchImagesCounter >= _Product.ProductImagesURLs.Count)
                SwitchImagesCounter = 0;

            if (SwitchImagesCounter < _Product.ProductImagesURLs.Count)
            {
                if (_Product.ProductImagesURLs.Count > 0)
                {
                    pbProductImage.ImageLocation = _Product.ProductImagesURLs[SwitchImagesCounter];
                }
            }
            SwitchImagesCounter++;
        }
    }
}
