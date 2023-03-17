using GameCatalogue.App_Db_Context;
using GameCatalogue.Model;
using GameCatalogue.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalogue.Controllers
{
    public class UserController : Controller
    {

        private readonly AppDbContext _DbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICurrentUserService _service;
        public UserController(AppDbContext testDBContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ICurrentUserService service)
        {
            _DbContext = testDBContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _service = service;
        }


        [HttpPut("Update Username")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult UpdateUsername(string new_name)
        {
            try
            {
                var user_id = _service.GetUserId();
                var testData = _DbContext.Users.Single(x => x.Id == user_id);

                testData.UserName = new_name;

                _DbContext.Users.Update(testData);
                _DbContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                ModelState.AddModelError("Id", "There is no user with the given properties");
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPut("Update Userfirst")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult UpdateFirstName(string new_name)
        {
            try
            {
                var user_id = _service.GetUserId();
                var testData = _DbContext.Users.Single(x => x.Id == user_id);

                testData.FirstName = new_name;

                _DbContext.Users.Update(testData);
                _DbContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                ModelState.AddModelError("Id", "There is no user with the given properties");
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPut("Update Secondname")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult UpdateSecondName(string new_name)
        {
            try
            {
                var user_id = _service.GetUserId();
                var testData = _DbContext.Users.Single(x => x.Id == user_id);

                testData.SecondName = new_name;

                _DbContext.Users.Update(testData);
                _DbContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                ModelState.AddModelError("Id", "There is no user with the given properties");
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPut("Update LastName")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult UpdateLastNamee(string new_name)
        {
            try
            {
                var user_id = _service.GetUserId();
                var testData = _DbContext.Users.Single(x => x.Id == user_id);

                testData.LastName = new_name;

                _DbContext.Users.Update(testData);
                _DbContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                ModelState.AddModelError("Id", "There is no user with the given properties");
                return BadRequest(ModelState);
            }
            return Ok();
        }


        [HttpPut("Update Password")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdatePassword(string new_pass)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    ModelState.AddModelError("Id", "There is no user with the given properties");
                    return BadRequest(ModelState);
                }

                var result = await _userManager.ChangePasswordAsync(user, user.PasswordHash, new_pass);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("Password", "Failed to change password");
                    return BadRequest(ModelState);
                }

                return Ok();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while updating password");
                return BadRequest(ModelState);
            }
        }
    }
}
