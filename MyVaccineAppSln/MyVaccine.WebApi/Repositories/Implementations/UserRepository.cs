using Microsoft.AspNetCore.Identity;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using System.Transactions;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class userRepository : BaseRepository<User>, IUserRepository
    {
        private readonly MyVaccineAppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public userRepository(MyVaccineAppDbContext context, UserManager<IdentityUser> userManager): base(context) 
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUser(RegisterRequestDto request)
        {
            var response = new IdentityResult();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var user = new ApplicationUser
                {
                    UserName = request.Username.ToLower(),
                    Email = request.Username
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                response = result;
                if (!result.Succeeded)
                {
                    return response;
                }
                var newUser = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    AspNetUserId = user.Id
                };
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                scope.Complete();
            }
            return response;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        //var user = new ApplicationUser
        //{
        //    UserName = request.Email.ToLower(),
        //   Email = request.Email
        //};

        //var result = await _userManager.CreateAsync(user, model.Password);
        //return null;

    }
}
