public class Todo
{
    public static int IdCounter = 0;

    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }

    public Todo(string title, bool completed)
    {
        this.Id = IdCounter++;
        this.Title = title;
        this.Completed = completed;
    }

    public static List<Todo> todos = new List<Todo>();

    public static void Start()
    {
        Console.WriteLine("Starting Todo Application...");

        Console.WriteLine("The following commands are available:");
        PrintHelp();

        string? line = Console.ReadLine();
        while (line != null && !CompareStrings(line, "exit"))
        {
            ExecuteCommand(line);
            Console.WriteLine("-------------------");
            line = Console.ReadLine();
        }
    }

    public static void ExecuteCommand(string command)
    {
        string[] args = command.Split(" ");

        if (args.Length == 0)
        {
            return;
        }

        string action = args[0];

        if (CompareStrings(action, "help"))
        {
            PrintHelp();
        }
        else if (CompareStrings(action, "list"))
        {
            foreach (Todo todo in todos)
            {
                PrintTodo(todo);
            }
        }
        else if (CompareStrings(action, "add"))
        {
            if (args.Length <= 1)
            {
                Console.WriteLine("Usage: add <title>");
                return;
            }

            string title = "";
            for (int i = 1; i < args.Length; i++)
            {
                title += args[i] + " ";
            }

            title = title.Substring(0, title.Length - 1);

            Todo todo = new Todo(title, false);
            todos.Add(todo);

            Console.WriteLine("Created todo.");
            PrintTodo(todo);
        }
        else if (CompareStrings(action, "remove"))
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: remove <id>");
                return;
            }

            int id = -1;
            try
            {
                id = Int32.Parse(args[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("<id> must be a valid integer.");
                return;
            }

            Todo? todo = todos.Find(all => all.Id == id);
            if (todo == null)
            {
                Console.WriteLine($"A todo-item with id {id} was not found.");
                return;
            }

            todos.Remove(todo);
            Console.WriteLine($"Todo-item with id {id} and title {todo.Title} was removed.");
        }
        else if (CompareStrings(action, "uncomplete"))
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: uncomplete <id>");
                return;
            }

            int id = -1;
            try
            {
                id = Int32.Parse(args[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("<id> must be a valid integer.");
                return;
            }

            Todo? todo = todos.Find(all => all.Id == id);
            if (todo == null)
            {
                Console.WriteLine($"A todo-item with id {id} was not found.");
                return;
            }

            todo.Completed = false;
            Console.WriteLine(
                $"Todo-item with id {id} and title {todo.Title} was marked as uncompleted."
            );
        }
        else if (CompareStrings(action, "complete"))
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: complete <id>");
                return;
            }

            int id = -1;
            try
            {
                id = Int32.Parse(args[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("<id> must be a valid integer.");
                return;
            }

            Todo? todo = todos.Find(all => all.Id == id);
            if (todo == null)
            {
                Console.WriteLine($"A todo-item with id {id} was not found.");
                return;
            }

            todo.Completed = true;
            Console.WriteLine(
                $"Todo-item with id {id} and title {todo.Title} was marked as completed."
            );
        }
    }

    public static bool CompareStrings(string a, string b)
    {
        return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }

    public static void PrintTodo(Todo todo)
    {
        string completed = todo.Completed ? "Yes" : "No";
        Console.WriteLine($"Todo #{todo.Id}:");
        Console.WriteLine($"  Title: {todo.Title}");
        Console.WriteLine($"  Completed: {completed}");
    }

    public static void PrintHelp()
    {
        Console.WriteLine("help - Displays help information about the commands.");
        Console.WriteLine("list - List all todo-items in storage.");
        Console.WriteLine("add <title> - Add a new todo-item to storage.");
        Console.WriteLine("remove <id> - Remove a todo-item from storage.");
        Console.WriteLine("complete <id> - Mark a todo-item as completed.");
        Console.WriteLine("uncomplete <id> Unmark a todo-item as completed.");
        Console.WriteLine("exit - Exit the program.");
    }
}
