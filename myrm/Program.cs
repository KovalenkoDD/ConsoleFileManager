using Pastel;
using System.Drawing;

public class Program
{
    public static void Main(string[] args)
    {
        MyRmCommand(args);
    }
    public static void MyRmCommand(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Не указан файл или директория для удаления".Pastel(Color.Red));
            return;
        }

        if (args[0] == "-h" || args[0] == "-help")
        {
            Console.WriteLine("Справка: Эта команда удаляет директорию (папку) или файл.\n" +
                              "myrm <path> - удалить файл или директорию по пути <path>");
            return;
        }

        string target = Path.Combine(Directory.GetCurrentDirectory(), args[0]);

        try
        {
            if (Directory.Exists(target))
            {
                Directory.Delete(target, true);
                Console.WriteLine($"Директория удалена: {target}".Pastel(Color.Green));
            }
            else if (File.Exists(target))
            {
                File.Delete(target);
                Console.WriteLine($"Файл удален: {target}".Pastel(Color.Green));
            }
            else
            {
                Console.WriteLine($"Файл или директория не найдены: {target}".Pastel(Color.Red));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}".Pastel(Color.Red));
        }
    }
}
