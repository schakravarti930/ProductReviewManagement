using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProductReviewManagement
{
    class Management
    {
        public readonly DataTable dataTable = new DataTable();
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview
                                orderby productReview.Rating descending
                                select productReview).Take(3);
            foreach(var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData =  from productReview in listProductReview
                                where (productReview.ProductID == 1 || productReview.ProductID == 4 || productReview.ProductID == 9)
                                && productReview.Rating > 3
                                select productReview;
            foreach(var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               group productReview by productReview.ProductID into g
                               select new { ProductId = g.Key, Count = g.Count() };
            foreach(var list in recordedData)
            {
                Console.WriteLine(list.ProductId + " " + list.Count);
            }
        }
        public void RetrieveProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               select new { productReview.ProductID, productReview.Review };
            foreach(var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Review);
            }
        }
        public void SkipTop5Records(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview
                                select productReview).Skip(5);
            foreach(var list in recordedData)
            {
                Console.WriteLine(list.ToString());
            }
        }
    }
}
