namespace Sawa_Store_Project.Controls
{
    partial class ctrlProduct
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.btnAddToCart = new Guna.UI2.WinForms.Guna2Button();
            this.pbProductImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnEditProduct = new Guna.UI2.WinForms.Guna2Button();
            this.cmsProduct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.productDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.cmsProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductName.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(15, 209);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(117, 29);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Product Name";
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductType.Font = new System.Drawing.Font("Dubai", 9.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductType.Location = new System.Drawing.Point(16, 241);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(96, 27);
            this.lblProductType.TabIndex = 2;
            this.lblProductType.Text = "Product type";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductPrice.Font = new System.Drawing.Font("Dubai", 9.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.Location = new System.Drawing.Point(152, 209);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(35, 29);
            this.lblProductPrice.TabIndex = 3;
            this.lblProductPrice.Text = "0 $";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Animated = true;
            this.btnAddToCart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(1)))));
            this.btnAddToCart.BorderRadius = 7;
            this.btnAddToCart.BorderThickness = 1;
            this.btnAddToCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddToCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddToCart.FillColor = System.Drawing.Color.White;
            this.btnAddToCart.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddToCart.ForeColor = System.Drawing.Color.Black;
            this.btnAddToCart.Location = new System.Drawing.Point(72, 275);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.PressedColor = System.Drawing.Color.DarkOrange;
            this.btnAddToCart.PressedDepth = 20;
            this.btnAddToCart.Size = new System.Drawing.Size(128, 37);
            this.btnAddToCart.TabIndex = 4;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            this.btnAddToCart.MouseLeave += new System.EventHandler(this.btnAddToCart_MouseLeave);
            this.btnAddToCart.MouseHover += new System.EventHandler(this.guna2Button1_MouseHover);
            // 
            // pbProductImage
            // 
            this.pbProductImage.BackColor = System.Drawing.Color.Transparent;
            this.pbProductImage.BorderRadius = 12;
            this.pbProductImage.FillColor = System.Drawing.Color.AntiqueWhite;
            this.pbProductImage.Image = global::Sawa_Store_Project.Properties.Resources.a2414e0d209394565244ccffd1b08017;
            this.pbProductImage.ImageRotate = 0F;
            this.pbProductImage.Location = new System.Drawing.Point(11, 16);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(189, 175);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImage.TabIndex = 0;
            this.pbProductImage.TabStop = false;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Animated = true;
            this.btnEditProduct.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnEditProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(1)))));
            this.btnEditProduct.BorderRadius = 7;
            this.btnEditProduct.BorderThickness = 1;
            this.btnEditProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditProduct.FillColor = System.Drawing.Color.White;
            this.btnEditProduct.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEditProduct.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProduct.ForeColor = System.Drawing.Color.Black;
            this.btnEditProduct.Location = new System.Drawing.Point(84, 275);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.PressedColor = System.Drawing.Color.DarkOrange;
            this.btnEditProduct.PressedDepth = 20;
            this.btnEditProduct.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.btnEditProduct.ShadowDecoration.Depth = 15;
            this.btnEditProduct.Size = new System.Drawing.Size(116, 37);
            this.btnEditProduct.TabIndex = 5;
            this.btnEditProduct.Text = "Edit";
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            this.btnEditProduct.MouseLeave += new System.EventHandler(this.btnEditProduct_MouseLeave);
            this.btnEditProduct.MouseHover += new System.EventHandler(this.btnEditProduct_MouseHover);
            // 
            // cmsProduct
            // 
            this.cmsProduct.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productDetailsToolStripMenuItem,
            this.deleteProductToolStripMenuItem,
            this.switchImageToolStripMenuItem});
            this.cmsProduct.Name = "cmsProduct";
            this.cmsProduct.Size = new System.Drawing.Size(183, 82);
            // 
            // productDetailsToolStripMenuItem
            // 
            this.productDetailsToolStripMenuItem.Image = global::Sawa_Store_Project.Properties.Resources.icons8_application_24;
            this.productDetailsToolStripMenuItem.Name = "productDetailsToolStripMenuItem";
            this.productDetailsToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.productDetailsToolStripMenuItem.Text = "Product details";
            this.productDetailsToolStripMenuItem.Click += new System.EventHandler(this.productDetailsToolStripMenuItem_Click);
            // 
            // deleteProductToolStripMenuItem
            // 
            this.deleteProductToolStripMenuItem.Image = global::Sawa_Store_Project.Properties.Resources.icons8_delete_24;
            this.deleteProductToolStripMenuItem.Name = "deleteProductToolStripMenuItem";
            this.deleteProductToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.deleteProductToolStripMenuItem.Text = "Delete product";
            this.deleteProductToolStripMenuItem.Click += new System.EventHandler(this.deleteProductToolStripMenuItem_Click);
            // 
            // switchImageToolStripMenuItem
            // 
            this.switchImageToolStripMenuItem.Image = global::Sawa_Store_Project.Properties.Resources.icons8_product_64;
            this.switchImageToolStripMenuItem.Name = "switchImageToolStripMenuItem";
            this.switchImageToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.switchImageToolStripMenuItem.Text = "Switch image";
            this.switchImageToolStripMenuItem.Click += new System.EventHandler(this.switchImageToolStripMenuItem_Click);
            // 
            // ctrlProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContextMenuStrip = this.cmsProduct;
            this.Controls.Add(this.btnEditProduct);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.pbProductImage);
            this.Name = "ctrlProduct";
            this.Size = new System.Drawing.Size(212, 325);
            this.Load += new System.EventHandler(this.ctrlProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.cmsProduct.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pbProductImage;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblProductPrice;
        private Guna.UI2.WinForms.Guna2Button btnAddToCart;
        private Guna.UI2.WinForms.Guna2Button btnEditProduct;
        private System.Windows.Forms.ContextMenuStrip cmsProduct;
        private System.Windows.Forms.ToolStripMenuItem productDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchImageToolStripMenuItem;
    }
}
