using System;

namespace ShopLibrary.Models.Order
{
    public class Transaction
    {
        public int Id { get; set; }
        public float Charge { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}