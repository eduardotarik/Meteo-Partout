using MeteoPartout.Data.Entities;
using MeteoPartout.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeteoPartout.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("eduardo@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Eduardo",
                    LastName = "Fernandes",
                    Email = "eduardo@gmail.com",
                    UserName = "eduardo@gmail.com",
                    PhoneNumber = "214583634"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("The user could not be created in seeder");
                }
            }
        }
    }
}
