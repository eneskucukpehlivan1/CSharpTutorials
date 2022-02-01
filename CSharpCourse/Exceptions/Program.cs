using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExceptionIntro();
            //TryCatch();

            //ActionDemo();

            Func<int, int, int> add = Topla;
            Console.WriteLine(add(3, 5));

            //Parametresiz methodlara delege yapıyo ama sonucunda int döndürüyor
            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };

            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);

            Console.WriteLine(getRandomNumber());
            Console.WriteLine(getRandomNumber2());


            Console.ReadLine();
        }

        static int Topla(int x, int y)
        {
            return x + y;
        }

        private static void ActionDemo()
        {
            //Method
            HandleException(() => { Find(); });
        }

        private static void TryCatch()
        {
            try
            {
                Find();
            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        //Action delegasyonu
        private static void HandleException(Action action)
        {
            try
            {
                //Find'ı parametre olarak gönderdiğimiz için Invoke kullanarak Find'ı çalıştırdık.
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Find()
        {
            List<string> students = new List<string> { "Enes", "Elif", "Ahmet" };

            if (!students.Contains("Salih"))
            {
                throw new RecordNotFoundException("Record not found!");
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }

        private static void ExceptionIntro()
        {
            try
            {
                string[] students = new string[3] { "Enes", "Elif", "Ahmet" };

                students[3] = "Ahmet";
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception!!!");
                Console.WriteLine(exception.Message);
            }
        }
    }

}
