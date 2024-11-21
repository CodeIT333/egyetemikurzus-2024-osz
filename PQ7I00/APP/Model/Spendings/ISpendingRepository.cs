using PQ7I00.Shared;

namespace PQ7I00.APP.Model.Spendings
{
    public interface ISpendingRepository
    {
        Task<List<Spending>> ListByCategoryAsync(CostCategory costCategory);
        Task AddAsync(Spending spending);
    }
}
