using System.Collections.Generic;
using System.Text.Json.Serialization;
using Lang.Client.Core.FrequencyDataParsers.Abstractions;

namespace Lang.Client.Core.FrequencyDataParsers.Models;

/// <summary>
/// Represent frequency result of given word from vocabulary.com
/// </summary>
public class VocabularyFreqResult : IParseResult
{
    public VocabularyFreqResult()
    {
        Entries = new List<VocabularyFreqEntry>();
    }

    public static VocabularyFreqResult CreateDefault()
    {
        return new VocabularyFreqResult()
        {
            HasData = false
        };
    }

    public VocabularyFreqEntry? Entry { get; init; }
    public List<VocabularyFreqEntry>? Entries { get; set; }

    public class VocabularyFreqEntry
    {
        [JsonPropertyName("word")]
        public string Word { get; set; } = "";

        [JsonPropertyName("freq")]
        public double Freq { get; set; }

        [JsonPropertyName("ffreq")]
        public double Ffreq { get; set; }

        //public bool hw { get; set; }
        //public int size { get; set; }
        //public int type { get; set; }
        //public string parent { get; set; }
    }

    public bool HasData { get; init; }
}