using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    [Table("RefreshTokens")]
    public class RefreshToken : IEntity
    {
        [Key]
        public int RefreshTokenId { get; set; }
        public int UserId { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string TokenValue { get; set; }
        public string RefreshTokenValue { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}