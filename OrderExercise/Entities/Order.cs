using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using OrderExercise.Entities;
using OrderExercise.Entities.Enums;

namespace OrderExercise.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order ()
        {
        }

        public Order(OrderStatus status, Client client)
        {
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (OrderItem item in Items)
            {
                sb.Append(item.Name);
                sb.Append(", $");
                sb.Append(item.Price.ToString("F2", CultureInfo.InvariantCulture));
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(", Subtotal: $");
                sb.AppendLine(item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            
            return sb.ToString();

            //foreach (OrderItem item in Items)
            //{
            //    Console.WriteLine(
            //    item.Name
            //        + ", $"
            //        + item.Price.ToString("F2", CultureInfo.InvariantCulture)
            //        + ", Quantity: " + item.Quantity
            //        + ", Subtotal $" + item.SubTotal().ToString("F2", CultureInfo.InvariantCulture)
            //        );
            //}
            //return ToString();
        }
    }
}
