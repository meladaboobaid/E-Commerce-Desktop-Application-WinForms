using SawaStore_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Permissions;

namespace SawaStore_BusinessLayer
{
    public class clsProductCatalog
    {
        public enum enMode { AddNew = 1, Update = 2 };

        public enMode Mode = enMode.AddNew;
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategoryID { get; set; }
        public clsProductCategory ProductCategoryInfo { get; set; }
        public int QuantityInStock { get; set; }
        public double ProductPrice { get; set; }
        public List<string> ProductImagesURLs { get; set; }
        public clsProductImages ProductImagesInfo { get; set; }
        private clsProductCatalog(int ProductID, string ProductName, string ProductDescription, int QuantityInStock, double ProductPrice, int ProductCategoryID)
        {
            Mode = enMode.Update;

            this.ProductID           = ProductID;
            this.ProductName         = ProductName;
            this.ProductDescription  = ProductDescription;
            this.QuantityInStock     = QuantityInStock;
            this.ProductPrice        = ProductPrice;
            this.ProductCategoryID   = ProductCategoryID;
            this.ProductImagesURLs = clsProductImages.FindImagesListByProductID(this.ProductID);
            this.ProductCategoryInfo = clsProductCategory.Find(ProductCategoryID);
        }

        public clsProductCatalog()
        {
            Mode = enMode.AddNew;
            this.ProductImagesURLs = new List<string>();

            this.ProductID = -1;
            this.ProductName = string.Empty;
            this.ProductDescription = string.Empty;
            this.QuantityInStock = 0;
            this.ProductPrice = 0.0;
            this.ProductCategoryID = -1;
        }

        private bool _AddNewProduct()
        {
            this.ProductID = clsProductCatalogData.AddNewProduct(this.ProductName, this.ProductDescription, 
                this.ProductPrice, this.QuantityInStock, this.ProductCategoryID);
            return this.ProductID != -1;
        }

        private bool _UpdateProduct()
        {
            return clsProductCatalogData.UpdateProduct(this.ProductID, this.ProductName, this.ProductDescription, this.ProductPrice, this.QuantityInStock, this.ProductCategoryID);
        }

        public static clsProductCatalog Find(int ProductID)
        {
            string ProductName = "";
            string ProductDescription = "";
            double ProductPrice = 0.0;
            int QuantityInStock = 0;
            int ProductCategoryID = -1;

            if (clsProductCatalogData.FindProductById(ProductID, ref ProductName, ref ProductDescription,
                ref ProductPrice, ref QuantityInStock, ref ProductCategoryID))
                return new clsProductCatalog(ProductID, ProductName, ProductDescription, QuantityInStock, ProductPrice, ProductCategoryID);
            else
                return null;
        }

        public static bool Delete(int ProductID)
        {
            return clsProductCatalogData.DeleteProduct(ProductID);
        }

        public static bool IsProductExist(int ProductID)
        {
            return clsProductCatalogData.IsProductExist(ProductID);
        }

        public static DataTable GetAllProducts()
        {
            return clsProductCatalogData.GetAllProducts();
        }

        public static DataTable GetProducts_Paging(int PageNumber, int PageSize)
        {
            return clsProductCatalogData.GetProducts_Paging(PageNumber, PageSize);
        }

        public static DataTable GetProductsInfo()
        {
            return clsProductCatalogData.GetProductsInfo();
        }

        public static DataTable GetAllProductsName()
        {
            return clsProductCatalogData.GetAllProductsName();
        }

        public static int GetTotalProducts()
        {
            return clsProductCatalogData.GetAllProducts().Rows.Count;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewProduct())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateProduct();
                default:
                    return false;
            }
        }
    }
}
