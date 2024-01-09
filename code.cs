using System;
using System.Collections.Generic;

class ToDoList
{
    private List<TaskItem> tasks = new List<TaskItem>();

    static void Main()
    {
        ToDoList toDoList = new ToDoList();
        toDoList.Run();
    }

    void Run()
    {
        while (true)
        {
            Console.WriteLine("To-Do List Application");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    MarkAsCompleted();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    void AddTask()
    {
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();

        TaskItem newTask = new TaskItem(description);
        tasks.Add(newTask);

        Console.WriteLine("Task added successfully!");
    }

    void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            Console.WriteLine("Tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    void MarkAsCompleted()
    {
        ViewTasks();

        Console.Write("Enter the task number to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].IsCompleted = true;
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid task number. Please try again.");
        }
    }

    void DeleteTask()
    {
        ViewTasks();

        Console.Write("Enter the task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid task number. Please try again.");
        }
    }
}

class TaskItem
{
    public string Description { get; }
    public bool IsCompleted { get; set; }

    public TaskItem(string description)
    {
        Description = description;
        IsCompleted = false;
    }

    public override string ToString()
    {
        return $"{Description} {(IsCompleted ? "[Completed]" : "")}";
    }
}
