namespace coffee_shop_finder.Exceptions
{
    public class InvalidCoordinateException : Exception
    {
        private static readonly string message = $"Provided coordinate {0} is not a number";

        public InvalidCoordinateException(string coordinateValue)
            : base(string.Format(message, coordinateValue)) { }
    }
}