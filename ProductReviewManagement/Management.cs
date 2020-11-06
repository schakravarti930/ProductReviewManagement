using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Count);
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
        public void SelectProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { x.ProductID, x.Review });
            foreach(var list in recordedData)
            {
                Console.WriteLine(list.ProductID + " " + list.Review);
            }
        }
    }
}
