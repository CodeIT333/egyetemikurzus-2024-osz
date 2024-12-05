using PQ7I00.APP.Model.Spendings;
using PQ7I00.APP.Model.Spendings.DTOs;
using PQ7I00.Shared;

namespace PQ7I00.APP.Application.Spendings
{
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
        public async Task<List<SpendingListDTO>> ListSpendingsByCategoriesAsync(CostCategory? costCategory)
        {
            var spendings = (await _spendingRepo.ListByCategoryAsync(costCategory))
                .Select(x => new SpendingListDTO
                {
                    name = x.Name,
                    amountInHUF = x.AmountInHUF,
                    category = x.Category,
                    comment = x.Comment,
                    date = x.Date
                })
                .ToList();

            return spendings == null ? new() : spendings;
        }

        // list by date (days or years)
        public async Task<List<SpendingListDTO>> ListSpendingsByDateAsync(int number, DateFilter? dateFilter)
        {
            var spendings = (await _spendingRepo.ListByDateAsync(number, dateFilter))
                .Select(x => new SpendingListDTO
                {
                    name = x.Name,
                    amountInHUF = x.AmountInHUF,
                    category = x.Category,
                    comment = x.Comment,
                    date = x.Date
                })
                .ToList();

            return spendings == null ? new() : spendings;
        }

        // create
        public async Task AddSpendingAsync(SpendingCreateDTO dto)
        {
            var spending = Spending.Create(dto.name, dto.amountInHUF, dto.category, dto.comment);

            await _spendingRepo.AddAsync(spending);
        }

    }
}
