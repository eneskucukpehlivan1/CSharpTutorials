using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            //using kullanırsak garbage collector beklemeden nesneyi zorla bellekten atarız
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
            }
        }

        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //Direkt veri tabanına where koşulu gönderiyor
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }

        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
            }
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //FirstOrDefault bu id'ye uygun olan ilk kaydı getir numarada bir kayıt yoksa null getir
                return context.Products.FirstOrDefault(p => p.Id == id);
                //SingleOrDefault o kayda uyan birden fazla kayıt bulursa hata veriyor
            }
        }

        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //context.Products.Add(product);
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //contexte bu product için abone ol
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
