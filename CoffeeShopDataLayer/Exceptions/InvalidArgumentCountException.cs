namespace CoffeeShopDataLayer.Exceptions
{
    public class InvalidArgumentCountException : CustomException
    {
        private const string Message = "You must provide 3 command line arguments separated by space - example: coffee-shop-finder.exe arg1 arg2 arg3";

        public InvalidArgumentCountException()
        : base(Message) { }
    }
}