using StockShark.Core.Brain.Base.Technical;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Other.IchimokuCloud.Analyzer.DTO;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Other.IchimokuCloud.Analyzer
{
    internal class IchimokuCloudResultAnalyze : ITechnicalAnalyzer<IchimokuCloudAnalyzerResult, IchimokuCloudAnalyzerParameter>
    {
        public IchimokuCloudAnalyzerResult Analyze(IchimokuCloudAnalyzerParameter parameter)
        {
            double score = 0;

            // Example scoring system based on the position of current price relative to the Ichimoku components
            if (parameter.CurrentPrice > parameter.SenkouSpanA && parameter.CurrentPrice > parameter.SenkouSpanB)
            {
                score += 50; // Price above cloud is generally bullish
            }
            else if (parameter.CurrentPrice < parameter.SenkouSpanA && parameter.CurrentPrice < parameter.SenkouSpanB)
            {
                score += 10; // Price below cloud is generally bearish
            }
            else
            {
                score += 30; // Price within cloud indicates consolidation
            }

            if (parameter.TenkanSen > parameter.KijunSen)
            {
                score += 20; // Bullish signal
            }
            else
            {
                score += 10; // Bearish signal
            }

            if (parameter.CurrentPrice > parameter.TenkanSen)
            {
                score += 10; // Price above Tenkan-sen
            }

            if (parameter.CurrentPrice > parameter.KijunSen)
            {
                score += 10; // Price above Kijun-sen
            }

            if (parameter.CurrentPrice > parameter.ChikouSpan)
            {
                score += 10; // Current price above Chikou span is generally bullish
            }

            return new IchimokuCloudAnalyzerResult { SignalScore = score }; // Final score is between 0 and 100
        }
    }
}
