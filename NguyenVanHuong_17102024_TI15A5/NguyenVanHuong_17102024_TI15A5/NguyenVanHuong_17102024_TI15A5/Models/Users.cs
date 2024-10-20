using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NguyenVanHuong_17102024_TI15A5.Models
{
    public class Users
    {
        //prop tab tab
        public int Id { get; set; }
        public string  Name { get; set; }
        public string  Address { get; set; }
        public string  Email { get; set; }
        [EmailAddress]

        public bool Gender { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}