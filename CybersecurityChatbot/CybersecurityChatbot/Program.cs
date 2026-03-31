using System;
using System.Threading;
using CybersecurityChatbot.Services;

namespace CybersecurityChatbot
{
    class Program
    {
        private static UIService _uiService;
        private static ChatbotService _chatbotService;
        private static AudioService _audioService;

        static void Main(string[] args)
        {
            // Initialize services
            _uiService = new UIService();
            _chatbotService = new ChatbotService();
            _audioService = new AudioService();

            // Set console window properties for better appearance
            Console.Title = "Cybersecurity Awareness Bot";
            Console.WindowWidth = 90;
            Console.BufferWidth = 90;

            // Play voice greeting
            _audioService.PlayGreeting();

            // Display ASCII art
            _uiService.DisplayAsciiArt();
            Thread.Sleep(1000); // Pause for effect

            // Welcome message with typing effect
            _uiService.TypeWriterEffect("\nInitializing security protocols...", 40);
            Thread.Sleep(500);
            _uiService.DisplaySuccessMessage("System ready!");
            Thread.Sleep(500);

            // Get user name with validation
            string userName = GetValidUserName();
            _chatbotService.SetUserName(userName);

            // Personalized welcome
            _uiService.DisplayDivider();
            _uiService.TypeWriterEffect($"\nHello, {userName}! Welcome to the Cybersecurity Awareness Bot!", 30);
            Thread.Sleep(500);
            _uiService.TypeWriterEffect("I'm here to help you stay safe online and protect your digital life.", 30);

            _uiService.DisplayDivider();
            _uiService.DisplayInfoMessage($"Type 'help' anytime to see what I can do, or 'bye' to exit.");
            _uiService.DisplayDivider();

            // Main chat loop
            bool isRunning = true;
            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\n[{userName}] > ");
                Console.ResetColor();

                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    _uiService.DisplayErrorMessage("Please enter a message. I'm here to help!");
                    continue;
                }

                _uiService.DisplayUserMessage(userName, userInput);

                // Get bot response
                var response = _chatbotService.GetResponse(userInput);

                // Check for exit command
                if (response.Topic == "Exit")
                {
                    _uiService.DisplayBotMessage(response.Message, "Farewell");
                    _uiService.DisplayDivider();
                    _uiService.DisplayInfoMessage("Thank you for using the Cybersecurity Awareness Bot!");
                    _uiService.DisplayInfoMessage("Remember: Stay vigilant, stay secure! 🔒");
                    isRunning = false;
                    break;
                }

                // Display bot response with typing effect for realism
                _uiService.TypeWriterEffect($"\nBOT [{response.Topic}]: {response.Message}", 20);

                // Show help menu if user asked for it
                if (response.Topic == "Help")
                {
                    _uiService.DisplayHelpMenu();
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static string GetValidUserName()
        {
            string userName = "";
            bool isValid = false;

            while (!isValid)
            {
                _uiService.DisplayHeader("WELCOME TO CYBERSECURITY AWARENESS BOT");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nPlease enter your name: ");
                Console.ResetColor();

                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    _uiService.DisplayErrorMessage("Name cannot be empty. Please enter a valid name.");
                }
                else if (userName.Length < 2)
                {
                    _uiService.DisplayErrorMessage("Name must be at least 2 characters long.");
                }
                else
                {
                    isValid = true;
                    // Capitalize first letter
                    userName = char.ToUpper(userName[0]) + userName.Substring(1).ToLower();
                }
            }

            return userName;
        }
    }
}