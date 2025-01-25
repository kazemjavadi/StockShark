using StockShark.Core.Brain.Base.Technical;
namespace StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.Analyzer.DTO
{
    public class FlagsAndPennantsAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public bool IsFlagsAndPennants { get; set; }
        public double FlagsAndPennantsScore { get; set; }
    }
}
