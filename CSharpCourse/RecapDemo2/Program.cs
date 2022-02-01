using System;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Logger = new SmsLogger(); //Bunu set etmek gerekiyor yoksa program hata verir
            customerManager.Add();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        public ILogger Logger { get; set; } //public property ile ILogger türünde bir Logger ürettik ve bu sayede istenilene göre log'lama işlemini yapabildik
        public void Add()
        {
            Logger.Log();
            Console.WriteLine("Customer Added!");
        }
    }

    //Bir class çıplak durmamalı mutlaka bir base'i olmalı
    class DatabaseLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database!");
        }
    }

    class FileLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file!");
        }
    }

    class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to SMS!");
        }
    }

    interface ILogger
    {
        void Log();
    }
}
