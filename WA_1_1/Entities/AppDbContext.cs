using Microsoft.EntityFrameworkCore;

namespace WA_1_1.Entities
{
    public class AppDbContext:DbContext
    {
        public virtual DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = LAPTOP-JHB8V59V\\SQLEXPRESS; Database= WA_1_1; Trusted_Connection=true; TrustServerCertificate=True");
        }
    }
}
