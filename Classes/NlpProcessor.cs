namespace CybersecurityAwarenessBot.Classes
{
    // Detects the user's intent using keyword matching.
    public class NlpProcessor
    {
        public string DetectIntent(string input)
        {
            input = input.ToLower();

            if (input.Contains("task") ||
                input.Contains("reminder") ||
                input.Contains("remember"))
            {
                return "TASK";
            }

            if (input.Contains("quiz") ||
                input.Contains("question") ||
                input.Contains("game"))
            {
                return "QUIZ";
            }

            if (input.Contains("password") ||
                input.Contains("phishing") ||
                input.Contains("privacy") ||
                input.Contains("scam"))
            {
                return "CYBERSECURITY";
            }

            if (input.Contains("activity log") ||
                input.Contains("what have you done for me"))
            {
                return "LOG";
            }

            return "UNKNOWN";
        }
    }
}