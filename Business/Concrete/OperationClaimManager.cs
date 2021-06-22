using System.Collections.Generic;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Add(OperationClaim entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            _operationClaimDal.Add(entity);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Delete(OperationClaim entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            var entityToDelete = GetById(entity.Id).Data;

            _operationClaimDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Update(OperationClaim entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            _operationClaimDal.Update(entity);
            return new SuccessResult();
        }

        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Id == id));
        }

        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<OperationClaim> GetByName(string operationClaimName)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Name == operationClaimName));
        }
    }
}
