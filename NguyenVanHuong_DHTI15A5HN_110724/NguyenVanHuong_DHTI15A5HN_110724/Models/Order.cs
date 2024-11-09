using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenVanHuong_DHTI15A5HN_110724.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        //Thuộc tính khóa ngoài
        public int CustomerId { get; set; }

        //Thuộc tính điều hướng
        public virtual Customer Customer { get; set; }
    }
}