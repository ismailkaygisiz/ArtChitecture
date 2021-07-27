using Core.Utilities.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Business
{
    public class RequestUserManager : IRequestUserService
    {
        private readonly CoreMessages _coreMessages;
        private RequestUser _requestUser;

        public RequestUserManager()
        {
            _coreMessages = new CoreMessages();
        }

        public IDataResult<RequestUser> GetUser()
        {
            if (_requestUser != null)
                return new SuccessDataResult<RequestUser>(_requestUser);

            return new SuccessDataResult<RequestUser>(new RequestUser());
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
                if (user.Id != userId)
                    return new ErrorResult(_coreMessages.AuthorizationDenied());
                return new SuccessResult();
            }

            return null;
        }

        public IResult CheckIfRequestUserIsNotEqualsUser(string email)
        {
            var user = GetUser().Data;
            if (user != null)
            {
                if (user.Email != email) return new ErrorResult(_coreMessages.AuthorizationDenied());
                return new SuccessResult();
            }

            return null;
        }
    }
}