using System;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(100); //parantez içinde göndermenin sebebi constructor olması
            customerManager.List();

            Product product = new Product{Id = 1, Name = "Laptop"};
            Product product2 = new Product(2, "Computer"); //class içinde constructor yaptığımız için bir üst satırdaki gibi yapmaya gerek kalmadan bu şekilde alabildik

            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            //employeeManager.Logger = new DatabaseLogger(); //Eğer constructor ile enjekte etmemiş olsak böyle kullanmak ve her seferinde bu komut eklemek gerekecekti ama cons. ile kullandığımız için 
                                                             //yukarıdak gibi parantez içine yazmak yeterli oldu
                                                             //Bu şekilde her employee için en başta unutmadan logger tipi belirlenir
            employeeManager.Add();

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();

            Teacher.Number = 10; //Bu şekilde static nesneler herkes tarafından kullanılır
            Utilities.Validate();

            Manager.DoSomething();
            Manager manager = new Manager();
            manager.DoSomething2();

            Console.ReadLine();
        }
    }

    //Cpnstructor bir sınıfın ihtiyac duyduğu farklı paramatler varsa ve bu parametreler kullanıma göre değişkenlik gösteriyorsa kullanılır
    class CustomerManager
    {
        //private field alt çizgi ile başlatılır
        private int _count=15;
        public CustomerManager(int count)
        {
            _count = count;
        }
        //Constructor overloading bu oluyor. 15 değeri set edilmiş eğer boş çağırırsan 15 alır eğer içini doldurursan o sayıyı alır
        public CustomerManager()
        {
            
        }
        public void List()
        {
            Console.WriteLine("Listed {0} items", _count);
        }

        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }


    class Product
    {
        public Product()
        {
            
        }

        private int _id;
        private string _name;

        public Product(int id,string name)
        {
            _id = id;
            _name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file");
        }
    }

    class EmployeeManager
    {
        private ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added");
        }
    }

    class BaseClass
    {
        private string _entity;

        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine("{0} message",_entity);
        }
    }
    
    //BaseClassta constructor olduğu için aşağısı hata verdi bunun için alttaki class'a da bir constructor verilmesi gerek
    class PersonManager:BaseClass
    {
        //Base sınıfa değer göndermek için :base kullanımı yapılır
        public PersonManager(string entity):base(entity)
        {
            
        }

        public void Add()
        {
            Console.WriteLine("Added!");
            //BaseClass'ı inherit ettiğimiz için oradaki Message() burada kullanılabildi
            Message();
        }
    }

    //static nesne için new yapılmaz
    //static nesne ile çalıştığında paylaşılan bir kaynak olup olmadığından emin olmalısın
    //static nesnenin içindeki bütün özellikler de static olmalı
    static class Teacher
    {
        public static int Number { get; set; }
    }

    static class Utilities
    {
        static Utilities()
        {
            //static bir nesnede mutlaka çalışması istenen kod bloğu varsa buraya koyulur
        }
        public static void Validate()
        {
            Console.WriteLine("Validation is done");
        }
    }

    class Manager
    {
        public static void DoSomething()
        {
            Console.WriteLine("Done");
        }

        public void DoSomething2()
        {
            Console.WriteLine("Done2");
        }
    }
}
