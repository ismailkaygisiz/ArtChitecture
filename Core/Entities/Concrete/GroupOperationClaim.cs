using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class GroupOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
