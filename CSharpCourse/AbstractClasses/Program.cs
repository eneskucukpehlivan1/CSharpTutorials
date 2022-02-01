using System;
using System.Xml.Serialization;

namespace AbstractClasses
{
    //interface'ler ve virtual methodların birleşimi
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Oracle();
            database.Add();
            database.Delete();

            Database database2 = new Oracle();
            database2.Add();
            database2.Delete();

            Console.ReadLine();
        }
    }

    //abstract'lar ile hem tamamlanmış method hem tamamlanmamış method aynı anda kullanılabilir
    abstract class Database
    {
        //Bu şekilde şunu söylemiş olduk, Add her DB için aynı ama Delete'i her DB'nin ayrı implemente etmesi gerekiyor

        //tamamlanmış method
        public void Add()
        {
            Console.WriteLine("Added by default");
        }

        //tamamlanmamış method //abstract demek içi dolu olmayan virtual method demektir
        public abstract void Delete();
    }

    class SqlServer:Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by SqlServer");
        }
    }

    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Oracle");
        }
    }
}
