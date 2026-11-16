using System;

namespace Lab4
{
    // клас-аргумент події
    public class QueueEventArgs : EventArgs
    {
        public int RemovedCount { get; }
        public string Message { get; }
        public DateTime Time { get; }

        public QueueEventArgs(int removedCount, string message)
        {
            RemovedCount = removedCount;
            Message = message;
            Time = DateTime.Now;
        }
    }
}
