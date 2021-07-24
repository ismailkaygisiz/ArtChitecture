namespace Core.API
{
    public interface IControllerRepository<TEntity, TResult>
    {
        TResult Add(TEntity entity);
        TResult Delete(TEntity entity);
        TResult Update(TEntity entity);
        TResult GetById(int id);
        TResult GetAll();
    }
}