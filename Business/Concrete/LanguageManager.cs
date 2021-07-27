using System.Collections.Generic;
using Business.Abstract;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class LanguageManager : BusinessService, ILanguageService
    {
        private readonly ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public IResult Add(Language entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            _languageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Language entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            var entityToDelete = GetById(entity.Id).Data;

            _languageDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IResult Update(Language entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            _languageDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll());
        }

        public IDataResult<Language> GetById(int id)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(l => l.Id == id));
        }

        public IDataResult<Language> GetByName(string name)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(l => l.LanguageName == name));
        }

        public IDataResult<Language> GetByCode(string code)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(l => l.LanguageCode == code));
        }
    }
}