using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ETradeContext:DbContext
    {
        //Bu komut mevcut Db'nin içindeki tablolarda Products diye bir tablo arıyor
        public DbSet<Product> Products { get; set; }

    }
}
