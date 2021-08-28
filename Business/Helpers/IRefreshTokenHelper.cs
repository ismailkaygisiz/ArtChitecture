using Core.Entities.Concrete;

namespace Business.Helpers
{
    public interface IRefreshTokenHelper
    {
        bool UseRefreshTokenEndDate { get; set; }
        string CreateRefreshToken();
        RefreshToken CreateNewRefreshToken(User user);
        RefreshToken UpdateOldRefreshToken();
        void CreateDifferentRefreshToken(RefreshToken refreshToken);
        bool Control(params string[] args);
    }
}
