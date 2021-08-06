using Core.Utilities.Constants;
using Core.Utilities.IoC;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Business
{
    public class RequestUserManager : IRequestUserService
    {
        private CoreMessages CoreMessages { get; }
        public RequestUser RequestUser
        {
            get
            {
                if (RequestUser != null)
                {
                    return RequestUser;
                }

                return new RequestUser();
            }
            set { }
        }

        public RequestUserManager(CoreMessages coreMessages)
        {
            CoreMessages = coreMessages;
        }

        public IResult CheckIfRequestUserIsNotEqualsUser(int userId)
        {
            if (RequestUser != null)
            {
                if (RequestUser.Id != userId)
                    return new ErrorResult(CoreMessages.AuthorizationDenied());
                return new SuccessResult();
            }

            return null;
        }

        public IResult CheckIfRequestUserIsNotEqualsUser(string email)
        {
            if (RequestUser != null)
            {
                if (RequestUser.Email != email) return new ErrorResult(CoreMessages.AuthorizationDenied());
                return new SuccessResult();
            }

            return null;
        }
    }
}