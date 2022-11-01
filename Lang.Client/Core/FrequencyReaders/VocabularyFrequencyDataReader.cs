using HtmlAgilityPack;
using Lang.Client.Core.FrequencyDataParsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using static Lang.Client.Core.FrequencyDataParsers.Models.VocabularyFreqResult;

namespace Lang.Client.Core.FrequencyReaders
{
    public class VocabularyFrequencyDataReader : IFrequencyDataReader<VocabularyFreqResult>
    {
        private readonly string _word;
        private readonly HtmlNode _documentNode;

        public VocabularyFrequencyDataReader(string htmlContent, string word)
        {
            _word = word;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            _documentNode = doc.DocumentNode;
        }

        public VocabularyFreqResult GetFrequencyData(string htmlContent)
        {
            var def = VocabularyFreqResult.CreateDefault();

            try
            {
                // <vcom:wordfamily lang="en" word="yes" data="[{&#034;word&#034...,&#034;type&#034;:1}]"></vcom:wordfamily>
                var vcom = _documentNode.Descendants("vcom:wordfamily").FirstOrDefault();
                if (vcom == null)
                    return def;

                var word = vcom.GetAttributeValue("word", null);
                if (word != _word)
                    return def;

                string freqJson = vcom.GetAttributeValue("data", null);
                if (freqJson == _word)
                    return def;

                freqJson = HttpUtility.HtmlDecode(freqJson);
                List<VocabularyFreqEntry>? entries = JsonSerializer.Deserialize<List<VocabularyFreqEntry>>(freqJson);
                VocabularyFreqEntry? entry = entries?.First(t => string.Equals(t.Word, _word, StringComparison.InvariantCultureIgnoreCase));

                return new VocabularyFreqResult()
                {
                    HasData = true,
                    Entries = entries,
                    Entry = entry
                };
            }
            catch (Exception e)
            {
                // ignored
            }

            return def;
        }
    }
}
