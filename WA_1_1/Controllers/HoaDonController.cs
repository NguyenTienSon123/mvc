using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WA_1_1.Entities;
using WA_1_1.Services;

namespace WA_1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly HoaDonServices hoaDonServices;
        public HoaDonController()
        {
            hoaDonServices = new HoaDonServices();
        }
        [HttpPost("ThemHoaDon")]
        public IActionResult ThemHoaDon([FromBody] HoaDon hoaDon)
        {
            var result = hoaDonServices.ThemHoaDon(hoaDon);
            if(result == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Them thanh cong");
            }
            else
            {
                return BadRequest("That bai");
            }
        }
        [HttpPut]
        public IActionResult SuaHoaDon(HoaDon hoaDon)
        {
            var res = hoaDonServices.SuaHoaDon(hoaDon);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult XoaHoaDon([FromBody] int MaHoaDon)
        {
            var result = hoaDonServices.XoaHoaDon(MaHoaDon);
            if (result == Helper.ErrorMessage.ThanhCong)
            {
                return Ok("Xoa thanh cong");
            }
            else
            {
                return BadRequest("That bai");
            }
        }
        [HttpGet]
        public IActionResult LayHoaDon([FromQuery] Pagination pagination)
        {
            var ret = hoaDonServices.LayHoaDon(pagination);
            return Ok(ret);
        }
        [HttpGet("LayHoaDonTheoNamThang")]
        public IActionResult LayHoaDonTheoNamThang( int nam, int thang, [FromQuery] Pagination pagination)
        {
            var ret = hoaDonServices.LayHoaDonTheoNamThang(nam, thang, pagination);
            return Ok(ret);
        }
        [HttpGet("LayHoaDonTheoNgay")]
        public IActionResult LayHoaDonTheoNgay(DateTime NBD, DateTime NKT, [FromQuery] Pagination pagination)
        {
            var ret = hoaDonServices.LayHoaDonTheoNgay(NBD, NKT, pagination);
            return Ok(ret);
        }
        [HttpGet("LayHoaDonTheoTongTien")]
        public IActionResult LayHoaDonTheoTongTien(double TienMin, double TienMax, [FromQuery] Pagination pagination)
        {
            var ret = hoaDonServices.LayHoaDonTheoTongTien(TienMin, TienMax, pagination);
            return Ok(ret);
        }
        [HttpGet("LayHoaDonTheoChuoi")]
        public IActionResult LayHoaDonTheoChuoi(string tenhoadon, [FromQuery] Pagination pagination)
        {
            var ret = hoaDonServices.LayHoaDonTheoChuoi(tenhoadon,pagination);
            return Ok(ret);
        }
    }
}
