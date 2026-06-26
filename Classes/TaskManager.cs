using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CybersecurityAwarenessBot.Models;

namespace CybersecurityAwarenessBot.Classes
{
    // Handles cybersecurity task management and database operations.
    public class TaskManager
    {
      private string connectionString =
      "server=localhost;database=CybersecurityBotDB;uid=root;pwd=CyberBot2026!;";
        private List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(TaskItem task)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO Tasks
                        (Title, Description, ReminderDate, IsCompleted)
                        VALUES
                        (@title, @description, @reminder, @completed)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", task.Title);
                cmd.Parameters.AddWithValue("@description", task.Description);
                cmd.Parameters.AddWithValue("@reminder", task.ReminderDate);
                cmd.Parameters.AddWithValue("@completed", task.IsCompleted);

                cmd.ExecuteNonQuery();
            }

            tasks.Add(task);
        }

        public List<TaskItem> GetTasks()
        {
            tasks.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Tasks";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tasks.Add(new TaskItem
                    {
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        ReminderDate = reader["ReminderDate"] == DBNull.Value
                            ? null
                            : (DateTime?)Convert.ToDateTime(reader["ReminderDate"]),
                        IsCompleted = Convert.ToBoolean(reader["IsCompleted"])
                    });
                }
            }

            return tasks;
        }

        public void CompleteTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].IsCompleted = true;

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE Tasks SET IsCompleted = TRUE WHERE Title = @title";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", tasks[index].Title);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Tasks WHERE Title = @title";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", tasks[index].Title);

                    cmd.ExecuteNonQuery();
                }

                tasks.RemoveAt(index);
            }
        }
    }
}