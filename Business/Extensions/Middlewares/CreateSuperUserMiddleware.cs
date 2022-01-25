using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Microsoft.AspNetCore.Http;

namespace Business.Extensions.Middlewares
{
    public class CreateSuperUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;

        public CreateSuperUserMiddleware(RequestDelegate next, IUserService userService,
            IUserOperationClaimService userOperationClaimService)
        {
            _next = next;
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            HashingHelper.CreatePasswordHash("Admin@123", out var passwordHash, out var passwordSalt);

            var user = new User
            {
                Email = "admin@admin.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            var newUser = _userService.AddWithId(user);
            if (newUser.Success)
                _userOperationClaimService.AddForSuperUser(new UserOperationClaim
                {
                    OperationClaimId = 1,
                    UserId = newUser.Data.UserId
                });

            await _next.Invoke(context);
        }
    }
}