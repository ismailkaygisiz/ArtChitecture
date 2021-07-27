using System.Collections.Generic;

namespace Core.Business.Translate
{
    public class TranslateContext : ITranslateContext
    {
        public Dictionary<string, string> Translates { get; set; } = new Dictionary<string, string>();
    }
}