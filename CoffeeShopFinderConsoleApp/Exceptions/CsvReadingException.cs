namespace CoffeeShopFinder.Exceptions
{
    public class CsvReadingException : CustomException
    {
        private const string Message = "Csv could not be read.";

        public CsvReadingException()
        : base(Message) { }
    }
}