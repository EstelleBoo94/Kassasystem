namespace Kassasystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

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
                            NewCustomer customer = new NewCustomer();
                            customer.StartPurchase();
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
