using Core.Utilities.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Business
{
    public class RequestUserManager : IRequestUserService
    {
        private RequestUser _requestUser;

        public IDataResult<RequestUser> GetUser()
        {
            return new SuccessDataResult<RequestUser>(_requestUser);
        }

        public IResult SetUser(RequestUser requestUser)
        {
            _requestUser = requestUser;
            return new SuccessResult();
        }


        public IResult CheckIfRequestUserIsNotEqualsUser(int userId)
        {
            var user = GetUser().Data;
            if (user != null)
            {

                if (user.Roles.Contains("Admin") || user.Roles.Contains("Moderatör"))
                {
                    return new SuccessResult();
                }

                if (user.Id != userId)
                {
                    return new ErrorResult(CoreMessages.AuthorizationDenied);
                }
            }


            return new SuccessResult();
        }

        public IResult CheckIfRequestUserIsNotEqualsUser(string email)
        {
            var user = GetUser().Data;
            if (user != null)
            {
                if (user.Roles.Contains("Admin") || user.Roles.Contains("Moderatör"))
                {
                    return new SuccessResult();
                }

                if (user.Email != email)
                {
                    return new ErrorResult(CoreMessages.AuthorizationDenied);
                }

            }
            return new SuccessResult();

        }
    }
}
