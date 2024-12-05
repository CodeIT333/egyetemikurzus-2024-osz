using PQ7I00.Shared;

namespace PQ7I00.APP.Model.Spendings.DTOs
{
    public class SpendingListByCategoryDTO
    {
        public CostCategory? costCategory { get; set; }
        public List<SpendingListDTO> spendings  { get; set; }
    }
}
