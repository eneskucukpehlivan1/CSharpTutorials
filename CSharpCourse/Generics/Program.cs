using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara", "İzmir", "Adana");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> result2 = utilities.BuildList<Customer>(new Customer { FirstName = "Enes" }, new Customer { FirstName = "Elif" });

            foreach (var customer in result2)
            {
                Console.WriteLine(customer.FirstName);
            }

            Console.ReadLine();
        }
    }

    class Utilities
    {
        //Generic method
        //Bu kullanım ile methodun içine istediğimiz türden veri gönderip istediğimiz türden bir liste oluşturabiliriz
        //params kullanımı methodun içine kaç tane eleman gönderileceği belli olmayan durumlarda olur
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }

    class Product : IEntity
    {

    }

    interface IProductDal : IRepository<Product>
    {
        List<Product> GetAll();
        Product Get(int id);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }

    class Customer : IEntity
    {
        public string FirstName { get; set; }
    }

    interface ICustomerDal : IRepository<Customer>
    {
        void Custom();
    }

    interface IStudentDal : IRepository<Student>
    {

    }

    class Student : IEntity
    {

    }

    interface IEntity
    {

    }

    //Bu şekilde her class için özel interface yazmaktansa tek bir interface ile ortak değişken kullanılabiliyor
    //Bu şekilde T'ye sadece referans tip yazılıyor, örneğin class veya string olabilir ama int olamaz
    //Sonuna new() eklediğimizde de stringin önüne geçmiş olduk
    //IEntity eklediğimizde IEntity'den implemente edilmiş olmalı 
    //new() her zaman en sonda olmalı
    //where T : struct yazarsak bu da sadece değer tip alabilir anlamına gelir
    interface IRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    class ProductDal : IProductDal
    {
        List<Product> IRepository<Product>.GetAll()
        {
            throw new NotImplementedException();
        }

        Product IProductDal.Get(int id)
        {
            throw new NotImplementedException();
        }

        void IProductDal.Add(Product product)
        {
            throw new NotImplementedException();
        }

        void IProductDal.Delete(Product product)
        {
            throw new NotImplementedException();
        }

        void IProductDal.Update(Product product)
        {
            throw new NotImplementedException();
        }

        List<Product> IProductDal.GetAll()
        {
            throw new NotImplementedException();
        }

        Product IRepository<Product>.Get(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<Product>.Add(Product entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Product>.Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Product>.Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    //IRepository değil de bunu yaparsak ICustomerDal'ın içindeki özel methodlar da implemente edilir
    class CustomerDal : ICustomerDal
    {
        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Custom()
        {
            throw new NotImplementedException();
        }
    }
}
