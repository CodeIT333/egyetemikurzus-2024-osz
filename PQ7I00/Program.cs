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
            ConsoleMenu.WaitingProgress();

            ISpendingRepository spendingRepository = new SpendingRepository();
            SpendingService spendingService = new SpendingService(spendingRepository);
            SpendingController spendingController = new SpendingController(spendingService);

            bool run = true;
            while (run)
            {
                switch (ConsoleMenu.Menu())
                {
                    case 1:
                        // add new
                        await spendingController.AddSpendingAsync();
                        break;
                    case 2:
                        // list by category
                        var spendingsByCategory = await spendingController.ListSpendingsByCategoryAsync();
                        if (!spendingsByCategory.Any()) ConsoleMenu.Refresh();
                        else ConsoleMenu.List(spendingsByCategory);
                        break;
                    case 3:
                        // list by date
                        var spendingsByDate = await spendingController.ListSpendingsByDateAsync();
                        if (!spendingsByDate.Any()) ConsoleMenu.Refresh();
                        else ConsoleMenu.List(spendingsByDate);
                        break;
                    case 4:
                        // clear console
                        ConsoleMenu.Refresh();
                        break;
                    case 5:
                        // exit
                        ConsoleMenu.Exit();
                        run = false;
                        break;
                }

                if (run) ConsoleMenu.Menu();
            }

            Console.ReadKey();
        }

    }

}


