using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.RequestParameters.Products
{
    public class ProductRequestParameter : RequestParameter
    {
        public int? CategoryId  { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public bool IsValidPrice => MaxPrice > MinPrice;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public ProductRequestParameter():this(1, 6)
        {
            
        }
        public ProductRequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}