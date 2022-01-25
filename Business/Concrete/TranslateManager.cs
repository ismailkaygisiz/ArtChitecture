using Business.Abstract;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Logging;
using Core.Business;
using Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TranslateManager : BusinessService, ITranslateService
    {
        private readonly ILanguageService _languageService;
        private readonly ITranslateDal _translateDal;

        public TranslateManager(ITranslateDal translateDal, ILanguageService languageService)
        {
            _translateDal = translateDal;
            _languageService = languageService;
        }

        [SecuredOperation("Admin")]
        [LogAspect(typeof(MsSqlLogger))]
        public IResult Add(Translate entity)
        {
            var result = BusinessRules.Run();

            if (!result.Success) return result;

            _translateDal.Add(entity);
            return new SuccessResult();
        }

        [SecuredOperation("Admin")]
        [LogAspect(typeof(MsSqlLogger))]
        public IResult Delete(DeleteModel entity)
        {
            var result = BusinessRules.Run();

            if (!result.Success) return result;

            var entityToDelete = GetById((int)entity.ID).Data;
            _translateDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        [SecuredOperation("Admin")]
        [LogAspect(typeof(MsSqlLogger))]
        public IResult Update(Translate entity)
        {
            var result = BusinessRules.Run();

            if (!result.Success) return result;

            _translateDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Translate>> GetAll()
        {
            return new SuccessDataResult<List<Translate>>(_translateDal.GetAll());
        }

        public IDataResult<Translate> GetById(int id)
        {
            return new SuccessDataResult<Translate>(_translateDal.Get(t => t.TranslateId == id));
        }

        public IDataResult<List<Translate>> GetByKey(string key)
        {
            return new SuccessDataResult<List<Translate>>(_translateDal.GetAll(t => t.Key == key));
        }

        public IDataResult<List<Translate>> GetByLanguageId(int languageId)
        {
            return new SuccessDataResult<List<Translate>>(_translateDal.GetAll(t => t.LanguageId == languageId));
        }

        public IDataResult<Dictionary<string, string>> GetTranslates(string languageCode)
        {
            var dictionary = new Dictionary<string, string>();
            var language = _languageService.GetByCode(languageCode).Data;
            if (language != null)
                GetByLanguageId(language.LanguageId).Data.ForEach(t => { dictionary.Add(t.Key, t.Value); });
            else
                GetByLanguageId(_languageService.GetByCode("en-Us").Data.LanguageId).Data
                    .ForEach(t => { dictionary.Add(t.Key, t.Value); });

            return new SuccessDataResult<Dictionary<string, string>>(dictionary);
        }
    }
}