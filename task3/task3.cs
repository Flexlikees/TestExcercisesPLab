/* 
 * Аргументы командной строки:
 * task3\values.json task3\tests.json task3\report.json
*/

using Newtonsoft.Json; // NuGet пакет
using Newtonsoft.Json.Linq; // NuGet пакет
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Ошибка: укажите все необходимые файлы в качестве аргументов командной строки\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("FAQ: values.json - результаты прохождения тестов; tests.json - структура для построения отчёта; report.json - результат");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        string valuesFilePath = args[0];
        string testsFilePath = args[1];
        string reportFilePath = args[2];

        var valuesJson = File.ReadAllText(valuesFilePath);
        var testsJson = File.ReadAllText(testsFilePath);

        JObject valuesObject = JObject.Parse(valuesJson);
        JObject testsObject = JObject.Parse(testsJson);

        var valuesDict = valuesObject["values"]
            .OfType<JObject>()
            .ToDictionary(v => (int)v["id"], v => (string)v["value"]);

        FillValues(testsObject, valuesDict);
        try
        {
            File.WriteAllText(reportFilePath, testsObject.ToString(Formatting.Indented));
            Console.WriteLine("Результат успешно записан в файл report.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex}");
        }
    }

    static void FillValues(JToken token, IDictionary<int, string> valuesDict)
    {
        if (token.Type == JTokenType.Object)
        {
            var obj = (JObject)token;

            if (obj["id"] != null && obj["value"] != null)
            {
                var id = (int)obj["id"];
                if (valuesDict.TryGetValue(id, out var value))
                {
                    obj["value"] = value;
                }
            }

            foreach (var property in obj.Properties())
            {
                FillValues(property.Value, valuesDict);
            }
        }
        else if (token.Type == JTokenType.Array)
        {
            foreach (var item in token.Children())
            {
                FillValues(item, valuesDict);
            }
        }
    }
}