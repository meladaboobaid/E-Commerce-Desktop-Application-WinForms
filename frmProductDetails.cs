using SawaStore_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmProductDetails : Form
    {
        private int _ProductID;
        private clsProductCatalog _Product;
        public frmProductDetails(int ProductID)
        {
            InitializeComponent();
            if(ProductID != -1)
            {
                _ProductID = ProductID;
                _Product = clsProductCatalog.Find(_ProductID);
            }
        }

        private void _LoadProductDetails()
        {
            if( _Product != null )
            {
                lblCategory.Text = _Product.ProductCategoryInfo.CategoryName;
                lblPrice.Text = _Product.ProductPrice.ToString() + " $";
                lblProductName.Text = _Product.ProductName;
                lblQuantityInStock.Text = _Product.QuantityInStock.ToString();
                lblDescription.Text = _Product.ProductDescription;
                lblProductID.Text = _Product.ProductID.ToString();
                if(_Product.ProductImagesURLs.Count > 0)
                { 
                    pbImage.ImageLocation = _Product.ProductImagesURLs[0];
                }
                else
                {
                    pbImage.Image = Properties.Resources.a2414e0d209394565244ccffd1b08017;
                }
            }
            else
            {
                lblCategory.Text = "???";
                lblDescription.Text = "???";
                lblPrice.Text = "???";
                lblProductName.Text = "???";
                lblQuantityInStock.Text = "???";
                lblProductID.Text = "???";
                pbImage.Image = Properties.Resources.a2414e0d209394565244ccffd1b08017;
            }
        }

        private void frmProductDetails_Load(object sender, EventArgs e)
        {
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            _LoadProductDetails();
        }

    }
}
