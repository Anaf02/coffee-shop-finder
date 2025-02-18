namespace CoffeeShopFinder.Exceptions
{
    public class CsvReadingException : Exception
    {
        private const string message = "Csv could not be read.";

        public CsvReadingException()
        : base(message) { }
    }
}