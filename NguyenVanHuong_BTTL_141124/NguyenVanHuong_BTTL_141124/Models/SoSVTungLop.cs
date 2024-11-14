using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace NguyenVanHuong_BTTL_141124.Models
{
    public class SoSVTungLop
    {
        [Display(Name = "Tên lớp")]
        public string tenLop { get; set; }
        [Display(Name ="Sĩ số")]
        public int siSo { get; set; }
       
    }
}