
using System;
using System.IO;

class FileExplorer
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Консольный файловый проводник ===");
            Console.WriteLine("1. Просмотр доступных дисков");
            Console.WriteLine("2. Выход");
            Console.Write("Выберите действие: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowDrives();
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }
    }

    static void ShowDrives()
    {
        var drives = DriveInfo.GetDrives();
        Console.Clear();
        Console.WriteLine("=== Доступные диски ===");

        for (int i = 0; i < drives.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {drives[i].Name} ({drives[i].DriveType})");
        }

        Console.Write("Выберите диск: ");
        if (int.TryParse(Console.ReadLine(), out int driveChoice) && driveChoice > 0 && driveChoice <= drives.Length)
        {
            ExploreDirectory(drives[driveChoice - 1].RootDirectory.FullName);
        }
        else
        {
            Console.WriteLine("Неверный выбор.");
            Console.ReadKey();
        }
    }

    static void ExploreDirectory(string path)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Текущий путь: {path}");

            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            Console.WriteLine("\nКаталоги:");
            for (int i = 0; i < dirs.Length; i++)
                Console.WriteLine($"[D] {i + 1}. {Path.GetFileName(dirs[i])}");

            Console.WriteLine("\nФайлы:");
            for (int i = 0; i < files.Length; i++)
                Console.WriteLine($"[F] {i + 1}. {Path.GetFileName(files[i])}");

            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Перейти в каталог");
            Console.WriteLine("2. Вернуться назад");
            Console.WriteLine("3. Открыть файл");
            Console.WriteLine("4. Создать каталог");
            Console.WriteLine("5. Создать файл");
            Console.WriteLine("6. Удалить файл/каталог");
            Console.WriteLine("7. Назад к списку дисков");
            Console.Write("Выберите действие: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Введите имя каталога: ");
                    string dirName = Console.ReadLine();
                    string newPath = Path.Combine(path, dirName);
                    if (Directory.Exists(newPath))
                        path = newPath;
                    else
                        Console.WriteLine("Каталог не найден.");
                    Console.ReadKey();
                    break;
                case "2":
                    if (Directory.GetParent(path) != null)
                        path = Directory.GetParent(path).FullName;
                    break;
                case "3":
                    Console.Write("Введите имя файла: ");
                    string fileName = Console.ReadLine();
                    string filePath = Path.Combine(path, fileName);
                    if (File.Exists(filePath))
                    {
                        Console.Clear();
                        Console.WriteLine(File.ReadAllText(filePath));
                    }
                    else
                        Console.WriteLine("Файл не найден.");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.Write("Введите имя нового каталога: ");
                    string newDir = Console.ReadLine();
                    Directory.CreateDirectory(Path.Combine(path, newDir));
                    break;
                case "5":
                    Console.Write("Введите имя нового файла: ");
                    string newFile = Console.ReadLine();
                    Console.WriteLine("Введите содержимое файла:");
                    string content = Console.ReadLine();
                    File.WriteAllText(Path.Combine(path, newFile), content);
                    break;
                case "6":
                    Console.Write("Введите имя файла или каталога для удаления: ");
                    string target = Console.ReadLine();
                    string targetPath = Path.Combine(path, target);
                    if (File.Exists(targetPath))
                    {
                        Console.Write("Удалить файл? (y/n): ");
                        if (Console.ReadLine().ToLower() == "y")
                            File.Delete(targetPath);
                    }
                    else if (Directory.Exists(targetPath))
                    {
                        Console.Write("Удалить каталог со всем содержимым? (y/n): ");
                        if (Console.ReadLine().ToLower() == "y")
                            Directory.Delete(targetPath, true);
                    }
                    else
                        Console.WriteLine("Объект не найден.");
                    Console.ReadKey();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Неверный ввод.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
