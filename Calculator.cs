public class Calculator
{
    public static void Start()
    {
        Console.WriteLine("Starting Calculator Application...");

        Console.WriteLine("What would you like to calculate?");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");

        string? choiceString = Console.ReadLine();
        if (choiceString == null)
        {
            Console.WriteLine("You must enter a valid argument: 1, 2, 3 or 4.");
            return;
        }

        int choice = -1;
        try
        {
            choice = Int32.Parse(choiceString);
        }
        catch (FormatException)
        {
            Console.WriteLine("You must enter a valid argument: 1, 2, 3 or 4.");
            return;
        }

        if (choice < 1 || choice > 4)
        {
            Console.WriteLine("You must enter a valid argument: 1, 2, 3 or 4.");
            return;
        }

        Console.WriteLine("Please enter a number:");
        string? firstNumString = Console.ReadLine();
        if (firstNumString == null)
        {
            Console.WriteLine("You must enter a valid number.");
            return;
        }

        Console.WriteLine("Please enter another number:");
        string? secondNumString = Console.ReadLine();

        if (secondNumString == null)
        {
            Console.WriteLine("You must enter a valid number.");
            return;
        }

        int firstNum = 0;
        int secondNum = 0;
        try
        {
            firstNum = Int32.Parse(firstNumString);
            secondNum = Int32.Parse(secondNumString);
        }
        catch (FormatException)
        {
            Console.WriteLine("You must enter valid numbers.");
            return;
        }

        if (choice == 1)
        {
            Console.WriteLine($"Result of {firstNum} + {secondNum} = {firstNum + secondNum}");
        }
        else if (choice == 2)
        {
            Console.WriteLine($"Result of {firstNum} - {secondNum} = {firstNum - secondNum}");
        }
        else if (choice == 3)
        {
            Console.WriteLine($"Result of {firstNum} * {secondNum} = {firstNum * secondNum}");
        }
        else if (choice == 4)
        {
            Console.WriteLine($"Result of {firstNum} / {secondNum} = {firstNum / secondNum}");
        }
        else
        {
            Console.WriteLine("You must enter a valid argument: 1, 2, 3 or 4.");
            return;
        }
    }
}
