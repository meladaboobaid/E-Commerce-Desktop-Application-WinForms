using SawaStore_DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SawaStore_BusinessLayer
{
    public class clsCustomers
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int CustomerID { get; set; }

        public clsPeople Person;
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        private clsCustomers(int CustomerID, int PersonID, string UserName, string Password)
        {
            this.Person = clsPeople.Find(PersonID);
            this.PersonID = PersonID;
            this.Password = Password;
            this.CustomerID = CustomerID;
            this.UserName = UserName;
            Mode = enMode.Update;
        }

        public clsCustomers()
        {
            this.CustomerID = -1;
            this.PersonID = -1;
            this.Person = null;
            this.UserName = "";
            this.Password = "";
            Mode = enMode.AddNew;
        }

        private bool _AddNewCustomer()
        {
            this.PersonID = clsCustomersData.AddNewCustomer(this.Person.PersonID, this.UserName, this.Password);
            return this.PersonID != -1;

        }
        private bool _UpdateCustomer()
        {
            return clsCustomersData.UpdateCustomer(this.CustomerID, this.Person.PersonID, this.UserName, this.Password);
        }
        public static DataTable GetAllCustomers()
        {
            return clsCustomersData.GetAllCustomers();
        }
        public static bool DeleteCustomer(int CustomerID)
        {
            return clsCustomersData.DeleteCustomer(CustomerID);
        }

        public static clsCustomers Find(int CustomerID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";

            if(clsCustomersData.GetCustomerInfoByID(CustomerID, ref PersonID, ref UserName, ref Password))
            {
                return new clsCustomers(CustomerID, PersonID, UserName, Password) ;

            }
            else
            {
                return null;
            }
        }

        public static bool IsCustomerExist(int CustomerID)
        {
            return clsCustomersData.IsCustomerExist(CustomerID) != -1;
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewCustomer())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return  _UpdateCustomer();
            }

            return false;
        }

        public static bool IsCustomerByEmail(string email)
        {
            return clsCustomersData.IsCustomerByEmail(email);
        }

        public static int FindCustomerByEmailAndPassword(string email,  string password)
        {
            return clsCustomersData.FindCustomerByEmailAndPassword(email, password);
        }


    }
}
