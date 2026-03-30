using System;
using System.Collections.Generic;
using System.Linq;
using CybersecurityChatbot.Models;

namespace CybersecurityChatbot.Services
{
    public class ChatbotService
    {
        private Dictionary<string, string[]> _intentKeywords;
        private Dictionary<string, string[]> _responses;
        private string _userName;

        public ChatbotService()
        {
            InitializeIntentKeywords();
            InitializeResponses();
        }

        private void InitializeIntentKeywords()
        {
            _intentKeywords = new Dictionary<string, string[]>
            {
                { "Password", new[] { "password", "pass", "strong password", "password manager", "2fa", "two factor", "authentication" } },
                { "Phishing", new[] { "phish", "phishing", "scam", "fraud", "suspicious email", "fake email" } },
                { "Browsing", new[] { "browse", "browsing", "https", "secure site", "public wifi", "wifi", "browser" } },
                { "Greeting", new[] { "how are you", "how are you doing", "how's it going", "what's up" } },
                { "Purpose", new[] { "what is your purpose", "what do you do", "who are you", "what can you do" } },
                { "Help", new[] { "help", "menu", "what can i ask", "commands", "options" } }
            };
        }

        private void InitializeResponses()
        {
            _responses = new Dictionary<string, string[]>
            {
                { "Password", new[]
                    {
                        "Use a password manager like Bitwarden or LastPass to generate and store unique passwords.",
                        "Create strong passwords with at least 12 characters, mixing uppercase, lowercase, numbers, and symbols.",
                        "Never reuse passwords across different accounts. Enable Two-Factor Authentication (2FA) whenever possible.",
                        "Consider using passphrases - a sequence of random words that's long but easy to remember."
                    }
                },
                { "Phishing", new[]
                    {
                        "Never click on suspicious links in emails. Always hover over links to see the actual URL.",
                        "Check the sender's email address carefully - scammers often use addresses that look similar to legitimate ones.",
                        "Legitimate companies never ask for your password or personal information via email.",
                        "Look for red flags: urgent language, spelling errors, requests for personal info, and unexpected attachments."
                    }
                },
                { "Browsing", new[]
                    {
                        "Always look for 'https://' and the padlock icon in your browser's address bar before entering sensitive information.",
                        "Avoid using public Wi-Fi for banking or shopping. If you must, use a VPN (Virtual Private Network).",
                        "Keep your browser and extensions updated to protect against security vulnerabilities.",
                        "Use ad-blockers and privacy extensions to reduce tracking and malicious ads."
                    }
                },
                { "Greeting", new[]
                    {
                        "I'm doing great, thanks for asking! I'm here to help you stay safe online. 😊",
                        "All systems secure! Ready to help you learn about cybersecurity.",
                        "I'm functioning perfectly! What would you like to know about online safety?"
                    }
                },
                { "Purpose", new[]
                    {
                        "I'm your Cybersecurity Awareness Bot! I'm here to educate you about online safety, including password security, phishing protection, and safe browsing habits.",
                        "My purpose is to help you stay safe in the digital world. I can teach you about passwords, phishing, safe browsing, and more!",
                        "I'm designed to raise cybersecurity awareness. Ask me anything about staying safe online!"
                    }
                },
                { "Help", new[]
                    {
                        "I can help you with:\n• Password safety tips\n• Phishing protection\n• Safe browsing practices\n• General cybersecurity questions\n\nTry asking: 'How to create strong passwords?' or 'What is phishing?'",
                        "Here's what I can do: answer questions about passwords, phishing, safe browsing, and cybersecurity best practices. Type 'help' anytime to see this menu!"
                    }
                }
            };
        }

        public void SetUserName(string name)
        {
            _userName = name;
        }

        public string GetUserName()
        {
            return _userName;
        }

        public ChatResponse GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return new ChatResponse("I didn't catch that. Could you please say something?", "Invalid Input");
            }

            string lowerInput = userInput.ToLower().Trim();

            // Check for goodbye
            if (lowerInput.Contains("bye") || lowerInput.Contains("goodbye") || lowerInput.Contains("exit") || lowerInput.Contains("quit"))
            {
                return new ChatResponse($"Goodbye, {_userName}! Stay safe online! ", "Exit");
            }

            // Find matching intent
            string intent = "General";
            foreach (var kvp in _intentKeywords)
            {
                if (kvp.Value.Any(keyword => lowerInput.Contains(keyword)))
                {
                    intent = kvp.Key;
                    break;
                }
            }

            // Get response based on intent
            string responseMessage;
            if (_responses.ContainsKey(intent))
            {
                var possibleResponses = _responses[intent];
                Random rand = new Random();
                responseMessage = possibleResponses[rand.Next(possibleResponses.Length)];

                // Personalize if user name is available
                if (!string.IsNullOrEmpty(_userName) && intent != "Greeting")
                {
                    responseMessage = responseMessage.Replace("you", _userName);
                }
            }
            else
            {
                responseMessage = GetDefaultResponse();
            }

            return new ChatResponse(responseMessage, intent);
        }

        private string GetDefaultResponse()
        {
            string[] defaultResponses = {
                "I'm not sure about that. Could you ask me about passwords, phishing, or safe browsing?",
                "Interesting question! I specialize in cybersecurity topics like password safety, phishing protection, and secure browsing.",
                "I didn't quite understand that. Try asking about passwords, phishing, or how to browse safely!",
                $"I'm here to help with cybersecurity! Would you like tips on passwords, phishing, or safe browsing?"
            };

            Random rand = new Random();
            return defaultResponses[rand.Next(defaultResponses.Length)];
        }
    }
}