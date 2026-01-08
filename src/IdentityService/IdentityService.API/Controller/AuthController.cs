using IdentityService.API.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            // 1. Yeni bir kullanıcı nesnesi oluştur
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            // 2. Kullanıcıyı şifresiyle birlikte veritabanına kaydet
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "Kullanıcı başarıyla oluşturuldu." });
            }

            // Hata varsa (şifre çok kısa, email zaten var vb.) hataları dön
            return BadRequest(result.Errors);
        }
    }
}
