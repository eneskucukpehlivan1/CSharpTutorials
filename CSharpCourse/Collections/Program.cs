using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList();
            //List();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("book","kitap");
            dictionary.Add("table","tablo");
            dictionary.Add("computer","bilgisayar");

            Console.WriteLine(dictionary["table"]);
            //Console.WriteLine(dictionary["glass"]);

            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
                //Console.WriteLine(item.Key);
                //Console.WriteLine(item.Value);   
            }

            Console.WriteLine(dictionary.ContainsKey("glass"));
            Console.WriteLine(dictionary.ContainsKey("table"));
            Console.WriteLine(dictionary.ContainsValue("bardak"));
            Console.WriteLine(dictionary.ContainsValue("tablo"));

            Console.ReadLine();
        }

        private static void List()
        {
            List<string> cities = new List<string>();
            cities.Add("Ankara");
            cities.Add("İstanbul");

            //Console.WriteLine(cities.Contains("Ankara"));

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

            //Profesyonel uygulamalarda Listlerin veri tipi olarak classlar kullanılabilir ve aşağıdaki gibi add yapılabilir
            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer{Id=1,FirstName = "Enes"});
            //customers.Add(new Customer{Id=2,FirstName = "Elif"});

            List<Customer> customers = new List<Customer>
            {
                new Customer {Id = 1, FirstName = "Enes"},
                new Customer {Id = 2, FirstName = "Elif"}
            };


            var customer2 = new Customer
            {
                Id = 3, FirstName = "Ahmet"
            };
            customers.Add(customer2);
            customers.AddRange(new Customer[2]
            {
                new Customer {Id = 4, FirstName = "Ali"},
                new Customer {Id = 5, FirstName = "Salih"}
            });
            var count = customers.Count;

            Console.WriteLine(customers.Contains(customer2));
            //customers.Clear();

            var index = customers.IndexOf(customer2);
            Console.WriteLine("Index : {0}", index);

            customers.Add(customer2);

            var lastIndexOf = customers.LastIndexOf(customer2);
            Console.WriteLine("Last Index : {0}", lastIndexOf);

            customers.Insert(0, customer2);

            customers.Remove(customer2);
            customers.RemoveAll(c => c.FirstName == "Ahmet"); //Müşterilerden ismi Salih olanları bul ve sil

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }

            Console.WriteLine("Count : {0}", count);
        }

        private static void ArrayList()
        {
            //tip güvenli çalışma durumu yoksa ArrayList tercih edilir
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add("Adana");
            cities.Add("İstanbul");
            cities.Add(1);
            cities.Add('A');

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
