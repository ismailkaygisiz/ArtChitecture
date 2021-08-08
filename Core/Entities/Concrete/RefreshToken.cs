using Core.Entities.Abstract;
using System;

namespace Core.Entities.Concrete
{
    public class RefreshToken : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ClientName { get; set; }
        public string RefreshTokenValue { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public virtual User User { get; set; }
    }
}
