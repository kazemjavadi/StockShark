namespace StockShark.Contracts.Histories.Repositories
{
    public class GetHistoryResult
    {
        public double[] Time { get; set; } = [];
        public double[] Open { get; set; } = [];
        public double[] Close { get; set; } = [];
        public double[] High { get; set; } = [];
        public double[] Low { get; set; } = [];
        public double[] Volume { get; set; } = [];
    }
}
