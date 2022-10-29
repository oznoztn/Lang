using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace Lang.Client.Core
{
    public class VocabularyReader : IFrequencyDataReader
    {
        private readonly string _word;
        private readonly HtmlNode _documentNOde;

        public VocabularyReader(string htmlContent, string word)
        {
            _word = word;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            _documentNOde = doc.DocumentNode;
        }
        
        public WordFrequencyResult GetFrequency()
        {
            var data = ((IFrequencyDataReader)this).GetFrequencyData(_documentNOde.OuterHtml);
            return data;
        }

        WordFrequencyResult IFrequencyDataReader.GetFrequencyData(string htmlContent)
        {
            try
            {
                // <vcom:wordfamily lang="en" word="yes" data="[{&#034;word&#034...,&#034;type&#034;:1}]"></vcom:wordfamily>
                var vcom = _documentNOde.Descendants("vcom:wordfamily").FirstOrDefault();

                if (vcom == null)
                    return WordFrequencyResult.CreateDefault();

                var word = vcom.GetAttributeValue("word", null);
                if (word != _word)
                    return WordFrequencyResult.CreateDefault();

                string freqJson = vcom.GetAttributeValue("data", null);
                if (freqJson == _word)
                    return WordFrequencyResult.CreateDefault();

                freqJson = HttpUtility.HtmlDecode(freqJson);
                var entries = JsonSerializer.Deserialize<List<VocabularyFreqEntry>>(freqJson);
                VocabularyFreqEntry? entry = entries?.First(t => t.word == _word);

                if (entry == null)
                    return WordFrequencyResult.CreateDefault();

                return new WordFrequencyResult()
                {
                    HasFrequencyData = true,
                    Content = JsonSerializer.Serialize(entry)
                };
            }
            catch (Exception e)
            {
                // ignored
            }

            return WordFrequencyResult.CreateDefault();
        }
    }
}
