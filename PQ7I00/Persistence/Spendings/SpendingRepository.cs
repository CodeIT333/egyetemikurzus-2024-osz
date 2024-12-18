﻿using PQ7I00.APP.Model.Spendings;
using PQ7I00.Persistence;
using PQ7I00.Shared;

namespace PQ7I00.Repositories.Spendings
{
    internal class SpendingRepository : ISpendingRepository
    {
        public async Task<List<Spending>> ListByCategoryAsync(CostCategory? costCategory) => await FileManager.ListByCategoryAsync(costCategory);
        public async Task<List<Spending>> ListByDateAsync(int number, DateFilter? dateFilter) => await FileManager.ListByDateAsync(number, dateFilter);
        public async Task AddAsync(Spending spending) => await FileManager.AddSpendingAsync(spending);
    }
}
