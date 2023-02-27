using System;
namespace ProjectOne
{
    public abstract class Client
    {
        public Address Address { get; set; } = new Address();
        public Guid Id { get; set; } = Guid.NewGuid();

    }
}

