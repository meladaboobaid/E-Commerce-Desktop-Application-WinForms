using Sawa_Store_Project.Controls;
using SawaStore_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmShoppingCart : Form
    {
        public static List<clsOrderItems> ShoppingCart;

        public frmShoppingCart(List<clsOrderItems> shoppingCart)
        {
            InitializeComponent();
            ShoppingCart = shoppingCart;
        }

        private void frmShoppingCart_Load(object sender, EventArgs e)
        {
            if (ShoppingCart != null)
            {
                lblNumberOfCartItems.Text = ShoppingCart.Count.ToString();
                _LoadOrderItemsInCartPanel();
            }
            else
            {
                lblNumberOfCartItems.Text = "0";    
            }

            _LoadOrderSummary();
        }

        private void _LoadOrderSummary()
        {
            ctrlOrderSummery.LoadOrderSummery(ShoppingCart, ctrlOrderSummery.enMode.CartView);
        }

        private void _OrderItemsRemovedFromCart(object sender, int ProductID)
        {
            var item = ShoppingCart.Where(i => i.ProductID == ProductID).FirstOrDefault();
            if (item != null)
            {
                ShoppingCart.Remove(item);
                flpCartItemsPanel.Controls.Remove(sender as ctrlCartItem);
                lblNumberOfCartItems.Text = ShoppingCart.Count.ToString();
                _LoadOrderItemsInCartPanel();
                _LoadOrderSummary();
            }
        }

        private void _LoadOrderItemsInCartPanel()
        {
            flpCartItemsPanel.Controls.Clear();

            foreach (clsOrderItems orderItem in ShoppingCart)
            {
                ctrlCartItem cartItemControl = new ctrlCartItem();
                cartItemControl.OnRemoveItemFromCart += _OrderItemsRemovedFromCart;
                cartItemControl.OnQuantityChanged += _LoadOrderSummary;
                cartItemControl.LoadCartItem(orderItem);
                flpCartItemsPanel.Controls.Add(cartItemControl);
            }
        }

        private void ctrlOrderSummery_Load(object sender, EventArgs e)
        {

        }
    }
}
