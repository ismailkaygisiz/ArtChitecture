using Core.Utilities.Constants;
using Core.Utilities.IoC;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Business
{
    public class RequestUserManager : IRequestUserService
    {
        private readonly CoreMessages _coreMessages;
        private RequestUser _requestUser;

        public RequestUserManager()
        {
            _coreMessages = ServiceTool.ServiceProvider.GetService<CoreMessages>();
        }

        public IResult SetRequestUser(RequestUser requestUser)
        {
            if (requestUser == null)
            {
                _requestUser = new RequestUser();
                return new SuccessResult();
            }

            _requestUser = requestUser;
            return new SuccessResult();
        }


        public IDataResult<RequestUser> GetRequestUser()
        {
            if (_requestUser == null)
                return new SuccessDataResult<RequestUser>(new RequestUser());


            return new SuccessDataResult<RequestUser>(_requestUser);
        }

        public IResult CheckIfRequestUserIsNotEqualsUser(int userId)
        {
            if (_requestUser != null)
            {
                if (_requestUser.Id != userId)
                    return new ErrorResult(_coreMessages.AuthorizationDenied());
                return new SuccessResult();
            }

            return null;
        }

        public IResult CheckIfRequestUserIsNotEqualsUser(string email)
        {
            if (_requestUser != null)
            {
                if (_requestUser.Email != email) return new ErrorResult(_coreMessages.AuthorizationDenied());
                return new SuccessResult();
            }

            return null;
        }
    }
}