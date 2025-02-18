using coffee_shop_finder.Exceptions;

namespace coffee_shop_finder
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
            ex is CsvReadingException
            || ex is InvalidArgumentCountException
            || ex is InvalidArgumentTypeException
            || ex is InvalidCoordinateException
            || ex is InvalidCsvContentException
            || ex is NetworkLocationNotFoundException
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