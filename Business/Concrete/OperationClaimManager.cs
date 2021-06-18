using System.Collections.Generic;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Authorization;
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
        private IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Add(OperationClaim entity)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _operationClaimDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(OperationClaim entity)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            var entityToDelete = GetById(entity.Id).Data;

            _operationClaimDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Update(OperationClaim entity)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _operationClaimDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Id == id));
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        public IDataResult<OperationClaim> GetByName(string operationClaimName)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Name == operationClaimName));
        }
    }
}
