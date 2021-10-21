using System.Collections.Generic;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface ITranslateService : IServiceRepository<Translate, int>
    {
        IDataResult<List<Translate>> GetByKey(string key);
        IDataResult<List<Translate>> GetByLanguageId(int languageId);
        IDataResult<Dictionary<string, string>> GetTranslates(string languageCode);
    }
}