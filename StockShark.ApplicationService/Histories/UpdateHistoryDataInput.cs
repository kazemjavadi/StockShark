namespace StockShark.ApplicationService.Histories
{
    public class UpdateHistoryDataInput
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string[] Symbols { get; set; } = [];
    }
}
