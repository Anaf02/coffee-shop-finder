using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee_shop_finder
{
    public class CoffeeShopLocation : Location
    {
        public string Name { get; private set; }

        public CoffeeShopLocation(double xCoordinate, double yCoordinate, string name) : base(xCoordinate, yCoordinate)
        {
            this.Name = name;
        }
    }
}