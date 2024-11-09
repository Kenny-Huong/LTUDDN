using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NguyenVanHuong_DHTI15A5HN_110724.Models
{
    public class Customer
    {
        [Key]   
        
        public int CustomerId { get; set; }
        public string Name { get; set; }
        //thuộc tính điều hướng
        public virtual ICollection<Order> Orders { get; set; }
    }
}