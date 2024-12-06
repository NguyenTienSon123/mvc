using System.Diagnostics;
using System.Linq;
using WA_1_1.Entities;
using WA_1_1.Helper;
using WA_1_1.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WA_1_1.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        private readonly AppDbContext dbContext;

        public HoaDonServices()
        {
            dbContext = new AppDbContext();
        }

        public PageResult<HoaDon> LayHoaDon(Pagination pagination)
        {
            var dsHoaDon = dbContext.HoaDon.AsQueryable();
            var query = PageResult<HoaDon>.ToPageResult(pagination, dsHoaDon);
            return new PageResult<HoaDon>(pagination, query);
        }

        public PageResult<HoaDon> LayHoaDonTheoChuoi(string Chuoi, Pagination pagination)
        {
            var dsHoaDon = dbContext.HoaDon.OrderByDescending(x => x.ThoiGiaTao).AsQueryable();
            dsHoaDon = dsHoaDon.Where(x => x.TenHoaDon == Chuoi ||x.MaGiaoDich== Chuoi);
            var query = PageResult<HoaDon>.ToPageResult(pagination, dsHoaDon);
            return new PageResult<HoaDon>(pagination, query);
        }

        public PageResult<HoaDon> LayHoaDonTheoNamThang(int nam, int thang, Pagination pagination)
        {
            var dsHoaDon = dbContext.HoaDon.OrderByDescending(x => x.ThoiGiaTao).AsQueryable();
            dsHoaDon = dsHoaDon.Where(x => x.ThoiGiaTao.Year == nam);
            dsHoaDon = dsHoaDon.Where(x => x.ThoiGiaTao.Month == thang);
            var query = PageResult<HoaDon>.ToPageResult(pagination, dsHoaDon);
            return new PageResult<HoaDon>(pagination, query);
        }

        public PageResult<HoaDon> LayHoaDonTheoNgay(DateTime NBD, DateTime NKT, Pagination pagination)
        {
            var dsHoaDon = dbContext.HoaDon.OrderByDescending(x => x.ThoiGiaTao).AsQueryable();
            dsHoaDon = dsHoaDon.Where(x => x.ThoiGiaTao >= NBD );
            dsHoaDon = dsHoaDon.Where(x => x.ThoiGiaTao <= NKT);
            var query = PageResult<HoaDon>.ToPageResult(pagination, dsHoaDon);
            return new PageResult<HoaDon>(pagination, query);
        }

        public PageResult<HoaDon> LayHoaDonTheoTongTien(double min, double max, Pagination pagination)
        {
            var dsHoaDon = dbContext.HoaDon.OrderByDescending(x => x.ThoiGiaTao).AsQueryable();
            dsHoaDon = dsHoaDon.Where(x => x.TongTien >= min);
            dsHoaDon = dsHoaDon.Where(x => x.TongTien <= max);
            var query = PageResult<HoaDon>.ToPageResult(pagination, dsHoaDon);
            return new PageResult<HoaDon>(pagination, query);
        }

        public HoaDon SuaHoaDon(HoaDon hoaDon)
        {
            if (hoaDon.chiTietHoaDons.Count()==0)
            {
                var lstCTHDHienTai = dbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDon.HoaDonID);
                dbContext.Remove(lstCTHDHienTai);
                dbContext.SaveChanges();

            }
            else
            {
                var lstCTHDHienTai = dbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDon.HoaDonID);
                var lstCTHDelete = new List<ChiTietHoaDon>();
                foreach (var chiTiet in lstCTHDelete)
                {
                    if (hoaDon.chiTietHoaDons.Any(x => x.ChiTietHoaDonId == chiTiet.ChiTietHoaDonId))
                    {
                        lstCTHDelete.Add(chiTiet);
                    }
                    else
                    {
                        var ChiTietMoi = hoaDon.chiTietHoaDons.FirstOrDefault(x => x.ChiTietHoaDonId == chiTiet.ChiTietHoaDonId);
                        chiTiet.SanPhamId = ChiTietMoi.SanPhamId;
                        chiTiet.SoLuong = ChiTietMoi.SoLuong;
                        chiTiet.DVT = ChiTietMoi.DVT;
                        var SanPham = dbContext.SanPham.FirstOrDefault(x => x.SanPhamId == ChiTietMoi.SanPhamId);
                        chiTiet.ThanhTien = SanPham.GiaThanh * ChiTietMoi.SoLuong;
                        dbContext.Update(chiTiet);
                        dbContext.SaveChanges();
                    }
                }
                dbContext.RemoveRange(lstCTHDelete);
                dbContext.SaveChanges();
                foreach (var chiTiet in lstCTHDelete)
                {
                    if (!lstCTHDHienTai.Any(x => x.ChiTietHoaDonId == chiTiet.ChiTietHoaDonId))
                    {
                        chiTiet.HoaDonId = hoaDon.HoaDonID;
                        var SanPham = dbContext.SanPham.FirstOrDefault(x => x.SanPhamId == chiTiet.SanPhamId);
                        chiTiet.ThanhTien = SanPham.GiaThanh * chiTiet.SoLuong;
                        dbContext.Add(chiTiet);
                        dbContext.SaveChanges();
                    }
                }
            }
            var TongTien = dbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDon.HoaDonID).Sum(x => x.ThanhTien);
            hoaDon.TongTien = TongTien;
            hoaDon.ThoiGiaGiaoCapNhat = DateTime.Now;
            hoaDon.chiTietHoaDons = null;
            dbContext.Update(hoaDon);
            dbContext.SaveChanges();
            return hoaDon;
        }

        public ErrorMessage ThemHoaDon(HoaDon hoaDon)
        {
            hoaDon.ThoiGiaTao = DateTime.Now;
            //var res = DateTime.Now.ToString("yyyymmdd") + "_";
            //var countSoGiaoDich = dbContext.HoaDon.Count(x => x.ThoiGiaTao == hoaDon.ThoiGiaTao);
            //if (countSoGiaoDich > 0)
            //{
            //    int tmp = countSoGiaoDich + 1;
            //    if (tmp < 10) res = res + "00" + tmp.ToString();
            //    else if (tmp < 1000) res = res + "0" + tmp.ToString();
            //    else res = res + tmp.ToString();
            //}
            //else
            //{
            //    res = res + "001";
            //}
            hoaDon.MaGiaoDich = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_00" + hoaDon.HoaDonID.ToString(); ;
            var lstChiTietHoaDon = hoaDon.chiTietHoaDons;
            hoaDon.chiTietHoaDons = null;
            dbContext.HoaDon.Add(hoaDon);
            dbContext.SaveChanges();
            foreach (var chiTiet in lstChiTietHoaDon)
            {
                if (dbContext.SanPham.Any(x => x.SanPhamId == chiTiet.SanPhamId))
                {
                    chiTiet.HoaDonId = hoaDon.HoaDonID;
                    var sanPhamCanTim = dbContext.SanPham.FirstOrDefault(x => x.SanPhamId == chiTiet.SanPhamId);
                    chiTiet.ThanhTien = chiTiet.SoLuong * sanPhamCanTim.GiaThanh;
                    dbContext.ChiTietHoaDon.Add(chiTiet);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("San pham chua ton tai!");
                }
            }
            hoaDon.TongTien = lstChiTietHoaDon.Sum(x => x.ThanhTien);
            dbContext.HoaDon.Update(hoaDon);
            dbContext.SaveChanges();
            return ErrorMessage.ThanhCong;
            //var hoaDonCanTim = dbContext.HoaDon.FirstOrDefault(x => x.HoaDonID == hoaDon.HoaDonID);
            //if (hoaDonCanTim != null)
            //{
            //    return ErrorMessage.HoaDonDaTonTai;
            //}
            //else
            //{
            //    hoaDon.TongTien = 0;
            //    hoaDon.MaGiaoDich = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_00" + hoaDon.HoaDonID.ToString();
            //    hoaDon.ThoiGiaTao = DateTime.Today;
            //    dbContext.HoaDon.Add(hoaDon);
            //    dbContext.SaveChanges();
            //    var listchiTietHoaDons = hoaDon.chiTietHoaDons;
            //    var countSoGiaoDich = dbContext.HoaDon.Count(x => x.ThoiGiaTao == hoaDon.ThoiGiaTao);
            //    foreach (var chiTiet in listchiTietHoaDons)
            //    {
            //        chiTiet.HoaDonId = hoaDon.HoaDonID;
            //        var SanPhamCanTim = dbContext.SanPham.FirstOrDefault(x => x.SanPhamId == chiTiet.SanPhamId);
            //        if (SanPhamCanTim != null)
            //        {
            //            chiTiet.ThanhTien = chiTiet.SoLuong * SanPhamCanTim.GiaThanh;
            //            dbContext.ChiTietHoaDon.Add(chiTiet);
            //            dbContext.SaveChanges();
            //        }
            //        else
            //        {
            //            return ErrorMessage.SanPhamChuaTonTai;
            //        }
            //    }
            //    hoaDon.TongTien = listchiTietHoaDons.Sum(x => x.ThanhTien);
            //    dbContext.HoaDon.Update(hoaDon);
            //    dbContext.SaveChanges();
            //    return ErrorMessage.ThanhCong;
            //}
        }

        public ErrorMessage XoaHoaDon(int MaHoaDon)
        {
            var HoaDonCanTim = dbContext.HoaDon.FirstOrDefault(x => x.HoaDonID == MaHoaDon);
            if (HoaDonCanTim == null)
            {
                return ErrorMessage.HoaDonChuaTonTai;
            }
            else
            {
                List<ChiTietHoaDon> chiTietHoaDons = dbContext.ChiTietHoaDon.AsQueryable().ToList();
                List<ChiTietHoaDon> chiTietHoaDonCanXoa = chiTietHoaDons.FindAll(x => x.HoaDonId == MaHoaDon);
                foreach (var chiTiet in chiTietHoaDonCanXoa)
                {
                    dbContext.ChiTietHoaDon.Remove(chiTiet);
                    dbContext.SaveChanges();
                }
                dbContext.HoaDon.Remove(HoaDonCanTim);
                dbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
        }

       
    }
}
