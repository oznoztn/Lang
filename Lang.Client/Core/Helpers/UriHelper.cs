using System;
using Lang.Client.Core.Enums;

namespace Lang.Client.Core.Helpers
{
    public static class UriHelper
    {
        public static string CreatedAddress(Source s, string word)
        {
            switch (s)
            {
                case Source.Ngram:
                    throw new NotImplementedException();
                    break;
                case Source.Vocabulary:
                    return "https://www.vocabulary.com/dictionary/" + word;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(s), s, null);
            }
        }
    }
}
