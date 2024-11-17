namespace PQ7I00.APP.Model.Spendings
{
    public interface ISpendingRepository
    {
        public Task AddAsync(Spending spending);
    }
}
