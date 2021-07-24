using System.Collections.Generic;
using Business.Abstract;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class GroupManager : IGroupService
    {
        private readonly IGroupDal _groupDal;

        public GroupManager(IGroupDal groupDal)
        {
            _groupDal = groupDal;
        }

        public IResult Add(Group entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            _groupDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Group entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            _groupDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Group>> GetAll()
        {
            return new SuccessDataResult<List<Group>>(_groupDal.GetAll());
        }

        public IDataResult<Group> GetById(int id)
        {
            return new SuccessDataResult<Group>(_groupDal.Get(g => g.Id == id));
        }

        public IResult Update(Group entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            _groupDal.Update(entity);
            return new SuccessResult();
        }
    }
}