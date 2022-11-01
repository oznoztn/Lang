using Lang.Client.Core.FrequencyDataParsers.Abstractions;
using Lang.Client.Core.FrequencyReaders.Models;

namespace Lang.Client.Core.FrequencyReaders;

public interface IFrequencyDataReader<TParseResult> where TParseResult : IParseResult
{
    /// <summary>
    /// İndirilmek istenen kelime Vocabulary'de bulunmadığında, sunucudan cevaben kelimeye bir kelimenin sayfası dönüyor.
    /// Dolayısıyla indirilen sayfanın daima istediğimiz kelimeye ait oluşturulduğundan emin olamayız.
    /// </summary>
    /// <returns></returns>
    TParseResult GetFrequencyData(string htmlContent);
}
