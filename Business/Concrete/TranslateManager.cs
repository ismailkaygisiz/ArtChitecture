using Business.Abstract;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TranslateManager : ITranslateService
    {
        private readonly ITranslateDal _translateDal;

        public TranslateManager(ITranslateDal translateDal)
        {
            _translateDal = translateDal;
        }

        public IResult Add(Translate entity)
        {
            var result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _translateDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Translate entity)
        {
            var result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _translateDal.Delete(entity);
            return new SuccessResult();
        }
        public IResult Update(Translate entity)
        {
            var result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _translateDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Translate>> GetAll()
        {
            return new SuccessDataResult<List<Translate>>(_translateDal.GetAll());
        }

        public IDataResult<Translate> GetById(int id)
        {
            return new SuccessDataResult<Translate>(_translateDal.Get(t => t.Id == id));
        }

        public IDataResult<List<Translate>> GetByKey(string key)
        {
            return new SuccessDataResult<List<Translate>>(_translateDal.GetAll(t => t.Key == key));
        }

        public IDataResult<List<Translate>> GetByLanguageId(int languageId)
        {
            return new SuccessDataResult<List<Translate>>(_translateDal.GetAll(t => t.LanguageId == languageId));
        }
    }
}
