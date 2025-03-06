namespace CoffeeShopDataLayer.Exceptions
{
    public class InvalidArgumentTypeException : CustomException
    {
        private const string Message = "Invalid arguments. Valid types: arg1 = double, arg2 = double, arg3 = *.csv";

        public InvalidArgumentTypeException()
        : base(Message) { }
    }
}