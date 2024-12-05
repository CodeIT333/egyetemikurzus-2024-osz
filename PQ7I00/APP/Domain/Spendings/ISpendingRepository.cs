using PQ7I00.Shared;

namespace PQ7I00.APP.Model.Spendings
{
    public interface ISpendingRepository
    {
        Task<List<Spending>> ListByCategoryAsync(CostCategory? costCategory = null);
        Task<List<Spending>> ListByDateAsync(int number, DateFilter? dateFilter);
        Task AddAsync(Spending spending);
    }
}
