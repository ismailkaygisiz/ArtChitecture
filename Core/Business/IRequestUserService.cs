using Core.Utilities.Results.Abstract;

namespace Core.Business
{
    public interface IRequestUserService
    {
        IDataResult<RequestUser> GetUser();
        IResult SetUser(RequestUser requestUser);

        IResult CheckIfRequestUserIsNotEqualsUser(int id);
        IResult CheckIfRequestUserIsNotEqualsUser(string email);
    }
}
