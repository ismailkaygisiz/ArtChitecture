using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class GroupUser : IEntity
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}