using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ProductDao
    {
        //----------------------------------------bütün ürünleri döndür
        public List<Product> GetAllProducts()
        {
            //using ile garbage collector beklemeden nesneyi zorla bellekten atar
            using (ECommerceContext context = new ECommerceContext())
            {
                //tabloları db den alma
                return context.Products.ToList();
            }

        }
        //------------------------------------Search 
        //burda direk db e sorgu atıyor(Daha perfor)(küçük büyük harf alıyor)
        public List<Product> GetByName(string key)
        {
            //using ile garbage collector beklemeden nesneyi zorla bellekten atar
            using (ECommerceContext context = new ECommerceContext())
            {
                //tabloları db den alma
                return context.Products.Where(p=> p.Name.Contains(key)).ToList();
            }
        }

        //fiyata göre arama
        public List<Product> GetByUnitPrice(decimal price)
        {
            //using ile garbage collector beklemeden nesneyi zorla bellekten atar
            using (ECommerceContext context = new ECommerceContext())
            {
                //tabloları db den alma
                return context.Products.Where(p => p.UnitPrice>=price).ToList();
            }
        }

        public List<Product> GetUnitPrice(decimal min, decimal max)
        {
            //using ile garbage collector beklemeden nesneyi zorla bellekten atar
            using (ECommerceContext context = new ECommerceContext())
            {
                //tabloları db den alma
                return context.Products.Where(p => p.UnitPrice>=min && p.UnitPrice<=max).ToList();
            }
        }

        //----------------------------tek bi product idye göre 
        public Product GetById(int id)
        {
            //using ile garbage collector beklemeden nesneyi zorla bellekten atar
            using (ECommerceContext context = new ECommerceContext())
            {
                //tabloları db den alma or single or default
                return context.Products.FirstOrDefault(p=> p.Id==id);
            }

        }

        //-------------------------------------------Add Product
        public void AddProduct(Product product)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                context.Products.Add(product);
                //burda da updatedeki gibi yapılabilir
                //var entity = context.Entry(product);
                //entity.State = EntityState.Added;
                context.SaveChanges();

                
            }

        }

       //------------------------------------------Update Product
        public void UpdateProduct(Product product)
        {
            using(ECommerceContext context= new ECommerceContext())
            {
                //db deki producta eşitle
                var entity = context.Entry(product);
                //güncelle
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        //---------------------------------------------Delete Product
        public void DeleteProduct(Product product)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                //db deki producta eşitle
                var entity = context.Entry(product);
                //sil
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
