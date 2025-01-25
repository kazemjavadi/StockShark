using StockShark.Core.Brain.Base.Technical;
namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Reversal.HeadAndShoulders.Analyzer.DTO
{
    internal class HeadAndShouldersAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double HeadAndShouldersScore { get; set; }
        public bool IsHeadAndShoulders { get; set; }
    }
}
