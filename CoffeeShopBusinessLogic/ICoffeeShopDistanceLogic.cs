using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopDataLayer;

namespace CoffeeShopBusinessLogic
{
    public interface ICoffeeShopDistanceLogic
    {
        List<CoffeeShopDto> ComputeClosestCoffeeShops(UserLocation userLocation, List<CoffeeShop> coffeeShops);
    }
}