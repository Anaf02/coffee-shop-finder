namespace CoffeeShopFinder.Exceptions
{
    public class CsvReadingException : CustomException
    {
        private const string message = "Csv could not be read.";

        public CsvReadingException()
        : base(message) { }
    }
}