namespace StockShark.Api.Controllers.Histories.Dto
{
    public class UpdateHistoryInput
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string[] Symbols { get; set; } = [];
    }
}
