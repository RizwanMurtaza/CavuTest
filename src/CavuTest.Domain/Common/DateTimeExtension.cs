namespace CavuTest.Domain.Common
{
    public static class DateTimeExtension
    {
        public static long ToEpochTime(this DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
        }
    }
}
