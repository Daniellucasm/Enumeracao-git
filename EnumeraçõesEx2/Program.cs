using EnumeraçõesEx2.Entities;
using EnumeraçõesEx2.Entities.Enums;
using System.Globalization;

namespace EnumeraçõesEx2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, date);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int qtd = int.Parse(Console.ReadLine());
            

            for(int i = 1; i <= qtd; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Product product = new Product(productName, price);
                OrderItem orderItem = new OrderItem(quantity, price, product);
                order.addItem(orderItem);
            }

            Console.WriteLine("");
            Console.WriteLine(order);

        }
    }
}