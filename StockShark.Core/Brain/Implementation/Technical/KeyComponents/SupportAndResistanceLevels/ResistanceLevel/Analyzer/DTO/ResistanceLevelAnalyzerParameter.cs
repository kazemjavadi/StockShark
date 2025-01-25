using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.SupportAndResistanceLevels.ResistanceLevel.Analyzer.DTO
{
    internal class ResistanceLevelAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] ResistanceLevels { get; set; } = [];
        public double CurrentPrice { get; set; }
    }
}
