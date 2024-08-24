/* 
 * Аргументы командной строки:
 * task2\circle.txt task2\points.txt
*/

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Ошибка: укажите оба файла с информацией об окружности и точках в качестве аргументов командной строки");
            return;
        }

        string[] circleInfo = File.ReadAllLines(args[0]);
        string[] centerCoords = circleInfo[0].Split(' ');
        double centerX = double.Parse(centerCoords[0]);
        double centerY = double.Parse(centerCoords[1]);
        double radius = double.Parse(circleInfo[1]);

        string[] points = File.ReadAllLines(args[1]);

        foreach (var point in points)
        {
            string[] pointCoords = point.Split(' ');
            double pointX = double.Parse(pointCoords[0]);
            double pointY = double.Parse(pointCoords[1]);

            double distanceSquared = Math.Pow(pointX - centerX, 2) + Math.Pow(pointY - centerY, 2);
            double radiusSquared = Math.Pow(radius, 2);

            if (Math.Abs(distanceSquared - radiusSquared) < 1e-9)
            {
                Console.WriteLine(0); // Точка лежит на окружности
            }
            else if (distanceSquared < radiusSquared)
            {
                Console.WriteLine(1); // Точка внутри
            }
            else
            {
                Console.WriteLine(2); // Точка снаружи
            }
        }
    }
}