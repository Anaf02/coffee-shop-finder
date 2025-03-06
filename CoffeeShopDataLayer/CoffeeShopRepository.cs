namespace CoffeeShopDataLayer
{
    public class CoffeeShopRepository : ICoffeeShopRepository, IDisposable
    {
        private readonly CoffeeShopDbContext _context;

        private bool _disposed = false;

        public CoffeeShopRepository(CoffeeShopDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<CoffeeShop> GetCoffeeShops()
        {            
            return _context.CoffeeShops.ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}