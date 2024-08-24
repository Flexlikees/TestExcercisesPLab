/* 
 * аргументы командной строки:
 * task4\numbers.txt
*/

using System;
using System.IO;

class program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Ошибка: укажите файл с элементами массива в качестве аргумента командной строки");
            return;
        }

        string numbersPath = args[0];

        List<int> mas;
        try
        {
            mas = File.ReadAllLines(numbersPath)
                          .Select(line => int.Parse(line))
                          .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return;
        }

        if (mas.Count == 0)
        {
            Console.WriteLine("Ошибка: указанный файл не содержит чисел");
            return;
        }

        mas.Sort();
        int median = mas[mas.Count / 2];

        int moves = mas.Sum(num => Math.Abs(num - median));

        Console.WriteLine($"Полученный массив: [{string.Join(", ", mas)}]\n");
        Console.WriteLine("Минимальное количество ходов, требуемых для приведения всех элементов к одному числу: " + moves);
    }
}