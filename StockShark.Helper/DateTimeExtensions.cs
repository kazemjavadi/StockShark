namespace StockShark.Helper
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTimestamp(this DateTime datetime)
        {
            long epochTicks = new DateTime(1970, 1, 1).Ticks;
            return ((datetime.Ticks - epochTicks) / TimeSpan.TicksPerSecond);
        }
    }
}
