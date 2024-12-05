using PQ7I00.Shared;

namespace PQ7I00.APP.Model.Spendings.DTOs
{
    public class SpendingListByDateDTO
    {
        public DateFilter? dateFilter { get; set; }
        public int number { get; set; }
        public List<SpendingListDTO> spendings { get; set; }
    }
}
