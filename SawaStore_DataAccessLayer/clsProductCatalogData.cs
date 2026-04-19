using System;
using System.Data;
using System.Data.SqlClient;

namespace SawaStore_DataAccessLayer
{
    public class clsProductCatalogData
    {
        // I need here to make a simple CRUD operations 
        public static bool FindProductById(int ProductID, ref string ProductName, ref string Description,
            ref double ProductPrice, ref int QuantityStock, ref int CategoryID)
        {
            bool IsFound = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT ProductName, Description, Price, QuantityInStock, CategoryID FROM ProductCatalog WHERE ProductID = @ProductID";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            ProductName = reader["ProductName"] != DBNull.Value ? Convert.ToString(reader["ProductName"]) : string.Empty;
                            Description = reader["Description"] != DBNull.Value ? Convert.ToString(reader["Description"]) : string.Empty;
                            ProductPrice = reader["Price"] != DBNull.Value ? Convert.ToDouble(reader["Price"]) : 0.0;
                            QuantityStock = reader["QuantityInStock"] != DBNull.Value ? Convert.ToInt32(reader["QuantityInStock"]) : 0;
                            CategoryID = reader["CategoryID"] != DBNull.Value ? Convert.ToInt32(reader["CategoryID"]) : 0;
                        }
                        else
                        {
                            IsFound = false;
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                    IsFound = false;
                }
                finally
                {
                    con.Close();
                }
            }

            return IsFound;
        }

        public static int AddNewProduct(string ProductName, string Description, double ProductPrice, int QuantityStock, int CategoryID)
        {
            int NewProductID = -1;
            // Call "SP_AddNewProduct" stored procedure to add a new product to the database and return the new product ID as output parameter
            // Use ADO.NET to connect to the database and execute the query
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_AddNewProduct", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", ProductName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ProductDescription", Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                cmd.Parameters.AddWithValue("@QuantityInStock", QuantityStock);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

                SqlParameter outParam = new SqlParameter("@NewProductID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        NewProductID = Convert.ToInt32(outParam.Value);   
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

            return NewProductID;
        }

        public static bool UpdateProduct(int ProductID, string ProductName, string Description, double ProductPrice, int QuantityStock, int CategoryID)
        {
            bool IsUpdated = false;
            // Call "SP_UpdateProduct" stored procedure to update the product data in the database and return true if the update was successful
            // Use ADO.NET to connect to the database and execute the query
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_UpdateProduct", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID",      ProductID);
                cmd.Parameters.AddWithValue("@ProductName",     ProductName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description",    Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ProductPrice",    ProductPrice);
                cmd.Parameters.AddWithValue("@QuantityStock", QuantityStock);
                cmd.Parameters.AddWithValue("@CategoryID",        CategoryID);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    IsUpdated = affected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                    IsUpdated = false;
                }
                finally
                {
                    con.Close();
                }
            }

            return IsUpdated;
        }

        public static bool DeleteProduct(int ProductID)
        {
            bool IsDeleted = false;
            // Call "SP_DeleteProduct" stored procedure to delete the product from the database and return true if the deletion was successful
            // Use ADO.NET to connect to the database and execute the query
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_DeleteProduct", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                clsProductImagesData.DeleteProductImages(ProductID);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    IsDeleted = affected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    IsDeleted = false;
                }
                finally
                {
                    con.Close();
                }
            }

            return IsDeleted;
        }

        public static DataTable GetAllProducts()
        {
            DataTable dtProductsTable = new DataTable("Products");
            // Call "SP_GetAllProducts" stored procedure to get all products from the database and fill the dtProductsTable with the data
            // Use ADO.NET to connect to the database and execute the query
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllProducts", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtProductsTable.Load(reader);
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            }

            return dtProductsTable;
        }

        public static bool IsProductExist(int ProductID)
        {
            bool IsExist = false;
            string query = @"Select f = 1 from ProductCatalog where ProductID = @ProductID";

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    IsExist = reader.HasRows;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    IsExist = false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return IsExist;
        }

        /// <summary>
        /// This method calls view from database, mixed between ProductCatalog table and ProductCategory
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProductsInfo()
        {
            DataTable dtProductsInfo = new DataTable();
            string query = @"select * from ProductsInfo";

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand( query, conn))
            {
                try
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtProductsInfo.Load(reader);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message); 
                }
                finally
                {
                    conn.Close(); 
                }
            }

            return dtProductsInfo;
        }

        public static DataTable GetAllProductsName()
        {
            DataTable dtProductsNames = new DataTable();


            using(SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllProductsName", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtProductsNames.Load(reader);
                        reader.Close();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message); 
                }
                finally
                {
                    conn.Close();
                }
            }

            return dtProductsNames;
        }

        public static DataTable GetProducts_Paging(int pageNumber, int pageSize)
        {
            DataTable dtProducts  = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetProductsPerPaging", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumberOfPage", pageNumber);
                cmd.Parameters.AddWithValue("@RowsPerPage", pageSize);

                try
                {
                    conn.Open();
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtProducts.Load(reader);
                        reader.Close();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return dtProducts;
        }


    }
}
