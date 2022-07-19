using System;
using System.Globalization;
using OrderExercise.Entities;
using OrderExercise.Entities.Enums;

namespace OrderExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(status, client);
            Product product = new Product();
            OrderItem items = new OrderItem();

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product Name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                items = new OrderItem(quantity, productPrice, productName);
                order.AddItem(items);
                product = new Product(name, productPrice);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine("Order moment: " + DateTime.Now.ToString("dd/MM/yyy HH:mm:ss"));
            Console.WriteLine("Order status: " + order.Status);
            Console.WriteLine("Client: " + order.Client);
            Console.WriteLine("Order Items:");
            Console.WriteLine(order.ToString());
            Console.WriteLine("Total price: $" + order.Total().ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
