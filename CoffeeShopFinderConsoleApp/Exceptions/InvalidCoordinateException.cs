namespace CoffeeShopFinder.Exceptions
{
    public class InvalidCoordinateException : CustomException
    {
        private static readonly string Message = "Provided coordinate '{0}', found in line '{1}' is not a number";

        public InvalidCoordinateException(string coordinateValue, string line)
            : base(string.Format(Message, coordinateValue, line.Replace("\r", ""))) { }
    }
}