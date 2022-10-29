using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Client.Data
{
    public class Word
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FreqData
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public FrequencySite FrequencySite { get; set; }
    }

    public enum FrequencySite
    {
        Vocabulary = 1,
        Ngram = 2
    }
}

// https://books.google.com/ngrams/graph?content=love&year_start=1800&year_end=2019&corpus=26&smoothing=3