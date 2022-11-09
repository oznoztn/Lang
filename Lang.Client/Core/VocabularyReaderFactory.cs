using Lang.Client.Core.Enums;
using Lang.Client.Core.FrequencyDataParsers;
using Lang.Client.Core.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lang.Client.Core;

public class VocabularyReaderFactory
{
    private readonly IHttpClientFactory _httpClientFactory;

    public VocabularyReaderFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public VocabularyParser Create(string htmlContent, string word)
    {
        return new VocabularyParser(htmlContent, word);
    }

    public async Task<VocabularyParser> Create(string word)
    {
        HttpResponseMessage r = 
            await _httpClientFactory
                .CreateClient()
                .GetAsync(UriHelper.CreatedAddress(Source.Vocabulary, word));

        string c = await r.Content.ReadAsStringAsync();

        VocabularyParser p = this.Create(c, word);

        return p;
    }
}