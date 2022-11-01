using System.Net.Http;
using Lang.Client.Core.FrequencyReaders;

namespace Lang.Client.Core;

public class VocabularyReaderFactory
{
    private readonly IHttpClientFactory _httpClientFactory;

    public VocabularyReaderFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public VocabularyFrequencyDataReader Create(string htmlContent, string word)
    {
        return new VocabularyFrequencyDataReader(htmlContent, word);
    }

    public VocabularyFrequencyDataReader Create(string word)
    {
        var httpClient = _httpClientFactory.CreateClient();

        this.Create("content", word);

        return null;
    }
}