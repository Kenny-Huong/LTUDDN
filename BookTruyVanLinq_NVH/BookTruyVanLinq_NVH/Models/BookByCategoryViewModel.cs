using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTruyVanLinq_NVH.Models
{
    public class BookByCategoryViewModel
    {

        public string CategoryName { get; set; }
        public int BookCount { get; set; }
        public Nullable<decimal> PriceSum { get; set; }
    }
}