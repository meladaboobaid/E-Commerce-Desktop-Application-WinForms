using System;
using System.Data;
using System.Data.SqlClient;

namespace SawaStore_DataAccessLayer
{
    public class clsOrderItemsData
    {

        public static bool AddNewOrderItem(int OrderID, int ProductID, int Quantity, double Price, double TotalItemsPrice)
        {
            bool isAdded = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = @"INSERT INTO OrderItems (OrderID, ProductID, Quantity, Price, TotalItemsPrice)
                             VALUES (@OrderID, @ProductID, @Quantity, @Price, @TotalItemsPrice)";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@TotalItemsPrice", TotalItemsPrice);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    isAdded = affected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return isAdded;
        }

        public static DataTable GetOrderItemsByOrderID(int OrderID)
        {
            DataTable dtOrderItems = new DataTable("OrderItems");

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = "SELECT * FROM OrderItems WHERE OrderID = @OrderID";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);

                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtOrderItems.Load(reader);
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return dtOrderItems;
        }

        public static bool UpdateOrderItem(int OrderID, int ProductID, int Quantity, double Price, double TotalItemsPrice)
        {
            bool isUpdated = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = @"UPDATE OrderItems 
                             SET Quantity = @Quantity,
                                 Price = @Price,
                                 TotalItemsPrice = @TotalItemsPrice
                             WHERE OrderID = @OrderID AND ProductID = @ProductID";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@TotalItemsPrice", TotalItemsPrice);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    isUpdated = affected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return isUpdated;
        }

        public static bool DeleteOrderItem(int OrderID, int ProductID)
        {
            bool isDeleted = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = "DELETE FROM OrderItems WHERE OrderID = @OrderID AND ProductID = @ProductID";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    isDeleted = affected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return isDeleted;
        }

        public static bool DeleteAllOrderItemsForOrder(int OrderID)
        {
            bool isDeleted = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = "DELETE FROM OrderItems WHERE OrderID = @OrderID";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    isDeleted = affected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return isDeleted;
        }
    }
}
