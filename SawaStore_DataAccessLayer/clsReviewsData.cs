using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SawaStore_DataAccessLayer
{
    public class clsReviewsData
    {
        public static bool GetReviewByID(int ReviewID, ref int CustomerID, ref int ProductID, ref string ReviewText
            , ref int Rate , ref DateTime ReviewDate)
        {
            bool IsFound  = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT CustomerID, ProductID, ReviewText, Rate, ReviewDate FROM Reviews WHERE ReviewID = @ReviewID";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ReviewID", ReviewID);

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            CustomerID = reader["CustomerID"] != DBNull.Value ? Convert.ToInt32(reader["CustomerID"]) : 0;
                            ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0;
                            ReviewText = reader["ReviewText"] != DBNull.Value ? Convert.ToString(reader["ReviewText"]) : string.Empty;
                            Rate = reader["Rate"] != DBNull.Value ? Convert.ToInt32(reader["Rate"]) : 0;
                            ReviewDate = reader["ReviewDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReviewDate"]) : DateTime.MinValue;
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

        public static int AddNewReview(int CustomerID, int ProductID, string ReviewText
            , int Rate, DateTime ReviewDate)
        {
            int ReviewID = -1;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Reviews (CustomerID, ProductID, ReviewText, Rate, ReviewDate) VALUES (@CustomerID, @ProductID, @ReviewText, @Rate, @ReviewDate); SELECT CAST(SCOPE_IDENTITY() AS int);", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ReviewText", ReviewText ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Rate", Rate);
                cmd.Parameters.AddWithValue("@ReviewDate", ReviewDate);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        ReviewID = Convert.ToInt32(result);
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

            return ReviewID;
        }

        public static bool UpdateReview(int ReviewID, int CustomerID, int ProductID, string ReviewText
            , int Rate, DateTime ReviewDate)
        {
            bool IsUpdated = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("UPDATE Reviews SET CustomerID = @CustomerID, ProductID = @ProductID, ReviewText = @ReviewText, Rate = @Rate, ReviewDate = @ReviewDate WHERE ReviewID = @ReviewID", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ReviewID", ReviewID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ReviewText", ReviewText ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Rate", Rate);
                cmd.Parameters.AddWithValue("@ReviewDate", ReviewDate);

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

        public static bool DeleteReview(int ReviewID)
        {
            bool isDeleted = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Reviews WHERE ReviewID = @ReviewID", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ReviewID", ReviewID);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    isDeleted = affected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                    isDeleted = false;
                }
                finally
                {
                    con.Close();
                }
            }

            return isDeleted;
        }

        public static DataTable GetAllReviews()
        {
            DataTable dtReviews = new DataTable("Reviews");

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM ReviewsInfo", con))
            {
                cmd.CommandType = CommandType.Text;
                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtReviews.Load(reader);
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

            return dtReviews;
        }



    }

}
