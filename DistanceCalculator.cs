namespace coffee_shop_finder
{
    public class DistanceCalculator
    {
        private double CalculateDistance(Location userLocation, CoffeeShopLocation coffeeShopLocation)
        {
            double distance = Math.Sqrt((Math.Pow(userLocation.XCoordinate - coffeeShopLocation.XCoordinate, 2) +
                           Math.Pow(userLocation.YCoordinate - coffeeShopLocation.YCoordinate, 2)));
            Math.Round(distance, 4);

            return distance;
        }

        public List<CoffeeShopLocation> ComputeTopThreeClosestCoffeeShops(Location userLocation, List<CoffeeShopLocation> coffeeShops)
        {
            return coffeeShops.OrderBy(coffeeShop => CalculateDistance(userLocation, coffeeShop))
                                .Take(3)
                                .ToList();
        }
    }
}