using StockShark.Core.Entities.Base;

namespace StockShark.Core.Entities
{
    public class History : BaseEntity<long>
    {
        public long ShareId { get; set; }
        public string? HistoryJson { get; set; } = string.Empty;
    }
}
