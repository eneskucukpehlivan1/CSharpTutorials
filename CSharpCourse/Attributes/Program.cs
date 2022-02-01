using System;
using System.ComponentModel.DataAnnotations;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                Id = 1,
                LastName = "Küçükpehlivan",
                Age = 27
            };

            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();
        }
    }

    //Attribute'lar sayesinde tanımlanan verilerin hangilerinin yazılması zorunda olduğu belirtilir
    [ToTable("Customers")] //Bu yapı dinamik sorgular için kullanılır
    [ToTable("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }

    class CustomerDal
    {
        //Hazır bir attribute bu, Obsolete eski demektir. Yenisini yaptım bunu kullanma artık diye diğer yazılımcılara söylemek için kullanılır
        //Yeni bir method yaptığımızıda eskiyi kullananlar bozulmasın diye eskiyi silemeyeceğimiz için bu kullanılır uyarı amaçlı
        [Obsolete("Don't use Add, instead use AddNew Method")]  
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!", customer.Id,customer.FirstName,customer.LastName,customer.Age);
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }

    //AttributeTargets.All bunu herkese kullanabilirsin demek AttributeTargets.Class desek sadece classların üstüne eklenebilir hale gelir
    //AttributeTargets.Property dersek de sadece nesneler için kullanılır anlamına gelir
    // | AttributeTargets.Field gibi pipe ile ayırarak birden fazla şey için kullanılabilir hale getirebiliriz
    //AllowMultiple attribute'un birden fazla kel uygulanabilirliğine izin veriyor
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
    class RequiredPropertyAttribute:Attribute
    {
        
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    class ToTableAttribute : Attribute
    {
        //Attribute'ta parametre gönderme varsa constructor gereklidir
        private string _tableName;

        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
}
