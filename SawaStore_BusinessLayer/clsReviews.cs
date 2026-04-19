using SawaStore_DataAccessLayer;
using System;
using System.Data;
namespace SawaStore_BusinessLayer
{
    public class clsReviews
    {
        public enum enMode { AddNew = 1, Update = 2 };

        public enMode Mode = enMode.AddNew;

        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public clsProductCatalog Product { get; set; }
        public int CustomerID { get; set; }
        public clsCustomers Customer { get; set; }
        public string ReviewText { get; set; }
        public int Rate { get; set; }
        public DateTime ReviewDate { get; set; }

        public clsReviews()
        {
            Mode = enMode.AddNew;
            this.ReviewID = -1;
            this.ProductID = -1;
            this.CustomerID = -1;
            this.ReviewText = string.Empty;
            this.Rate = 0;
            this.ReviewDate = DateTime.Now; 
        }

        private clsReviews(int ReviewID,int CustomerID , int ProductID, string ReviewText,  int Rate,  DateTime ReviewDate)
        {
            Mode = enMode.Update;
            this.ReviewID = ReviewID;
            this.CustomerID = CustomerID;

            if(this.CustomerID != -1)
            {
                this.Customer = clsCustomers.Find(this.CustomerID);
            }
            this.ProductID = ProductID;
            if(this.ProductID != -1)
            {
                this.Product = clsProductCatalog.Find(this.ProductID);
            }

            this.ReviewText =ReviewText;
            this.Rate = Rate;
            this.ReviewDate = ReviewDate;
        }

        private bool _AddNewReview()
        {
            this.ReviewID = clsReviewsData.AddNewReview(this.CustomerID, this.ProductID, this.ReviewText, 
                this.Rate, this.ReviewDate);

            return (this.ReviewID != -1);
        }

        private bool _UpdateReview()
        {
            return clsReviewsData.UpdateReview(this.ReviewID, this.CustomerID, this.ProductID, 
                this.ReviewText, this.Rate, this.ReviewDate);
        }

        public static bool DeleteReview(int ReviewID)
        {
            return clsReviewsData.DeleteReview(ReviewID);
        }

        /// <summary>
        /// In this method we will deal with ReviewsInfo
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllReviews()
        {
            return clsReviewsData.GetAllReviews();   
        }

        public static clsReviews FindReview(int ReviewID)
        {
            int productID = -1;
            int customerID = -1;
            string reviewText = string.Empty;
            int rate = 0;
            DateTime reviewDate = DateTime.MinValue;

            if (clsReviewsData.GetReviewByID(ReviewID, ref customerID, ref productID, ref reviewText, ref rate, ref reviewDate))
            {
                return new clsReviews(ReviewID, customerID, productID, reviewText, rate, reviewDate);
            }
            else
            {
                return null;
            }
        }

    }
}
