using CoffeeShopFinder.Exceptions;

namespace CoffeeShopFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                (double, double, string) parsedArgs = ProgramArgs.GetArgs(args);
                Location userLocation = new Location(parsedArgs.Item1, parsedArgs.Item2);
                CoffeeShopDataProvider coffeeShopDataProvider = new CoffeeShopDataProvider(parsedArgs.Item3);
                CoffeeShopBusinessLogic coffeeShopBusinessLogic = new CoffeeShopBusinessLogic(coffeeShopDataProvider);
                coffeeShopBusinessLogic.ComputeCoffeeShopsDistance(userLocation);
                ResultsPresenter.DisplayTopThreeCoffeeShops(coffeeShopBusinessLogic.CoffeeShopsWithDistances);
            }
            catch (Exception ex) when (
            ex is CustomException
            || ex is HttpRequestException
            || ex is IOException)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}