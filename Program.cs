namespace Kassasystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> productList = new List<Product>
            {
                new Product(001, "äpple", 34.95f, true),
                new Product(002, "banan", 28.95f, true),
                new Product(003, "mjölk 1l", 13.50f, false),
                new Product(004, "snabbkaffe", 78.95f, false),
                new Product(005, "nötfärs 1kg", 120.00f, false),
                new Product(006, "varmkorv", 37.95f, false),
                new Product(007, "bröd", 29.95f, false),
                new Product(008, "korvbröd", 20.95f, false),
                new Product(009, "kakor", 21.95f, false),
                new Product(010, "läsk", 15.95f, false),

            };

            //Menyval Ny kund, Admin, Avsluta
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Skriv siffra för menyval:");
                Console.WriteLine("1. Ny kund");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Avsluta");

                string input = Console.ReadLine();
                int option;

                Console.Clear();

                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Ny kund val");
                            break;

                        case 2:
                            Console.WriteLine("Admin val");
                            break;

                        case 3:
                            Console.WriteLine("Kassan stängs, tryck valfri tangent...");
                            Console.ReadKey();
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                }
            }



            //Ny kund
            //Få/söka en lista på produkter och artikelnummer
            //Skriva in artikelnummer och antal (beep, för simulering av att "blippa" varor, skriver ut artikelnamn och antal plus pris, samnt om rea
            //Betalfunktion

            //Admin
            //Lägg till varor/ändra nammn pris
            //ta bort varor
            //lägg till kampanj
            //ta bort kampanj

            //kvitton ska sparas ner med dagens datum, alla på samma dygn tillsammans, individuella löpnummer +1 för varje nytt kvitto
        }
    }
}
