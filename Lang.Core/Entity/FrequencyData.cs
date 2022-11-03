using Lang.Core.Entity.Enums;

namespace Lang.Core.Entity;

public class FrequencyData
{
    public int Id { get; set; }
    public int WordId { get; set; }
    public string Content { get; set; }
    public FrequencySource FrequencySource { get; set; }
    public Word Word { get; set; }
}