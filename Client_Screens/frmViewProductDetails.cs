using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmViewProductDetails : Form
    {
        public frmViewProductDetails()
        {
            InitializeComponent();
        }

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.FromArgb(234, 114, 0);
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.Black;

        }

        private void btnProducts_MouseHover(object sender, EventArgs e)
        {
            btnProducts.ForeColor = Color.FromArgb(234, 114, 0);

        }

        private void btnProducts_MouseLeave(object sender, EventArgs e)
        {
            btnProducts.ForeColor = Color.Black;
        }

        private void btnBlog_MouseHover(object sender, EventArgs e)
        {
            btnBlog.ForeColor = Color.FromArgb(234, 114, 0);
        }

        private void btnBlog_MouseLeave(object sender, EventArgs e)
        {
            btnBlog.ForeColor = Color.Black;
        }

        private void btnContact_MouseHover(object sender, EventArgs e)
        {
            btnContact.ForeColor = Color.FromArgb(234, 114, 0);
        }

        private void btnContact_MouseLeave(object sender, EventArgs e)
        {
            btnContact.ForeColor = Color.Black;
        }

        private void btnLarge_Click(object sender, EventArgs e)
        {
            btnMedium.FillColor = Color.White;
            btnLarge.FillColor = Color.FromArgb(254, 105, 1);

        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            btnMedium.FillColor = Color.FromArgb(254, 105, 1); 
            btnLarge.FillColor = Color.White;
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnExploreMoreProducts_MouseHover(object sender, EventArgs e)
        {
            btnRelatedProducts.FillColor = Color.FromArgb(254, 105, 1);

        }

        private void btnRelatedProducts_Click(object sender, EventArgs e)
        {

        }

        private void btnRelatedProducts_MouseLeave(object sender, EventArgs e)
        {
            btnRelatedProducts.FillColor = Color.White;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmViewProductDetails_Load(object sender, EventArgs e)
        {
            
        }
    }
}
