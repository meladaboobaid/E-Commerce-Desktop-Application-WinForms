using System;
using System.Data;
using System.Data.SqlClient;

namespace SawaStore_DataAccessLayer
{
    public class clsPeopleData
    {

        // CRUD 
        // Create =>  Done
        // Delete =>  Done
        // Update =>  Done
        // Read   =>  Done
        // Find   =>  Done

        public static bool GetPersonInfoByID(int PersonID, ref string Name,
                         ref string Email, ref string Phone, ref string Address)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Name = (string)reader["Name"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];

                    //ThirdName: allows null in database so we should handle null
                    if (reader["Address"] != DBNull.Value)
                    {
                        Address = (string)reader["Address"];
                    }
                    else
                    {
                        Address = "";
                    }
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

        public static int AddNewPerson(string Name, string Email, string Phone, string Address)
        {
            int personID = -1;


            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_AddNewPerson", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", Address ?? (object)DBNull.Value);

                SqlParameter outParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        personID = Convert.ToInt32(outParam.Value);
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

            return personID;
        }

        public static bool DeletePerson(int PersonID)
        {
            bool IsDeleted = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_DeletePerson", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    con.Open();
                    int affected = cmd.ExecuteNonQuery();
                    IsDeleted = affected > 0;
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

            return IsDeleted;
        }

        public static bool UpdatePerson(int PersonID, string Name, string Email, string Phone, string Address)
        {
            bool IsUpdated = false;

            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_UpdatePerson", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@Name", Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", Address ?? (object)DBNull.Value);

                try
                {
                    con.Open();

                    int affected = cmd.ExecuteNonQuery();
                    IsUpdated = affected > 0;
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

            return IsUpdated;
        }

        public static int IsPersonExist(int PersonID)
        {

            string connStr = clsDataAccessSettings.ConnectionString;

            int foundId = -1;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT PersonID FROM People WHERE PersonID = @PersonID";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        foundId = Convert.ToInt32(result);
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

            return foundId;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dtPeople = new DataTable("People");


            string connStr = clsDataAccessSettings.ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllPeople", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtPeople.Load(reader);
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

            return dtPeople;
        }

    }
}
