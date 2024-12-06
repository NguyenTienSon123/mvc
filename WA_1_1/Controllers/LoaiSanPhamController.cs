using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WA_1_1.Entities;
using WA_1_1.IServices;
using WA_1_1.Services;
using WA_1_1.Helper;

namespace WA_1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        private readonly LoaiSanPhamServices loaiSanPhamServices;

        public LoaiSanPhamController()
        {
            loaiSanPhamServices = new LoaiSanPhamServices();
        }
        [HttpGet]
        public IActionResult GetLoaiSanPham()
        {
            var result = loaiSanPhamServices.GetDanhSachLoaiSanPham();
            return Ok(result);
        }
        [HttpPost("Themloaisanpham")]
        public IActionResult ThemLoaiSanPham([FromBody] LoaiSanPham loaiSanPham)
        {
          
            var result = loaiSanPhamServices.ThemLoaiSamPham(loaiSanPham);
            if (result == ErrorMessage.ThanhCong)
            {
                return Ok("Them thanhh cong");
            }
            else
            {
                return BadRequest("That bai");
            }
        }
        [HttpDelete("id")]
        public IActionResult XoaLoaiSanPham([FromQuery] int MLSP)
        {
            var result = loaiSanPhamServices.XoaLoaiSanPham(MLSP);
            if(result == ErrorMessage.ThanhCong)
            {
                return Ok("Thanh cong");
            }
            else
            {
                return BadRequest("That Bai");
            }
        }
    }
}
