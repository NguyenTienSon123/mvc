using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WA_1_1.Entities;
using WA_1_1.Helper;
using WA_1_1.Services;

namespace WA_1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhanController : ControllerBase
    {
        private readonly SanPhamServices sanPhamServices;

        public SanPhanController()
        {
            sanPhamServices = new SanPhamServices();
        }
        [HttpPost]
        public IActionResult ThemSanPham([FromBody] SanPham sanPham)
        {
            var result = sanPhamServices.ThemSanPham(sanPham);
            if (result == ErrorMessage.ThanhCong)
            {
                return Ok("Them thanh cong san pham");
            }
            else
            {
                return BadRequest("Them That bai");
            }
        }
    }
}
