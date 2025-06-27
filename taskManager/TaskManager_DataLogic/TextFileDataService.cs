using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager_Common;

namespace TaskManager_DataLogic
{
    public class TextFileDataService : IDataService
    {
        string filepath = "tasks.txt";
        List<Tasks> list_tasks = new List<Tasks>();
        public TextFileDataService()
        {
            GetDataFromFile();
        }
        private void GetDataFromFile()
        {
            var lines = File.ReadAllLines(filepath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                list_tasks.Add(new Tasks
                {
                    TaskName = parts[1],
                    Status = parts[0]
                });
            }
        }
        public bool AddTask(string task)
        {
            foreach (var tasks in list_tasks)
            {
                if (tasks.TaskName == task)
                {
                    return false;
                }
            }
            list_tasks.Add(new Tasks
            {
                TaskName = task,
                Status = "Pending"
            });

            var newTask = $"Pending|{task}\n";
            File.AppendAllText(filepath, newTask);
            return true;
        }

        public bool DeleteTask(int index)
        {
            if (index < 0 || index >= list_tasks.Count)
            {
                return false;
            }
            list_tasks.RemoveAt(index);
            var lines = File.ReadAllLines(filepath).ToList();
            lines.RemoveAt(index);
            File.WriteAllLines(filepath, lines);
            return true;
        }

        public List<Tasks> GetAll()
        {
            return list_tasks;
        }

        public int GetTaskCount()
        {
            return list_tasks.Count;
        }

        public bool UpdateTask(int index)
        {
            if (index < 0 || index >= list_tasks.Count)
            {
                return false;
            }
            var task = list_tasks[index];
            if (task.Status == "Pending")
            {
                task.Status = "Completed";
            }
            var lines = File.ReadAllLines(filepath).ToList();
            lines[index] = $"{task.Status}|{task.TaskName}";
            File.WriteAllLines(filepath, lines);
            return true;
        }
    }
}