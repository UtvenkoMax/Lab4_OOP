using System;

namespace Lab4
{
    // клас з методами-обробниками події
    public class QueueHandler
    {
        // обробник: повідомлення користувачу
        public void ShowMessage(object sender, QueueEventArgs e)
        {
            MyQueue q = (MyQueue)sender;
            Console.WriteLine();
            Console.WriteLine(">>> ПОДІЯ: черга \"" + q.Name + "\" очищена!");
            Console.WriteLine("    Причина: " + e.Message);
            Console.WriteLine("    Видалено елементів: " + e.RemovedCount);
            Console.WriteLine("    Час: " + e.Time.ToString("HH:mm:ss"));
            Console.WriteLine();
        }

        // ще один обробник: запис у "журнал"
        public void WriteLog(object sender, QueueEventArgs e)
        {
            MyQueue q = (MyQueue)sender;
            Console.WriteLine("[LOG] " + e.Time.ToString("HH:mm:ss") + " - " + q.Name + ": " + e.Message);
        }
    }
}
