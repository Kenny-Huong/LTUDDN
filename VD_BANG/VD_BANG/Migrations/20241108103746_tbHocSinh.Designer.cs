﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VD_BANG.Context;

namespace VD_BANG.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241108103746_tbHocSinh")]
    partial class tbHocSinh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VD_BANG.Context.HocSinh", b =>
                {
                    b.Property<int>("maHocSinh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("hoTen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maHocSinh");

                    b.ToTable("hocSinhs");
                });
#pragma warning restore 612, 618
        }
    }
}