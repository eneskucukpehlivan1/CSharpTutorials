using System;

namespace Inheritance
{
    class Program
    {
        //Eğer interface kullanılabiliyorsa inheritance zorunluluğu yoksa interface'ten devam edilebilir
        static void Main(string[] args)
        {
            Person[] persons = new Person[3]
            {
                new Customer
                {
                    FirstName="Enes"
                },new Student
                {
                    FirstName = "Elif"
                },new Person
                {
                    FirstName = "Ahmet"
                } //Buraya new Person() da eklenilebiliyor çünkü interface tek başına bir anlam ifade etmese de class tek başına bir anlam ifade ediyor
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person.FirstName);
            }

            Console.ReadLine();
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Customer : Person //Customer'ın ebeveyni Person'dır yani Customer Persondan dünyaya gelmiş bir nesne //Sadece tek bir babası olacağı için Person'ın yanına Person2 yazılamaz ama IPerson yazılabilir
    {
        public string City { get; set; }
    }

    class Student : Person //Customer'ın ebeveyni Person'dır yani Customer Persondan dünyaya gelmiş bir nesne
    {
        public string Department { get; set; }
    }

}
