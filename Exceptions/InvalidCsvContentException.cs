namespace coffee_shop_finder.Exceptions
{
    internal class InvalidCsvContentException : Exception
    {
        private const string message = "The .csv must be comma separated file with rows of the following form: Name,Y Coordinate,X Coordinate";

        public InvalidCsvContentException()
        : base(message) { }
    }
}