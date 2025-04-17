using Pastel;
using System.Drawing;

public class Program
{
    public static void Main(string[] args)
    {
        MyMkdirCommand(args);
    }
    public static void MyMkdirCommand(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Не указано имя директории".Pastel(Color.Red));
            return;
        }

        if (args[0] == "-h" || args[0] == "-help")
        {
            Console.WriteLine("Справка: Эта команда создаёт директорию (папку) в текущей директории.\n" +
                              "mymkdir <folder> - создать директорию (папку) по имени <folder>");
            return;
        }

        string dirName = args[0];
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), dirName);

        try
        {
            Directory.CreateDirectory(fullPath);
            Console.WriteLine($"Директория создана: {fullPath}".Pastel(Color.Green));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}".Pastel(Color.Red));
        }
    }
}
