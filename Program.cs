using Kassasystem.MenusFolder;

namespace Kassasystem
{
    internal class Program
    {

        static void Main(string[] args)
        {

            WelcomeAnimation.ShowWelcomeAnimation();
            Console.ReadKey();
            StartMenu startMenu = new StartMenu();
            startMenu.ShowMenu();

        }
    }
}
