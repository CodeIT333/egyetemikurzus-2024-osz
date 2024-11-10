using PQ7I00.Models.Spendings;

namespace PQ7I00.APP.Spendings
{
    public interface ISpendingRepository
    {
        public Task<Spending> FindAsync();
        public Task AddAsync(Spending spending);
    }
}
