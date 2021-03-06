﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopLibrary.Models.Order
{
    public class Order
    {
        public OrderStatus Status { get; set; }
        public int OrderId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int BuyerId { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}