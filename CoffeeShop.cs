namespace CoffeeShopFinder
{
    public class CoffeeShop : Location
    {
        public string Name { get; private set; }

        public CoffeeShop(double x, double y, string name) : base(x, y)
        {
            this.Name = name;
        }
    }
}