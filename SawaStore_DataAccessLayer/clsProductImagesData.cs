using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SawaStore_DataAccessLayer
{
    public class clsProductImagesData
    {
        // I need here to make a simple CRUD operations 


        /// <summary>
        /// This Methods finds the images related to a specific product based 
        /// on the ProductID and returns list of these images  
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="ImageURLs"></param>
        /// <returns>
        /// return the list of image URLs in the ImageURLs as list sent by ref in parameters collection 
        /// return true if the images are found or false if not found or an error occurs
        /// </returns>
        public static bool FindProductImagesByProductId(int ProductID, ref List<string> ImageURLs)
        {
            bool IsFound = false;

            if (ImageURLs == null)
                ImageURLs = new List<string>();
            else
                ImageURLs.Clear();

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ImageURL FROM ProductImages WHERE ProductID = @ProductID ORDER BY ImageOrder";
                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        IsFound = reader.HasRows;

                        while (reader.Read())
                        {
                            string url = reader["ImageURL"] != DBNull.Value ? Convert.ToString(reader["ImageURL"]) : string.Empty;
                            ImageURLs.Add(url);
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    IsFound = false;
                }
                finally
                {
                    con.Close();
                }
            }

            return IsFound;
        }

        public static bool FindImageByImageID(int ImageID, ref int ProductID, ref string ImageURL, ref int ImageOrder)
        {
            bool IsFound = false;
            string query = @"select ProductID, ImageURL, ImageOrder from ProductImages where ImageID = @ImageID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@ImageID", ImageID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IsFound = true;

                        ProductID = Convert.ToInt32( reader["ProductID"]);
                        ImageOrder = Convert.ToInt32(reader["ImageOrder"]);
                        ImageURL = reader["ImageURL"].ToString();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    IsFound = false;
                }
                finally
                {
                    connection.Close();
                }
            }

            return IsFound;
        }
        public  static int AddNewImage(int ProductID, string ImageURL, int ImageOrder)
        {
            int NewImageID = -1;
            // Here you would a parameterized query that  add a new image and return the new ImageID
            // Use ADO.NET to connect to the database and execute the query to insert the new image, then retrieve the new ImageID  from the database and return it
            string connStr = clsDataAccessSettings.ConnectionString;
            string query = @"INSERT INTO ProductImages (ProductID, ImageURL, ImageOrder) 
                             VALUES (@ProductID, @ImageURL, @ImageOrder); 
                             SELECT CAST(SCOPE_IDENTITY() AS int);";
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ImageURL", ImageURL ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ImageOrder", ImageOrder);

                try
                {
                    con.Open();

                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out NewImageID))
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

            return NewImageID;
        }

        public  static bool DeleteImage(int ImageID)
        {
            bool IsDeleted = false;
            // Here you would typically call a method from the Data Access Layer to delete the image with the given ImageID
            // Use ADO.Net to connect the database and execute the query to delete the image , then set IsDeleted to true if the deletion was successful
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM ProductImages WHERE ImageID = @ImageID", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ImageID", ImageID);

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
        public static  bool DeleteImage(int ProductID, int ImageOrder)
        {
            bool IsDeleted = false;
            // Here I want you to delete the image based on the ProductID and the ImageOrder
            // The delete image is related with a specific product and the image order is used to identify the image to be deleted
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM ProductImages WHERE ProductID = @ProductID AND ImageOrder = @ImageOrder", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ImageOrder", ImageOrder);

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

        public static bool DeleteProductImages(int ProductID)
        {
            bool IsDeleted = false;
            // Here I want you to delete the image based on the ProductID and the ImageOrder
            // The delete image is related with a specific product and the image order is used to identify the image to be deleted
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM ProductImages WHERE ProductID = @ProductID", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);

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

        public static bool UpdateImage(int ImageID, int ProductID, string NewImageURL, int NewImageOrder)
        {
            bool IsUpdated = false;
            // Here you would execute a query that update the image with the given ImageID
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("UPDATE ProductImages SET ProductID = @ProductID, ImageURL = @ImageURL, ImageOrder = @ImageOrder WHERE ImageID = @ImageID", con))
            {
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ImageID", ImageID);
                cmd.Parameters.AddWithValue("@ProductID",ProductID);
                cmd.Parameters.AddWithValue("@ImageURL", NewImageURL ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ImageOrder", NewImageOrder);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    IsUpdated = affected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    IsUpdated = false;
                }
                finally
                {
                    con.Close();
                }
            }

            return IsUpdated;
        }

        public static DataTable GetAllImagesInfoAboutProduct(int ProductID)
        {
            DataTable dtProductImages = new DataTable();

            string query = @"select * from ProductImages where ProductID = @ProductID order by ImageOrder";
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, conn))
            {

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@ProductID", ProductID);


                try
                {
                    conn.Open();

                    using (SqlDataReader reader  = command.ExecuteReader())
                    {
                        dtProductImages.Load(reader);
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return dtProductImages;
        }
    }
}
