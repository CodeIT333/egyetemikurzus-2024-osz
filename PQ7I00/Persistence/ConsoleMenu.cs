using PQ7I00.APP.Model.Spendings.DTOs;

namespace PQ7I00.Persistence
{
    public static class ConsoleMenu
    {
        // TODO: add | list by categories | list by date (week, mounth, 1 year, 5 years)
        
        public static void WaitingProgress()
        {
            Console.WriteLine("Updating progress...");
            for (int i = 0; i <= 100; i += 10)
            {
                Console.SetCursorPosition(0, 1); // Move to the second line (row 1)
                Console.Write($"Progress: {i}%");
                Thread.Sleep(100); // Wait for 0.5 seconds
            }
            Console.Clear();
        }

        public static void ClearLastRows(int n)
        {
            if (n <= 0) return;

            int currentLineCursor = Console.CursorTop;

            for (int i = 0; i < n; i++)
            {
                // Move cursor up one line
                if (currentLineCursor - i >= 0)
                {
                    Console.SetCursorPosition(0, currentLineCursor - i);
                    Console.Write(new string(' ', Console.WindowWidth)); // Clear the line
                }
            }

            // Move the cursor back to the original position
            Console.SetCursorPosition(0, Math.Max(0, currentLineCursor - n));
        }

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

        public static T ReadEnumInput<T>(string prompt) where T : Enum
        {
            DisplayMessage(prompt);
            foreach (var type in Enum.GetValues(typeof(T)))
            {
                DisplayMessage($"{type}: {(int)type}");
            }

            return (T)(object)ReadValidatedInput(
                "Enter a valid number: ",
                input => (int.TryParse(input, out int result) && Enum.IsDefined(typeof(T), result), result),
                "Invalid input. Please enter a valid number.");
        }

        public static void Exit()
        {
            Console.WriteLine("Press a button to exit.");
            Console.ReadKey();
        }
    }
}
