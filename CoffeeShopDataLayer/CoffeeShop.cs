using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeShopDataLayer
{
    public class CoffeeShop : ILocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public CoffeeShop()
        {

        }

        public CoffeeShop(double x, double y, string name)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
        }
    }
}