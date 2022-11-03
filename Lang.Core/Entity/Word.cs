namespace Lang.Core.Entity;

public class Word
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<FrequencyData> FrequencyData { get; set; }
    public ICollection<WordListWord> WordListWords { get; set; }
}