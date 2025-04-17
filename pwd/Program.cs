public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
            PwdCommand();
        else if (args.Length == 1 && (args[0] == "--help" || args[0] == "-h"))
            Console.WriteLine("Справка: Эта команда выводит текущую директорию.");
        else
            Console.WriteLine("Команда pwd без параметров!");
    }
    public static void PwdCommand()
    {
        Console.WriteLine($"Текущая директория: {Directory.GetCurrentDirectory()}");
    }
}