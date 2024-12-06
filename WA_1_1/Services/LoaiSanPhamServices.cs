using WA_1_1.Entities;
using WA_1_1.Helper;
using WA_1_1.IServices;

namespace WA_1_1.Services
{
    public class LoaiSanPhamServices : ILoaiSanPhamServices
    {
        private readonly AppDbContext dbContext;

        public LoaiSanPhamServices()
        {
            dbContext = new AppDbContext();
        }

        public List<LoaiSanPham> GetDanhSachLoaiSanPham()
        {
            return dbContext.LoaiSanPham.AsQueryable().ToList();
        }

        public ErrorMessage ThemLoaiSamPham(LoaiSanPham loaiSanPham)
        {
            
                dbContext.LoaiSanPham.Add(loaiSanPham);
                dbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
          
        }

        public ErrorMessage XoaLoaiSanPham(int MLSP)
        {
            var LoaiSanPhamCanTim = dbContext.LoaiSanPham.FirstOrDefault(x => x.LoaiSanPhamId == MLSP);
            if(LoaiSanPhamCanTim == null)
            {
                return ErrorMessage.LoaiSanPhamKhongTonTai;
            }
            else
            {
                List<SanPham> sanPhams = dbContext.SanPham.AsQueryable().ToList();
                sanPhams = sanPhams.FindAll(x=>x.LoaiSanPhamId== MLSP);
                foreach (var item in sanPhams)
                {
                    dbContext.SanPham.Remove(item);
                    dbContext.SaveChanges();
                }
                dbContext.LoaiSanPham.Remove(LoaiSanPhamCanTim);
                dbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
        }
    }
}
