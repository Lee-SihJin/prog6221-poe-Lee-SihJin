using System;
using System.IO;
using System.Media;

namespace CybersecurityChatbot.Services
{
    public class AudioService
    {
        private string _audioFilePath;

        public AudioService()
        {
            // Look for audio file in multiple possible locations
            string[] possiblePaths = {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "greeting.wav"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav"),
                Path.Combine(Directory.GetCurrentDirectory(), "Data", "greeting.wav"),
                Path.Combine(Directory.GetCurrentDirectory(), "greeting.wav")
            };

            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    _audioFilePath = path;
                    break;
                }
            }
        }

        public void PlayGreeting()
        {
            try
            {
                if (!string.IsNullOrEmpty(_audioFilePath) && File.Exists(_audioFilePath))
                {
                    using (SoundPlayer player = new SoundPlayer(_audioFilePath))
                    {
                        player.PlaySync(); // Play synchronously to complete before continuing
                    }
                }
                else
                {
                    Console.WriteLine("[Audio] Greeting file not found. Continuing without audio...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio] Error playing greeting: {ex.Message}");
            }
        }
    }
}