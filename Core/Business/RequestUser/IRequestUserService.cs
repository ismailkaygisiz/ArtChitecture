using Core.Utilities.Results.Abstract;

namespace Core.Business
{
    public interface IRequestUserService
    {
        RequestUser RequestUser { get; set; }
        IResult CheckIfRequestUserIsNotEqualsUser(int id);
        IResult CheckIfRequestUserIsNotEqualsUser(string email);
    }
}