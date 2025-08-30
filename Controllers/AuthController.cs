using BookingSystemApi.Data;
using BookingSystemApi.Model.Domain;
using BookingSystemApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BookingSystemApiDbContext dbContext;

        public AuthController(BookingSystemApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] User user)
        {
            var domainUser = new User
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = PasswordHelper.HashPassword(user.Password),
                Roles = await dbContext.Roles.FirstOrDefaultAsync(x => x.Name == "Admin")
            };

            await dbContext.Users.AddAsync(domainUser);
            await dbContext.SaveChangesAsync();

            return Ok(domainUser);
        }
    }
}
