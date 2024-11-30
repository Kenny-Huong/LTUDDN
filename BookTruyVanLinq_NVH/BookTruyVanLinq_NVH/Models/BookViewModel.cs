using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTruyVanLinq_NVH.Models
{
    public class BookViewModel
    {
        public String Title { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}