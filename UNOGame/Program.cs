class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("===============================");
        Console.WriteLine("          U N O   G A M E      ");
        Console.WriteLine("===============================\n");

        Console.WriteLine("1. Start New Game");
        Console.WriteLine("2. View Rules");
        Console.WriteLine("3. View Scores");
        Console.WriteLine("4. Exit\n");

        Console.WriteLine("Choose an option: ");
        int option = int.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1:
                Console.Clear();
                Game game = new Game();
                game.Start();
                Pause();
                break;

            case 2:
                Console.Clear();
                ShowRules();
                Pause();
                break;

            case 3:
                Console.Clear();
                ShowScores();
                Pause();
                break;

            case 4:
                Console.Clear();
                break;

            default:
                Console.WriteLine("[ERROR] Invalid option! Try again.");
                Pause();
                break;
        }        
    }

    static void ShowRules()
    {
        Console.WriteLine("============== RULES ==============");
        Console.WriteLine("- Match by colour or number.");
        Console.WriteLine("- Wild cards change colour.");
        Console.WriteLine("- +2 makes next player draw 2 cards.");
        Console.WriteLine("- Wild +4: change colour & next player draws 4.");
        Console.WriteLine("- First player to reach 500 points wins.");
        Console.WriteLine("===================================");
    }

    static void ShowScores()
    {
        Console.WriteLine("============== SCORES ==============");

        string filePath = "scores.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No scores found. Play a game first!");
            return;
        }

        var lines = File.ReadAllLines(filePath);

        if (lines.Length == 0)
        {
            Console.WriteLine("Scores file is empty.");
            return;
        }

        foreach (var line in lines)
        {
            Console.WriteLine("- " + line);
        }

        Console.WriteLine("====================================");
    }
    static void Pause()
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}