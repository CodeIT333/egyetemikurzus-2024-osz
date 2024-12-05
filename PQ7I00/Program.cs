using PQ7I00.API.Spendings;
using PQ7I00.APP.Model.Spendings;
using PQ7I00.APP.Application.Spendings;
using PQ7I00.Persistence;
using PQ7I00.Repositories.Spendings;

namespace PQ7I00
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConsoleManager.WaitingProgress();

            ISpendingRepository spendingRepository = new SpendingRepository();
            SpendingService spendingService = new SpendingService(spendingRepository);
            SpendingController spendingController = new SpendingController(spendingService);

            bool run = true;
            while (run)
            {
                switch (ConsoleManager.Menu())
                {
                    case 1:
                        // add new
                        await spendingController.AddSpendingAsync();
                        ConsoleManager.Refresh();
                        break;
                    case 2:
                        // list by category
                        var spendingsByCategory = await spendingController.ListSpendingsByCategoryAsync();
                        ConsoleManager.ListByCategoryTitle(spendingsByCategory.costCategory);
                        ConsoleManager.List(spendingsByCategory.spendings);
                        ConsoleManager.Sum(spendingsByCategory.spendings);
                        ConsoleManager.WaitForRefresh();
                        break;
                    case 3:
                        // list by date
                        var spendingsByDate = await spendingController.ListSpendingsByDateAsync();
                        ConsoleManager.ListByDateTitle(spendingsByDate.dateFilter, spendingsByDate.number);
                        ConsoleManager.List(spendingsByDate.spendings);
                        ConsoleManager.Sum(spendingsByDate.spendings);
                        ConsoleManager.WaitForRefresh();
                        break;
                    case 4:
                        // clear console
                        ConsoleManager.Refresh();
                        break;
                    case 5:
                        // exit
                        ConsoleManager.Exit();
                        run = false;
                        break;
                }

            }

        }

    }

}


