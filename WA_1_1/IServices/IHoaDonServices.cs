using WA_1_1.Entities;
using WA_1_1.Helper;

namespace WA_1_1.IServices
{
    public interface IHoaDonServices
    {
        ErrorMessage ThemHoaDon(HoaDon hoaDon);
        HoaDon SuaHoaDon(HoaDon hoaDon);
        ErrorMessage XoaHoaDon(int MaHoaDon);
        PageResult<HoaDon> LayHoaDon(Pagination pagination);
        PageResult<HoaDon> LayHoaDonTheoNamThang(int nam, int thang, Pagination pagination);
        PageResult<HoaDon> LayHoaDonTheoNgay(DateTime NBD, DateTime NKT, Pagination pagination);
        PageResult<HoaDon> LayHoaDonTheoTongTien(double min, double max, Pagination pagination);
        PageResult<HoaDon> LayHoaDonTheoChuoi(string Chuoi, Pagination pagination);
    }
}
