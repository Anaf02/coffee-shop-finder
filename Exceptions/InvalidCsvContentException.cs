namespace CoffeeShopFinder.Exceptions
{
    internal class InvalidCsvContentException : Exception
    {
        private static readonly string message = "Invalid line '{0}'. The .csv must be comma separated file with rows of the following form: Name,X Coordinate,Y Coordinate";

        public InvalidCsvContentException(string line)
        : base(String.Format(message, line.Replace("\r", ""))) { }
    }
}