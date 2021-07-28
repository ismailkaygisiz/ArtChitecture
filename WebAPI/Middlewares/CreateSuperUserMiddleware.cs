using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    public class CreateSuperUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public CreateSuperUserMiddleware(RequestDelegate next, IUserService userService, IUserOperationClaimService userOperationClaimService)
        {
            _next = next;
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash("Admin@123", out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = "admin@admin.com",
                FirstName = "Admin",
                LastName = "System Secure Admin",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            var newUser = _userService.AddWithId(user);
            if (newUser.Success)
            {
                _userOperationClaimService.AddForSuperUser(new UserOperationClaim()
                {
                    OperationClaimId = 1,
                    UserId = newUser.Data.Id
                });
            }

            await _next.Invoke(context);
        }
    }
}
