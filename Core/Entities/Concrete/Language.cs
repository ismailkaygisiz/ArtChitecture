using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    [Table("Languages")]
    public class Language : IEntity
    {
        [Key]
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
    }
}