using PQ7I00.APP.Model.Spendings;
using PQ7I00.APP.Model.Spendings.DTOs;
using PQ7I00.Shared;

namespace PQ7I00.APP.Application.Spendings
{
    // TODO: client can cancel the methods
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


        // list by categories
        public async Task<List<SpendingDTO>> ListSpendingsByCategoriesAsync(CostCategory costCategory)
        {
            var spendings = (await _spendingRepo.ListByCategoryAsync(costCategory))
                .Select(x => new SpendingDTO
                {
                    name = x.Name,
                    amountInHUF = x.AmountInHUF,
                    category = x.Category,
                    comment = x.Comment,
                })
                .ToList();

            return spendings == null ? new() : spendings;
        }

        // list by date (week, mounth, 1 year, 5 years)


        // find



        // create
        public async Task AddSpendingAsync(SpendingDTO dto)
        {
            var spending = Spending.Create(dto.name, dto.amountInHUF, dto.category, dto.comment);

            await _spendingRepo.AddAsync(spending);
        }



    }
}
