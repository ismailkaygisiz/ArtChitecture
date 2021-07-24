using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class Language : IEntity
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
    }
}