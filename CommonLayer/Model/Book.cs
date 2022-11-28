using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public long ActualPrice { get; set; }
        public long DiscountedPrice { get; set; }
        public int Rating{ get; set; }
        public long CustomerRatedcount { get; set; }
        public long BookStockQty { get; set; }

    }
}
