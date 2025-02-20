namespace CoffeeShopFinder
{
    public class UserLocation : ILocation
    {
        public double X { get; set; }

        public double Y { get; set; }

        public UserLocation(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}