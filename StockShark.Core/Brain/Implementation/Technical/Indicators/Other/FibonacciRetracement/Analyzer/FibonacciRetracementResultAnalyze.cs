using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Other.FibonacciRetracement.Analyzer.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Other.FibonacciRetracement.Analyzer
{
    internal class FibonacciRetracementResultAnalyze : ITechnicalAnalyzer<FibonacciRetracementAnalyzerResult, FibonacciRetracementAnalyzerParameter>
    {
        public FibonacciRetracementAnalyzerResult Analyze(FibonacciRetracementAnalyzerParameter parameter)
        {
            double currentPrice = parameter.CurrentPrice;

            double score = 0;

            // Simple scoring system based on proximity to retracement levels
            foreach (var level in parameter.Levels)
            {
                double distance = Math.Abs(currentPrice - level.Value);
                double weight = 0;

                switch (level.Key)
                {
                    case "23.6%":
                        weight = 0.1;
                        break;
                    case "38.2%":
                        weight = 0.2;
                        break;
                    case "50%":
                        weight = 0.3;
                        break;
                    case "61.8%":
                        weight = 0.4;
                        break;
                }

                score += weight * (1 - distance / currentPrice); // Closer to level gives higher score
            }

            return new FibonacciRetracementAnalyzerResult { SignalScore = score * 100 }; // Normalize score to 0-100
        }
    }
}
