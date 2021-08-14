using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Core.Entities.DTOs
{
    public class UserOperationClaimDetailDto : IDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OperationClaim> Claims { get; set; }
    }
}