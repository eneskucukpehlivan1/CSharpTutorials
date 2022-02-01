using System;
using System.Xml.Serialization;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //pirvate sadece tanımlandığı blok içerisinde geçerlidir
    //ptorected private'ın tüm özelliklerini kapsıyor
    //internal proje içerisinde istediğimiz noktada çağırılabilir.
    //public referans verildiği zaman başka bir projede kullanılabilir. public Course2 classını AccessModifiersDemo projesinde bu projesi referans göstererek kullandık.
    class Customer
    {
        private int Id { get; set; }
        protected int Id2 { get; set; }

        public void Save()
        {

        }

        public void Delete()
        {

        }
    }

    class Student:Customer
    {
        public void Save2()
        {
            //private Id burada kullanılamaz
            //protected inherit edildiği sınıflarda kullanılabilir.
            //Id kullanılamaz Id2 kullanılabilir.
        }
    }

    //class'ın defaultu internal'dır
    //class ya internal ya public olur iç içe class'larda private kullanılabilir
    class Course
    {
        public string Name { get; set; }

        private class NestedClass
        {

        }
    }

    public class Course2
    {

    }
}
