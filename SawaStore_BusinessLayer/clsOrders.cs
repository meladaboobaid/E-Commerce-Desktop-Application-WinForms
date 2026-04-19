using System;
using System.Data;
using SawaStore_DataAccessLayer;

namespace SawaStore_BusinessLayer
{
    public class clsOrders
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enum enOrderStatus { Pending = 1, OnWay = 2, Shipping = 3, Delivered = 4, Canceled = 5 };

        public enMode Mode = enMode.AddNew;

        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public clsCustomers CustomerInfo { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public enOrderStatus OrderStatus { get; set; }

        public clsOrders()
        {
            this.Mode = enMode.AddNew;
            this.OrderDate = DateTime.Now;
            this.OrderStatus = enOrderStatus.Pending;
            this.OrderID = -1;
            this.CustomerID = -1;
            this.TotalAmount = 0.0;
        }

        private clsOrders(int OrderID, int CustomerID, DateTime OrderDate, double TotalAmount, enOrderStatus OrderStatus)
        {
            this.Mode = enMode.Update;
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
             this.CustomerInfo = clsCustomers.Find(CustomerID);
            this.OrderDate = OrderDate;
            this.TotalAmount = TotalAmount;
            this.OrderStatus = OrderStatus;
        }

        private bool _AddNewOrder()
        {
            this.OrderID = clsOrdersData.AddNewOrder(this.CustomerID, this.OrderDate, this.TotalAmount, (byte)this.OrderStatus); 
            return this.OrderID != -1;
        }

        private bool _UpdateOrder()
        {
            return clsOrdersData.UpdateOrder(this.OrderID, this.CustomerID, this.OrderDate, this.TotalAmount, (byte)this.OrderStatus);
        }

        public static clsOrders Find(int OrderID)
        {
            int CustomerID = -1;
            DateTime OrderDate = DateTime.Now;
            double TotalAmount = 0;
            byte OrderStatus = 1;

            if (clsOrdersData.GetOrderInfoByID(OrderID, ref CustomerID, ref OrderDate, ref TotalAmount, ref OrderStatus))
            {
                return new clsOrders(OrderID, CustomerID, OrderDate, TotalAmount, (enOrderStatus)OrderStatus);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Save method is used to either add a new order or update
        /// an existing order based on the current mode.
        /// </summary>
        /// <returns>bool val indicates if operation is done successfully or not</returns>
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrder())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateOrder();

                default:
                    return false;
            }
        }

        /// <summary>
        /// This method is used to delete an order. 
        /// It first deletes all the order items associated with 
        /// the order, and then deletes the order itself.
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns>bool val indicates if operation is done successfully or not</returns>
        public static bool Delete(int OrderID)
        {
            // Usually you should delete OrderItems first
            clsOrderItems.DeleteAllOrderItemsForOrder(OrderID);
            return clsOrdersData.DeleteOrder(OrderID);
        }

        public static DataTable GetAllOrders()
        {
            return clsOrdersData.GetAllOrders();
        }


        /// <summary>
        /// This method is used to get all orders for a specific customer. 
        /// It can be used in the customer's profile page to show all their orders.
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns>DataTable of Orders associated with specific customer</returns>
        public static DataTable GetOrdersByCustomerID(int CustomerID)
        {
            return clsOrdersData.GetOrdersByCustomerID(CustomerID);
        }

        /// <summary>
        /// This method is used to update the status of an order. It can be used by the admin to update the
        /// order status as it progresses through the different stages (e.g., from Pending to OnWay, then to Shipping, and finally to Delivered).
        /// It can also be used to cancel an order by setting the status to Canceled.
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="OrderStatus"></param>
        /// <returns>bool val indicates if operation is done successfully or not</returns>
        public static bool UpdateOrderStatus(int OrderID, enOrderStatus OrderStatus)
        {
            return clsOrdersData.UpdateOrderStatus(OrderID, (byte)OrderStatus);
        }
    }
}
