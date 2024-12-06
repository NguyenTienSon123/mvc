using WA_1_1.Entities;
using WA_1_1.Helper;

namespace WA_1_1.IServices
{
    public interface ILoaiSanPhamServices
    {
        ErrorMessage ThemLoaiSamPham(LoaiSanPham loaiSanPham);
        List<LoaiSanPham> GetDanhSachLoaiSanPham();
        ErrorMessage XoaLoaiSanPham(int MLSP);
    }
}
