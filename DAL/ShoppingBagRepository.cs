using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.interfaces;
using Model;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
   public class ShoppingBagRepository : IShoppingBagRepository
    {
        DataContext context;
        public ShoppingBagRepository(DataContext _context)
        {
            context = _context;
        }

        public void Add(ShoppingBag shoppingBag)
        {
            context.ShoppingBags.Add(shoppingBag);
            context.SaveChanges();
        }

        public ShoppingBag FindById(int id)
        {
            return context.ShoppingBags.Where(s => s.ShoppingBagId == id)
                .Include(c => c.Customer).Single();
        }

        public int FindLastId()
        {
            return context.ShoppingBags.Max(m => m.ShoppingBagId);
        }

        public List<ShoppingBag> Get()
        {
            return context.ShoppingBags.Include(l => l.Customer).ToList();
        }

        public void Remove(int id)
        {
            var shoppingBag = context.ShoppingBags.SingleOrDefault(p => p.ShoppingBagId == id);
            context.ShoppingBags.Remove(shoppingBag);
            context.SaveChanges();
        }

        public void Update(ShoppingBag shoppingBag)
        {
            context.ShoppingBags.Update(shoppingBag);
            context.SaveChanges();
            
        }

        public ShoppingBag shoppingBag;
        public List<ShoppingItem> shoppingItems;
      
    }
}
