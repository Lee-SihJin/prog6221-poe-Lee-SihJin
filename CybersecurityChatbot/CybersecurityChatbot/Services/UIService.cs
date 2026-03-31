using System;
using System.Threading;

namespace CybersecurityChatbot.Services
{
    public class UIService
    {
        private static readonly object _consoleLock = new object();

        public void DisplayAsciiArt()
        {
            string asciiArt = @"
    ╔════════════════════════════════════════════════════════╗
    ║                                                        ║
    ║    ██████╗██╗   ██╗██████╗ ███████╗██████╗             ║
    ║   ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗            ║
    ║   ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝            ║
    ║   ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗            ║
    ║   ╚██████╗   ██║   ██████╔╝███████╗██║  ██║            ║
    ║    ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝            ║
    ║                                                        ║
    ║         █████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗      ║
    ║        ██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝      ║
    ║        ███████║██║ █╗ ██║███████║██████╔╝█████╗        ║
    ║        ██╔══██║██║███╗██║██╔══██║██╔══██╗██╔══╝        ║
    ║        ██║  ██║╚███╔███╔╝██║  ██║██████╔╝███████╗      ║
    ║        ╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═════╝ ╚══════╝      ║
    ║                                                        ║
    ║            Cybersecurity Awareness Bot v1              ║
    ║        Your Guide to Online Safety & Security          ║
    ║                                                        ║
    ╚════════════════════════════════════════════════════════╝
";
            lock (_consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(asciiArt);
                Console.ResetColor();
            }
        }

        public void DisplayHeader(string title)
        {
            lock (_consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n┌{new string('─', 60)}┐");
                Console.WriteLine($"│ {title.PadRight(59)}│");
                Console.WriteLine($"└{new string('─', 60)}┘");
                Console.ResetColor();
            }
        }

        public void DisplayDivider()
        {
            lock (_consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n{new string('─', 72)}");
                Console.ResetColor();
            }
        }

        public void DisplayBotMessage(string message, string topic = "General")
        {
            lock (_consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n BOT ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[{topic}]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($": {message}");
                Console.ResetColor();
            }
        }

        public void DisplayUserMessage(string userName, string message)
        {
            lock (_consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"\n {userName}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($" [{DateTime.Now:HH:mm:ss}]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($": {message}");
                Console.ResetColor();
            }
        }

        public void DisplayErrorMessage(string message)
        {
            lock (_consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n  {message}");
                Console.ResetColor();
            }
        }

        public void DisplayInfoMessage(string message)
        {
            lock (_consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n  {message}");
                Console.ResetColor();
            }
        }

        public void DisplaySuccessMessage(string message)
        {
            lock (_consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n {message}");
                Console.ResetColor();
            }
        }

        public void TypeWriterEffect(string message, int delayMs = 30)
        {
            lock (_consoleLock)
            {
                foreach (char c in message)
                {
                    Console.Write(c);
                    Thread.Sleep(delayMs);
                }
                Console.WriteLine();
            }
        }

        public void DisplayHelpMenu()
        {
            DisplayHeader("WHAT CAN I HELP YOU WITH?");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  PASSWORD SAFETY");
            Console.ResetColor();
            Console.WriteLine("     • How to create strong passwords");
            Console.WriteLine("     • Password managers");
            Console.WriteLine("     • Two-factor authentication");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  PHISHING PROTECTION");
            Console.ResetColor();
            Console.WriteLine("     • Identifying phishing emails");
            Console.WriteLine("     • Suspicious links");
            Console.WriteLine("     • Email safety tips");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  SAFE BROWSING");
            Console.ResetColor();
            Console.WriteLine("     • HTTPS and secure websites");
            Console.WriteLine("     • Public Wi-Fi safety");
            Console.WriteLine("     • Browser extensions");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  GENERAL QUESTIONS");
            Console.ResetColor();
            Console.WriteLine("     • 'How are you?'");
            Console.WriteLine("     • 'What is your purpose?'");
            Console.WriteLine("     • 'Help' or 'Menu'");

            DisplayDivider();
        }
    }
}