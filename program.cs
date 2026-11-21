using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        const int size = 50_000_000;
        const int accesses = 50_000_000;

        Console.WriteLine("Заполняем массив...");
        int[] data = new int[size];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = i;
        }

        Console.WriteLine("Прогрев...");
        RunTest("Прогрев", data, 1, 10_000_000);

        int[] steps = { 1, 2, 4, 8, 16, 32, 64 };
        Console.WriteLine("\nЗамеры по шагам:");

        foreach (int step in steps)
        {
            RunTest($"Шаг {step}", data, step, accesses);
        }

        Console.WriteLine("\nГотово.");
    }

    static void RunTest(string label, int[] data, int step, int accesses)
    {
        long sum = 0;
        int idx = 0;
        int len = data.Length;

        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < accesses; i++)
        {
            sum += data[idx];
            idx += step;
            if (idx >= len)
            {
                idx -= len;
            }
        }
        sw.Stop();

        Console.WriteLine($"{label}: {sw.ElapsedMilliseconds} мс (sum={sum})");
    }
}
