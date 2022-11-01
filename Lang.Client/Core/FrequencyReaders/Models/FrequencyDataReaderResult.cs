namespace Lang.Client.Core.FrequencyReaders.Models;

public class FrequencyDataReaderResult
{
    public bool HasFrequencyData { get; set; }
    public string Content { get; set; } = "";

    public static FrequencyDataReaderResult CreateDefault() => new();
}