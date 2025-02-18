namespace coffee_shop_finder.Exceptions
{
    public class CsvReadingException : Exception
    {
        private const string message = "Csv could not be read.";

        public CsvReadingException()
        : base(message) { }
    }
}