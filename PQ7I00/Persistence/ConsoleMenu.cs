using PQ7I00.APP.Model.Spendings.DTOs;

namespace PQ7I00.Persistence
{
    public static class ConsoleMenu
    {
        // TODO: add | list by categories | list by date (week, mounth, 1 year, 5 years)
        
        public static int Menu()
        {
            Console.WriteLine("Welcome to the personal cost-tracking application!");
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Add a new spending");
            Console.WriteLine("2. List spendings by category");
            Console.WriteLine("3. List spendings by date");
            Console.WriteLine("4. Refresh console (clear)");
            Console.WriteLine("5. Exit");

            int selectedAction;
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out selectedAction);
                if (selectedAction >= 1 && selectedAction <= 5)
                    break;

                Console.WriteLine("Invalid input. Please enter a correct action value.");
            }

            return selectedAction;
        }

        public static void List(List<SpendingDTO> spendings)
        {
            Console.WriteLine(new string('-', 40));

            foreach (var spending in spendings)
            {
                Console.WriteLine($"Name: {spending.name}");
                Console.WriteLine($"Amount: {spending.amountInHUF:C}");
                Console.WriteLine($"Comment: {spending.comment}");
                Console.WriteLine(new string('-', 40));
            }
        }

        public static void Refresh()
        {
            Console.Clear();
        }

        public static void Exit()
        {
            Console.WriteLine("Press a button to exit.");
            Console.ReadKey();
        }
    }
}
