using System.Collections.Generic;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Core.Entities.DTOs
{
    public class UserDetailDto : IDto
    {
        public User User { get; set; }
        public List<Group> Groups { get; set; }
        public List<OperationClaim> OperationClaims { get; set; }
    }
}