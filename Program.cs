namespace Kassasystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StartMenu startMenu = new StartMenu();

            startMenu.ShowMenu();

            //Menyval Ny kund, Admin, Avsluta

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
