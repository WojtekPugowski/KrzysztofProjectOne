using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ProjectOne
{
    public struct Pesel
    {
        int sum = 0;
        int[] multiplier = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        bool isValidPesel = false;
        int rest = 0;

        public Pesel(string clientPesel)
        {

            ClientPesel = clientPesel;
            //if (clientPesel.Length != 11)
            //{
            //    throw new ArgumentException($"{nameof(clientPesel)} must have 11 chars");
            //}

            //ValidatePesel(clientPesel);

            //if (isValidPesel)
            //{
            //    ClientPesel = clientPesel;
            //}
            //else
            //{
            //    throw new InvalidOperationException("Wrong PESEL");
            //}
        }

        public string ClientPesel { get; }
        private bool ValidatePesel(string pesel)
        {
            rest = sum % 10;
            isValidPesel = CountSum(pesel).Equals(pesel[10].ToString());
            return isValidPesel;
        }
        private string CountSum(string clientPesel)
        {
            for (int i = 0; i < multiplier.Length; i++)
            {
                sum += multiplier[i] * int.Parse(clientPesel[i].ToString());
            }
            return rest == 0 ? rest.ToString() : (10 - rest).ToString();
        }

        public static implicit operator Pesel(string pesel) => new Pesel(pesel);

        //public override bool Equals([NotNullWhen(true)] object? obj)
        //{
            
        //    return;
        //}

        public override string ToString() => ClientPesel;

    }
}