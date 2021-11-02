using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindModel.Requests.Product
{
    public class ProductSearchRequest
    {
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
    }
}
