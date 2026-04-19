using SawaStore_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sawa_Store_Project.Controls
{
    public partial class ctrlCartItem : UserControl
    {
        public delegate void RemoveItemFormCart(object sender, int ProductID);
        public event RemoveItemFormCart OnRemoveItemFromCart;
        //
        public delegate void QuantityChanged();
        public event QuantityChanged OnQuantityChanged;

        public int ProductID;
        private string _ProductName;
        private double _Price;
        private int _Quantity;
        public clsProductCatalog Product;

        public ctrlCartItem()
        {
            InitializeComponent();
            Product = new clsProductCatalog();
        }

        public void LoadCartItem(clsOrderItems Item)
        {
            if(ProductID != -1)
            {
                ProductID = Item.ProductID;
                Product = clsProductCatalog.Find(ProductID);
                _ProductName = Product.ProductName;
                _Price = Product.ProductPrice;
                _Quantity = Item.Quantity;
                
                if(Product.ProductImagesURLs.Count > 0)
                {
                    pbProductImage.ImageLocation = Product.ProductImagesURLs[0];
                }
                else
                {
                    pbProductImage.Image = Properties.Resources.a2414e0d209394565244ccffd1b08017;
                }
                lblProductName.Text = _ProductName;
                lblProductPrice.Text = _Price.ToString();
                nudQuantityOfItems.Value = _Quantity;
            }
        }

        private void btnRemoveItemFromCart_Click(object sender, EventArgs e)
        {
            OnRemoveItemFromCart?.Invoke(this, ProductID);
        }

        private void nudQuantityOfItems_ValueChanged(object sender, EventArgs e)
        {
            var item = frmShoppingCart.ShoppingCart.Where(i=> i.ProductID == ProductID).FirstOrDefault();
            item.Quantity = (int)nudQuantityOfItems.Value;
            item.CalculateTotalPrice();
            OnQuantityChanged?.Invoke();
        }
    }
}
