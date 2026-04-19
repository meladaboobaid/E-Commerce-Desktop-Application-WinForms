namespace Sawa_Store_Project.Controls
{
    partial class ctrlCartItem
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
            this.nudQuantityOfItems = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.btnRemoveItemFromCart = new Guna.UI2.WinForms.Guna2Button();
            this.pbProductImage = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityOfItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // nudQuantityOfItems
            // 
            this.nudQuantityOfItems.BackColor = System.Drawing.Color.Transparent;
            this.nudQuantityOfItems.BorderRadius = 9;
            this.nudQuantityOfItems.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudQuantityOfItems.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudQuantityOfItems.Location = new System.Drawing.Point(371, 93);
            this.nudQuantityOfItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudQuantityOfItems.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nudQuantityOfItems.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantityOfItems.Name = "nudQuantityOfItems";
            this.nudQuantityOfItems.Size = new System.Drawing.Size(99, 40);
            this.nudQuantityOfItems.TabIndex = 54;
            this.nudQuantityOfItems.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.nudQuantityOfItems.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantityOfItems.ValueChanged += new System.EventHandler(this.nudQuantityOfItems_ValueChanged);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.DarkGray;
            this.guna2Separator1.Location = new System.Drawing.Point(13, 199);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(652, 17);
            this.guna2Separator1.TabIndex = 53;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductPrice.Font = new System.Drawing.Font("Dubai", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.Location = new System.Drawing.Point(188, 96);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(29, 37);
            this.lblProductPrice.TabIndex = 51;
            this.lblProductPrice.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Dubai", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 37);
            this.label2.TabIndex = 52;
            this.label2.Text = "$";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductName.Font = new System.Drawing.Font("Dubai", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(183, 42);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(153, 37);
            this.lblProductName.TabIndex = 50;
            this.lblProductName.Text = "Product Name";
            // 
            // btnRemoveItemFromCart
            // 
            this.btnRemoveItemFromCart.Animated = true;
            this.btnRemoveItemFromCart.BorderColor = System.Drawing.Color.White;
            this.btnRemoveItemFromCart.BorderRadius = 9;
            this.btnRemoveItemFromCart.BorderThickness = 1;
            this.btnRemoveItemFromCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveItemFromCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveItemFromCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveItemFromCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveItemFromCart.FillColor = System.Drawing.Color.White;
            this.btnRemoveItemFromCart.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnRemoveItemFromCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveItemFromCart.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveItemFromCart.Image = global::Sawa_Store_Project.Properties.Resources.icons8_close_25;
            this.btnRemoveItemFromCart.Location = new System.Drawing.Point(487, 93);
            this.btnRemoveItemFromCart.Name = "btnRemoveItemFromCart";
            this.btnRemoveItemFromCart.PressedColor = System.Drawing.Color.DarkOrange;
            this.btnRemoveItemFromCart.PressedDepth = 20;
            this.btnRemoveItemFromCart.Size = new System.Drawing.Size(123, 40);
            this.btnRemoveItemFromCart.TabIndex = 55;
            this.btnRemoveItemFromCart.Text = "Remove";
            this.btnRemoveItemFromCart.Click += new System.EventHandler(this.btnRemoveItemFromCart_Click);
            // 
            // pbProductImage
            // 
            this.pbProductImage.BorderRadius = 9;
            this.pbProductImage.FillColor = System.Drawing.Color.AntiqueWhite;
            this.pbProductImage.Image = global::Sawa_Store_Project.Properties.Resources.a2414e0d209394565244ccffd1b08017;
            this.pbProductImage.ImageRotate = 0F;
            this.pbProductImage.Location = new System.Drawing.Point(13, 12);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(159, 181);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImage.TabIndex = 49;
            this.pbProductImage.TabStop = false;
            // 
            // ctrlCartItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.btnRemoveItemFromCart);
            this.Controls.Add(this.nudQuantityOfItems);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.pbProductImage);
            this.Name = "ctrlCartItem";
            this.Size = new System.Drawing.Size(697, 218);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityOfItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnRemoveItemFromCart;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudQuantityOfItems;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProductName;
        private Guna.UI2.WinForms.Guna2PictureBox pbProductImage;
    }
}
