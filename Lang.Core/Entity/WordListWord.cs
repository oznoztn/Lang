namespace Lang.Core.Entity;

public class WordListWord
{
    public int WordId { get; set; }
    public int WordListId { get; set; }
    public WordList WordList { get; set; }
    public Word Word { get; set; }
}