using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    [Table("OperationClaims")]
    public class OperationClaim : IEntity
    {
        [Key]
        public int OperationClaimId { get; set; }
        public string Name { get; set; }
    }
}