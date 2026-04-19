using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SawaStore_DataAccessLayer
{
    public class clsOrdersData
    {
        // OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus

        public static bool GetOrderInfoByID(int OrderID, ref int CustomerID, ref DateTime OrderDate, ref double TotalAmount
            , ref byte OrderStatus)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Orders WHERE OrderID = @OrderID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", OrderID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                    OrderStatus = Convert.ToByte(reader["OrderStatus"]);
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewOrder(int CustomerID, DateTime OrderDate, double TotalAmount, byte OrderStatus)
        {
            int OrderID = -1;

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = @"INSERT INTO Orders (CustomerID, OrderDate, TotalAmount, OrderStatus)
                             VALUES (@CustomerID, @OrderDate, @TotalAmount, @OrderStatus);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
                cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out OrderID))
                    {

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

            return OrderID;
        }

        public static bool UpdateOrder(int OrderID, int CustomerID, DateTime OrderDate, double TotalAmount, byte OrderStatus)
        {
            bool isUpdated = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = @"UPDATE Orders
                             SET CustomerID = @CustomerID,
                                 OrderDate = @OrderDate,
                                 TotalAmount = @TotalAmount,
                                 OrderStatus = @OrderStatus
                             WHERE OrderID = @OrderID";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
                cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);

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

        public static bool DeleteOrder(int OrderID)
        {
            bool isDeleted = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = "DELETE FROM Orders WHERE OrderID = @OrderID";

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
    
        public static DataTable GetAllOrders()
        {
            DataTable dtOrders = new DataTable("Orders");

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = "SELECT * FROM OrderDetails";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtOrders.Load(reader);
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

            return dtOrders;
        }

        public static DataTable GetOrdersByCustomerID(int CustomerID)
        {
            DataTable dtOrders = new DataTable("CustomerOrders");

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = "SELECT * FROM Orders WHERE CustomerID = @CustomerID";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtOrders.Load(reader);
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

            return dtOrders;
        }

        public static bool UpdateOrderStatus(int OrderID, byte OrderStatus)
        {
            bool isUpdated = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            string query = @"UPDATE Orders
                             SET OrderStatus = @OrderStatus
                             WHERE OrderID = @OrderID";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);

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
    }
}
