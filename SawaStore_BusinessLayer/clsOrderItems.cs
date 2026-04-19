using System;
using System.Data;
using SawaStore_DataAccessLayer;

namespace SawaStore_BusinessLayer
{
    public class clsOrderItems
    {
        public enum enMode { AddNew = 1, Update = 2 };

        public enMode Mode = enMode.AddNew;

        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalItemsPrice { get; set; }

        public clsProductCatalog ProductInfo { get; set; } // Reference to product class
        public clsOrders OrderInfo { get; set; } // Reference to order class
        
        public clsOrderItems()
        {
            this.Mode = enMode.AddNew;
            this.OrderID = -1;
            this.ProductID = -1;
            this.Quantity = 0;
            this.Price = 0.0;
            this.TotalItemsPrice = 0.0;
        }

        /// <summary>
        /// This constructor is used when we want to load an existing order item from the database for editing. 
        /// It initializes the object with the existing values and sets the mode to Update.
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="ProductID"></param>
        /// <param name="Quantity"></param>
        /// <param name="Price"></param>
        /// <param name="TotalItemsPrice"></param>
        private clsOrderItems(int OrderID, int ProductID, int Quantity, double Price, double TotalItemsPrice)
        {
            this.Mode = enMode.Update;
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
            this.Price = Price;
            this.TotalItemsPrice = TotalItemsPrice;

            this.ProductInfo = clsProductCatalog.Find(ProductID);
            this.OrderInfo = clsOrders.Find(OrderID);
        }

        private bool _AddNewOrderItem()
        {
            return clsOrderItemsData.AddNewOrderItem(this.OrderID, this.ProductID, this.Quantity, this.Price, this.TotalItemsPrice);
        }

        private bool _UpdateOrderItem()
        {
            return clsOrderItemsData.UpdateOrderItem(this.OrderID, this.ProductID, this.Quantity, this.Price, this.TotalItemsPrice);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrderItem())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateOrderItem();

                default:
                    return false;
            }
        }

        public static bool DeleteOrderItem(int OrderID, int ProductID)
        {
            return clsOrderItemsData.DeleteOrderItem(OrderID, ProductID);
        }

        public static bool DeleteAllOrderItemsForOrder(int OrderID)
        {
            return clsOrderItemsData.DeleteAllOrderItemsForOrder(OrderID);
        }

        public static DataTable GetOrderItemsByOrderID(int OrderID)
        {
            return clsOrderItemsData.GetOrderItemsByOrderID(OrderID);
        }

        // Additional business logic like calculating total items price
        public void CalculateTotalPrice()
        {
            this.TotalItemsPrice = this.Quantity * this.Price;
        }
    }
}
