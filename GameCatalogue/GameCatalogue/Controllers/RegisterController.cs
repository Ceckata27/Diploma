using GameCatalogue.App_Db_Context;
using GameCatalogue.Model;
using GameCatalogue.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using System.Security.Cryptography;

namespace GameCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AppDbContext _DbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICurrentUserService _service;

        public RegisterController(AppDbContext testDBContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ICurrentUserService service)
        {
            _DbContext = testDBContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _service = service;
        }


        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> CreateUser(CreateUserModel input)
        {
            var newUser = new User(input.Username);
            newUser.FirstName = input.FirstName;
            newUser.SecondName = input.SecondName;
            newUser.LastName = input.LastName;
            newUser.create_at = DateTime.Now;

            var tmp1 = await _userManager.CreateAsync(newUser, input.Password);
            return Ok();
        }
    }
}
