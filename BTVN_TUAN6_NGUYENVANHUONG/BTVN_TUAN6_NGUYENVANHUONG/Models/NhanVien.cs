using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace BTVN_TUAN6_NGUYENVANHUONG.Models
{
    public class NhanVien
    {
        [Key]
        [StringLength(4)]
        public string maNV { get; set; }
        [Display(Name ="Tên quầy")]
        [StringLength(30)]
        public string tenQuay { get; set; }
        [Display(Name ="Họ tên")]
        public string hoTen { get; set; }

        public virtual ICollection<BanHang> BanHangs { get; set; }

       
    }
}