using System;

namespace Lab4
{
    // делегат для перевірки рядка
    delegate bool CheckString(string s);

    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Лабораторна робота 3.4. Варіант 6");
            Console.WriteLine();

            Part1();
            Part2();
        }

        // Завдання 1: визначення наявності літер у рядку
        static void Part1()
        {
            Console.WriteLine("=== Завдання 1. Наявність літер у рядку ===");

            // анонімний метод
            CheckString anon = delegate (string s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (char.IsLetter(s[i]))
                    {
                        return true;
                    }
                }
                return false;
            };

            // лямбда-вираз
            CheckString lambda = s =>
            {
                foreach (char c in s)
                {
                    if (char.IsLetter(c))
                        return true;
                }
                return false;
            };

            string[] tests = { "12345", "abc123", "Привіт", "!@# 2021", "" };

            foreach (string t in tests)
            {
                Console.WriteLine("Рядок \"" + t + "\":");
                Console.WriteLine("   анонімний метод: " + (anon(t) ? "є літери" : "немає літер"));
                Console.WriteLine("   лямбда-вираз:    " + (lambda(t) ? "є літери" : "немає літер"));
            }

            Console.Write("Введіть свій рядок: ");
            string input = Console.ReadLine();
            if (input == null)
            {
                input = "";
            }
            Console.WriteLine("Результат (лямбда): " + (lambda(input) ? "є літери" : "немає літер"));
            Console.WriteLine();
        }

        // Завдання 2-3: черга з подією "очищення черги"
        static void Part2()
        {
            Console.WriteLine("=== Завдання 2-3. Черга, подія очищення ===");

            MyQueue queue = new MyQueue("Q1");
            QueueHandler handler = new QueueHandler();

            // підписка на подію
            queue.Cleared += handler.ShowMessage;
            queue.Cleared += handler.WriteLog;

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Print();

            queue.Dequeue();
            queue.Print();
            Console.WriteLine("Перший елемент: " + queue.Peek());

            // очищення - спрацює подія
            queue.Clear();
            queue.Print();

            Console.WriteLine("--- Знову заповнюємо і забираємо по одному ---");
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Dequeue();
            queue.Dequeue(); // черга стане порожньою - подія

            // відписка від одного обробника
            queue.Cleared -= handler.WriteLog;
            Console.WriteLine("--- Відписались від WriteLog ---");
            queue.Enqueue(1);
            queue.Clear();

            // спроба забрати з порожньої черги
            try
            {
                queue.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
            Console.WriteLine();
        }
    }
}
