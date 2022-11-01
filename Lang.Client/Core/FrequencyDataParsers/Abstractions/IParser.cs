namespace Lang.Client.Core.FrequencyDataParsers.Abstractions;

public interface IParser<out T> where T : IParseResult
{
    T Parse(string rawText);
}