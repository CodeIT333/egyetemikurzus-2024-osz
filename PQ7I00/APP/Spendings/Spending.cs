using PQ7I00.Shared;

namespace PQ7I00.Models.Spendings
{
    public class Spending
    {
        // később akár lehetne deviza kategória is
        public string Name { get; set; }
        public float AmountInHUF { get; set; }
        public CostCategory Category { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }


}
