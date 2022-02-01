using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
            customerManager.Update();

            ProductManager productManager = new ProductManager();
            productManager.Add();
            productManager.Update();

            Customer customer = new Customer();
            customer.City = "İStanbul"; //Bu şekilde olduğunda get; set; kısmındaki set bloğu çalışır yani City property'sine İstanbul set edilir
            customer.Id = 1;
            customer.FirstName = "Enes";
            customer.LastName = "Küçükpehlivan";

            Customer customer2 = new Customer
            {
                Id = 2, City = "Eskişehir", FirstName = "Elif", LastName = "Gürkaş"
            };

            Console.WriteLine(customer2.FirstName); //Buradaki kullanımda ise get bloğu çalışır ve değeri getirir

            Console.ReadLine();
        }
    }
}
