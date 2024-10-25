using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuyenDe_2310.Models
{
    public class HoaDon
    {
        [Required]
        public string SoHD {  get; set; }
        [Required]
        public string Ten {  get; set; }
        [Required]
        public string NgayDat {  get; set; }
        [Required]
        //Trường số lượng có giá trị từ 1 - 100
        [Range(1,100)]
        public double SoLuong {  get; set; }
        [Required]
        //Trường đơn giá thấp nhất phải từ 1000 trở lên
        [Range(1000, double.MaxValue)]
        public double DonGia {  get; set; }
        [Required]
        public string MaKH { get; set; }

    }
}