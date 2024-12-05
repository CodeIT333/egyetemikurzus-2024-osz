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

        public async Task<SpendingListByCategoryDTO> ListSpendingsByCategoryAsync()
        {
            ConsoleManager.DisplayMessage("List spendings by category.");

            var costCategory = ConsoleManager.ReadEnumInput<CostCategory>("Select a category:");

            var spendings = await _spendingService.ListSpendingsByCategoriesAsync(costCategory);

            if (!spendings.Any())
                ConsoleManager.DisplayMessage(costCategory.HasValue ? "No spendings found in this category." : "No spendings found.");

            return new()
            {
                costCategory = costCategory,
                spendings = spendings
            };
        }

        public async Task<SpendingListByDateDTO> ListSpendingsByDateAsync()
        {
            ConsoleManager.DisplayMessage("List spendings by date.");
            var dateFilter = ConsoleManager.ReadEnumInput<DateFilter>("Select to list spendings by:");

            int number = dateFilter.HasValue ?
                ConsoleManager.ReadValidatedInput(
                    $"Add how many {dateFilter.Value.ToString().ToLower()} of spendings you want to list.",
                    value => (int.TryParse(value, out int result) && result > 0, result),
                    "Invalid input. Please enter a positive number.") :
                0;

            var spendings = await _spendingService.ListSpendingsByDateAsync(number, dateFilter);

            if (!spendings.Any()) ConsoleManager.DisplayMessage("No spendings found in this interval.");

            return new()
            {
                dateFilter = dateFilter,
                number = number,
                spendings = spendings
            };
        }

        public async Task AddSpendingAsync()
        {
            ConsoleManager.DisplayMessage("Create a new spending.");

            string name = ConsoleManager.ReadValidatedInput(
                "Spending name: ",
                value => (value.Length >= 3, value),
                "Invalid input. Please enter at least 3 characters.");

            decimal amountInHUF = ConsoleManager.ReadValidatedInput(
                "Spending amount in HUF (10550.34): ",
                value => (decimal.TryParse(value, out decimal result) && result > 0, result),
                "Invalid input. Please enter a positive decimal value.");

            var costCategory = ConsoleManager.ReadEnumInput<CostCategory>("Select a category:");
            string comment = ConsoleManager.ReadInput("Comment (optional): ");

            SpendingCreateDTO dto = new()
            {
                name = name,
                amountInHUF = amountInHUF,
                category = costCategory ?? CostCategory.Other,
                comment = comment
            };

            await _spendingService.AddSpendingAsync(dto);
        }
    }
}
