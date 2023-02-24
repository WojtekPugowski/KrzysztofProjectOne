using System;
namespace ProjectOne
{
    public class Order
    {
        public Order()
        {
        }

        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}

