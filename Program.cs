using System;

namespace SingletonExample
{
    public sealed class Logging
    {
        private static Logging instance;
        private static readonly object _lock = new object();

        private Logging()
        {
        }

        public static Logging Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new Logging();
                        }
                    }
                }
                return instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"Logging: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logging logger1 = Logging.Instance;
            logger1.Log("Log message from logger1");

            Logging logger2 = Logging.Instance;
            logger2.Log("Log message from logger2");

            Console.ReadLine();
        }
    }
}