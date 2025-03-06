using CoffeeShopDataLayer;
using CoffeeShopDataLayer.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopBusinessLogic
{
    public class DatabaseSeeder
    {
        private readonly CoffeeShopDbContext _dbContext;

        private readonly string _csvPath = @"https://raw.githubusercontent.com/Agilefreaks/test_oop/master/coffee_shops.csv";

        public DatabaseSeeder(CoffeeShopDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task SeedDatabaseAsync()
        {
            if (await _dbContext.CoffeeShops.CountAsync() > 0)
            {
                Console.WriteLine("Database already seeded.");
                return;
            }

            List<CoffeeShop> coffeeShops = await GetCoffeeShopsFromCsv();

            if (coffeeShops.Count > 0)
            {
                await _dbContext.CoffeeShops.AddRangeAsync(coffeeShops);
                await _dbContext.SaveChangesAsync();
                Console.WriteLine("Database successfully seeded.");
            }
            else
            {
                throw new CsvReadingException();
            }
        }

        private async Task<List<CoffeeShop>> GetCoffeeShopsFromCsv()
        {
            string csvContent = "";

            if (Uri.IsWellFormedUriString(_csvPath, UriKind.Absolute) && await IsUrlReachable(_csvPath))
            {
                csvContent = await ReadFromUri(_csvPath);
            }
            else if (File.Exists(_csvPath))
            {
                csvContent = ReadFromCsvFile(_csvPath);
            }

            if (!string.IsNullOrEmpty(csvContent))
            {
                IsCsvContentValid(csvContent);
                return ParseCsv(csvContent);
            }
            else
            {
                throw new CsvReadingException();
            }
        }

        private List<CoffeeShop> ParseCsv(string csvContent)
        {
            List<string> lines = csvContent.Split("\n").Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            return lines.Select((line, index) =>
            {
                var values = line.Split(",");
                return new CoffeeShop(double.Parse(values[1]), double.Parse(values[2]), values[0]);
            }).ToList();
        }

        private static async Task<bool> IsUrlReachable(string url)
        {
            using HttpClient client = new();
            try
            {
                HttpRequestMessage request = new(HttpMethod.Head, url);
                HttpResponseMessage response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                throw new NetworkLocationNotFoundException(url);
            }
        }

        private bool IsCsvContentValid(string csvContent)
        {
            string[] lines = csvContent.Split("\n");

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) { continue; }

                string[] lineValues = line.Split(",");

                if (lineValues.Length != 3)
                {
                    throw new InvalidCsvContentException(line);
                }

                if (!double.TryParse(lineValues[1], out _))
                {
                    throw new InvalidCoordinateException(lineValues[1], line);
                }

                if (!double.TryParse(lineValues[2], out _))
                {
                    throw new InvalidCoordinateException(lineValues[2], line);
                }
            }

            return true;
        }

        private async Task<string> ReadFromUri(string uri)
        {
            using HttpClient client = new();
            return await client.GetStringAsync(uri);
        }

        private string ReadFromCsvFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}