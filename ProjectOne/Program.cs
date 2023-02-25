namespace ProjectOne;
class Program
{
    static void Main(string[] args)
    {
        var repository = new Repository();

        while (true)
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine(" 1 - Dodaj klienta\n" +
                "2 - Wyświetl klientów\n" +
                "3 - Usuń klienta\n");
            Console.WriteLine(" 4 - Dodaj produkt\n" +
                "5 - Wyświetl produkt\n" +
                "6 - Usuń produkt\n");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    AddClient(repository);
                    break;
                case 2:
                    ShowClients(repository);
                    break;
                case 3:
                    DeleteClient(repository);
                    break;
                case 4:
                    AddProduct(repository);
                    break;
                case 5:
                    ShowProducts(repository);
                    break;
                case 6:
                    DeleteProduct(repository);
                    break;
                default:
                    Console.WriteLine("Wybrałeś zły numer. Wybierz od 1-6");
                    break;
            }

        }
    }

    private static void DeleteProduct(Repository repo)
    {
        throw new NotImplementedException();
    }

    private static void ShowProducts(Repository repo)
    {
        throw new NotImplementedException();
    }

    private static void AddProduct(Repository repo)
    {
        throw new NotImplementedException();
    }

    private static void DeleteClient(Repository repo)
    {
        throw new NotImplementedException();
    }

    private static void ShowClients(Repository repo)
    {
        throw new NotImplementedException();
    }

    private static void AddClient(Repository repo)
    {
        Console.WriteLine("Wybierz rodzaj klienta:");
        Console.WriteLine("1 - Firma\n" +
            "2 - Klient prywatny");

        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                var companyClient = new CompanyClient();

                companyClient.Name = AskUser("Podaj nazwę firmy:");
                companyClient.NIP = AskUser("Podaj numer NIP:");
                companyClient.Address.Street = AskUser("Podaj ulicę");
                companyClient.Address.BuildingNumber = AskUser("Podaj numer budynku:");
                companyClient.Address.LocalNumber = AskUser("Podaj numer lokalu:");
                companyClient.Address.PostalCode = AskUser("Podaj kod pocztowy:");
                companyClient.Address.City = AskUser("Podaj nazwę miasta:");
                
                repo.Clients.Add(companyClient);
                break;
        }
    }

    private static string AskUser(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();
    }
}

