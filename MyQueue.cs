using System;
using System.Collections.Generic;

namespace Lab4
{
    // клас, в якому генерується подія
    public class MyQueue
    {
        private List<int> items;

        public string Name { get; }

        // подія "очищення черги"
        public event EventHandler<QueueEventArgs> Cleared;

        public MyQueue(string name)
        {
            Name = name;
            items = new List<int>();
        }

        public int Count
        {
            get { return items.Count; }
        }

        public bool IsEmpty
        {
            get { return items.Count == 0; }
        }

        // додати елемент в кінець черги
        public void Enqueue(int value)
        {
            items.Add(value);
            Console.WriteLine("Додано: " + value);
        }

        // забрати елемент з початку черги
        public int Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Черга порожня!");
            }

            int value = items[0];
            items.RemoveAt(0);
            Console.WriteLine("Видалено: " + value);

            if (IsEmpty)
            {
                OnCleared(new QueueEventArgs(1, "останній елемент забрали з черги"));
            }

            return value;
        }

        // подивитися перший елемент
        public int Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Черга порожня!");
            }
            return items[0];
        }

        // очистити чергу
        public void Clear()
        {
            int count = items.Count;
            items.Clear();
            OnCleared(new QueueEventArgs(count, "черга очищена методом Clear()"));
        }

        public void Print()
        {
            Console.Write("Черга \"" + Name + "\": ");
            if (IsEmpty)
            {
                Console.WriteLine("(порожня)");
                return;
            }
            foreach (int x in items)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }

        // метод, що викликає подію
        protected virtual void OnCleared(QueueEventArgs e)
        {
            if (Cleared != null)
            {
                Cleared(this, e);
            }
        }
    }
}
