/*using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("Задайте круговой массив от 1 до n. \nВведите n (n > 0): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("\nОшибка: неверный формат");
            Console.Write("\nВведите n (n > 0): ");
        }

        int[] mas = new int[n];
        Console.Write($"\nПолученный массив: ");
        for (int i = 0; i < n; i++)
        {
            mas[i] = i + 1;
            Console.Write(mas[i]);
        }

        Console.Write("\n\nЗадайте интервал движения по массиву - m. \nВведите m (m > 0, m < n): ");
        int m;
        while (!int.TryParse(Console.ReadLine(), out m) || m <= 0 || m > n)
        {
            Console.WriteLine("\nОшибка - неверный формат");
            Console.Write("\nУкажите m (m > 0, m < n): ");
        }

        string path = "";
        int idx = 0;

        do
        {
            path += mas[idx];
            idx = (idx + m - 1) % n;
        } 
        while (idx != 0);

        Console.WriteLine("Результирующий путь: " + path);
    }
}
*/