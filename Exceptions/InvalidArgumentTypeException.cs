namespace CoffeeShopFinder.Exceptions
{
    public class InvalidArgumentTypeException : CustomException
    {
        private const string message = "Invalid arguments. Valid types: arg1 = double, arg2 = double, arg3 = *.csv";

        public InvalidArgumentTypeException()
        : base(message) { }
    }
}