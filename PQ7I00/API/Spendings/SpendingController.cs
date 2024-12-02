using PQ7I00.APP.Application.Spendings;
using PQ7I00.APP.Model.Spendings.DTOs;
using PQ7I00.Persistence;
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
            ConsoleMenu.DisplayMessage("List spendings by category.");

            var costCategory = ConsoleMenu.ReadEnumInput<CostCategory>("Select a category:");

            var spendings = await _spendingService.ListSpendingsByCategoriesAsync(costCategory);

            if (!spendings.Any()) ConsoleMenu.DisplayMessage("No spendings found in this category.");

            return spendings;
        }

        public async Task<List<SpendingDTO>> ListSpendingsByDateAsync()
        {
            ConsoleMenu.DisplayMessage("List spendings by date.");

            string measurement = ConsoleMenu.ReadValidatedInput(
                "Select to list spendings by date in days (d) or in years (y).",
                value => (value.ToLower().Equals("d") || value.ToLower().Equals("y"), value),
                "Invalid input. Please enter a 'd' or 'y' character.");

            int number = ConsoleMenu.ReadValidatedInput(
                "Add how many days or years of spendings you want to list.",
                value => (int.TryParse(value, out int result) && result > 0, result),
                "Invalid input. Please enter a positive number.");

            var spendings = await _spendingService.ListSpendingsByDateAsync(number, measurement);

            if (!spendings.Any()) ConsoleMenu.DisplayMessage("No spendings found in this interval.");

            return spendings;
        }

        public async Task AddSpendingAsync()
        {
            ConsoleMenu.DisplayMessage("Create a new spending.");

            string name = ConsoleMenu.ReadValidatedInput(
                "Spending name: ",
                value => (value.Length >= 3, value),
                "Invalid input. Please enter at least 3 characters.");

            decimal amountInHUF = ConsoleMenu.ReadValidatedInput(
                "Spending amount in HUF (10550.34): ",
                value => (decimal.TryParse(value, out decimal result) && result > 0, result),
                "Invalid input. Please enter a positive decimal value.");

            var costCategory = ConsoleMenu.ReadEnumInput<CostCategory>("Select a category:");
            string comment = ConsoleMenu.ReadInput("Comment (optional): ");

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
