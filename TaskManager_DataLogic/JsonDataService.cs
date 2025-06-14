using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManager_Common;

namespace TaskManager_DataLogic
{
    public class JsonDataService : IDataService
    {
        List<Tasks> list_tasks = new List<Tasks>();
        string filepath = "tasks.json";
        public JsonDataService()
        {
            ReadJsonDataFromFile();
        }
        private void ReadJsonDataFromFile()
        {
            string json = File.ReadAllText(filepath);
            list_tasks = JsonSerializer.Deserialize<List<Tasks>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public void SaveDataToFile()
        {
            var json = JsonSerializer.Serialize(list_tasks);
            File.WriteAllText(filepath, json);
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
            SaveDataToFile();
            return true;
        }

        public bool DeleteTask(int index)
        {
            if (index < 0 || index >= list_tasks.Count)
            {
                return false;
            }
            list_tasks.RemoveAt(index);
            SaveDataToFile();
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
            SaveDataToFile();
            return true;
        }
    }
}