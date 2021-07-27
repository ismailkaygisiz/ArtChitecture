using System.Collections.Generic;

namespace Core.Business.Translate
{
    public interface ITranslateContext
    {
        Dictionary<string, string> Translates { get; set; }
    }
}