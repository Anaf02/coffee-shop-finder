namespace coffee_shop_finder
{
    public class CoffeeShop : Location
    {
        public string Name { get; private set; }

        public CoffeeShop(double xCoordinate, double yCoordinate, string name) : base(xCoordinate, yCoordinate)
        {
            this.Name = name;
        }
    }
}