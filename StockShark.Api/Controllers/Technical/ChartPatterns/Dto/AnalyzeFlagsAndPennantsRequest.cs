namespace StockShark.Api.Controllers.Technical.ChartPatterns.Dto
{
    public class AnalyzeFlagsAndPennantsRequest
    {
        public int Period { get; set; }
        public string Symbol { get; set; } = string.Empty;
    }
}
