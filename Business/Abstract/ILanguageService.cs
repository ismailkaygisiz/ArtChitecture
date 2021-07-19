using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface ILanguageService : IServiceRepository<Language>
    {
        IDataResult<Language> GetByName(string name);
        IDataResult<Language> GetByCode(string code);
    }
}
