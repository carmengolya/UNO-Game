class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Game game = new Game();
        game.Start();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}