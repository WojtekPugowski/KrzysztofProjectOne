using System;
namespace ProjectOne
{
    public class PrivateClient : Client
    {
        public PrivateClient()
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Pesel Pesel { get; set; }
    }
}

