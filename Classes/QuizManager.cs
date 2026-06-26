using System.Collections.Generic;
using CybersecurityAwarenessBot.Models;

namespace CybersecurityAwarenessBot.Classes
{
    public class QuizManager
    {
        public List<QuizQuestion> Questions { get; set; }

        public QuizManager()
        {
            Questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What should you do if you receive an email asking for your password?",
                    Options = new string[]
                    {
                        "Reply with your password",
                        "Delete the email",
                        "Report it as phishing",
                        "Ignore it"
                    },
                    CorrectAnswerIndex = 2,
                    Explanation = "Reporting phishing emails helps prevent scams."
                },
                new QuizQuestion
                {
                    Question = "What does 2FA stand for?",
                    Options = new string[]
                    {
                       "Two-Factor Authentication",
                       "Two-File Access",
                       "Second Firewall Access",
                       "Two-Folder Authorization"
                    },
                    CorrectAnswerIndex = 0,
                    Explanation = "2FA adds an extra layer of security to your account."
                },
                new QuizQuestion
                {
                    Question = "True or False: Public Wi-Fi networks are always safe.",
                    Options = new string[]
                    {
                       "True",
                       "False"
                    },
                    CorrectAnswerIndex = 1,
                    Explanation = "Public Wi-Fi can expose your data to attackers."
                },
                new QuizQuestion
                {
                    Question = "Which of the following is the strongest password?",
                    Options = new string[]
                    {
                      "password123",
                      "John2024",
                      "P@55w0rd!",
                      "T#8kL!9zQ@2x"
                    },
                    CorrectAnswerIndex = 3,
                    Explanation = "Strong passwords use a combination of symbols, numbers, and letters."
                },
                 new QuizQuestion
                {
                    Question = "What is phishing?",
                    Options = new string[]
                    {
                       "A fishing hobby",
                       "A type of cyberattack using fake messages",
                       "A security update",
                       "A password manager"
                    },
                    CorrectAnswerIndex = 1,
                    Explanation = "Phishing tricks users into revealing sensitive information."
                },
                 new QuizQuestion
                {
                    Question = "True or False: You should share your passwords with friends.",
                    Options = new string[]
                    {
                       "True",
                       "False"
                    },
                    CorrectAnswerIndex = 1,
                    Explanation = "Passwords should never be shared."
                },
                 new QuizQuestion
                {
                   Question = "What should you do before clicking a link in an email?",
                   Options = new string[]
                   {
                      "Click immediately",
                      "Check the sender and URL",
                      "Forward it",
                      "Ignore everything"
                   },
                   CorrectAnswerIndex = 1,
                   Explanation = "Always verify links before clicking."
                },
                 new QuizQuestion
                {
                   Question = "What is malware?",
                   Options = new string[]
                   {
                       "A computer game",
                       "Malicious software",
                       "A web browser",
                       "A firewall"
                   },
                   CorrectAnswerIndex = 1,
                   Explanation = "Malware is software designed to damage or exploit systems."
                },
                 new QuizQuestion
                {
                   Question = "True or False: Software updates improve security.",
                   Options = new string[]
                   {
                       "True",
                       "False"
                   },
                   CorrectAnswerIndex = 0,
                   Explanation = "Updates often fix security vulnerabilities."
                },
                 new QuizQuestion
                {
                   Question = "What is social engineering?",
                   Options = new string[]
                   {
                       "Building social media apps",
                       "Manipulating people into revealing information",
                       "Creating websites",
                       "Installing software"
                   },
                   CorrectAnswerIndex = 1,
                   Explanation = "Social engineering targets people rather than systems."
                },
                 new QuizQuestion
                {
                   Question = "What should you do if you suspect ransomware?",
                   Options = new string[]
                   {
                        "Pay immediately",
                        "Disconnect the device and report it",
                        "Ignore it",
                        "Share it with friends"
                   },
                   CorrectAnswerIndex = 1,
                   Explanation = "Disconnecting helps stop the spread of ransomware."
                },
                new QuizQuestion
                {
                    Question = "True or False: Using the same password for all accounts is safe.",
                    Options = new string[]
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswerIndex = 1,
                    Explanation = "Each account should have a unique password."
                }
            };
        }
    }
}