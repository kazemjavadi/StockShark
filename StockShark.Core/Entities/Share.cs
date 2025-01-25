using StockShark.Core.Entities.Base;

namespace StockShark.Core.Entities
{
    public class Share : BaseEntity<long>
    {
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
    }
}
