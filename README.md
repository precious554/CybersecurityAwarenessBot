# Cybersecurity Awareness Chatbot

## Project Overview

The Cybersecurity Awareness Chatbot is a GUI-based desktop application developed in C# using Windows Presentation Foundation (WPF). The application educates users about cybersecurity while providing interactive features such as task management, reminders, quizzes, Natural Language Processing (NLP) simulation, activity logging, and MySQL database integration.

This project was developed as the Final Portfolio of Evidence (POE) for Programming.

---

## Features

### Cybersecurity Chatbot

* Answers cybersecurity-related questions.
* Provides guidance on passwords, phishing, scams and privacy.
* Uses keyword recognition to understand user requests.

### Task Assistant

* Add cybersecurity tasks.
* Store tasks in a MySQL database.
* Mark tasks as completed.
* Delete tasks.
* Set reminders using simple natural language.

### Cybersecurity Quiz

* 12 cybersecurity questions.
* Multiple-choice and True/False questions.
* Immediate feedback after each answer.
* Final score displayed at the end.

### Natural Language Processing (NLP)

The chatbot recognises different user requests using keyword detection with string manipulation techniques such as `string.Contains()`.

Examples include:

* Add task
* Reminder
* Password
* Privacy
* Phishing
* Quiz

### Activity Log

The chatbot records important user activities, including:

* Tasks added
* Tasks completed
* Tasks deleted
* Reminder creation
* Quiz started
* Quiz completed

Only the most recent activities are displayed to keep the log concise.

---

## Technologies Used

* C#
* Windows Presentation Foundation (WPF)
* XAML
* .NET
* MySQL
* MySQL Workbench
* Visual Studio 2022

---

## Database

Database Name:

CybersecurityBotDB

Table:

Tasks

---

## Installation

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Install the MySql.Data NuGet package.
4. Create the MySQL database named:

CybersecurityBotDB

5. Update the connection string if necessary.
6. Build the solution.
7. Run the application.

---

## Example Usage

User:
Add task Review privacy settings tomorrow

Bot:
Task added successfully. Reminder set for tomorrow.

User:
Quiz

Bot:
Starts the cybersecurity quiz.

User:
Show activity log

Bot:
Displays the most recent chatbot activities.

---

## Author

Tshegofatso Mokotedi
