using DAL.interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        DataContext context;
        public ShoppingItemRepository(DataContext _context)
        {
            context = _context;
        }
        public void Add(ShoppingItem shoppingItem)
        {
            context.ShoppingItems.Add(shoppingItem);
            context.SaveChanges();
        }

        public ShoppingItem FindById(int id)
        {
            return context.ShoppingItems.Where(s => s.ShoppingItemId == id).Single();
            
        }

        public List<ShoppingItem> Get()
        {
            return context.ShoppingItems.ToList();
        }

        public void Remove(int id)
        {
            var shoppingItem = context.ShoppingItems.SingleOrDefault(r => r.ShoppingItemId == id);
            context.ShoppingItems.Remove(shoppingItem);
            context.SaveChanges();
            
        }

        public void Update(ShoppingItem shoppingItem)
        {
            context.ShoppingItems.Update(shoppingItem);
            context.SaveChanges();
            
        }
    }
}
