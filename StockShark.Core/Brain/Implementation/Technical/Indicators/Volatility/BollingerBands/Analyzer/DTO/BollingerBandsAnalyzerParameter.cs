using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.Indicators.Volatility.BollingerBands.Analyzer.DTO
{
    internal class BollingerBandsAnalyzerParameter : ITechnicalAnalyzerParameter
    {
        public double[] MiddleBand { get; set; } = [];
        public double[] UpperBand { get; set; } = [];
        public double[] LowerBand { get; set; } = [];

        public double[] ClosingPrices { get; set; } = [];
    }
}
