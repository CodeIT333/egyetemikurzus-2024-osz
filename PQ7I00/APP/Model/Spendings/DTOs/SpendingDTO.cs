using PQ7I00.Shared;

namespace PQ7I00.APP.Model.Spendings.DTOs
{
    public class SpendingDTO
    {
        public string name { get; set; }
        public decimal amountInHUF { get; set; }
        public CostCategory category { get; set; }
        public string comment { get; set; }
    }
}
