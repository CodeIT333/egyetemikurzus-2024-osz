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
            ISpendingRepository spendingRepository = new SpendingRepository();
            SpendingService spendingService = new SpendingService(spendingRepository);
            SpendingController spendingController = new SpendingController(spendingService);

            switch (ConsoleMenu.Menu())
            {
                case 1:
                    // add new
                    await spendingController.AddSpendingAsync();
                    break;
                case 2:
                    var spendings = await spendingController.ListSpendingsByCategoryAsync();
                    if (!spendings.Any()) ConsoleMenu.Exit();
                    else ConsoleMenu.List(spendings);
                    // ConsoleMenu again
                    break;
                case 3:
                    // list by date
                    break;
                case 4:
                    // exit
                    ConsoleMenu.Exit();
                    break;
            }

        }

    }

}


