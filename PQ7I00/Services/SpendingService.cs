using PQ7I00.APP.Spendings;
using PQ7I00.Models.Spendings;

namespace PQ7I00.Services
{
    // client can cancel the methods
    public class SpendingService
    {
        private readonly ISpendingRepository _spendingRepo;

        public SpendingService
            (
            ISpendingRepository spendingRepository
            )
        {
            _spendingRepo = spendingRepository;
        }


        // list all
        //public Task<List<Spending>> ListSpendingsAsync()
        


        // find



        // create




    }
}
