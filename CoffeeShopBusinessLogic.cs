namespace coffee_shop_finder
{
    public class CoffeeShopBusinessLogic
    {
        public List<(CoffeeShop, double)> CoffeeShopsWithDistances { get; private set; }

        private List<CoffeeShop> CoffeeShops { get; set; }

        private int Precision = 4;

        public CoffeeShopBusinessLogic(CoffeeShopDataProvider coffeeShopDataProvider)
        {

            CoffeeShopsWithDistances = new List<(CoffeeShop, double)>();

            CoffeeShops = coffeeShopDataProvider.GetCoffeeShops();
        }

        private double CalculateDistance(Location userLocation, CoffeeShop coffeeShopLocation)
        {
            double distance = Math.Sqrt((Math.Pow(userLocation.X - coffeeShopLocation.X, 2) +
                           Math.Pow(userLocation.Y - coffeeShopLocation.Y, 2)));
            distance = Math.Round(distance, Precision);

            return distance;
        }

        public void ComputeCoffeeShopsDistance(Location userLocation)
        {
            foreach (CoffeeShop coffeeShop in CoffeeShops)
            {
                CoffeeShopsWithDistances.Add((coffeeShop, CalculateDistance(userLocation, coffeeShop)));
            }
        }
    }
}