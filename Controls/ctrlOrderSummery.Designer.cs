namespace Sawa_Store_Project.Controls
{
    partial class ctrlOrderSummery
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
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.txtDiscountCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnApplyDiscountCode = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.label9 = new System.Windows.Forms.Label();
            this.lblEstimatedDeliveryDate = new System.Windows.Forms.Label();
            this.lblSubTotalAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblShippingAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Dubai", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 49);
            this.label3.TabIndex = 41;
            this.label3.Text = "Order Summary";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(25, 58);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(309, 29);
            this.guna2Separator1.TabIndex = 42;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductName.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(20, 102);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(82, 29);
            this.lblProductName.TabIndex = 43;
            this.lblProductName.Text = "Subtotal :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 45;
            this.label2.Text = "Shipping :";
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Location = new System.Drawing.Point(25, 200);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(309, 21);
            this.guna2Separator2.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Dubai", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 40);
            this.label7.TabIndex = 50;
            this.label7.Text = "Total :";
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalBill.Font = new System.Drawing.Font("Dubai", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.Location = new System.Drawing.Point(239, 225);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(31, 42);
            this.lblTotalBill.TabIndex = 51;
            this.lblTotalBill.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Dubai", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(298, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 42);
            this.label10.TabIndex = 53;
            this.label10.Text = "$";
            // 
            // btnCheckout
            // 
            this.btnCheckout.Animated = true;
            this.btnCheckout.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckout.BorderRadius = 9;
            this.btnCheckout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCheckout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(111)))), ((int)(((byte)(0)))));
            this.btnCheckout.Font = new System.Drawing.Font("Dubai", 13.5F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(25, 281);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.ShadowDecoration.BorderRadius = 9;
            this.btnCheckout.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.btnCheckout.ShadowDecoration.Depth = 15;
            this.btnCheckout.ShadowDecoration.Enabled = true;
            this.btnCheckout.Size = new System.Drawing.Size(302, 49);
            this.btnCheckout.TabIndex = 54;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // txtDiscountCode
            // 
            this.txtDiscountCode.Animated = true;
            this.txtDiscountCode.BackColor = System.Drawing.Color.Transparent;
            this.txtDiscountCode.BorderRadius = 10;
            this.txtDiscountCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiscountCode.DefaultText = "";
            this.txtDiscountCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiscountCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiscountCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscountCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscountCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscountCode.Font = new System.Drawing.Font("Dubai", 11F);
            this.txtDiscountCode.ForeColor = System.Drawing.Color.Black;
            this.txtDiscountCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscountCode.Location = new System.Drawing.Point(27, 350);
            this.txtDiscountCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiscountCode.Name = "txtDiscountCode";
            this.txtDiscountCode.PasswordChar = '\0';
            this.txtDiscountCode.PlaceholderText = "Discount code";
            this.txtDiscountCode.SelectedText = "";
            this.txtDiscountCode.ShadowDecoration.BorderRadius = 9;
            this.txtDiscountCode.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.txtDiscountCode.ShadowDecoration.Depth = 12;
            this.txtDiscountCode.Size = new System.Drawing.Size(165, 39);
            this.txtDiscountCode.TabIndex = 55;
            // 
            // btnApplyDiscountCode
            // 
            this.btnApplyDiscountCode.Animated = true;
            this.btnApplyDiscountCode.BackColor = System.Drawing.Color.Transparent;
            this.btnApplyDiscountCode.BorderRadius = 9;
            this.btnApplyDiscountCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApplyDiscountCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApplyDiscountCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApplyDiscountCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApplyDiscountCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(111)))), ((int)(((byte)(0)))));
            this.btnApplyDiscountCode.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Bold);
            this.btnApplyDiscountCode.ForeColor = System.Drawing.Color.White;
            this.btnApplyDiscountCode.Location = new System.Drawing.Point(214, 350);
            this.btnApplyDiscountCode.Name = "btnApplyDiscountCode";
            this.btnApplyDiscountCode.ShadowDecoration.BorderRadius = 9;
            this.btnApplyDiscountCode.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.btnApplyDiscountCode.ShadowDecoration.Depth = 15;
            this.btnApplyDiscountCode.ShadowDecoration.Enabled = true;
            this.btnApplyDiscountCode.Size = new System.Drawing.Size(115, 39);
            this.btnApplyDiscountCode.TabIndex = 56;
            this.btnApplyDiscountCode.Text = "Apply";
            this.btnApplyDiscountCode.Click += new System.EventHandler(this.btnApplyDiscountCode_Click);
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.Location = new System.Drawing.Point(25, 456);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(309, 11);
            this.guna2Separator3.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 481);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 29);
            this.label9.TabIndex = 58;
            this.label9.Text = "Extimated Delivry :";
            // 
            // lblEstimatedDeliveryDate
            // 
            this.lblEstimatedDeliveryDate.AutoSize = true;
            this.lblEstimatedDeliveryDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEstimatedDeliveryDate.Font = new System.Drawing.Font("Dubai", 9.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedDeliveryDate.Location = new System.Drawing.Point(201, 483);
            this.lblEstimatedDeliveryDate.Name = "lblEstimatedDeliveryDate";
            this.lblEstimatedDeliveryDate.Size = new System.Drawing.Size(96, 27);
            this.lblEstimatedDeliveryDate.TabIndex = 59;
            this.lblEstimatedDeliveryDate.Text = "00-00-0000";
            // 
            // lblSubTotalAmount
            // 
            this.lblSubTotalAmount.AutoSize = true;
            this.lblSubTotalAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTotalAmount.Font = new System.Drawing.Font("Dubai", 9.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalAmount.Location = new System.Drawing.Point(281, 102);
            this.lblSubTotalAmount.Name = "lblSubTotalAmount";
            this.lblSubTotalAmount.Size = new System.Drawing.Size(21, 27);
            this.lblSubTotalAmount.TabIndex = 62;
            this.lblSubTotalAmount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Dubai", 9.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(308, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 27);
            this.label6.TabIndex = 61;
            this.label6.Text = "$";
            // 
            // lblShippingAmount
            // 
            this.lblShippingAmount.AutoSize = true;
            this.lblShippingAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShippingAmount.Font = new System.Drawing.Font("Dubai", 9.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShippingAmount.Location = new System.Drawing.Point(280, 153);
            this.lblShippingAmount.Name = "lblShippingAmount";
            this.lblShippingAmount.Size = new System.Drawing.Size(21, 27);
            this.lblShippingAmount.TabIndex = 64;
            this.lblShippingAmount.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Dubai", 9.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(308, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 27);
            this.label11.TabIndex = 63;
            this.label11.Text = "$";
            // 
            // ctrlOrderSummery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblShippingAmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblSubTotalAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblEstimatedDeliveryDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.guna2Separator3);
            this.Controls.Add(this.btnApplyDiscountCode);
            this.Controls.Add(this.txtDiscountCode);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTotalBill);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.guna2Separator2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label3);
            this.Name = "ctrlOrderSummery";
            this.Size = new System.Drawing.Size(355, 522);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
        private Guna.UI2.WinForms.Guna2TextBox txtDiscountCode;
        private Guna.UI2.WinForms.Guna2Button btnApplyDiscountCode;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEstimatedDeliveryDate;
        private System.Windows.Forms.Label lblSubTotalAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblShippingAmount;
        private System.Windows.Forms.Label label11;
    }
}
