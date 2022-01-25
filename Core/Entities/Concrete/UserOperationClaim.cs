using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    [Table("UserOperationClaims")]
    public class UserOperationClaim : IEntity
    {
        [Key]
        public int UserOperationClaimId { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}