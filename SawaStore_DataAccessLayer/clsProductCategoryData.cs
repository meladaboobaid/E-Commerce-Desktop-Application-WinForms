using System;
using System.Data;
using System.Data.SqlClient;
namespace SawaStore_DataAccessLayer
{

    
    public class clsProductCategoryData
    {
        public static bool FindCategoryByName(string CategoryName , ref int CategoryID)
        {
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CategoryID FROM ProductCategory WHERE CategoryName = @CategoryName";
                command.Parameters.AddWithValue("@CategoryName", CategoryName);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out CategoryID))
                    {
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return (CategoryID != -1);
        }

        public static bool FindCategoryByID(int CategoryID, ref string CategoryName)
        {
            bool isFound = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CategoryName FROM ProductCategory WHERE CategoryID = @CategoryID";
                command.Parameters.AddWithValue("@CategoryID", CategoryID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        CategoryName = Convert.ToString(result);
                        isFound = true;
                    }
                    else
                    {
                        isFound = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }
            }

            return isFound;
        }
         public static int AddNewCategory(string CategoryName)
         {
            int CategoryID = -1;

            // Call "SP_AddNewCategory" stored procedure to add a new category to the database
            // Use ADO.Net to connect to the database and execute the stored procedure with the provided category CategoryName
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_AddNewCategory", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName ?? (object)DBNull.Value);

                SqlParameter OutPutParameter = new SqlParameter("@NewCategoryID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(OutPutParameter);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    
                    if(result != null && result != DBNull.Value)
                    {
                        CategoryID = Convert.ToInt32(result);
                    }
                    else
                    {
                        CategoryID = -1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                    CategoryID = -1;
                }
                finally
                {
                    con.Close();
                }
            }

            return CategoryID;
         }
          public static bool UpdateCategory(int CategoryID, string CategoryName)
          {
                bool IsUpdated = false;
                // Call "SP_UpdateCategory" stored procedure to update the category CategoryName in the database based on the CategoryID
                // Use ADO.Net to connect to the database and execute the stored procedure with the provided CategoryID and new CategoryName
                string connStr = clsDataAccessSettings.ConnectionString;

                using (SqlConnection con = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("SP_UpdateCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", CategoryName ?? (object)DBNull.Value);

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
           public static bool DeleteCategory(int CategoryID)
           {
                bool IsDeleted = false;
                // Call "SP_DeleteCategory" stored procedure to delete the category from the database based on the CategoryID
                // Use ADO.Net to connect to the database and execute the stored procedure with the provided CategoryID
                string connStr = clsDataAccessSettings.ConnectionString;

                using (SqlConnection con = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("SP_DeleteCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

                    try
                    {
                        con.Open();
                        int affected = cmd.ExecuteNonQuery();
                        IsDeleted = affected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.StackTrace);
                        IsDeleted = false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                return IsDeleted;
           }


            public static DataTable GetAllCategories()
            {
                DataTable dtCategories = new DataTable("Categories");
                // Call "SP_GetAllCategories" stored procedure to retrieve all categories from the database
                // Use ADO.Net to connect to the database and execute the stored procedure, then fill a DataTable with the results and return it
                string connStr = clsDataAccessSettings.ConnectionString;
            string query = @"select CategoryName from ProductCategory ";

                using (SqlConnection con = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    try
                    {
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dtCategories.Load(reader);
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

                return dtCategories;
            }

    }
}
