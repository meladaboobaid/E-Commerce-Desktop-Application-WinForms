using SawaStore_DataAccessLayer;
using System.Data;

namespace SawaStore_BusinessLayer
{
    public class clsUsers
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int UserID { get; set; }

        public clsPeople Person;
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonID { get; set; }
        public bool IsActive { get; set; }

        private clsUsers(int UserID, int PersonID, string UserName, string Password, bool isActive)
        {
            this.Person = clsPeople.Find(PersonID);
            this.PersonID = PersonID;
            this.Password = Password;
            this.UserID = UserID;
            this.UserName = UserName;
            Mode = enMode.Update;
            IsActive = isActive;
        }

        public clsUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Person = null;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            Mode = enMode.AddNew;
        }

        private bool _AddNewUser()
        {
            this.PersonID =  clsUsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return this.PersonID != -1;
        }
        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.UserID, this.Person.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static clsUsers Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsUsersData.GetUserInfoByID(UserID, ref PersonID, ref UserName, ref Password ,ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);

            }
            else
            {
                return null;
            }
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUsersData.isUserExist(UserID) != -1;
        }

        public static bool IsPersonAlreadyUser(int PersonID)
        {
            return clsUsersData.IsPersonAlreadyUser(PersonID) != -1;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public static int FindByEmailAndPassword(string Email, string Password)
        {
            return clsUsersData.FindByEmailAndPassword(Email, Password);
        }

    }
}
