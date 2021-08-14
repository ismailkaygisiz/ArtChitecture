using Core.Utilities.Results.Abstract;

namespace Core.Business
{
    public interface IRequestUserService
    {
        IResult CheckIfRequestUserIsNotEqualsUser(int id);
        IResult CheckIfRequestUserIsNotEqualsUser(string email);
        IResult SetRequestUser(RequestUser requestUser);
        IDataResult<RequestUser> GetRequestUser();
    }
}