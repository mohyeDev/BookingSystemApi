using BookingSystemApi.Data;
using BookingSystemApi.Model.Domain;
using BookingSystemApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemApi.Repositiory
{
    public class UserRepositiory : IUserRepositiory
    {
        private readonly BookingSystemApiDbContext dbContext;

        public UserRepositiory(BookingSystemApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            var User = new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = PasswordHelper.HashPassword(user.Password)
            };

            await dbContext.Users.AddAsync(User);

            return User;
        }
    }
}
