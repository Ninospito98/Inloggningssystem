using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Drawing;
using static System.Console;

namespace Inloggningssystem
{
    internal class Program
    {
        static bool running = true;

        //Det går att använda lists så man kan skapa så många konto som möjligt.
        //just nu man kan bara skapa 5 konto, går att ändra!
        static string[] userName = new string[5];
        static string[] passWord = new string[5];
        static int userCount = 0;

        static void Main(string[] args)
        {

            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║   Välkommen till inloggningssidan    ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                ResetColor();
                WriteLine();
                Console.WriteLine("Välj en åtgärd:");

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\n1. Skapa konto");
                Console.WriteLine("2. Logga in");
                Console.WriteLine("3. Avsluta programmet");
                ResetColor();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SignIn();

                        break;


                    case "2":
                        LogIn();
                        break;

                    case "3":
                        running = false;
                        Console.WriteLine("Tack, Vi ses!");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Välja (1) (2) eller (3)");
                        Console.ReadKey();
                        break;
                }

            }

        }

        static void SignIn()
        {
            bool skapa = true;

            while (skapa)
            {
                Console.Clear();
                Console.Write("Ange ett användarnamn: ");

                Console.ForegroundColor = ConsoleColor.White;
                string newUserName = Console.ReadLine();
                ResetColor();

                bool finns = false;
                for (int i = 0; i < userCount; i++)
                {
                    if (newUserName.ToLower() == userName[i].ToLower())
                    {                                              //Så To.Lower här gör att Man kan inte skapa en account med tillex
                                                                   //Ninos och sen en annan account med NINOS 
                        finns = true;
                    }

                }
                if (finns)
                {
                    Console.WriteLine("Konto finns redan, try again");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Ange ett lösenord: ");

                Console.ForegroundColor = ConsoleColor.White;
                string newPassWord = Console.ReadLine();
                ResetColor();
                if(newPassWord.Length < 6) //lite extra just for fun
                {
                    ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nLösenordet måste vara minst 6 tecken långt.försök igen.");
                    ResetColor();
                    ReadKey();
                    continue;
                }
                userName[userCount] = newUserName;
                passWord[userCount] = newPassWord;
                userCount++;

                Console.Clear();
                Console.WriteLine("Du har skapat ett konto.");
                Console.WriteLine();
                Console.WriteLine($"Ditt användarnamn är: {newUserName}");
                Console.WriteLine($"Ditt lösenord är: {newPassWord}");
                Console.WriteLine();
                Console.WriteLine("klick Enter för att Gå tillbaka till huvudmenyn för att logga in.");
                Console.ReadKey();
                skapa = false;
            }
            

        }

        static void LogIn()
        {
            bool LoggedIn = false;

            while (!LoggedIn)
            {
                Console.Clear();
                Console.Write("Användarnamn: ");
                string typeUsername = Console.ReadLine();
                Console.Write("Lösenord: ");
                string typePassword = Console.ReadLine();

                bool hittad = false;

                for (int i = 0; i < userCount; i++)
                {

                    if (typeUsername == userName[i] && typePassword == passWord[i])
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("you are logged in");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nHello {userName[i]}");
                        Console.ReadKey();
                        hittad = true;
                        LoggedIn = true;
                        running = false; //when logged in then stop the whole program from running.
                                         //should delete if later want to continue running after logged in
                        break;
                    }

                }
                if (!hittad)
                {
                    Console.Clear();
                    Console.WriteLine("Fel användarnamn eller lösenord, Försök igen!");
                    
                    Console.ReadKey();

                }
            }
                

        }
    }
}
