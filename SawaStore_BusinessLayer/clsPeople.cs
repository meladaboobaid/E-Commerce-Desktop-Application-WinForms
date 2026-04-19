using SawaStore_DataAccessLayer;
using System.Data;

namespace SawaStore_BusinessLayer
{
    public class clsPeople
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public clsPeople()
        {
            PersonID = -1;
            Name = "";
            Email = "";
            Phone = "";
            Address = "";
            Mode = enMode.AddNew;
        }

        private clsPeople(int PersonID, string Name, string Email, string Phone, string Address)
        {

            this.Name = Name;
            this.PersonID = PersonID;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            Mode = enMode.Update;
        }

        private  bool _AddNewPerson()
        {
            this.PersonID =  clsPeopleData.AddNewPerson(this.Name, this.Email, this.Phone, this.Address);

            return this.PersonID != -1;
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);    
        }
        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(this.PersonID, this.Name, this.Email, this.Phone, this.Address);
        }
        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople(); 
        }
        public static int IsPersonExist(int PersonID)
        {
            return clsPeopleData.IsPersonExist(PersonID); 
        }

        public static clsPeople Find(int PersonID)
        {
            string Name = "";
            string Email = "";
            string Address = "";
            string Phone = "";

            if (clsPeopleData.GetPersonInfoByID(PersonID, ref Name, ref Email, ref Phone, ref Address))
                return new clsPeople(PersonID, Name, Email, Phone, Address);

            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }

    }
}
