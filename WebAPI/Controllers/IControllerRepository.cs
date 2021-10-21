using Core.Entities.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public interface IControllerRepository<TEntity, TId> where TEntity : class, IEntity, new()
    {
        IActionResult Add(TEntity entity);
        IActionResult Delete(TEntity entity);
        IActionResult Update(TEntity entity);
        IActionResult GetById(TId id);
        IActionResult GetAll();
    }
}