using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VD_BANG.Context
{
    public class HocSinh
    {
        [Key]
        public int maHocSinh { get; set; }
        public string hoTen { get; set; }   
    }
}