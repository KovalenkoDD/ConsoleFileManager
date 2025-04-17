using Pastel;
using System.Drawing;


public class Program
{
    public static void Main(string[] args)
    {
        LsCommand(args);
    }
    public static void LsCommand(string[] args)
    {
        string path = Directory.GetCurrentDirectory();
        bool detailed = false;
        bool showHidden = false;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-l")
            {
                detailed = true;
                continue;
            }
            else if (args[i] == "-a")
            {
                showHidden = true;
                continue;
            }
            else if (!args[i].StartsWith("-") && i == args.Length - 1)
            {
                path = args[i];
            }
            else if (args[i] == "-h" || args[i] == "-help")
            {
                Console.WriteLine("Справка: Эта команда выводит содержимое текущей директории.\n" +
                                  "\t-l подробный вывод\n" +
                                  "\t-a показать скрытые файлы");
                return;
            }

        }

        try
        {
            if (detailed)
            {
                DetailedLs(path, showHidden);
            }
            else
            {
                SimpleLs(path, showHidden);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}".Pastel(Color.Red));
        }
    }

    private static void SimpleLs(string path, bool showHidden)
    {
        Console.WriteLine($"Содержимое директории {path}:");

        // Folders
        foreach (var dir in Directory.GetDirectories(path))
        {
            var dirInfo = new DirectoryInfo(dir);
            if (!showHidden && dirInfo.Attributes.HasFlag(FileAttributes.Hidden))
                continue;

            Console.Write($"{Path.GetFileName(dir)}/  ".Pastel(Color.Blue));
        }

        // Files
        foreach (var file in Directory.GetFiles(path))
        {
            var fileInfo = new FileInfo(file);
            if (!showHidden && fileInfo.Attributes.HasFlag(FileAttributes.Hidden))
                continue;

            Console.Write($"{fileInfo.Name}  ".Pastel(GetFileColor(fileInfo.Extension)));
        }

        Console.WriteLine();
    }

    private static void DetailedLs(string path, bool showHidden)
    {
        Console.WriteLine($"Содержимое директории {path}:");
        Console.WriteLine("Папки:".Pastel(Color.Blue));
        foreach (var dir in Directory.GetDirectories(path))
        {
            var dirInfo = new DirectoryInfo(dir);
            if (!showHidden && dirInfo.Attributes.HasFlag(FileAttributes.Hidden))
                continue;

            Console.WriteLine($"  {Path.GetFileName(dir)}/".Pastel(Color.Blue));
        }

        Console.WriteLine("\nФайлы:");
        foreach (var file in Directory.GetFiles(path))
        {
            var fileInfo = new FileInfo(file);
            if (!showHidden && fileInfo.Attributes.HasFlag(FileAttributes.Hidden))
                continue;

            Console.Write($"  {fileInfo.Name,-30}".Pastel(GetFileColor(fileInfo.Extension)));
            Console.WriteLine($" {fileInfo.Length,10} байт");
        }
    }

    private static Color GetFileColor(string extension)
    {
        return extension.ToLower() switch
        {
            ".exe" or ".dll" => Color.Yellow,
            ".txt" or ".md" or ".json" => Color.White,
            ".jpg" or ".png" or ".gif" => Color.Magenta,
            ".cs" or ".cpp" or ".h" => Color.Cyan,
            ".zip" or ".rar" or ".7z" => Color.DarkOrange,
            _ => Color.Gray,
        };
    }
}
