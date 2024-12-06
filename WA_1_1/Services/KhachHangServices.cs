using WA_1_1.Entities;
using WA_1_1.Helper;
using WA_1_1.IServices;

namespace WA_1_1.Services
{
    public class KhachHangServices : IKhachHangServices
    {
        private readonly AppDbContext dbContext;

        public KhachHangServices()
        {
            dbContext = new AppDbContext();
        }

        public ErrorMessage ThemKhachHang(KhachHang khachHang)
        {
            var khachHangCanTim= dbContext.KhachHang.FirstOrDefault(x => x.KhachHangId == khachHang.KhachHangId);
            if(khachHangCanTim == null )
            {
                dbContext.KhachHang.Add(khachHang);
                dbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ThatBai;
            }
            
        }
    }
}
