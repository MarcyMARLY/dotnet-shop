using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ShopLibrary.Models
{
    public class Basket
    {
        private List<BasketItem> _items { get; set; }

        public Basket()
        {
            _items = new List<BasketItem>();
        }

        public List<BasketItem> GetBasketItems()
        {
            return this._items;
        }

        public void AddProduct(string productId)
        {
            var item = _items.Find(x => x.GetId() == productId);
            if (item == null)
            {
                _items.Add(new BasketItem(productId, 1));
            }
            else
            {
                item.AddItem();
            }
        }

        public void RemoveProduct(string productId)
        {
            var item = _items.Find(x => x.GetId() == productId);
            item?.RemoveItem();
        }

        public void RemoveWholeProduct(string productId)
        {
            var item = _items.Find(x => x.GetId() == productId);
            if (item != null)
            {
                _items.Remove(item);
            }            
        }
    }
}