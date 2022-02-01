using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2, 3); //2 ve 3 değeri constructorda set ediliyor
            //Console.WriteLine(dortIslem.Topla2());
            //Console.WriteLine(dortIslem.Topla(3, 4));

            var type = typeof(DortIslem);
            //DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type,6,7); //bu satırla gelen tipe göre newleniyor reflection bu
            //Console.WriteLine(dortIslem.Topla(4, 5));
            //Console.WriteLine(dortIslem.Topla2());

            var instance = Activator.CreateInstance(type, 6, 5);
            //getType ile tipe ulaştık GetMethod ile istediğimiz methoda ulaştık Invoke ile de onu çalıştırdık
            Console.WriteLine(instance.GetType().GetMethod("Topla2").Invoke(instance, null));

            //Bu da farklı bir kullanım
            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");
            Console.WriteLine(methodInfo.Invoke(instance,null));

            //Sınıftaki tüm methodları bulur
            var methods = type.GetMethods();
            foreach (var info in methods)
            {
                Console.WriteLine("Metod adı : {0}",info.Name);
                //Method'ların parametrelerine ulaşır
                foreach (var parameters in info.GetParameters())
                {
                    Console.WriteLine("Paramatre : {0}",parameters.Name);
                }

                foreach (var attribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Name : {0}", attribute.GetType().Name);
                }
            }

            Console.ReadLine();
        }
    }

    public class DortIslem
    {
        private int _sayi1;
        private int _sayi2;

        public DortIslem(int sayi1,int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public DortIslem()
        {
            
        }

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
        [MethodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
    }

    public class MethodNameAttribute:Attribute
    {
        public MethodNameAttribute(string name)
        {
            
        }
    }
}
