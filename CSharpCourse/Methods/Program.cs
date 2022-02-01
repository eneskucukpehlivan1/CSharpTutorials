using System;
using System.Linq;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add();
            //var result = Add2();

            //int number1 = 20;
            //int number2 = 100;
            //var result2 = Add3(ref number1, number2);
            //Console.WriteLine(result2);
            //Console.WriteLine(number1);

            Console.WriteLine(Multiply(2, 4));
            Console.WriteLine(Multiply(2, 4, 5));

            Console.WriteLine(Add4(1, 2, 3, 4, 5, 6));
            Console.ReadLine();
        }

        static void Add()
        {
            Console.WriteLine("Added!");
        }

        //number2=30 number2 verilmezse default olarak 30 kullan demek
        //default değerler methodun en sonunda olması gerek
        static int Add2(int number1 = 20, int number2 = 30)
        {
            var result = number1 + number2;
            return result;
        }

        static int Add3(ref int number1, int number2)
        {
            //number1 30 olsa da dışarı çıktığında tekrar eski değerini alıyor
            //eger ref int number1 şeklinde yazılırsa o zaman dışarıdaki değişken de etkileniyor
            //ref'te number1'in set edilmiş olması gerekiyor ama out'ta böyle bir şeye ihtiyac yok
            number1 = 30;
            return number1 + number2;
        }

        //Aynı isimli methodlarda farklı parametlere ile bu şekilde yaparsak buna method overloading deniyor
        static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
        static int Multiply(int number1, int number2, int number3)
        {
            return number1 * number2 * number3;
        }

        //Birden fazla overload yapmamak için params keywordü ile methoda aynı tipte değişkenleri dizi şeklinde gönderebiliriz
        //params'tan önce de parametre eklenebilir ama params her zaman methodun son parametresi olmak zorunda
        static int Add4(params int[] numbers)
        {
            return numbers.Sum();
        }

    }
}
