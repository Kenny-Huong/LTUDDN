using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VD_BANG.Context
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source = DESKTOP-P9QQDV1; Initial Catalog = HocSinhDb; Integrated Security = True");
            
        }
        //b1: add-migration <tên migration>
        //b2: update-database
        public DbSet<HocSinh> hocSinhs { get; set; }
        public DbSet<Lop> lops { get; set; }
        public DbSet<Truong> truongs { get; set; }
        public DbSet<GiangVien> giangViens { get; set; }



    }
}