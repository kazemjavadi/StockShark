namespace StockShark.Contracts.Histories.EternalServices
{
    public class GetHistoryExternalServiceQuery
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Symbol { get; set; } = string.Empty;
    }
}
