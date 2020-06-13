using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.interfaces
{
   public interface IShoppingBagService
    {
        List<ShoppingBag> GetAllShoppingBags();
        ShoppingBag FindById(int id);
        void Add(ShoppingBag shoppingBag);
        void Update(ShoppingBag shoppingBag);
        void Remove(int id);
        int FindLastId();
        ShoppingBag AddItem2ShoppingBag(int shoppingBagId, int customerId, int productId, int quantity);

        ShoppingBag FindShoppingWithItems(int id);

    }
}
