using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.interfaces;

namespace DAL
{
     public class ProductRepository : IProductRepository
    {
        DataContext context;
        //private List<Product> products;

        public ProductRepository(DataContext _context)
        {
            context = _context;
            //products = new List<Product>();
            //products.Add(new Product() { ProductId = 1, Name = "Supercharger", Price = 7599 });
            //products.Add(new Product() { ProductId = 2, Name = "Charger", Price = 6000 });
            //products.Add(new Product() { ProductId = 3, Name = "Load 300", Price = 8599 });
            //products.Add(new Product() { ProductId = 4, Name = "Basic Bike", Price = 5150});
        }

        public List<Product> Get()
        {
            return context.Products.ToList(); ;
        }

        public Product FindById (int id)
        {
            return context.Products.Where(p => p.ProductId == id).Single();
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();

        }

        public void Remove(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.ProductId == id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
