namespace CoffeeShopFinder.Exceptions
{
    public class NetworkLocationNotFoundException : CustomException
    {
        private static readonly string message = "Network Location '{0}' unreachable";

        public NetworkLocationNotFoundException(string networkLocation)
        : base(String.Format(message, networkLocation)) { }
    }
}