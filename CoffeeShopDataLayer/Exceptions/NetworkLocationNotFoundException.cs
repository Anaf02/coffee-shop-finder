namespace CoffeeShopDataLayer.Exceptions
{
    public class NetworkLocationNotFoundException : CustomException
    {
        private static readonly string Message = "Network Location '{0}' unreachable";

        public NetworkLocationNotFoundException(string networkLocation)
        : base(String.Format(Message, networkLocation)) { }
    }
}