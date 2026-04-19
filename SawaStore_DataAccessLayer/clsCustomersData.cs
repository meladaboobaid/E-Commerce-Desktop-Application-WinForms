using System;
using System.Data;
using System.Data.SqlClient;

namespace SawaStore_DataAccessLayer
{
    public class clsCustomersData
    {
        // CRUD 
        // Create =>  Done
        // Delete =>  Done
        // Update =>  Done
        // Read   =>  Done
        // Find   =>  Done

        public static bool GetCustomerInfoByID(int CustomerID, ref int PersonID,
                 ref string UserName, ref string Password)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustomerID", CustomerID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    PersonID = Convert.ToInt32( reader["PersonID"]);

                }
                else
                {
                    // The record was not found
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

        public static int AddNewCustomer(int PersonID, string UserName, string Password)
        {
            int CustomerID = -1;
            string connStr  = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_AddNewCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@UserName", UserName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Password", Password ?? (object)DBNull.Value);

                SqlParameter outParam = new SqlParameter("@NewCustomerID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                try
                {

                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        CustomerID = Convert.ToInt32(outParam.Value);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            }

            return CustomerID;
        }

        public static bool DeleteCustomer(int CustomerID)
        {
            bool IsDeleted = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_DeleteCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    IsDeleted = affected > 0;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            }

            return IsDeleted;
        }

        public static bool UpdateCustomer(int CustomerID, int PersonID, string UserName, string Password)
        {
            bool IsUpdated = false;
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_UpdateCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@UserName", UserName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Password", Password ?? (object)DBNull.Value);

                try
                {
                    con.Open();

                    int affected = cmd.ExecuteNonQuery();
                    IsUpdated = affected > 0;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }   
            }

            return IsUpdated;
        }

        public static int IsCustomerExist(int CustomerID)
        {
            string connStr = clsDataAccessSettings.ConnectionString;

            int foundId = -1;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT CustomerID FROM Customers WHERE CustomerID = @CustomerID";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        foundId = Convert.ToInt32(result);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            }

            return foundId;
        }

        public static DataTable GetAllCustomers()
        {
            DataTable dtCustomers = new DataTable("Customers");

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllCustomers", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtCustomers.Load(reader);
                        reader.Close();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            }

            return dtCustomers;
        }


        public static bool IsCustomerByEmail(string Email)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string Query = @"select f = 1 from CustomersInfo where Email = @Email";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Email", Email);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            IsExist = reader.HasRows;
                            reader.Close();
                        }
                     }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        IsExist = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
                
            return IsExist;
        }

        public static int FindCustomerByEmailAndPassword(string email, string password)
        {
            int CustomerID = -1;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_FindCustomerByEmailAndPassword", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                SqlParameter OutputParameter = new SqlParameter("@CustomerID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(OutputParameter);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    if (OutputParameter.Value != DBNull.Value)
                        CustomerID = Convert.ToInt32(OutputParameter.Value);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
            return CustomerID;
        }

    }
}
