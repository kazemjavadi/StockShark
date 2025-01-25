using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.OBV.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volume.OBV.Analyzer
{
    internal class ObvAnalyzer : ITechnicalAnalyzer<ObvAnalyzerResult, ObvAnalyzerParameter>
    {
        public ObvAnalyzerResult Analyze(ObvAnalyzerParameter parameter)
        {
            ObvAnalyzerResult result = new();

            if (parameter.ObvValues.Length == 0)
            {
                result.SignalScore = Config.MaxRange / 2;
                return result; // Neutral if there's no data
            }

            double latestOBV = parameter.ObvValues[parameter.ObvValues.Length - 1];
            double minOBV = double.MaxValue;
            double maxOBV = double.MinValue;

            foreach (var obv in parameter.ObvValues)
            {
                if (obv < minOBV) minOBV = obv;
                if (obv > maxOBV) maxOBV = obv;
            }

            if (maxOBV == minOBV)
            {
                result.SignalScore = Config.MaxRange / 2;
                return result; // Neutral if there's no variation
            }
            // Normalize the latest OBV to a score between 0 and 100
            double signalScore = (latestOBV - minOBV) / (maxOBV - minOBV) * 100;

            return new ObvAnalyzerResult { SignalScore = signalScore };
        }
    }
}
