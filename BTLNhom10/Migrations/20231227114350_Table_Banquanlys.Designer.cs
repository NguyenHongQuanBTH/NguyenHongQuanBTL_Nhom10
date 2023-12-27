﻿// <auto-generated />
using BTLNhom10.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLNhom10.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    [Migration("20231227114350_Table_Banquanlys")]
    partial class Table_Banquanlys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("BTLNhom10.Models.Banquanly", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NamKN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("QueQuan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tuoi")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaNV");

                    b.ToTable("Banquanlys");
                });

            modelBuilder.Entity("BTLNhom10.Models.Nhanvien", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NamKN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("QueQuan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tuoi")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaNV");

                    b.ToTable("Nhanviens");
                });
#pragma warning restore 612, 618
        }
    }
}
