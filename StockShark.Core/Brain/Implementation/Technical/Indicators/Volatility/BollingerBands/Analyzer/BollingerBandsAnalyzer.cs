using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.BollingerBands.Analyzer.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.BollingerBands.Analyzer
{
    internal class BollingerBandsAnalyzer : ITechnicalAnalyzer<BollingerBandsAnalyzerResult, BollingerBandsAnalyzerParameter>
    {
        public BollingerBandsAnalyzerResult Analyze(BollingerBandsAnalyzerParameter parameter)
        {
            double latestClosingPrice = parameter.ClosingPrices[parameter.ClosingPrices.Length - 1];
            double latestUpperBand = parameter.UpperBand[parameter.UpperBand.Length - 1];
            double latestLowerBand = parameter.LowerBand[parameter.LowerBand.Length - 1];

            // Calculate the position of the latest closing price relative to the upper and lower bands
            double position = (latestClosingPrice - latestLowerBand) / (latestUpperBand - latestLowerBand);

            // Convert position to a score between 0 and 100
            double signalScore = (1 - position) * 100;

            return new BollingerBandsAnalyzerResult { SignalScore = signalScore };
        }
    }
}
