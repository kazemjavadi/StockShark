using StockShark.Core.Brain.Base.Technical;

namespace StockShark.Core.Brain.Implementation.Technical.KeyComponents.Trends.Up.Calculator.DTO
{
    internal class UpTrendCalculatorResult : ITechnicalCalculatorResult
    {
        public bool IsUpTrend { get; set; }
    }
}
