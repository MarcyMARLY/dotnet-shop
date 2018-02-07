using System;
using System.Data.Common;
using Microsoft.Win32.SafeHandles;

namespace ShopLibrary.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public float Charge { get; set; }
        public DateTime TransactionDateTime { get; set; }

        public Transaction()
        {
        }

        public Transaction(int id, float charge)
        {
            this.Id = id;
            this.Charge = charge;
            this.TransactionDateTime = DateTime.Now;
        }
    }
}