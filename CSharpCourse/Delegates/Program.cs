using System;
using System.Xml.Serialization;

namespace Delegates
{
    class Program
    {
        //void olan ve parametre almayan operasyonlara delegelik yapıyor
        public delegate void MyDelegate();
        public delegate void MyDelegate2(string text);//void olan string bir parametre alan methodlara hizmet eder
        public delegate int MyDelegate3(int number1, int number2);//int döndüren 2 tane int parametre alan methodlara hizmet eder

        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.SendMessage();
            customerManager.ShowAlert();

            Console.WriteLine("-------------------");

            //Yapılacak işler önce sıra ile toplanıyor sonrasında tek bir komut ile o sıra çağrılıyor ihtiyac halinde
            //özel bir elçi customerManager'ın sendMessage'ına delege edilmiş
            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert; //Bu şekilde iki mesajı birden elçiye söyledik
            myDelegate(); //elçiyi çağırdık ve işlem gerçekleşti

            Console.WriteLine("-------------------");

            myDelegate -= customerManager.SendMessage; //Bu şekilde SendMessage işlemi geri alınabilir
            myDelegate();

            Console.WriteLine("-------------------");

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;

            myDelegate2("Hello"); //Bu şekilde ikisine de aynı değeri gönderdik

            Console.WriteLine("-------------------");

            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;
            var sonuc = myDelegate3(2, 3); //Son islem neyse onu return ile döndürür
            Console.WriteLine(sonuc);




            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be careful!");
        }

        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }

    public class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
