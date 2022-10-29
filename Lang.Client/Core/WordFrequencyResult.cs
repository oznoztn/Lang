namespace Lang.Client.Core;

public class WordFrequencyResult
{
    public bool HasFrequencyData { get; set; }
    public string Content { get; set; } = "";

    public static WordFrequencyResult CreateDefault() => new();
}