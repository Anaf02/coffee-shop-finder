namespace CoffeeShopBusinessLogic   
{
    public class CoffeeShopDto
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance { get; set; }

        public CoffeeShopDto(string name, double x, double y, double distance)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Distance = distance;
        }
    }
}
