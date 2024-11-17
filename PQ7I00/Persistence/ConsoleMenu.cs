namespace PQ7I00.Persistence
{
    public static class ConsoleMenu
    {
        // add | list by categories | list by date (week, mounth, 1 year, 5 years)
        
        public static int Menu()
        {
            Console.WriteLine("Welcome to the personal cost-tracking application!");
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Add a new spending");
            Console.WriteLine("2. List spendings by category");
            Console.WriteLine("3. List spendings by date");
            Console.WriteLine("4. Exit");

            int selectedAction;
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out selectedAction);
                if (selectedAction >= 1 && selectedAction <= 4)
                    break;

                Console.WriteLine("Invalid input. Please enter a correct action value.");
            }

            return selectedAction;
        }

        public static void Exit()
        {
            Console.WriteLine("Press a button to exit.");
            Console.ReadKey();
        }
    }
}
