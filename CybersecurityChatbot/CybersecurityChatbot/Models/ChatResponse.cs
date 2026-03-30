using System;

namespace CybersecurityChatbot.Models
{
    public class ChatResponse
    {
        public string Message { get; set; }
        public string Topic { get; set; }
        public DateTime Timestamp { get; set; }

        public ChatResponse()
        {
            Timestamp = DateTime.Now;
        }

        public ChatResponse(string message, string topic) : this()
        {
            Message = message;
            Topic = topic;
        }
    }
}