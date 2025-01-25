using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Down.Calculator.DTO
{
    internal class DownTrendCalculatorResult : ITechnicalCalculatorResult
    {
        public bool IsDownTrend { get; set; }
    }
}
