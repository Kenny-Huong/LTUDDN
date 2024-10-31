using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNguoiDung.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên bắt buộc phải nhập")]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Họ tên")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ReEnterPassword { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public int Age { get; set; }
        [Required]
        public bool Gender { get; set; }

        public string GenderText
        {
            get { return Gender ? "Nam" : "Nữ"; }
        }
    }
}