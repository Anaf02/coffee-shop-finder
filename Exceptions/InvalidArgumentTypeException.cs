namespace coffee_shop_finder.Exceptions
{
    public class InvalidArgumentTypeException : Exception
    {
        private const string message = "Invalid arguments. Valid types: arg1 = double, arg2 = double, arg3 = *.csv";

        public InvalidArgumentTypeException()
        : base(message) { }
    }
}