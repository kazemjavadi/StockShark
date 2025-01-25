namespace StockShark.Core.Entities.Base
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }

        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDateTime { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
