using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    [Table("Translates")]
    public class Translate : IEntity
    {
        [Key]
        public int TranslateId { get; set; }
        public int LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}