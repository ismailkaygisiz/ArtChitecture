using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Core.Business
{
    public interface IServiceRepository<T> where T : class, IEntity, new()
    {
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
        IDataResult<T> GetById(int id);
        IDataResult<List<T>> GetAll();
    }
}