using Guna.UI2.WinForms;
using SawaStore_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmAddEditProduct : Form
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode Mode = enMode.AddNew;
        private int _ProductID = -1;
        private clsProductCatalog _Product;
        private List<string> _ProductImagesURLs;
        private List<clsProductImages> _ProductImages;
        private byte ProductImageOrderForDelete = 0;


        public frmAddEditProduct(int ProductID)
        {
             InitializeComponent();

            if (ProductID == -1)
            {
                Mode  = enMode.AddNew;
                lblCaption.Text = "Add New Product";
                _Product = new clsProductCatalog();
                _ProductImages = new List<clsProductImages>();
                _ProductImagesURLs = new List<string>();
            }
            else
            {
                Mode = enMode.Update;
                lblCaption.Text = "Update Product";
                _ProductID = ProductID;
                _Product = clsProductCatalog.Find(_ProductID);
                //_LoadProductImages();
            }
        }

        private void _LoadProductImages()
        {
            _ProductImages = new List<clsProductImages>();
            DataTable dtProductsImages = clsProductImages.GetAllImagesInfoAboutProduct(_ProductID);

            foreach(DataRow row in dtProductsImages.Rows)
            {
                clsProductImages image = new clsProductImages();
                image.ProductID = _ProductID;
                image.ImageURL = row["ImageURL"].ToString();
                image.ImageID = Convert.ToInt32(row["ImageID"]);
                image.ImageOrder = Convert.ToInt32(row["ImageOrder"]);

                _ProductImages.Add(image);
            }

            for(int i = 0; i < _ProductImages.Count; i++)
            {
                if(i== 0)
                {
                    pbMainImage1.ImageLocation = _ProductImages[i].ImageURL;
                    pbMainImage1.Tag = 1;
                    pbMainImage1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (i == 1)
                {
                    pbImage2.ImageLocation = _ProductImages[i].ImageURL;
                    pbImage2.Tag = 2;
                    pbImage2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (i == 2)
                {
                    pbImage3.ImageLocation = _ProductImages[i].ImageURL;
                    pbImage3.Tag = 3;
                    pbImage3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (i == 3)
                {
                    pbImage4.ImageLocation = _ProductImages[i].ImageURL;
                    pbImage4.Tag = 4;
                    pbImage4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

        }

        private void  SaveProductImages(int ProductID)
        {
            clsProductImages.DeleteProductImages(_ProductID);
            
            //_ProductImagesURLs.Clear();
            _ProductImages.Clear();

            if(Convert.ToInt32( pbMainImage1.Tag) > 0)
            {
                clsProductImages image1 = new clsProductImages();
                image1.ProductID = ProductID;
                image1.ImageURL = pbMainImage1.ImageLocation;
                image1.ImageOrder = 1;
                image1.Save();
                _ProductImages.Add(image1);
            }
            if(Convert.ToInt32(pbImage2.Tag) > 0)
            {
                clsProductImages image2 = new clsProductImages();
                image2.ProductID = ProductID;
                image2.ImageURL = pbImage2.ImageLocation;
                image2.ImageOrder = 2;
                image2.Save();
                _ProductImages.Add(image2);
            }
            if (Convert.ToInt32(pbImage3.Tag) > 0)
            {
                clsProductImages image3 = new clsProductImages();
                image3.ProductID = ProductID;
                image3.ImageURL = pbImage3.ImageLocation;
                image3.ImageOrder = 3;
                image3.Save();
                _ProductImages.Add(image3);
            }
            if (Convert.ToInt32(pbImage4.Tag) > 0)
            {
                clsProductImages image4 = new clsProductImages();
                image4.ProductID = ProductID;
                image4.ImageURL = pbImage4.ImageLocation;
                image4.ImageOrder = 4;
                image4.Save();
                _ProductImages.Add(image4);
            }
        }

        private void _LoadProductData()
        {

            if (Mode == enMode.Update && _Product != null)
            {
                _LoadProductImages();
                cbCategories.SelectedIndex = cbCategories.FindString(_Product.ProductCategoryInfo.CategoryName);
                txtProductName.Text = _Product.ProductName;
                txtDescription.Text = _Product.ProductDescription;
                txtProductPrice.Text = _Product.ProductPrice.ToString();
                txtQauntityInStock.Text = _Product.QuantityInStock.ToString();
            }
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Make sure there are no empty fields 
            if (txtDescription.Text == "" || txtProductName.Text == "" || txtProductPrice.Text == ""|| cbCategories.Text == ""||
                txtQauntityInStock.Text.Trim().Length == 0)
            {
                MessageBox.Show("There are empty fields, Make sure all fields full", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Product.ProductCategoryID = clsProductCategory.Find(cbCategories.Text.Trim()).CategoryID;
            _Product.ProductName = txtProductName.Text.Trim();
            _Product.ProductPrice = Convert.ToSingle( txtProductPrice.Text.Trim());
            _Product.ProductDescription = txtDescription.Text.Trim();
            _Product.QuantityInStock = Convert.ToInt32( txtQauntityInStock.Text.Trim());

            if(_Product.Save())
            {
                _ProductID = _Product.ProductID;
                SaveProductImages(_Product.ProductID);

                MessageBox.Show("Product Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("Product Added Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.FromArgb(234, 134, 0);
        }
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.FillColor = Color.White;
        }
        private void pbMainImage1_Click(object sender, EventArgs e)
        {
            ofdInsertImage.Filter = "Image Files|*.png;*.jpg; *.jpeg;*.pmb";
            ofdInsertImage.FilterIndex = 0;
            ofdInsertImage.RestoreDirectory = true;

            if (ofdInsertImage.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = ofdInsertImage.FileName;
                pbMainImage1.ImageLocation = ImagePath;
                pbMainImage1.Tag = 1;
                pbMainImage1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void pbImage4_Click(object sender, EventArgs e)
        {
            ofdInsertImage.Filter = "Image Files|*.png;*.jpg; *.jpeg;*.pmb";
            ofdInsertImage.FilterIndex = 0;
            ofdInsertImage.RestoreDirectory = true;

            if (ofdInsertImage.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = ofdInsertImage.FileName;
                pbImage4.ImageLocation = ImagePath;
                pbImage4.Tag = 4;
                pbImage4.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void pbImage3_Click(object sender, EventArgs e)
        {
            ofdInsertImage.Filter = "Image Files|*.png;*.jpg; *.jpeg;*.pmb";
            ofdInsertImage.FilterIndex = 0;
            ofdInsertImage.RestoreDirectory = true;

            if (ofdInsertImage.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = ofdInsertImage.FileName;
                pbImage3.ImageLocation = ImagePath;
                pbImage3.Tag = 3;
                pbImage3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void pbImage2_Click(object sender, EventArgs e)
        {
            ofdInsertImage.Filter = "Image Files|*.png;*.jpg; *.jpeg;*.pmb";
            ofdInsertImage.FilterIndex = 0;
            ofdInsertImage.RestoreDirectory = true;

            if (ofdInsertImage.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = ofdInsertImage.FileName;
                pbImage2.ImageLocation = ImagePath;
                pbImage2.Tag = 2;
                pbImage2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void frmAddEditProduct_Load(object sender, EventArgs e)
        {
            _LoadCategoriesInComboBox();
            _LoadProductData();
        }
        private void SwitchBetweenImages()
        {
            if(Convert.ToInt32( pbImage4.Tag) > 0)
            {
                pbMainImage1.ImageLocation = pbImage2.ImageLocation;
                pbImage2.ImageLocation = pbImage4.ImageLocation;
                pbImage4.Tag = 0;
                pbImage4.Image = Properties.Resources.icons8_upload_100__4_;
                pbImage4.SizeMode = PictureBoxSizeMode.Zoom;
                return;

            }
            else if(Convert.ToInt32(pbImage3.Tag )> 0)
            {
                pbMainImage1.ImageLocation = pbImage2.ImageLocation;
                pbImage2.ImageLocation = pbImage3.ImageLocation;
                pbImage3.Tag = 0;
                pbImage3.Image = Properties.Resources.icons8_upload_100__4_;
                pbImage3.SizeMode = PictureBoxSizeMode.Zoom;
                return;

            }
            else if(Convert.ToInt32(pbImage2.Tag) > 0)
            {
                pbMainImage1.ImageLocation = pbImage2.ImageLocation;
                pbImage2.Tag = 0;
                pbImage2.Image = Properties.Resources.icons8_upload_100__4_;
                pbImage2.SizeMode = PictureBoxSizeMode.Zoom;
                return;
            }
            else if (Convert.ToInt32(pbImage4.Tag) == 0 && Convert.ToInt32(pbImage3.Tag) == 0
                && Convert.ToInt32(pbImage2.Tag) == 0)
            {
                pbMainImage1.Image = Properties.Resources.icons8_upload_image_100;
                pbMainImage1.SizeMode = PictureBoxSizeMode.CenterImage;
                pbMainImage1.Tag = 0;
            }
        }
        private void removeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SwitchBetweenImages();
            SaveProductImages(_ProductID);

        }
    }
}
