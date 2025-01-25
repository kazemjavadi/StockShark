namespace StockShark.Api.Controllers.Technical.ChartPatterns.Dto
{
    public class AnalyzeAscendingTriangleRequest
    {
        public int Period { get; set; }
        public string Symbol { get; set; } = string.Empty;
    }
}
