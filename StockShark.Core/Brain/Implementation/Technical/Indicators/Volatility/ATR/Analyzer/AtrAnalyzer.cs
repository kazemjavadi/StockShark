using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.ATR.Analyzer.DTO;
using StockShark.Core.Configs;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.ATR.Analyzer
{
    internal class AtrAnalyzer : ITechnicalAnalyzer<AtrAnalyzerResult, AtrAnalyzerParameter>
    {
        public AtrAnalyzerResult Analyze(AtrAnalyzerParameter parameter)
        {
            // Calculate the highest and lowest ATR values in the given period
            double maxATR = double.MinValue;
            double minATR = double.MaxValue;

            foreach (var atr in parameter.AtrValues)
            {
                if (atr > maxATR)
                    maxATR = atr;
                if (atr < minATR)
                    minATR = atr;
            }

            // Calculate the current ATR score in the range of 0 to 100
            double currentATR = parameter.AtrValues[parameter.AtrValues.Length - 1];
            double signalScore = Math.Round((currentATR - minATR) / (maxATR - minATR) * Config.MaxRange);

            return new AtrAnalyzerResult { SignalScore = signalScore };
        }
    }
}
