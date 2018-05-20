using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UzywaneKsiazki.Models.DTO;
using UzywaneKsiazki.Models.Services;

namespace UzywaneKsiazki.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] AuthDTO registerDTO)
        {
            try
            {
                await _authService.RegisterUserAsync(registerDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] AuthDTO loginDTO)
        {
            try
            {
                var jwt = await _authService.LoginUserAsync(loginDTO);
                return Ok(jwt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}