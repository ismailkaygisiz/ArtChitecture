using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}