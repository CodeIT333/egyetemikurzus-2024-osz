using System.Text.Json;
using PQ7I00.APP.Model.Spendings;
using PQ7I00.Shared;

namespace PQ7I00.Persistence
{
    // READ AND WRITE THE JSON FILES
    public static class FileManager
    {
        private static readonly string ProjectRootDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;

        // Combine with the relative path to get the DataFiles/Spendings directory
        private static readonly string SpendingsDirectory = Path.Combine(ProjectRootDirectory, "DataFiles", "Spendings");

        private static async Task<List<Spending>> GetSpendingsAsync()
        {
            if (!Directory.Exists(SpendingsDirectory))
            {
                return new List<Spending>();
            }

            var files = Directory.GetFiles(SpendingsDirectory, "*.json");

            var tasks = files.Select(async file =>
            {
                var content = await File.ReadAllTextAsync(file);
                return JsonSerializer.Deserialize<Spending>(content);
            });

            var spendings = (await Task.WhenAll(tasks))
                .Where(spending => spending != null)
                .ToList();

            return spendings;
        }

        public static async Task<List<Spending>> ListByCategoryAsync(CostCategory? costCategory)
        {
            var spendings = await GetSpendingsAsync();
            return spendings.Where(spending => costCategory.HasValue ? spending.Category == costCategory : true)
                            .OrderByDescending(spending => spending.Date)
                            .ToList();
        }

        public static async Task<List<Spending>> ListByDateAsync(int number, DateFilter? dateFilter)
        {
            var spendings = await GetSpendingsAsync();

            DateTime today = DateTime.UtcNow;
            DateTime cutoffDate;
            switch (dateFilter) {
                case DateFilter.Days:
                    cutoffDate = today.AddDays(-number);
                    break;
                case DateFilter.Years:
                    cutoffDate = today.AddYears(-number);
                    break;
                /* Add new if needed */
                default:
                    // if null list all
                    cutoffDate = DateTime.MinValue;
                    break;
            }

            return spendings
                .Where(spending => spending.Date >= cutoffDate)
                .OrderByDescending(spending => spending.Date)
                .ToList();
        }

        public static async Task AddSpendingAsync(Spending spending)
        {
            if (!Directory.Exists(SpendingsDirectory))
            {
                Directory.CreateDirectory(SpendingsDirectory);
            }

            string fileName = $"{spending.Id}.json";
            string filePath = Path.Combine(SpendingsDirectory, fileName);

            string jsonData = JsonSerializer.Serialize(spending, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(filePath, jsonData);
        }
    }
}
