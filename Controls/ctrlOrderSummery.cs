using SawaStore_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sawa_Store_Project.Controls
{

    public partial class ctrlOrderSummery : UserControl
    {
        public enum enMode { CartView= 1, ShippingView = 2 };
        enMode _Mode = enMode.CartView;

        private List<clsOrderItems> _ShoppingCartItems;
        private double _TotalBill = 0;


        public ctrlOrderSummery()
        {
            InitializeComponent();
            _ShoppingCartItems = new List<clsOrderItems>();
        }

        private double CalculateSubTotal()
        {
            double subTotal = 0;

            foreach (clsOrderItems item in _ShoppingCartItems)
            {
                subTotal += item.TotalItemsPrice;
            }

            return subTotal;
        }

        public void LoadOrderSummery(List<clsOrderItems> shoppingCartItems, enMode mode)
        {
            _ShoppingCartItems = shoppingCartItems;
            _Mode = mode;
            lblSubTotalAmount.Text = CalculateSubTotal().ToString();
            lblShippingAmount.Text = clsGlobal.ShippingAmount.ToString();
            _TotalBill = CalculateSubTotal() + clsGlobal.ShippingAmount;

            if(CalculateSubTotal() == 0)
            {
                _TotalBill = 0;
            }

            lblTotalBill.Text = _TotalBill.ToString();

        }

        private double CalculateTotalBillAfterDiscount()
        {
            _TotalBill  = _TotalBill - (_TotalBill * 0.1);

            return _TotalBill;
        }
        private void btnApplyDiscountCode_Click(object sender, EventArgs e)
        {
            if(clsGlobal.IsValidDiscountCode(txtDiscountCode.Text.Trim()))
            {
                lblTotalBill.Text = CalculateTotalBillAfterDiscount().ToString();
            }
            else
            {
                MessageBox.Show("Invalid Discount Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCheckout_Click(object sender, EventArgs e)
        {
            clsOrders newOrder = new clsOrders();
            newOrder.CustomerID = clsGlobal.LoggedInCustomer.CustomerID;
            newOrder.OrderDate = DateTime.Now;
            newOrder.OrderStatus = clsOrders.enOrderStatus.Pending;
            newOrder.TotalAmount = _TotalBill;

            if(newOrder.Save())
            {
                foreach (clsOrderItems item in _ShoppingCartItems)
                {
                    item.OrderID = newOrder.OrderID;
                    item.Save();
                }

                MessageBox.Show("Order Placed Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ShoppingCartItems.Clear();
                btnCheckout.Enabled = false;
            }
            else
            {
                MessageBox.Show("Order Placed Failed!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
