using Pastel;
using System.Drawing;

public class Program
{
    public static void Main(string[] args)
    {
        CpCommand(args);
    }
    public static void CpCommand(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Не указаны исходный и целевой файлы".Pastel(Color.Red));
            return;
        }

        if (args[0] == "-h" || args[0] == "-help")
        {
            Console.WriteLine("Справка: Эта команда копирует файлы, определённой директории.\n" +
                              "cp <source> <dest> - копировать файлы из <source> в <dest>");
            return;
        }

        string source = Path.Combine(Directory.GetCurrentDirectory(), args[0]);
        string destination = Path.Combine(Directory.GetCurrentDirectory(), args[1]);

        try
        {
            if (Directory.Exists(source))
            {
                CopyDirectory(source, destination);
                Console.WriteLine($"Директория скопирована из {source} в {destination}".Pastel(Color.Green));
            }
            else if (File.Exists(source))
            {
                File.Copy(source, destination, true);
                Console.WriteLine($"Файл скопирован из {source} в {destination}".Pastel(Color.Green));
            }
            else
            {
                Console.WriteLine($"Исходный файл или директория не найдены: {source}".Pastel(Color.Red));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}".Pastel(Color.Red));
        }
    }

    private static void CopyDirectory(string sourceDir, string destDir)
    {
        Directory.CreateDirectory(destDir);

        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(destDir, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        foreach (string subDir in Directory.GetDirectories(sourceDir))
        {
            string destSubDir = Path.Combine(destDir, Path.GetFileName(subDir));
            CopyDirectory(subDir, destSubDir);
        }
    }
}
