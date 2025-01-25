using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.SupportLevel.Analyzer.DTO
{
    internal class SupportLevelAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] SupportLevels { get; set; } = [];
        public double CurrentPrice { get; set; }
    }
}
