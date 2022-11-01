using Lang.Client.Core.FrequencyDataParsers.Abstractions;

namespace Lang.Client.Core.FrequencyDataParsers.Models;

/// <summary>
/// Represent frequency result of given word from Google Ngram
/// </summary>
public class NgramFreqResult : IParseResult
{
    public bool HasData { get; init; }
}