using BLL.interfaces;
using DAL.interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ShoppingItemService : IShoppingItemService
    {
        IShoppingItemRepository repository;
        public ShoppingItemService(IShoppingItemRepository _repository)
        {
            repository = _repository;
        }
        public void Add(ShoppingItem shoppingItem)
        {
            repository.Add(shoppingItem);
        }

        public ShoppingItem FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<ShoppingItem> GetAllShoppingItems()
        {
            return repository.Get();
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void Update(ShoppingItem shoppingItem)
        {
            repository.Update(shoppingItem);
        }
    }
}
