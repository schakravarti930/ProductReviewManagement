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
    }
}
