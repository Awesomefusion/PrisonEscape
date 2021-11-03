using System;
using System.Runtime.InteropServices;
using Figgle;

namespace PrisonEscape
{
    class Program
    {
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        static void Main()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Title = "Prison Escape";
                Console.WindowHeight = 50;
                Console.WindowWidth = 125;
            }

            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);

            static void Dialog(string message, string colour){
                if (colour == "red")
                { Console.ForegroundColor = ConsoleColor.Red; }
                else if (colour == "cyan")
                { Console.ForegroundColor = ConsoleColor.Cyan; }
                else if (colour == "yellow")
                { Console.ForegroundColor = ConsoleColor.Yellow; }
                else
                { Console.ForegroundColor = ConsoleColor.White; }

                Console.WriteLine(message);
                Console.ResetColor();
            }

            Console.WriteLine(FiggleFonts.Standard.Render("Prison Escape"));
            Console.WriteLine("");
            Dialog("You wake up in a cold, damp dark and musty prison cell. You hear a spirit whisper to you, 'What is your name, prisoner?", "cyan");
            Console.WriteLine("");
            string name = Console.ReadLine();
            Console.WriteLine("");
            Dialog("Hello {name}, it seems you find yourself in a bit of a predicament, let's try and get you out of here.", "cyan");
            Console.WriteLine("");
            bool win = false;
            string choiceOne = "1";
            string choiceTwo = "2";
            Dialog("You notice a loose slab of rock on the floor of your prison cell and also a set of bent prison bars you may be able to fit through, Input 1 to check the floor or Input 2 to squeeze through the bars.", "red");
            Console.WriteLine("");
            string input = "";
            input = Console.ReadLine();
            Console.WriteLine("");
            if ( input == choiceOne)
            {
                Dialog("You managed to drop down to the room below your prison cell, finding the armory. Input 1 to gear up. Input 2 to make a run for it.", "cyan");
                Console.WriteLine("");
                input = Console.ReadLine();
                if ( input == choiceOne)
                {
                    win = true;
                    Dialog("You find a longsword and a studded armor set and begin to search for an exit, you encounter a guard and manage to surprise him and drive your sword through his chest. Luckily the prison was under construction and you found a small hole to crawl out of.", "cyan");
                        if (win == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine(FiggleFonts.Standard.Render("You Win!"));
                        }
                }
                if ( input == choiceTwo )
                {
                    win = false;
                    Dialog("You make a run for it, frantically searching for an exit, a prison guard encounters you and bashes you in the head with his cudgel and returns you to your cell.", "cyan");
                        if (win == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine(FiggleFonts.Standard.Render("You Lose! Enjoy Prison!"));
                        }
                }
                else
                {
                    Dialog("Input either 1 or 2!", "cyan");
                }
            }


            else if ( input == choiceTwo)
            {
                Dialog("You squeeze through the prison bars, however it is very tight and you break a rib limiting your movement. You move to the shadows to avoid detection. Input 1 to sneak out. Input 2 to sprint to the exit.", "cyan");
                Console.WriteLine("");
                input = Console.ReadLine();
                if (input == choiceOne)
                    win = true;
                    if (win == true)
                    {
                        Dialog("You manage to sneak past the guards and stick to the shadowy corners of the prison halls until you find a drainage gap with a few bars missing", "cyan");
                        Console.WriteLine("");
                        Console.WriteLine(FiggleFonts.Standard.Render("You Win!"));
                    }
                if (input == choiceTwo)
                {
                    win = false;
                    if (win == false)
                    {
                        Console.WriteLine("");
                        Dialog("You begin sprinting frantically around the corridoors until you come across a guard, enraged at your escape he chases you and runs you through with his sword.", "cyan");
                        Console.WriteLine(FiggleFonts.Standard.Render("You Lose! RIP"));
                    }
                }
            }
            else
            {
                Dialog("Input either 1 or 2", "red");
            }


            Console.ReadLine();
        }
    }
}
