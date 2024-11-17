using PQ7I00.Shared;

namespace PQ7I00.APP.Model.Spendings.DTOs
{
    public class SpendingCreateDTO
    {
        public string Name { get; set; }
        public decimal AmountInHUF { get; set; }
        public CostCategory Category { get; set; }
        public string Comment { get; set; }
    }
}
