﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WA_1_1.Entities;

#nullable disable

namespace WA_1_1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WA_1_1.Entities.ChiTietHoaDon", b =>
                {
                    b.Property<int>("ChiTietHoaDonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietHoaDonId"));

                    b.Property<string>("DVT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HoaDonId")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<double?>("ThanhTien")
                        .HasColumnType("float");

                    b.HasKey("ChiTietHoaDonId");

                    b.HasIndex("HoaDonId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("ChiTietHoaDon");
                });

            modelBuilder.Entity("WA_1_1.Entities.HoaDon", b =>
                {
                    b.Property<int>("HoaDonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoaDonID"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhachHangId")
                        .HasColumnType("int");

                    b.Property<string>("MaGiaoDich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHoaDon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ThoiGiaGiaoCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGiaTao")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("HoaDonID");

                    b.HasIndex("KhachHangId");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("WA_1_1.Entities.KhachHang", b =>
                {
                    b.Property<int>("KhachHangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhachHangId"));

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KhachHangId");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("WA_1_1.Entities.LoaiSanPham", b =>
                {
                    b.Property<int?>("LoaiSanPhamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("LoaiSanPhamId"));

                    b.Property<string>("TenLoaiSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiSanPhamId");

                    b.ToTable("LoaiSanPham");
                });

            modelBuilder.Entity("WA_1_1.Entities.SanPham", b =>
                {
                    b.Property<int>("SanPhamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanPhamId"));

                    b.Property<double>("GiaThanh")
                        .HasColumnType("float");

                    b.Property<string>("KiHieuSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiSanPhamId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayHetHan")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SanPhamId");

                    b.HasIndex("LoaiSanPhamId");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("WA_1_1.Entities.ChiTietHoaDon", b =>
                {
                    b.HasOne("WA_1_1.Entities.HoaDon", "HoaDon")
                        .WithMany("chiTietHoaDons")
                        .HasForeignKey("HoaDonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WA_1_1.Entities.SanPham", "SanPham")
                        .WithMany("chiTietHoaDons")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WA_1_1.Entities.HoaDon", b =>
                {
                    b.HasOne("WA_1_1.Entities.KhachHang", "KhachHang")
                        .WithMany("hoaDons")
                        .HasForeignKey("KhachHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("WA_1_1.Entities.SanPham", b =>
                {
                    b.HasOne("WA_1_1.Entities.LoaiSanPham", "LoaiSanPham")
                        .WithMany()
                        .HasForeignKey("LoaiSanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSanPham");
                });

            modelBuilder.Entity("WA_1_1.Entities.HoaDon", b =>
                {
                    b.Navigation("chiTietHoaDons");
                });

            modelBuilder.Entity("WA_1_1.Entities.KhachHang", b =>
                {
                    b.Navigation("hoaDons");
                });

            modelBuilder.Entity("WA_1_1.Entities.SanPham", b =>
                {
                    b.Navigation("chiTietHoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}
