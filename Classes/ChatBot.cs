using System.Collections.Generic;

namespace CybersecurityAwarenessBot.Classes
{
    public class ChatBot
    {
        private Dictionary<string, string> responses;

        public ChatBot()
        {
            responses = new Dictionary<string, string>()
            {
                { "password", "Use strong and unique passwords for every account." },
                { "phishing", "Be careful of suspicious emails asking for personal information." },
                { "privacy", "Review your privacy settings regularly to protect your data." },
                { "scam", "Never share sensitive information with unverified sources." }
            };
        }

        public string GetResponse(string input)
        {
            input = input.ToLower();

            foreach (var item in responses)
            {
                if (input.Contains(item.Key))
                {
                    return item.Value;
                }
            }

            return "I didn't quite understand that. Could you rephrase?";
        }
    }
}