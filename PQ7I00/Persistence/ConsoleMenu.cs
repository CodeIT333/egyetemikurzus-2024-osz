using PQ7I00.APP.Model.Spendings.DTOs;

namespace PQ7I00.Persistence
{
    public static class ConsoleMenu
    {        
        public static void WaitingProgress()
        {
            Console.WriteLine("Loading...");
            for (int i = 0; i <= 100; i += 10)
            {
                Console.SetCursorPosition(0, 1);
                Console.Write($"Progress: {i}%");
                Thread.Sleep(100);
            }
            Console.Clear();
        }

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

        public static void Sum(List<SpendingDTO> spendings)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Summary: {spendings.Sum(x => x.amountInHUF)}");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string ReadInput(string prompt)
        {
            DisplayMessage(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public static T ReadValidatedInput<T>(string prompt, Func<string, (bool isValid, T result)> parseAndValidate, string error)
        {
            while (true)
            {
                string input = ReadInput(prompt);
                var (isValid, result) = parseAndValidate(input);
                if (isValid)
                {
                    return result;
                }
                DisplayMessage(error);
            }
        }

        public static T ReadEnumInput<T>(string prompt, bool canAcceptInvalidInput = false) where T : Enum
        {
            Console.WriteLine(prompt);
            foreach (var type in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"{type}: {(int)type}");
            }

            if (canAcceptInvalidInput)
            {
                //TODO int input = int.TryParse(Console.ReadLine());
            }

            return (T)(object)ReadValidatedInput(
                "Enter a valid number: ",
                input => (int.TryParse(input, out int result) && Enum.IsDefined(typeof(T), result), result),
                "Invalid input. Please enter a valid number.");
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
