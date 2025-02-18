namespace coffee_shop_finder.Exceptions
{
    public class InvalidArgumentTypeException : Exception
    {
        private const string message = "Valid types: arg1, arg2 = double, arg3 = *.csv";

        public InvalidArgumentTypeException()
        : base(message) { }
    }
}