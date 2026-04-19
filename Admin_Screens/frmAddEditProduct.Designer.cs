namespace Sawa_Store_Project
{
    partial class frmAddEditProduct
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCaption = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtQauntityInStock = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCategories = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtProductPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtProductName = new Guna.UI2.WinForms.Guna2TextBox();
            this.pbImage4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cmsRemoveImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbImage3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbImage2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbMainImage1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.ofdInsertImage = new System.Windows.Forms.OpenFileDialog();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage4)).BeginInit();
            this.cmsRemoveImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCaption.Font = new System.Drawing.Font("Dubai", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(135, 42);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(121, 51);
            this.lblCaption.TabIndex = 62;
            this.lblCaption.Text = "Caption";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.LightGray;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.txtQauntityInStock);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.cbCategories);
            this.guna2Panel1.Controls.Add(this.txtDescription);
            this.guna2Panel1.Controls.Add(this.txtProductPrice);
            this.guna2Panel1.Controls.Add(this.txtProductName);
            this.guna2Panel1.Location = new System.Drawing.Point(27, 147);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(646, 354);
            this.guna2Panel1.TabIndex = 66;
            // 
            // txtQauntityInStock
            // 
            this.txtQauntityInStock.Animated = true;
            this.txtQauntityInStock.BackColor = System.Drawing.Color.Transparent;
            this.txtQauntityInStock.BorderRadius = 9;
            this.txtQauntityInStock.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQauntityInStock.DefaultText = "";
            this.txtQauntityInStock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQauntityInStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQauntityInStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQauntityInStock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQauntityInStock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQauntityInStock.Font = new System.Drawing.Font("Dubai", 11F);
            this.txtQauntityInStock.ForeColor = System.Drawing.Color.Black;
            this.txtQauntityInStock.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQauntityInStock.IconLeft = global::Sawa_Store_Project.Properties.Resources.icons8_shop_251;
            this.txtQauntityInStock.Location = new System.Drawing.Point(454, 130);
            this.txtQauntityInStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQauntityInStock.Name = "txtQauntityInStock";
            this.txtQauntityInStock.PasswordChar = '\0';
            this.txtQauntityInStock.PlaceholderText = "Qauntity ..";
            this.txtQauntityInStock.SelectedText = "";
            this.txtQauntityInStock.ShadowDecoration.BorderRadius = 9;
            this.txtQauntityInStock.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.txtQauntityInStock.ShadowDecoration.Depth = 12;
            this.txtQauntityInStock.Size = new System.Drawing.Size(132, 38);
            this.txtQauntityInStock.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Dubai", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(295, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 30);
            this.label3.TabIndex = 69;
            this.label3.Text = "Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Dubai", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 30);
            this.label1.TabIndex = 67;
            this.label1.Text = "Qauntity In Stock";
            // 
            // cbCategories
            // 
            this.cbCategories.BackColor = System.Drawing.Color.Transparent;
            this.cbCategories.BorderRadius = 9;
            this.cbCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategories.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategories.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategories.Font = new System.Drawing.Font("Dubai", 10F);
            this.cbCategories.ForeColor = System.Drawing.Color.Black;
            this.cbCategories.ItemHeight = 30;
            this.cbCategories.Location = new System.Drawing.Point(298, 51);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(316, 36);
            this.cbCategories.TabIndex = 55;
            // 
            // txtDescription
            // 
            this.txtDescription.Animated = true;
            this.txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.BorderRadius = 9;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Dubai", 11F);
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.IconLeft = global::Sawa_Store_Project.Properties.Resources.icons8_description_64;
            this.txtDescription.Location = new System.Drawing.Point(21, 223);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.PlaceholderText = "Description ...";
            this.txtDescription.SelectedText = "";
            this.txtDescription.ShadowDecoration.BorderRadius = 9;
            this.txtDescription.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.txtDescription.ShadowDecoration.Depth = 12;
            this.txtDescription.Size = new System.Drawing.Size(593, 87);
            this.txtDescription.TabIndex = 54;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Animated = true;
            this.txtProductPrice.BackColor = System.Drawing.Color.Transparent;
            this.txtProductPrice.BorderRadius = 9;
            this.txtProductPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductPrice.DefaultText = "";
            this.txtProductPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductPrice.Font = new System.Drawing.Font("Dubai", 11F);
            this.txtProductPrice.ForeColor = System.Drawing.Color.Black;
            this.txtProductPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductPrice.IconLeft = global::Sawa_Store_Project.Properties.Resources.icons8_price_50;
            this.txtProductPrice.Location = new System.Drawing.Point(21, 126);
            this.txtProductPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.PasswordChar = '\0';
            this.txtProductPrice.PlaceholderText = "Price ...";
            this.txtProductPrice.SelectedText = "";
            this.txtProductPrice.ShadowDecoration.BorderRadius = 9;
            this.txtProductPrice.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.txtProductPrice.ShadowDecoration.Depth = 12;
            this.txtProductPrice.Size = new System.Drawing.Size(255, 48);
            this.txtProductPrice.TabIndex = 52;
            // 
            // txtProductName
            // 
            this.txtProductName.Animated = true;
            this.txtProductName.BackColor = System.Drawing.Color.Transparent;
            this.txtProductName.BorderRadius = 9;
            this.txtProductName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductName.DefaultText = "";
            this.txtProductName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductName.Font = new System.Drawing.Font("Dubai", 11F);
            this.txtProductName.ForeColor = System.Drawing.Color.Black;
            this.txtProductName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductName.IconLeft = global::Sawa_Store_Project.Properties.Resources.icons8_product_64;
            this.txtProductName.Location = new System.Drawing.Point(21, 48);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PasswordChar = '\0';
            this.txtProductName.PlaceholderText = "Product name ...";
            this.txtProductName.SelectedText = "";
            this.txtProductName.ShadowDecoration.BorderRadius = 9;
            this.txtProductName.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.txtProductName.ShadowDecoration.Depth = 12;
            this.txtProductName.Size = new System.Drawing.Size(255, 47);
            this.txtProductName.TabIndex = 49;
            // 
            // pbImage4
            // 
            this.pbImage4.BackColor = System.Drawing.Color.Transparent;
            this.pbImage4.BorderRadius = 12;
            this.pbImage4.FillColor = System.Drawing.Color.Gainsboro;
            this.pbImage4.Image = global::Sawa_Store_Project.Properties.Resources.icons8_upload_100__4_;
            this.pbImage4.ImageRotate = 0F;
            this.pbImage4.Location = new System.Drawing.Point(1048, 395);
            this.pbImage4.Name = "pbImage4";
            this.pbImage4.ShadowDecoration.BorderRadius = 2;
            this.pbImage4.ShadowDecoration.Color = System.Drawing.Color.Gainsboro;
            this.pbImage4.ShadowDecoration.Depth = 13;
            this.pbImage4.ShadowDecoration.Enabled = true;
            this.pbImage4.Size = new System.Drawing.Size(115, 105);
            this.pbImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage4.TabIndex = 70;
            this.pbImage4.TabStop = false;
            this.pbImage4.Tag = "0";
            this.pbImage4.Click += new System.EventHandler(this.pbImage4_Click);
            // 
            // cmsRemoveImage
            // 
            this.cmsRemoveImage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRemoveImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeImageToolStripMenuItem});
            this.cmsRemoveImage.Name = "contextMenuStrip1";
            this.cmsRemoveImage.Size = new System.Drawing.Size(183, 30);
            // 
            // removeImageToolStripMenuItem
            // 
            this.removeImageToolStripMenuItem.Image = global::Sawa_Store_Project.Properties.Resources.icons8_delete_24;
            this.removeImageToolStripMenuItem.Name = "removeImageToolStripMenuItem";
            this.removeImageToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.removeImageToolStripMenuItem.Text = "Remove Image";
            this.removeImageToolStripMenuItem.Click += new System.EventHandler(this.removeImageToolStripMenuItem_Click);
            // 
            // pbImage3
            // 
            this.pbImage3.BackColor = System.Drawing.Color.Transparent;
            this.pbImage3.BorderRadius = 10;
            this.pbImage3.FillColor = System.Drawing.Color.Gainsboro;
            this.pbImage3.Image = global::Sawa_Store_Project.Properties.Resources.icons8_upload_100__4_;
            this.pbImage3.ImageRotate = 0F;
            this.pbImage3.Location = new System.Drawing.Point(1048, 273);
            this.pbImage3.Name = "pbImage3";
            this.pbImage3.ShadowDecoration.BorderRadius = 2;
            this.pbImage3.ShadowDecoration.Color = System.Drawing.Color.Gainsboro;
            this.pbImage3.ShadowDecoration.Depth = 13;
            this.pbImage3.ShadowDecoration.Enabled = true;
            this.pbImage3.Size = new System.Drawing.Size(115, 105);
            this.pbImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage3.TabIndex = 69;
            this.pbImage3.TabStop = false;
            this.pbImage3.Tag = "0";
            this.pbImage3.Click += new System.EventHandler(this.pbImage3_Click);
            // 
            // pbImage2
            // 
            this.pbImage2.BackColor = System.Drawing.Color.Transparent;
            this.pbImage2.BorderRadius = 10;
            this.pbImage2.FillColor = System.Drawing.Color.Gainsboro;
            this.pbImage2.Image = global::Sawa_Store_Project.Properties.Resources.icons8_upload_100__4_;
            this.pbImage2.ImageRotate = 0F;
            this.pbImage2.Location = new System.Drawing.Point(1048, 147);
            this.pbImage2.Name = "pbImage2";
            this.pbImage2.ShadowDecoration.BorderRadius = 2;
            this.pbImage2.ShadowDecoration.Color = System.Drawing.Color.Gainsboro;
            this.pbImage2.ShadowDecoration.Depth = 13;
            this.pbImage2.ShadowDecoration.Enabled = true;
            this.pbImage2.Size = new System.Drawing.Size(115, 105);
            this.pbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage2.TabIndex = 68;
            this.pbImage2.TabStop = false;
            this.pbImage2.Tag = "0";
            this.pbImage2.Click += new System.EventHandler(this.pbImage2_Click);
            // 
            // pbMainImage1
            // 
            this.pbMainImage1.BackColor = System.Drawing.Color.Transparent;
            this.pbMainImage1.BorderRadius = 12;
            this.pbMainImage1.ContextMenuStrip = this.cmsRemoveImage;
            this.pbMainImage1.FillColor = System.Drawing.Color.Gainsboro;
            this.pbMainImage1.Image = global::Sawa_Store_Project.Properties.Resources.icons8_upload_image_100;
            this.pbMainImage1.ImageRotate = 0F;
            this.pbMainImage1.Location = new System.Drawing.Point(691, 147);
            this.pbMainImage1.Name = "pbMainImage1";
            this.pbMainImage1.ShadowDecoration.BorderRadius = 2;
            this.pbMainImage1.ShadowDecoration.Color = System.Drawing.Color.Gainsboro;
            this.pbMainImage1.ShadowDecoration.Depth = 13;
            this.pbMainImage1.ShadowDecoration.Enabled = true;
            this.pbMainImage1.Size = new System.Drawing.Size(338, 353);
            this.pbMainImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMainImage1.TabIndex = 67;
            this.pbMainImage1.TabStop = false;
            this.pbMainImage1.Tag = "0";
            this.pbMainImage1.Click += new System.EventHandler(this.pbMainImage1_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::Sawa_Store_Project.Properties.Resources._8e6c9e216d3295645aab32d5a2b94ece1;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(41, -2);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(88, 123);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 65;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.BorderRadius = 8;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnClose.Font = new System.Drawing.Font("Dubai", 10.7F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::Sawa_Store_Project.Properties.Resources.icons8_close_25;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Location = new System.Drawing.Point(27, 544);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.DarkOrange;
            this.btnClose.PressedDepth = 20;
            this.btnClose.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.btnClose.ShadowDecoration.Depth = 5;
            this.btnClose.ShadowDecoration.Enabled = true;
            this.btnClose.Size = new System.Drawing.Size(171, 54);
            this.btnClose.TabIndex = 64;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.BorderRadius = 8;
            this.btnSave.BorderThickness = 1;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSave.Font = new System.Drawing.Font("Dubai", 10.7F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::Sawa_Store_Project.Properties.Resources.icons8_save_25;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.Location = new System.Drawing.Point(204, 544);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.DarkOrange;
            this.btnSave.PressedDepth = 20;
            this.btnSave.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.btnSave.ShadowDecoration.Depth = 5;
            this.btnSave.ShadowDecoration.Enabled = true;
            this.btnSave.Size = new System.Drawing.Size(171, 54);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "Save ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnSave.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // ofdInsertImage
            // 
            this.ofdInsertImage.FileName = "openFileDialog1";
            // 
            // frmAddEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1191, 638);
            this.Controls.Add(this.pbImage4);
            this.Controls.Add(this.pbImage3);
            this.Controls.Add(this.pbImage2);
            this.Controls.Add(this.pbMainImage1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add & Edit product";
            this.Load += new System.EventHandler(this.frmAddEditProduct_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage4)).EndInit();
            this.cmsRemoveImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lblCaption;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2TextBox txtProductPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbCategories;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox pbMainImage1;
        private Guna.UI2.WinForms.Guna2PictureBox pbImage2;
        private Guna.UI2.WinForms.Guna2PictureBox pbImage3;
        private Guna.UI2.WinForms.Guna2PictureBox pbImage4;
        private Guna.UI2.WinForms.Guna2TextBox txtQauntityInStock;
        private System.Windows.Forms.OpenFileDialog ofdInsertImage;
        private System.Windows.Forms.ContextMenuStrip cmsRemoveImage;
        private System.Windows.Forms.ToolStripMenuItem removeImageToolStripMenuItem;
    }
}