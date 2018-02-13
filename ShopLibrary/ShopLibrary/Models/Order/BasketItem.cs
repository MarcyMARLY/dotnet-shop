namespace ShopLibrary.Models.Order
{
    public class BasketItem
    {
        private string id;
        private int amount;

        public BasketItem(string _id, int _amount)
        {
            this.id = _id;
            this.amount = _amount;
        }
        
        public int GetAmount()
        {
            return amount;
        }

        public string GetId()
        {
            return id;
        }

        public void AddItem()
        {
            this.amount++;
        }

        public void RemoveItem()
        {
            this.amount--;
        }
    }
}