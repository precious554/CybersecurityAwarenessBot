namespace CybersecurityAwarenessBot.Models
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string[] Options { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string Explanation { get; set; }
    }
}