namespace CoffeeShopFinder.Exceptions
{
    public class InvalidArgumentCountException : Exception
    {
        private const string message = "You must provide 3 command line arguments separated by space - example: coffee-shop-finder.exe arg1 arg2 arg3";

        public InvalidArgumentCountException()
        : base(message) { }
    }
}