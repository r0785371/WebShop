using BLL.interfaces;
using DAL.interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ShoppingBagService : IShoppingBagService
    {
        IShoppingBagRepository repository;
        IShoppingItemRepository shoppingItemRepository;
        public ShoppingBagService(IShoppingBagRepository _repository, IShoppingItemRepository _shoppingItemRepository)
        {
            repository = _repository;
            this.shoppingItemRepository = _shoppingItemRepository;
        }
        public void Add(ShoppingBag shoppingBag)
        {
            repository.Add(shoppingBag);
        }

        public ShoppingBag FindById(int id)
        {
            return repository.FindById(id);
        }

        public int FindLastId()
        {
            return repository.FindLastId();
        }

        public List<ShoppingBag> GetAllShoppingBags()
        {
            return repository.Get();
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void Update(ShoppingBag shoppingBag)
        {
            repository.Update(shoppingBag);
        }

        public ShoppingBag AddItem2ShoppingBag(int shoppingBagId, int customerId, int productId, int quantity)
        {
            ShoppingBag shoppingBag = null;
            if (shoppingBagId == 0)
            {
                //Nieuwe shoppingBag 
                shoppingBag = new ShoppingBag
                {
                    CustomerId = 1,//customerId,
                    Date = DateTime.Now.Date
                };
                Add(shoppingBag);
                shoppingBagId = FindLastId();
                shoppingBag.ShoppingBagId = shoppingBagId;
            }
            //add product to shoppingitem
            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.ShoppingBagId = shoppingBagId;
            shoppingItem.ProductId = 1;//productId;
            shoppingItem.Quantity = quantity;
            //shoppingitem toevoegen aan database
            shoppingItemRepository.Add(shoppingItem);

            return shoppingBag;
        }
        
        
        public ShoppingBag FindShoppingWithItems(int id)
        {
            ShoppingBag shoppingBag = new ShoppingBag();
            
            foreach (var item in shoppingBag.ShoppingItems)
            {
                item.SubTotaal = item.Quantity * item.Product.Price;
            }
            shoppingBag.TotaalQuantity = shoppingBag.ShoppingItems.Sum(x => x.Quantity);
            shoppingBag.SubTotaal = shoppingBag.ShoppingItems.Sum(x => x.SubTotaal);


            //calculate discount
            if (shoppingBag.TotaalQuantity >= 3 || shoppingBag.TotaalQuantity < 6)
            {
                shoppingBag.DiscountPercentage = 5;
                shoppingBag.DiscountValue = shoppingBag.SubTotaal * shoppingBag.DiscountPercentage / 100;
                shoppingBag.Totaal = shoppingBag.SubTotaal - shoppingBag.DiscountValue;
            }
            else if (shoppingBag.TotaalQuantity > 6)
            {
                shoppingBag.DiscountPercentage = 10;
                shoppingBag.DiscountValue = shoppingBag.SubTotaal * shoppingBag.DiscountPercentage / 100;
                shoppingBag.Totaal = shoppingBag.SubTotaal - shoppingBag.DiscountValue;
            }
            else
            {
                shoppingBag.DiscountValue = 0;
                shoppingBag.Totaal = shoppingBag.SubTotaal;
            }



            return shoppingBag;

        }

    }   
        
           
    
}
