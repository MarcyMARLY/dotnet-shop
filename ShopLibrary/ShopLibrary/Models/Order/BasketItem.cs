namespace ShopLibrary.Models.Order
{
    public class BasketItem
    {
        private int id;
        private int amount;

        public BasketItem(int _id, int _amount)
        {
            this.id = _id;
            this.amount = _amount;
        }
        
        public int GetAmount()
        {
            return amount;
        }

        public int GetId()
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