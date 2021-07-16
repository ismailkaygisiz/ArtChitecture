using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITranslateService : IServiceRepository<Translate>
    {
        IDataResult<List<Translate>> GetByKey(string key);
        IDataResult<List<Translate>> GetByLanguageId(int languageId);
    }
}
