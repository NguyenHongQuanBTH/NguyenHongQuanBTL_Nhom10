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
    [Migration("20231228071617_Add_Quanlyhosos")]
    partial class Add_Quanlyhosos
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

            modelBuilder.Entity("BTLNhom10.Models.Chamcong", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<int>("NgayNghiPhep")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoGioCong")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoNgayCong")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNV");

                    b.ToTable("Chamcongs");
                });

            modelBuilder.Entity("BTLNhom10.Models.Luong", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<int>("HeSoLuong")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LuongChuyenCan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LuongCoBan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PhuCap")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNV");

                    b.ToTable("Luongs");
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

            modelBuilder.Entity("BTLNhom10.Models.Quanlyhoso", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NgayLamViec")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhongBan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SinhNgay")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SoTaiKhoan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNV");

                    b.ToTable("Quanlyhosos");
                });
#pragma warning restore 612, 618
        }
    }
}
