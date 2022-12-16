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

        [HttpPut("Update Email")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult UpdateEmail(string email)
        {
            try
            {
                var user_id = _service.GetUserId();
                var testData = _DbContext.Users.Single(x => x.Id == user_id);

                testData.Email = email;

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
    }
}
