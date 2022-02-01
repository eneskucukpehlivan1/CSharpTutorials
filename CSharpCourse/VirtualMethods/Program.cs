using System;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();
            MySql mySql = new MySql();
            mySql.Add();

            Console.ReadLine();
        }
    }

    //Aşağıdaki durum interface ile yapılamaz böyle bir ihtiyaçta inheritance yapılması gerekiyor
    class Database
    {
        public virtual void Add() //virtual olarak tanımlayınca child olan class üzerinden bu method override ile çağrılır ve farklı komutlar koşularak ezilebilir
        {
            Console.WriteLine("Added by default");
        }

        public virtual void Delete()
        {
            Console.WriteLine("Deleted by default");
        }
    }

    class SqlServer:Database
    {
        //override kullanıldığında Database class'ında virtual olan methodlar gelir
        public override void Add()
        {
            Console.WriteLine("Added by Sql Code");
            //base.Add(); //Bu komut ile Database içindeki Add methodunu da çalıştırır
        }
    }

    class MySql:Database
    {
        
    }
}
