using System;
namespace ProjectOne
{
    public class Address
    {
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string LocalNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return $"ul. {Street} {BuildingNumber} / {LocalNumber}\n" +
                   $"{PostalCode} {City}"; 
        }
    }


}

