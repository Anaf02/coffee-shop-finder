using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDataLayer
{
    public interface ILocation
    {
        public double X { get; }
        public double Y { get; }
    }
}