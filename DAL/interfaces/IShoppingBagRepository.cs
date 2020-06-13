using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.interfaces
{
    public interface IShoppingBagRepository
    {
        List<ShoppingBag> Get();
        ShoppingBag FindById(int id);

        int FindLastId();

        void Update(ShoppingBag shoppingBag);

        void Add(ShoppingBag shoppingBag);

        void Remove(int id);
    }
}
