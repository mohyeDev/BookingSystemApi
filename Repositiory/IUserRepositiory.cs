using BookingSystemApi.Model.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemApi.Repositiory
{
    public interface IUserRepositiory
    {

        public Task<User> CreateAsync(User user);
    }
}
