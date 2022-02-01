using System;

namespace Interfaces
{
    class Program
    {
        //Interface'ler katmanlar arası geçişlerde yoğun olarak kullanılır, amaç uygulama bağımlılıklarını minimize etmek
        static void Main(string[] args)
        {
            //InterfacesIntro();

            //Demo();

            ICustomerDal[] customerDals = new ICustomerDal[3]
            {
                new SqlServerCustomerDal(),
                new OracleCustomerDal(),
                new MySqlCustomerDal()
            };

            foreach (var customerDal in customerDals)
            {
                customerDal.Add(); //Bu şekilde aynı veri mevcut tüm veri tabanlarına gönderilebilir
            }

            Console.ReadLine();
        }

        private static void Demo()
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServerCustomerDal());
            customerManager.Add(new OracleCustomerDal());
            customerManager.Update(new SqlServerCustomerDal());
            customerManager.Delete(new OracleCustomerDal());
        }

        private static void InterfacesIntro()
        {
            PersonManager manager = new PersonManager();
            Studuent studuent = new Studuent
            {
                Id = 1,
                FirstName = "Elif",
                LastName = "Küçükpehlivan",
                Department = "Business"
            };
            manager.Add(studuent); //PersonManager class'ının içindeki Add methodunda Customer yerine IPerson person yazarsak kabul eder aksi halde sadece customer kabul eder
            manager.Add(new Customer { Id = 1, FirstName = "Enes", LastName = "Küçükpehlivan", Adress = "İstanbul" });
        }
    }

    interface IPerson
    {
        //Temel nesne oluşturup bütün nesneleri ondan implemente etmek
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    //class'lar somut nesne interface'ler soyut nesne
    class Customer : IPerson //Bu kullanım ile IPerson'da tanımlanmış her şey hem interface'te hem class'ta görülebilir
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Adress { get; set; }
    }

    class Studuent : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Department { get; set; }
    }

    class Worker : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Department { get; set; }
    }

    class PersonManager
    {
        public void Add(IPerson person)
        {
            Console.WriteLine(person.FirstName);
        }
    }
}
