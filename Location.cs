using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee_shop_finder
{
    public class Location
    {
        public double XCoordinate { get; set; }

        public double YCoordinate { get; set; }

        public Location(double xCoordinate, double yCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }
    }
}
