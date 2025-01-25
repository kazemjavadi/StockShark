namespace StockShark.Contracts.Histories.EternalServices
{
    public class GetHistoryExternalServiceResult
    {
        public long[] t { get; set; } = [];
        public long[] o { get; set; } = [];
        public long[] c { get; set; } = [];
        public long[] h { get; set; } = [];
        public long[] l { get; set; } = [];
        public long[] v { get; set; } = [];

        public string s { get; set; } = string.Empty;
        public long nextTime { get; set; }
    }
}
