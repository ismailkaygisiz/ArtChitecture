using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILanguageService : IServiceRepository<Language>
    {
        IDataResult<Language> GetByName(string name);
        IDataResult<Language> GetByCode(string code);
    }
}
