using System;
using System.Data;

namespace ReferenceAndValueType
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 10;
            int number2 = 20;
            number2 = number1;
            number1 = 30;

            Console.WriteLine(number2);

            string[] cities1 = new string[] {"Ankara", "Adana", "Afyon"};   //101 diye bir referans numarası atanıyır
            string[] cities2 = new string[] {"Bursa", "Bolu", "Balıkesir"}; //102

            cities2 = cities1;  //burda olay bellekteki referans üzerinden gidiyor 102=101
            cities1[0] = "İstanbul"; //Böyle yapıldığında 102 ortadan kalktığı için cities2'nin 0. elemanı da etkilenir ve istanbul olur
            Console.WriteLine(cities2[0]);

            //DataTable dataTable = new DataTable(); //new'lemek bellekteki en pahalı işlem 
            //DataTable dataTable2 = new DataTable();

            //Yukarıdaki gibi yapmak yerine böyle yapılabilirdi çünkü zaten datatable=datatable2 dediğinde referans gideceği için datatable için new yapmaya gerek yok
            DataTable dataTable;
            DataTable dataTable2 = new DataTable();
            dataTable = dataTable2;

            Console.ReadLine();
        }
    }
}
