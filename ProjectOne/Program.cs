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

    private static void AddProduct(Repository repo)
    {
        var productAdded = new Product();

        productAdded.Name = AskUser<string>("Podaj nazwę produktu:");
        productAdded.Price = AskUser<decimal>("Podaj cenę produktu:");
        productAdded.Ean = AskUser<string>("Podaj kod produktu:");

        repo.Products.Add(productAdded);
    }

    private static void ShowProducts(Repository repo)
    {
        var product = repo.Products.FirstOrDefault(x => x.Ean == AskUser<string>("Podaj numer EAN do wyświetlenia"));
        if (product != null)
        {
            Console.WriteLine($"Nazwa produktu: {product.Name}, cena: {product.Price}, EAN: {product.Ean}\n");
        }
        else { Console.WriteLine("Nie ma w DB takiego EAN\n"); }
    }

    private static void DeleteProduct(Repository repo)
    {
        var product = repo.Products.FirstOrDefault(x => x.Ean == AskUser<string>("Podaj numer EAN do usunięcia"));
        if (AskUser<string>($"Na pewno chcesz usunąć produkt z EAN {product.Ean}? wybierz T lub N") == "T")
        {
            repo.Products.Remove(product);
        }
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

                companyClient.Name = AskUser<string>("Podaj nazwę firmy:");
                companyClient.NIP = AskUser<string>("Podaj numer NIP:");
                companyClient.Address.Street = AskUser<string>("Podaj ulicę");
                companyClient.Address.BuildingNumber = AskUser<string>("Podaj numer budynku:");
                companyClient.Address.LocalNumber = AskUser<string>("Podaj numer lokalu:");
                companyClient.Address.PostalCode = AskUser<string>("Podaj kod pocztowy:");
                companyClient.Address.City = AskUser<string>("Podaj nazwę miasta:");
                companyClient.Id = Guid.NewGuid();

                repo.Clients.Add(companyClient);
                break;

            case 2:
                var privateClient = new PrivateClient();

                privateClient.FirstName = AskUser<string>("Podaj imię:");
                privateClient.SecondName = AskUser<string>("Podaj nazwisko:");
                privateClient.Pesel = AskUser<string>("Podaj numer PESEL:");
                privateClient.Address.Street = AskUser<string>("Podaj ulicę");
                privateClient.Address.BuildingNumber = AskUser<string>("Podaj numer budynku:");
                privateClient.Address.LocalNumber = AskUser<string>("Podaj numer lokalu:");
                privateClient.Address.PostalCode = AskUser<string>("Podaj kod pocztowy:");
                privateClient.Address.City = AskUser<string>("Podaj nazwę miasta:");
                privateClient.Id = Guid.NewGuid();

                repo.Clients.Add(privateClient);

                break;
        }
    }

    private static void ShowClients(Repository repo)
    {
        var client = repo.Clients.FirstOrDefault(x => x.Id == AskUser<Guid>("Podaj numer ID klienta, którego dane chcesz zobaczyć"));
    }

    private static void DeleteClient(Repository repo)
    {
        var client = repo.Clients.FirstOrDefault(x => x.Id == AskUser<Guid>("Podaj numer ID"));
        if (AskUser<string>($"Na pewno chcesz usunąć klienta o ID = {client.Id}? wybierz T lub N") == "T")
        {
            repo.Clients.Remove(client);
        }
    }

    private static T? AskUser<T>(string question)
    {
        Console.WriteLine(question);
        if (typeof(T).Equals(typeof(String)))
        {
            return (T)(Console.ReadLine() as object);
        }
        else if (typeof(T).Equals(typeof(Decimal)))
        {
            do
            {
                try
                {
                    return (T)(object)decimal.Parse(Console.ReadLine() ?? string.Empty);
                }
                catch
                {
                    Console.WriteLine("Podaj poprawne dane w postaci liczbowej");
                }

            } while (true);
        }
        else if (typeof(T).Equals(typeof(Guid)))
        {
            do
            {
                try
                {
                    return (T)(object)Guid.Parse(Console.ReadLine() ?? string.Empty);
                }
                catch
                {
                    Console.WriteLine("Podaj poprawne dane ID");
                }

            } while (true);
        }
        else { return default(T); }

    }
}

