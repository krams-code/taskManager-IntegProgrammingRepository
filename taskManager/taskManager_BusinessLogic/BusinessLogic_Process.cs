using TaskManager_Common;
using TaskManager_DataLogic;
namespace taskManager_BusinessLogic
{
    public class BusinessLogic_Process
    {
        dataProcess process = new dataProcess();
        public List<Tasks> GetAllTasks()
        {
            return process.GetAll();
        }
        public int GetTaskCount()
        {
            return process.GetTaskCount();
        }
        public bool SaveTask(string task)
        {
            return process.AddTask(task);
        }
        public bool RemoveTask(int index)
        {
            return process.DeleteTask(index);
        }
        public bool UpdateTask(int index)
        {
            return process.UpdateTask(index);
        }
    }
}