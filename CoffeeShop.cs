namespace CoffeeShopFinder
{
    public class CoffeeShop : ILocation
    {
        public string Name { get; private set; }

        public double X { get; private set; }

        public double Y { get; private set; }

        public CoffeeShop(double x, double y, string name)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
        }
    }
}