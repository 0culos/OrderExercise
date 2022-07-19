using System;
using System.Collections.Generic;
using System.Text;

namespace OrderExercise.Entities
{
    internal class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int quantity, double price, string name)
        {
            Quantity = quantity;
            Price = price;
            Name = name;
        }

        public double SubTotal()
        {
            return Price * Quantity;
        }

    }
}
