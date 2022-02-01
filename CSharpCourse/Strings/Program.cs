using System;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intro();
            string sentence = "My name is Enes Küçükpehlivan";

            var result = sentence.Length;
            var result2 = sentence.Clone();
            sentence = "My name is Elif";

            bool result3 = sentence.EndsWith("f");
            bool result4 = sentence.StartsWith("My name");

            var result5 = sentence.IndexOf("name"); //Bulamazsa -1 döndürür
            var result6 = sentence.IndexOf(" "); //Bulduğu ilk anda sayar ve çıktı verir
            var result7 = sentence.LastIndexOf(" "); //Aramaya sondan başlar ama verdiği çıktı yine baştan sayıp da verdiği sayıdır
            var result8 = sentence.Insert(0, "Hello, ");
            var result9 = sentence.Substring(3,4);
            var result10 = sentence.ToLower();
            var result11 = sentence.ToUpper();
            var result12 = sentence.Replace(" ","-");
            var result13 = sentence.Remove(2,5);

            Console.WriteLine(result13);
            Console.ReadLine();
        }

        private static void Intro()
        {
            string city = "İstanbul";
            Console.WriteLine(city[0]);

            foreach (var item in city)
            {
                Console.WriteLine(item);
            }

            string city2 = "Eskişehir";
            string result = city + city2;

            //result değişkeni kullanmak yerine bu şekilde kullanılabilir
            Console.WriteLine(String.Format("{0} {1}", city, city2));
        }
    }
}
