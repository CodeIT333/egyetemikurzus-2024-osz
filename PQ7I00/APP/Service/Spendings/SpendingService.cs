using PQ7I00.APP.Model.Spendings;
using PQ7I00.APP.Model.Spendings.DTOs;

namespace PQ7I00.APP.Service.Spendings
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


        // list by categories | date (week, mounth, 1 year, 5 years)



        // find



        // create
        public async Task AddSpendingAsync(SpendingCreateDTO dto)
        {
            var spending = Spending.Create(dto.Name, dto.AmountInHUF, dto.Category, dto.Comment);

            await _spendingRepo.AddAsync(spending);
        }



    }
}
