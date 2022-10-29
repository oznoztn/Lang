using System.Text.Json.Serialization;

namespace Lang.Client.Core;

/// <summary>
/// Represent frequency result of given word from vocabulary.com
/// </summary>
public class VocabularyFreqEntry
{
    [JsonPropertyName("word")]
    public string Word { get; set; } = "";

    [JsonPropertyName("freq")]
    public float Freq { get; set; }

    [JsonPropertyName("ffreq")]
    public float Ffreq { get; set; }

    //public bool hw { get; set; }
    //public int size { get; set; }
    //public int type { get; set; }
    //public string parent { get; set; }
}