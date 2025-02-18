namespace coffee_shop_finder
{
    public static class ResultsPresenter
    {
        public static void DisplayTopThreeCoffeeShops(List<(CoffeeShop, double)> coffeeShopsWithDistances)
        {
            coffeeShopsWithDistances.OrderBy(x => x.Item2)
                                    .Take(3)
                                    .ToList()
                                    .ForEach(x => Console.WriteLine($"{x.Item1.Name}, {x.Item2}"));
        }
    }
}