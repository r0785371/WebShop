using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.interfaces
{
    public interface IShoppingItemService
    {
        List<ShoppingItem> GetAllShoppingItems();
        ShoppingItem FindById(int id);
        void Add(ShoppingItem shoppingItem);
        void Update(ShoppingItem shoppingItem);
        void Remove(int id);

    }
}
