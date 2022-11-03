using Lang.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lang.Core;

public class LangDbContext : DbContext
{
    public LangDbContext(DbContextOptions<LangDbContext> options) : base(options)
    {

    }

    public DbSet<Word> Words { get; set; }
    public DbSet<FrequencyData> FrequencyData { get; set; }
    public DbSet<WordList> WordLists { get; set; }
    public DbSet<WordListWord> WordListWords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WordListWord>()
            .HasKey(t => new
            {
                t.WordId,
                t.WordListId
            });

        modelBuilder.Entity<WordListWord>()
            .HasOne(pt => pt.Word)
            .WithMany(p => p.WordListWords)
            .HasForeignKey(pt => pt.WordId);

        modelBuilder.Entity<WordListWord>()
            .HasOne(pt => pt.WordList)
            .WithMany(t => t.WordListWords)
            .HasForeignKey(pt => pt.WordListId);

        modelBuilder.Entity<WordList>().HasData(new List<WordList>()
        {
            new WordList() { Id = 1, Title = "Alfa" },
            new WordList() { Id = 2, Title = "Babel" },
            new WordList() { Id = 3, Title = "2021" },
            new WordList() { Id = 4, Title = "2022" },
            new WordList() { Id = 4, Title = "2022 II" },
            new WordList() { Id = 5, Title = "2023" },
        });

        modelBuilder
            .Entity<FrequencyData>()
            .ToTable("FrequencyData");

        base.OnModelCreating(modelBuilder);
    }
}