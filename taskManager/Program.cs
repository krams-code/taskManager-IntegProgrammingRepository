using System;
using System.Diagnostics;
using taskManager_BusinessLogic;

namespace taskManager
{
    public class Program
    {
        static string[] tasks = new string[100];
        static bool[] taskStatus = new bool[100];
        static int taskCount = 0;
        static BusinessLogic_Process businessLogic = new BusinessLogic_Process();
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO TASK MANAGER");

            while (true)
            {
                DisplayMenu();
                int userAction = GetUserInput();

                switch (userAction)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        ViewTasks();
                        break;
                    case 3:
                        MarkTaskAsCompleted();
                        break;
                    case 4:
                        DeleteTask();
                        break;
                    case 5:
                        Console.WriteLine("Exiting Task Manager...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("\nACTIONS:");
            Console.WriteLine("[1] Add Task");
            Console.WriteLine("[2] View Tasks");
            Console.WriteLine("[3] Mark Task as Completed");
            Console.WriteLine("[4] Delete Task");
            Console.WriteLine("[5] Exit");
            Console.Write("Enter Action: ");
        }
        public static int GetUserInput()
        {
            int userAction;
            if (int.TryParse(Console.ReadLine(), out userAction))
            {
                return userAction;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return 0;
            }
        }
        static void AddTask()
        {
            Console.Write("Enter Task: ");
            string task = Console.ReadLine();
            if (businessLogic.SaveTask(task) && businessLogic.GetTaskCount() < 100)
            {
                Console.WriteLine("Task added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add task. Please try again.");

            }
        }

        static void ViewTasks()
        {
            if (businessLogic.GetTaskCount() == 0)
            {
                Console.WriteLine("No tasks available.");
            }
            else
            {
                Console.WriteLine("\nTASK LIST:");

                int index = 1;
                foreach (var task in businessLogic.GetAllTasks())
                {
                    Console.WriteLine($"{index}. [{task.Status.Trim()}] {task.TaskName.Trim()} ");
                    index++;
                }
            }
        }

        static void MarkTaskAsCompleted()
        {
            Console.Write("Enter task number to mark as completed: ");
            int taskNum = GetUserInput();

            if (businessLogic.UpdateTask(taskNum - 1))
            {
                Console.WriteLine("Task marked as completed!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        static void DeleteTask()
        {
            Console.Write("Enter task number to delete: ");
            int taskNum = GetUserInput();

            if (businessLogic.RemoveTask(taskNum - 1))
            {
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }





    }
}