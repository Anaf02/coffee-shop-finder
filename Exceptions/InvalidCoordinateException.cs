namespace coffee_shop_finder.Exceptions
{
    public class InvalidCoordinateException : Exception
    {
        private static readonly string message = "Provided coordinate '{0}', found in line '{1}' is not a number";

        public InvalidCoordinateException(string coordinateValue, string line)
            : base(string.Format(message, coordinateValue, line.Replace("\r", ""))) { }
    }
}