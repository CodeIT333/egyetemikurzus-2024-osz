using PQ7I00.APP.Model.Spendings;
using PQ7I00.APP.Model.Spendings.DTOs;
using PQ7I00.APP.Application.Spendings;
using PQ7I00.Shared;

namespace PQ7I00.API.Spendings
{
    public class SpendingController
    {
        private readonly SpendingService _spendingService;

        public SpendingController(SpendingService spendingService)
        {
            _spendingService = spendingService;
        }

        public async Task<List<SpendingDTO>> ListSpendingsByCategoryAsync()
        {
            Console.WriteLine("List spendings by category.");

            Console.WriteLine("Select a category.");
            foreach (var category in Enum.GetValues(typeof(CostCategory)))
            {
                Console.WriteLine($"{category}: {(int)category}");
            }
            CostCategory costCategory;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int categoryValue) && Enum.IsDefined(typeof(CostCategory), categoryValue))
                {
                    costCategory = (CostCategory)categoryValue;
                    break;
                }

                Console.WriteLine("Invalid input. Please select a valid category number.");
            }

            var spendings = await _spendingService.ListSpendingsByCategoriesAsync(costCategory);

            if (!spendings.Any()) Console.WriteLine("No Spendings yet.");

            return spendings;
        }

        public async Task AddSpendingAsync()
        {
            Console.WriteLine("Create a new spending.");

            Console.Write("Spending name: ");
            string name;
            while (true)
            {
                name = Console.ReadLine() ?? string.Empty;
                if (name.Length >= 3)
                    break;

                Console.WriteLine("Invalid input. Please enter minimum 3 character for the spending name.");
            }

            Console.Write("Spending amount in HUF (10550.34): ");
            decimal amountInHUF;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out amountInHUF) && amountInHUF > 0)
                    break;

                Console.WriteLine("Invalid input. Please enter a positive decimal value.");
            }

            Console.WriteLine("Select a category.");
            foreach (var category in Enum.GetValues(typeof(CostCategory)))
            {
                Console.WriteLine($"{category}: {(int)category}");
            }

            Console.Write("Category number: ");
            CostCategory costCategory;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int categoryValue) && Enum.IsDefined(typeof(CostCategory), categoryValue))
                {
                    costCategory = (CostCategory)categoryValue;
                    break;
                }

                Console.WriteLine("Invalid input. Please select a valid category number.");
            }

            Console.Write("Comment (optional): ");
            string comment = Console.ReadLine() ?? string.Empty;


            SpendingDTO dto = new()
            {
                name = name,
                amountInHUF = amountInHUF,
                category = costCategory,
                comment = comment
            };

            await _spendingService.AddSpendingAsync(dto);
        }
    }
}
