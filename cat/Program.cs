using System.Drawing;
using Pastel;

public class Program
{
    public static void Main(string[] args)
    {
        CatCommand(args);
    }
    public static void CatCommand(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Не указан файл для просмотра");
            return;
        }
        if (args[0] == "-h" || args[0] == "-help")
        {
            Console.WriteLine("Справка: Эта команда выводит содержимое файла.\n" +
                              "cat <file> - показать содержимое файла");
            return;
        }

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), args[0]);

        try
        {
            Console.WriteLine($"Содержимое файла {filePath}:".Pastel(Color.Green));
            Console.WriteLine("----------------------------------------");
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("----------------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
