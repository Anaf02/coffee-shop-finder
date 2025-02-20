namespace CoffeeShopFinder
{
    public class CoffeeShopBusinessLogic
    {
        private List<CoffeeShop> CoffeeShops { get; set; }

        private int Precision = 4;

        public CoffeeShopBusinessLogic(CoffeeShopDataProvider coffeeShopDataProvider)
        {
            CoffeeShops = coffeeShopDataProvider.GetCoffeeShops();
        }

        private double CalculateDistance(UserLocation userLocation, CoffeeShop coffeeShopLocation)
        {
            double distance = Math.Sqrt((Math.Pow(userLocation.X - coffeeShopLocation.X, 2) +
                           Math.Pow(userLocation.Y - coffeeShopLocation.Y, 2)));
            distance = Math.Round(distance, Precision);

            return distance;
        }

        public void DisplayTopThreeCoffeeShops(UserLocation userLocation)
        {
            List<(CoffeeShop, double)> CoffeeShopsWithDistances = new List<(CoffeeShop, double)>();
            foreach (CoffeeShop coffeeShop in CoffeeShops)
            {
                CoffeeShopsWithDistances.Add((coffeeShop, CalculateDistance(userLocation, coffeeShop)));
            }

            CoffeeShopsWithDistances.OrderBy(x => x.Item2)
                                    .Take(3)
                                    .ToList()
                                    .ForEach(x => Console.WriteLine($"{x.Item1.Name}, {x.Item2}"));
        }
    }
}