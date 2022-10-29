namespace Lang.Client.Core;

public interface IFrequencyDataReader
{
    /// <summary>
    /// İndirilmek istenen kelime Vocabulary'de bulunmadığında, sunucudan cevaben kelimeye bir kelimenin sayfası dönüyor.
    /// Dolayısıyla indirilen sayfanın daima istediğimiz kelimeye ait oluşturulduğundan emin olamayız.
    /// </summary>
    /// <returns></returns>
    WordFrequencyResult GetFrequencyData(string htmlContent);
}