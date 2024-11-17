using PQ7I00.APP.Model.Spendings;
using PQ7I00.Persistence;

namespace PQ7I00.Repositories.Spendings
{
    internal class SpendingRepository : ISpendingRepository
    {
        public async Task AddAsync(Spending spending)
        {
            await FileManager.AddSpendingAsync(spending);
        }
    }
}
