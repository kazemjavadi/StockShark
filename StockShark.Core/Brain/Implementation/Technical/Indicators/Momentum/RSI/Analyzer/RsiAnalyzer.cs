using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Analyzer
{
    public class RsiAnalyzer : ITechnicalAnalyzer<RsiAnalyzerResult, RsiAnalyzerParameter>
    {
        public RsiAnalyzerResult Analyze(RsiAnalyzerParameter parameter)
        {
            RsiAnalyzerResult result = new();

            if (parameter.RsiValues == null || parameter.RsiValues.Length < 2)
                throw new ArgumentException("RSI values cannot be null and must contain at least two values.");

            // Define thresholds for signal analysis
            const double strongBuyThreshold = 20;
            const double buyThreshold = 30;
            const double sellThreshold = 70;
            const double strongSellThreshold = 80;

            // Calculate the latest RSI value (most recent data point)
            double latestRsiValue = parameter.RsiValues.Last();

            // Calculate trend direction by comparing recent values with the overall average
            double longTermAverage = parameter.RsiValues.Average();
            double recentAverage = parameter.RsiValues.Skip(Math.Max(0, parameter.RsiValues.Length - 10)).Average(); // Last 10 periods

            // Calculate volatility (standard deviation of RSI values)
            double volatility = Math.Sqrt(parameter.RsiValues.Average(v => Math.Pow(v - longTermAverage, 2)));

            // Adjusted signal score based on latest RSI value, trend, and volatility
            double signalScore;

            if (latestRsiValue <= strongBuyThreshold)
            {
                // Very strong buy signal
                signalScore = 100;
            }
            else if (latestRsiValue <= buyThreshold)
            {
                // Strong buy signal, adjust with volatility
                signalScore = 70 + ((buyThreshold - latestRsiValue) / (buyThreshold - strongBuyThreshold)) * 30;
                signalScore += volatility > 10 ? -5 : 5; // Adjust based on volatility
            }
            else if (latestRsiValue < sellThreshold)
            {
                // Neutral to moderate sell signal, adjust with trend direction
                double trendAdjustment = recentAverage > longTermAverage ? 10 : -10;
                signalScore = 50 + trendAdjustment - (volatility / 2); // Adjust for trend and volatility
            }
            else if (latestRsiValue < strongSellThreshold)
            {
                // Strong sell signal, interpolate between 30 and 0
                signalScore = 30 - ((latestRsiValue - sellThreshold) / (strongSellThreshold - sellThreshold)) * 30;
                signalScore -= volatility > 10 ? 5 : -5; // Adjust based on volatility
            }
            else
            {
                // Very strong sell signal
                signalScore = 0;
            }

            // Clamp final score between 0 and 100
            return new RsiAnalyzerResult() { SignalScore = Math.Clamp(signalScore, 0, 100) };
        }
    }
}
