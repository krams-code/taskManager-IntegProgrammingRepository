using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Common;

namespace TaskManager_DataLogic
{
    public class InMemoryDataService : IDataService
    {

        List<Tasks> list_tasks = new List<Tasks>();
        public List<Tasks> GetAll()
        {
            return list_tasks;
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
            return true;
        }
        public int GetTaskCount()
        {
            return list_tasks.Count;
        }

        public bool DeleteTask(int index)
        {
            if (index < 0 || index >= list_tasks.Count)
            {
                return false;
            }
            list_tasks.RemoveAt(index);
            return true;
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
            list_tasks[index] = task;
            return true;
        }
    }
}