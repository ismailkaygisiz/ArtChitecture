using Core.Entities.Concrete;

namespace Business.Helpers
{
    public interface IRefreshTokenHelper
    {
        bool UseRefreshTokenEndDate { get; set; }
        string CreateRefreshToken();
        RefreshToken CreateNewRefreshToken(User user, string tokenValue);
        RefreshToken UpdateOldRefreshToken(string tokenValue);
        void CreateDifferentRefreshToken(RefreshToken refreshToken);
        bool Control(params string[] args);
    }
}
