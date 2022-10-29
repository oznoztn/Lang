using System.Net.Http;

namespace Lang.Client.Core;

public class VocabularyReaderFactory
{
    private readonly IHttpClientFactory _httpClientFactory;

    public VocabularyReaderFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public VocabularyReader Create(string htmlContent, string word)
    {
        return new VocabularyReader(htmlContent, word);
    }

    public VocabularyReader Create(string word)
    {
        var httpClient = _httpClientFactory.CreateClient();

        this.Create("content", word);

        return null;
    }
}