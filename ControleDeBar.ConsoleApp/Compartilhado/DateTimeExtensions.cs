
namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public static class DateTimeExtensions
    {
        public static int CompareWithoutMinutes(this DateTime source, DateTime toCompare)
        {
            source = new DateTime(source.Year, source.Month, source.Day, source.Hour, 0, 0);
            toCompare = new DateTime(toCompare.Year, toCompare.Month, toCompare.Day, toCompare.Hour, 0, 0);

            return source.CompareTo(toCompare);
        }
    }
}
