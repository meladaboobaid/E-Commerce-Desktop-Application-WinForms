using System;
using System.Data;
using SawaStore_DataAccessLayer;

namespace SawaStore_BusinessLayer
{
    public class clsProductCategory
    {

        public enum enMode { AddNew = 1, Update = 2};

        public enMode Mode = enMode.AddNew;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        private clsProductCategory(int CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            Mode = enMode.Update;
        }

        public clsProductCategory()
        {
            this.CategoryID = -1;
            this.CategoryName = "";
            Mode = enMode.AddNew;
        }

        private bool _AddNewCategory()
        {
            this.CategoryID = clsProductCategoryData.AddNewCategory(this.CategoryName);
            return this.CategoryID != -1;
        }

        private bool _UpdateCategory()
        {
            return clsProductCategoryData.UpdateCategory(this.CategoryID, this.CategoryName);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewCategory())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateCategory();

            }

            return false;
        }

        public static bool DeleteCategory(int CategoryID)
        {
            return clsProductCategoryData.DeleteCategory(CategoryID);
        }

        public static DataTable GetAllCategories()
        {
            return clsProductCategoryData.GetAllCategories();
        }

        public static bool IsCategoryExist(int CategoryID)
        {
            string tmp = string.Empty;
            int result  = clsProductCategoryData.FindCategoryByID(CategoryID, ref tmp) ? CategoryID : -1;
            return result != -1;
        }

        public static clsProductCategory Find(int CategoryID)
        {
            string CategoryName = "";

            if (clsProductCategoryData.FindCategoryByID(CategoryID, ref CategoryName))
                return new clsProductCategory(CategoryID, CategoryName);

            else
                return null;
        }
        public static clsProductCategory Find(string CategoryName)
        {
            int CategoryID = -1;

            if (clsProductCategoryData.FindCategoryByName(CategoryName, ref CategoryID))
                return new clsProductCategory(CategoryID, CategoryName);

            else
                return null;
        }
    }
}
