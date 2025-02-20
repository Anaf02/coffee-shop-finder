using CoffeeShopFinder.Exceptions;

namespace CoffeeShopFinder
{
    public class ProgramArgs
    {
        private static bool CheckArgs(string[] args)
        {
            if (args.Length != 3)
            {
                throw new InvalidArgumentCountException();
            }

            if (!Double.TryParse(args[0], out _) || !Double.TryParse(args[1], out _) || !args[2].EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidArgumentTypeException();
            }
            return true;
        }

        private static (double, double, string) ParseArgs(string[] args)
        {
            return new(Double.Parse(args[0]), Double.Parse(args[1]), args[2]);
        }

        public static (double, double, string) GetArgs(string[] args)
        {
            CheckArgs(args);

            return ParseArgs(args);
        }
    }
}