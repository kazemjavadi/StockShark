using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Analyzer.DTO;
using StockShark.Core.Configs;
using System.Diagnostics.Metrics;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Analyzer
{
    public class MacdAnalyzer : ITechnicalAnalyzer<MacdAnalyzerResult, MacdAnalyzerParameter>
    {
        public MacdAnalyzerResult Analyze(MacdAnalyzerParameter parameter)
        {

            if (parameter.Histogram == null || parameter.Histogram.Length == 0)
                throw new ArgumentException("Histogram data is required to calculate signal score.");

            // Use the last few histogram values for averaging
            var recentValues = parameter.Histogram.Skip(Math.Max(0, parameter.Histogram.Length - parameter.HistogramAveragePeriod)).ToList();
            double averageValue = recentValues.Average();

            double signalScore;
            if (averageValue >= parameter.PositiveThreshold)
            {
                // Strong buy signal
                signalScore = 100;
            }
            else if (averageValue <= parameter.NegativeThreshold)
            {
                // Strong sell signal
                signalScore = 0;
            }
            else
            {
                // Linear interpolation for values between thresholds
                signalScore = (averageValue - parameter.NegativeThreshold) / (parameter.PositiveThreshold - parameter.NegativeThreshold) * 100;
            }


            return new MacdAnalyzerResult { SignalScore = signalScore };
        }
    }
}
