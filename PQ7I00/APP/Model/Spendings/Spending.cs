using PQ7I00.Shared;

namespace PQ7I00.APP.Model.Spendings
{
    public class Spending
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // később akár lehetne deviza kategória is
        public decimal AmountInHUF { get; set; }
        public CostCategory Category { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }


        public static Spending Create(string name, decimal amountInHUF, CostCategory category, string comment)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = name,
                AmountInHUF = amountInHUF,
                Category = category,
                Date = DateTime.UtcNow,
                Comment = comment
            };
        }
    }
}
