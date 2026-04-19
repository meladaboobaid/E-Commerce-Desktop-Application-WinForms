using SawaStore_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace SawaStore_BusinessLayer
{
    public class clsProductImages
    {
        // You should use a List to Handle the images order for specific order 
        public enum enMode { AddNew = 1, Update = 2 };

        public enMode Mode = enMode.AddNew;
        public int ImageID { get; set; }
        public string ImageURL { get; set; }
        public int ProductID { get; set; }
        public clsProductCatalog Product {  get; set; }
        public int ImageOrder { get; set; }

        private clsProductImages(int ImageID, string ImageURL, int ProductID, int ImageOrder)
        {
            Mode = enMode.Update;

            this.ImageID = ImageID;
            this.ProductID = ProductID;
            if(this.ProductID != -1)
            {
                this.Product = clsProductCatalog.Find(this.ProductID);
            }
            this.ImageURL = ImageURL;
            this.ImageOrder = ImageOrder;
        }

        public clsProductImages()
        {
            Mode = enMode.AddNew;
            this.ProductID = -1;
            this.ImageID = -1;
            this.ImageURL = string.Empty;
            this.ImageOrder = 0;
        }



        private bool _AddNewProductImage()
        {
            this.ImageID = clsProductImagesData.AddNewImage(this.ProductID, this.ImageURL, this.ImageOrder);
            return this.ImageID != -1;
        }

        private bool _UpdateProductImage()
        {
            return clsProductImagesData.UpdateImage(this.ImageID, this.ProductID, this.ImageURL, this.ImageOrder);
        }

        public  static List<string> FindImagesListByProductID(int ProductID)
        {
            List <string > ImageURLs = new List<string>();

            if (clsProductImagesData.FindProductImagesByProductId(ProductID, ref ImageURLs))
            {
                return ImageURLs;
            }
            else
            {
                ImageURLs.Clear();
                return ImageURLs;
            }
        }



        public static bool DeleteByImageID(int ImageID)
        {
            return clsProductImagesData.DeleteImage(ImageID);
        }
        public static bool DeleteByProductID(int ProductID, int ImageOrder)
        {
            return clsProductImagesData.DeleteImage(ProductID, ImageOrder);
        }

        public static bool DeleteProductImages(int ProductID)
        {
            return clsProductImagesData.DeleteProductImages(ProductID);
        }

        public static DataTable GetAllImagesInfoAboutProduct(int ProductID)
        {
            return clsProductImagesData.GetAllImagesInfoAboutProduct(ProductID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewProductImage())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateProductImage();
                default:
                    return false;
            }
        }




    }
}
