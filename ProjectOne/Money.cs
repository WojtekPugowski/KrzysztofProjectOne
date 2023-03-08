namespace ProjectOne
{
    public struct Money
    {
        public Money(decimal price, string currency)
        {
            if (!(price > 0))
            {
                throw new ArgumentException($"{nameof(Price)} must be greater than 0");
            }

            if (string.IsNullOrEmpty(currency) || currency.Length != 3)
            {
                throw new ArgumentException($"{nameof(Currency)} Null Or empty or incorrect value");
            }

            Price = price;
            Currency = currency.ToUpper();
        }

        public decimal Price { get; }
        public string Currency { get; }

        public static Money CreateNewFromPln(decimal price)
        {
            return new Money(price, "PLN");
        }

        public override string ToString() => $"{Price} {Currency}";

    }
}
