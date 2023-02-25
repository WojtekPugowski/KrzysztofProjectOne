namespace ProjectOne
{
    public class Repository
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
