using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.DTOs
{
    public class UserDetailDto : IDto
    {
        public User User { get; set; }
        public List<Group> Groups { get; set; }
        public List<OperationClaim> OperationClaims { get; set; }
    }
}
