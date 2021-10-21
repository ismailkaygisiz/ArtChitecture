using System.Collections.Generic;
using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;

namespace Core.Business
{
    public interface IServiceRepository<TEntity, TId> where TEntity : class, IEntity, new()
    {
        IResult Add(TEntity entity);
        IResult Delete(TEntity entity);
        IResult Update(TEntity entity);
        IDataResult<TEntity> GetById(TId id);
        IDataResult<List<TEntity>> GetAll();
    }
}