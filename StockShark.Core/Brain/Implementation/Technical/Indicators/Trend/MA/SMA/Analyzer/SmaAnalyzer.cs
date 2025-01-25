using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.SMA.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.SMA.Analyzer
{
    internal class SmaAnalyzer : ITechnicalAnalyzer<SmaAnalyzerResult, SmaAnalyzerParameter>
    {
        public SmaAnalyzerResult Analyze(SmaAnalyzerParameter parameter)
        {
            SmaAnalyzerResult result = new();

            // Ensure we have enough data
            if (parameter.ClosingPrices.Length < parameter.Period + 1)
            {
                result.SignalScore = Config.MaxRange / 2;
                return result; // Neutral score if there's not enough data
            }

            double previousPrice = parameter.ClosingPrices[parameter.ClosingPrices.Length - parameter.Period - 1];
            double currentPrice = parameter.ClosingPrices.Last();
            double previousMa = parameter.SmaData[parameter.SmaData.Length - 2]; // Use the second last value for the previous MA
            double currentMa = parameter.SmaData.Last();

            if (previousPrice < previousMa && currentPrice > currentMa)
            {
                // Calculate the severity of the buy signal
                double severity = Math.Min((currentPrice - currentMa) / currentMa, 1.0) * 100;
                result.SignalScore = Config.MaxRange / 2 + severity / 2;
                return result;
            }
            else if (previousPrice > previousMa && currentPrice < currentMa)
            {
                // Calculate the severity of the sell signal
                double severity = Math.Min((previousPrice - currentMa) / currentMa, 1.0) * 100;
                result.SignalScore = Config.MaxRange / 2 - severity / 2;
                return result;
            }
            else
            {
                result.SignalScore = Config.MaxRange / 2;
                return result; // Neutral score if no clear signal
            }
        }
    }
}
