using Lang.Client.Core.FrequencyDataParsers.Models;
using System;

namespace Lang.Client.Core.FrequencyReaders;

public class NgramFrequencyDataReader : IFrequencyDataReader<NgramFreqResult>
{
    public NgramFreqResult GetFrequencyData(string htmlContent)
    {
        throw new NotImplementedException();
    }
}