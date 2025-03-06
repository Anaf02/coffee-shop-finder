namespace CoffeeShopDataLayer
{
    public interface ICoffeeShopRepository : IDisposable
    {
        IEnumerable<CoffeeShop> GetCoffeeShops();
    }
}