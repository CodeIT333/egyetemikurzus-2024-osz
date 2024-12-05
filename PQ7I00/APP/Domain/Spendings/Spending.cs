using PQ7I00.Shared;

namespace PQ7I00.APP.Model.Spendings
{
    public class Spending
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal AmountInHUF { get; protected set; }
        public CostCategory Category { get; protected set; }
        public DateTime Date { get; protected set; }
        public string Comment { get; protected set; }


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
