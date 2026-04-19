using Sawa_Store_Project.Controls;

namespace Sawa_Store_Project
{
    partial class frmShoppingCart
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.flpCartItemsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfCartItems = new System.Windows.Forms.Label();
            this.ctrlOrderSummery = new Sawa_Store_Project.Controls.ctrlOrderSummery();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.guna2Panel1.BorderRadius = 5;
            this.guna2Panel1.Controls.Add(this.flpCartItemsPanel);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(33, 93);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(721, 536);
            this.guna2Panel1.TabIndex = 1;
            // 
            // flpCartItemsPanel
            // 
            this.flpCartItemsPanel.AllowDrop = true;
            this.flpCartItemsPanel.AutoScroll = true;
            this.flpCartItemsPanel.BackColor = System.Drawing.Color.White;
            this.flpCartItemsPanel.Location = new System.Drawing.Point(8, 7);
            this.flpCartItemsPanel.Name = "flpCartItemsPanel";
            this.flpCartItemsPanel.Size = new System.Drawing.Size(710, 511);
            this.flpCartItemsPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Dubai", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 49);
            this.label3.TabIndex = 42;
            this.label3.Text = "Cart Items";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Dubai", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 42);
            this.label1.TabIndex = 43;
            this.label1.Text = "(";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Dubai", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(239, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 42);
            this.label2.TabIndex = 44;
            this.label2.Text = ")";
            // 
            // lblNumberOfCartItems
            // 
            this.lblNumberOfCartItems.AutoSize = true;
            this.lblNumberOfCartItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumberOfCartItems.Font = new System.Drawing.Font("Dubai", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfCartItems.Location = new System.Drawing.Point(212, 24);
            this.lblNumberOfCartItems.Name = "lblNumberOfCartItems";
            this.lblNumberOfCartItems.Size = new System.Drawing.Size(31, 42);
            this.lblNumberOfCartItems.TabIndex = 45;
            this.lblNumberOfCartItems.Text = "0";
            // 
            // ctrlOrderSummery
            // 
            this.ctrlOrderSummery.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ctrlOrderSummery.Location = new System.Drawing.Point(771, 100);
            this.ctrlOrderSummery.Name = "ctrlOrderSummery";
            this.ctrlOrderSummery.Size = new System.Drawing.Size(355, 522);
            this.ctrlOrderSummery.TabIndex = 46;
            this.ctrlOrderSummery.Load += new System.EventHandler(this.ctrlOrderSummery_Load);
            // 
            // frmShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1170, 667);
            this.Controls.Add(this.ctrlOrderSummery);
            this.Controls.Add(this.lblNumberOfCartItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShoppingCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shopping Cart";
            this.Load += new System.EventHandler(this.frmShoppingCart_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Controls.ctrlOrderSummery ctrlOrderSummery1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfCartItems;
        private System.Windows.Forms.FlowLayoutPanel flpCartItemsPanel;
        private ctrlOrderSummery ctrlOrderSummery;
    }
}