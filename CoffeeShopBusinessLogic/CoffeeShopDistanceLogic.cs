using CoffeeShopDataLayer;

namespace CoffeeShopBusinessLogic
{
    public class CoffeeShopDistanceLogic : ICoffeeShopDistanceLogic
    {
        private const int Precision = 4;

        private static double CalculateDistance(UserLocation userLocation, CoffeeShop coffeeShopLocation)
        {
            double distance = Math.Sqrt(Math.Pow(userLocation.X - coffeeShopLocation.X, 2) +
                           Math.Pow(userLocation.Y - coffeeShopLocation.Y, 2));
            distance = Math.Round(distance, Precision);

            return distance;
        }

        public List<CoffeeShopDto> ComputeClosestCoffeeShops(UserLocation userLocation, List<CoffeeShop> coffeeShops)
        {
            return coffeeShops.Select(coffeeShop => new CoffeeShopDto(coffeeShop.Name, coffeeShop.X, coffeeShop.Y, CalculateDistance(userLocation, coffeeShop)))
                            .OrderBy(dto => dto.Distance)
                            .ToList();
        }
    }
}