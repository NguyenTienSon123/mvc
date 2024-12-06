using WA_1_1.Entities;
using WA_1_1.Helper;
using WA_1_1.IServices;

namespace WA_1_1.Services
{
    public class SanPhamServices : ISanPhamServices
    {
        private readonly AppDbContext dbContext;

        public SanPhamServices()
        {
            dbContext = new AppDbContext();
        }

        public ErrorMessage ThemSanPham(SanPham sanPham)
        {
            var LoaiSanPhamCanTim= dbContext.LoaiSanPham.FirstOrDefault(x=>x.LoaiSanPhamId==sanPham.LoaiSanPhamId);
            if(LoaiSanPhamCanTim==null)
            {
                return ErrorMessage.LoaiSanPhamKhongTonTai;
            }
            else
            {
                dbContext.SanPham.Add(sanPham);
                dbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
        }
    }
}
