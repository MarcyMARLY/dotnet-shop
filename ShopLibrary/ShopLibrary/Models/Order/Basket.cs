using System.Collections.Generic;

namespace ShopLibrary.Models.Order
{
    public class Basket
    {
        private List<BasketItem> _items { get; set; }

        public void CleanBasket()
        {
            _items.Clear();
        }
        
        public Basket()
        {
            _items = new List<BasketItem>();
        }

        public List<BasketItem> GetBasketItems()
        {
            return this._items;
        }

        public void AddProduct(int productId)
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

        public void RemoveProduct(int productId)
        {
            var item = _items.Find(x => x.GetId() == productId);
            item?.RemoveItem();
        }

        public void RemoveWholeProduct(int productId)
        {
            var item = _items.Find(x => x.GetId() == productId);
            if (item != null)
            {
                _items.Remove(item);
            }            
        }
    }
}