using System;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;

namespace SawaStore_DataAccessLayer
{
    public class clsUsersData
    {

        // CRUD 
        // Create =>  Done
        // Delete =>  Done
        // Update =>  Done
        // Read   =>  Done
        // Find   =>  Done

        public static bool GetUserInfoByID(int UserID, ref int PersonID,
         ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
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


        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int userID = -1;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_AddNewUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@UserName", UserName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Password", Password ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", IsActive ? 1 : 0);

                SqlParameter outParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (outParam.Value != DBNull.Value)
                        userID = Convert.ToInt32(outParam.Value);
                }
                finally
                {
                    con.Close();
                }
            }

            return userID;
        }

        public static bool DeleteUser(int UserID)
        {
            bool IsDeleted = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_DeleteUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    IsDeleted = affected > 0;
                }
                finally
                {
                    con.Close();
                }
            }

            return IsDeleted;
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            bool IsUpdated = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_UpdateUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@UserName", UserName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Password", Password ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", IsActive ? 1 : 0);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    IsUpdated = affected > 0;
                }
                finally
                {
                    con.Close();
                }
            }

            return IsUpdated;
        }

        public static int isUserExist(int UserID)
        {

            string connStr = clsDataAccessSettings.ConnectionString;
            int foundId = -1;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT UserID FROM Users WHERE UserID = @UserID";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        foundId = Convert.ToInt32(result);
                }
                finally
                {
                    con.Close();
                }
            }

            return foundId;
        }
        public static int IsPersonAlreadyUser(int PersonID)
        {
            string connStr = clsDataAccessSettings.ConnectionString;
            int foundId = -1;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT UserID FROM Users WHERE PersonID = @PersonID";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        foundId = Convert.ToInt32(result);
                }
                finally
                {
                    con.Close();
                }
            }

            return foundId;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable("Users");
            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllUsers", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtUsers.Load(reader);
                        reader.Close();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return dtUsers;
        }

        public static int FindByEmailAndPassword(string email, string password)
        {
            int UserID = -1;

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_FindByEmailAndPassword", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                SqlParameter OutputParameter = new SqlParameter("@UserID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(OutputParameter);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    if (OutputParameter.Value != DBNull.Value)
                        UserID = Convert.ToInt32(OutputParameter.Value);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close() ;
                }

                return UserID;
            }
        }
    }
}
