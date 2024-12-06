using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WA_1_1.Entities;
using WA_1_1.Helper;
using WA_1_1.Services;

namespace WA_1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly KhachHangServices khachHangServices;

        public KhachHangController()
        {
            khachHangServices  = new KhachHangServices();   
        }

        [HttpPost("ThemKhachHang")]
        public IActionResult ThemKhachHang([FromBody] KhachHang khachHang)
        {
            var result = khachHangServices.ThemKhachHang(khachHang);
            if (result == ErrorMessage.ThanhCong)
            {
                return Ok("Them thanh cong !");
            }
            else
            {
                return BadRequest("That bai!");
            }
        }
    }
}
