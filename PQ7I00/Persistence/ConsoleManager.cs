using PQ7I00.APP.Model.Spendings.DTOs;
using PQ7I00.Shared;

namespace PQ7I00.Persistence
{
    public static class ConsoleManager
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
            Console.WriteLine("Select an action by writing a number:");
            Console.WriteLine("1. Add a new spending");
            Console.WriteLine("2. List spendings by category");
            Console.WriteLine("3. List spendings by date");
            Console.WriteLine("4. Refresh console (clear)");
            Console.WriteLine("5. Exit");

            int selectedAction;
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    selectedAction = 4;
                    break;
                }
                else
                {
                    Int32.TryParse(input, out selectedAction);
                    if (selectedAction >= 1 && selectedAction <= 5)
                        break;

                    Console.WriteLine("Invalid input. Please enter a correct action value.");
                }

            }

            return selectedAction;
        }

        public static void ListByCategoryTitle(CostCategory? category)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"List by {(category.HasValue ? category.ToString() : "all categories")}");
        }

        public static void ListByDateTitle(DateFilter? filter, int number)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(
                $"List by {
                (filter.HasValue ? 
                    $"the last {number}" : 
                    string.Empty
                )} {
                (filter.HasValue ? 
                    (number == 1) ? 
                        filter.ToString().ToLower().TrimEnd('s') : 
                        filter.ToString().ToLower() : 
                    "all dates")
                }");
        }

        public static void List(List<SpendingListDTO> spendings)
        {
            Console.WriteLine(new string('-', 40));

            foreach (var spending in spendings)
            {
                Console.WriteLine($"Name: {spending.name}");
                Console.WriteLine($"Amount: {spending.amountInHUF:C}");
                Console.WriteLine($"Date: {spending.date.ToString("yyyy MM dd")}");
                if (!string.IsNullOrWhiteSpace(spending.comment)) Console.WriteLine($"Comment: {spending.comment}");
                Console.WriteLine(new string('-', 40));
            }
        }

        public static void Sum(List<SpendingListDTO> spendings)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Summary: {spendings.Sum(x => x.amountInHUF):C}");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string ReadInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine()?.Trim() ?? string.Empty;
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
                Console.WriteLine(error);
            }
        }

        public static T? ReadEnumInput<T>(string prompt) where T : struct, Enum
        {
            Console.WriteLine(prompt);

            Console.WriteLine("List all: 0 or Enter");
            foreach (var type in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }

            return ReadValidatedInput(
                "Enter a valid number: ",
                input =>
                {
                    if (string.IsNullOrWhiteSpace(input) || input.Equals("0"))
                    {
                        return (true, (T?)null);
                    }

                    if (int.TryParse(input, out int result) && Enum.IsDefined(typeof(T), result))
                    {
                        return (true, (T)(object)result);
                    }

                    return (false, default(T?));
                },
                "Invalid input. Please enter a valid number."
            );
        }

        public static void Refresh()
        {
            Console.Clear();
        }

        public static void WaitForRefresh()
        {
            Console.WriteLine("Press a button to refresh the console.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void Exit()
        {
            Console.WriteLine("Press a button to exit.");
            Console.ReadKey();
        }
    }
}
