using Microsoft.Win32; // this namespace called registry functionality 
using SawaStore_BusinessLayer;
using System;
using System.Windows.Forms;
namespace Sawa_Store_Project
{
    public class clsGlobal
    {
        public static clsUsers CurrentUser;
        public static clsCustomers LoggedInCustomer;

        // Hard coded shipping amount, in real life this
        // should be calculated based on the order details and the shipping address
        public static double ShippingAmount = 100;
        
        public static bool GetStoredCredential(ref string Email, ref string Password)
        {
            string KeyName = @"HKEY_CURRENT_USER\Software\SawaStore";

            try
            {
                string ValueEmail = "Email";
                string ValuePassword = "Password";


                string email = Registry.GetValue(KeyName, ValueEmail, null) as string;
                string password = Registry.GetValue(KeyName, ValuePassword, null) as string;

                if (email != null && password != null)
                {
                    Email = email;
                    Password = password;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("An Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool RememberEmailAndPassword(string Email, string Password)
        {
            string KeyName = @"HKEY_CURRENT_USER\Software\SawaStore";

            try
            {
                string ValueEmail = "Email";
                string ValuePassword = "Password";

                // In case the user doesn't want to save his credential 
                if (Email == "" || Password == "")
                {
                    string keyPath = @"SOFTWARE\SawaStore";
                    using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        using (RegistryKey Key = baseKey.OpenSubKey(keyPath, true))
                        {
                            if (Key != null)
                            {
                                Key.DeleteValue(ValueEmail);
                                Key.DeleteValue(ValuePassword);
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }

                Registry.SetValue(KeyName, ValueEmail, Email, RegistryValueKind.String);
                Registry.SetValue(KeyName, ValuePassword, Password, RegistryValueKind.String);
                return true;
            }
            catch (UnauthorizedAccessException ex1)
            {
                Console.WriteLine("Unauthorized Access Exception : Run the program as administrator");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public static bool IsValidDiscountCode(string DiscountCode)
        {
            // In real life this should be checked in the database
            return DiscountCode == "SAWA10";
        }
    }
}
