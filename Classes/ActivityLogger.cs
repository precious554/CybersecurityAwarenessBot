using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityAwarenessBot.Classes
{
    // Records and retrieves chatbot activities.
    public class ActivityLogger
    {
        private List<string> activities = new List<string>();

        public void Log(string action)
        {
            activities.Add($"{DateTime.Now:G} - {action}");
        }

        public List<string> GetRecentActivities(int count = 10)
        {
            return activities.TakeLast(count).ToList();
        }
    }
}