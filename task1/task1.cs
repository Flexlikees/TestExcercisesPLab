using System;

class Program
{
    static void Main(string[] args)
    {

        if (args.Length < 2)
        {
            Console.WriteLine("Ошибка: задайте все необходимые аргументы командной строки (n, m)\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("FAQ: элементы массива от 1 до n; m - интервал движения по массиву");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        if (!int.TryParse(args[0], out int n) || !int.TryParse(args[1], out int m) || n < 1 || m < 1 || m > n)
        {
            Console.WriteLine("Ошибка: неверный формат аргументов командной строки \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("FAQ: n > 0; m > 0; m <= n");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Console.WriteLine($"Заданные аргументы: n = {n}, m = {m}\n");
        int[] mas = new int[n];
        Console.Write($"Круговой массив: ");
        for (int i = 0; i < n; i++)
        {
            mas[i] = i + 1;
            Console.Write(mas[i]);
        }

        string path = "";
        int idx = 0;

        do
        {
            path += mas[idx];
            idx = (idx + m - 1) % n;
        }
        while (idx != 0);

        Console.WriteLine("\n\nПолученный путь: " + path);
    }
}
