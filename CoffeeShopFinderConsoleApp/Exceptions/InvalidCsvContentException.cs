namespace CoffeeShopFinder.Exceptions
{
    public class InvalidCsvContentException : CustomException
    {
        private static readonly string Message = "Invalid line '{0}'. The .csv must be comma separated file with rows of the following form: Name,X Coordinate,Y Coordinate";

        public InvalidCsvContentException(string line)
        : base(String.Format(Message, line.Replace("\r", ""))) { }
    }
}