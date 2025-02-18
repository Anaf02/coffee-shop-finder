namespace coffee_shop_finder.Exceptions
{
    public class NetworkLocationNotFoundException : Exception
    {
        private static readonly string message = "Network Location '{0}' unreachable";

        public NetworkLocationNotFoundException(string networkLocation)
        : base(String.Format(message, networkLocation)) { }
    }
}