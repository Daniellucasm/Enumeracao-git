using EnumeraçõesEx2.Entities.Enums;
using System.Text;
using System.Globalization;

namespace EnumeraçõesEx2.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        
        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {

        }

        public void addItem(OrderItem items)
        {
            Items.Add(items);
        }

        public void removeItem(OrderItem items)
        {
            Items.Remove(items);
        }

        public double total()
        {
            double sum = 0; 
            foreach (OrderItem item in Items)
            {
                sum += item.subTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY: ");
            sb.AppendLine("Order Moment: " + Moment);
            sb.AppendLine("Order Status: " + Status);
            sb.Append("Client: " + Client);
            sb.AppendLine("Order Items: ");
            foreach(OrderItem item in Items)
            {
                sb.Append(item.Product.Name + ", $" + item.Price + ", Quantity: " + item.Quantity);
                sb.AppendLine(", Subtotal: " + item.subTotal().ToString("F2", CultureInfo.InvariantCulture)); 
            }
            sb.AppendLine("Total price: $" + total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
