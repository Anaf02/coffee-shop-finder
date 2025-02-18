using coffee_shop_finder.Exceptions;

namespace coffee_shop_finder
{
    public class CoffeeShopDataProvider
    {
        private List<CoffeeShop> CoffeeShops { get; set; }

        public CoffeeShopDataProvider(string path)
        {
            string csvContent = "";

            if (Uri.IsWellFormedUriString(path, UriKind.Absolute) && IsUrlReachable(path))
            {
                csvContent = ReadFromUri(path).GetAwaiter().GetResult();
            }
            else if (File.Exists(path))
            {
                csvContent = ReadFromCsvFile(path);
            }

            if (!String.IsNullOrEmpty(csvContent))
            {
                IsCsvContentValid(csvContent);

                CoffeeShops = csvContent.Split("\n")
                                         .Select(line => line.Split(","))
                                         .Select(values => new CoffeeShop(double.Parse(values[1]), double.Parse(values[2]), values[0]))
                                         .ToList();
            }
            else
            {
                throw new CsvReadingException();
            }
        }

        private static bool IsUrlReachable(string url)
        {
            using HttpClient client = new();
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url);
                HttpResponseMessage response = client.Send(request);
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
                string[] lineValues = line.Split(",");

                if (lineValues.Length != 3)
                {
                    throw new InvalidCsvContentException();
                }

                if (!Double.TryParse(lineValues[1], out _))
                {
                    throw new InvalidCoordinateException(lineValues[1]);
                }

                if (!Double.TryParse(lineValues[2], out _))
                {
                    throw new InvalidCoordinateException(lineValues[2]);
                }
            }

            return true;
        }

        private async Task<string> ReadFromUri(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                string csvContent = await client.GetStringAsync(uri);

                return csvContent;
            }
        }

        private string ReadFromCsvFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string csvContent = reader.ReadToEnd();

            return csvContent;
        }

        public List<CoffeeShop> GetCoffeeShops()
        {
            return new List<CoffeeShop>(CoffeeShops);
        }
    }
}