using System.Windows;
using CybersecurityAwarenessBot.Classes;
using CybersecurityAwarenessBot.Models;

namespace CybersecurityAwarenessBot
{
    public partial class MainWindow : Window
    {
        private ChatBot chatbot;
        private ActivityLogger logger;
        private NlpProcessor nlp;
        private TaskManager taskManager;
        private QuizManager quizManager;

        private int currentQuestionIndex = 0;
        private int score = 0;
        private bool quizInProgress = false;

        public MainWindow()
        {
            InitializeComponent();

            chatbot = new ChatBot();
            logger = new ActivityLogger();
            nlp = new NlpProcessor();
            taskManager = new TaskManager();
            quizManager = new QuizManager();
            foreach (var task in taskManager.GetTasks())
            {
                TaskListBox.Items.Add(task.Title);
            }

            ChatDisplay.AppendText("Cybersecurity Bot: Welcome! Ask me about passwords, phishing, privacy, scams, tasks, or quizzes.\n\n");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            ChatDisplay.AppendText("You: " + userMessage + "\n");

            string intent = nlp.DetectIntent(userMessage);
            string response;
            if (quizInProgress)
            {
                if (int.TryParse(userMessage, out int answer))
                {
                    var question = quizManager.Questions[currentQuestionIndex];

                    if (answer - 1 == question.CorrectAnswerIndex)
                    {
                        score++;

                        ChatDisplay.AppendText(
                            $"Bot: Correct! {question.Explanation}\n\n");
                    }
                    else
                    {
                        ChatDisplay.AppendText(
                            $"Bot: Incorrect. {question.Explanation}\n\n");
                    }

                    ScoreText.Text = $"Score: {score}";

                    currentQuestionIndex++;

                    ShowQuestion();

                    UserInput.Clear();
                    return;
                }
            }
            switch (intent)
            {
                case "CYBERSECURITY":
                    response = chatbot.GetResponse(userMessage);
                    break;

                case "TASK":

                    string taskTitle = userMessage
                        .Replace("add task", "")
                        .Replace("task", "")
                        .Trim();

                    if (!string.IsNullOrWhiteSpace(taskTitle))
                    {
                        TaskItem task = new TaskItem
                        {
                            Title = taskTitle,
                            Description = taskTitle
                        };
                        if (userMessage.ToLower().Contains("tomorrow"))
                        {
                            task.ReminderDate = DateTime.Now.AddDays(1);
                        }

                        if (userMessage.ToLower().Contains("3 days"))
                            logger.Log($"Reminder set for task: {task.Title}");
                        {
                            task.ReminderDate = DateTime.Now.AddDays(3);
                        }

                        if (userMessage.ToLower().Contains("7 days"))
                            logger.Log($"Reminder set for task: {task.Title}");
                        {
                            task.ReminderDate = DateTime.Now.AddDays(7);
                        }

                        taskManager.AddTask(task);

                        TaskListBox.Items.Add(task.Title);

                        if (task.ReminderDate != null)
                        {
                            response = $"Task added: {task.Title}. Reminder set for {task.ReminderDate:dd MMM yyyy}.";
                        }
                        else
                        {
                            response = $"Task added: {task.Title}";
                        }

                        logger.Log($"Task added: {task.Title}");
                    }
                    else
                    {
                        response = "Please provide a task name.";
                    }

                    break;

                case "QUIZ":

                    if (!quizInProgress)
                    {
                        quizInProgress = true;
                        currentQuestionIndex = 0;
                        score = 0;

                        ScoreText.Text = "Score: 0";

                        logger.Log("Quiz started.");

                        response = "Starting Cybersecurity Quiz!";
                        ShowQuestion();
                    }
                    else
                    {
                        response = "Quiz already in progress.";
                    }

                    break;

                case "LOG":
                    response = "Showing recent activity log...";
                    foreach (var activity in logger.GetRecentActivities())
                    {
                        ActivityLogList.Items.Add(activity);
                    }
                    break;

                default:
                    response = chatbot.GetResponse(userMessage);
                    break;
            }

            ChatDisplay.AppendText("Bot: " + response + "\n\n");

            logger.Log("User asked: " + userMessage);

            UserInput.Clear();
        }

        private void CompleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedIndex >= 0)
            {
                taskManager.CompleteTask(TaskListBox.SelectedIndex);

                string taskName = TaskListBox.SelectedItem.ToString();

                logger.Log($"Task completed: {taskName}");

                MessageBox.Show("Task marked as completed.");
            }
            else
            {
                MessageBox.Show("Please select a task first.");
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedIndex >= 0)
            {
                string taskName = TaskListBox.SelectedItem.ToString();

                taskManager.DeleteTask(TaskListBox.SelectedIndex);

                TaskListBox.Items.Clear();

                foreach (var task in taskManager.GetTasks())
                {
                    TaskListBox.Items.Add(task.Title);
                }

                logger.Log($"Task deleted: {taskName}");

                MessageBox.Show("Task deleted.");
            }
            else
            {
                MessageBox.Show("Please select a task first.");
            }
        }
        private void ShowQuestion()
        {
            if (currentQuestionIndex >= quizManager.Questions.Count)
            {
                ChatDisplay.AppendText($"Bot: Quiz completed! Final Score: {score}/{quizManager.Questions.Count}\n\n");

                ScoreText.Text = $"Score: {score}";

                logger.Log($"Quiz completed. Score: {score}/{quizManager.Questions.Count}");

                quizInProgress = false;
                return;
            }

            var question = quizManager.Questions[currentQuestionIndex];

            string questionText = $"Question {currentQuestionIndex + 1}: {question.Question}\n";

            for (int i = 0; i < question.Options.Length; i++)
            {
                questionText += $"{i + 1}. {question.Options[i]}\n";
            }

            ChatDisplay.AppendText("Bot: " + questionText + "\n");
        }
    }
}