using PQ7I00.APP.Model.Spendings;

namespace PQ7I00.Persistence
{
    // READ AND WRITE THE JSON FILES
    public static class FileManager
    {
        private static readonly string ProjectRootDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;

        // Combine with the relative path to get the DataFiles/Spendings directory
        private static readonly string SpendingsDirectory = Path.Combine(ProjectRootDirectory, "DataFiles", "Spendings");

        public static async Task AddSpendingAsync(Spending spending)
        {
            if (!Directory.Exists(SpendingsDirectory))
            {
                Directory.CreateDirectory(SpendingsDirectory);
            }

            string fileName = $"{spending.Id}.json";
            string filePath = Path.Combine(SpendingsDirectory, fileName);

            string jsonData = System.Text.Json.JsonSerializer.Serialize(spending, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(filePath, jsonData);
        }
    }
}
