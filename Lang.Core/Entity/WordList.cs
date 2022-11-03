namespace Lang.Core.Entity;

public class WordList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<WordListWord> WordListWords { get; set; }
}