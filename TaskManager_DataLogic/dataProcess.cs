using System.Security.Cryptography.X509Certificates;
using TaskManager_Common;

namespace TaskManager_DataLogic

{
    public class dataProcess
    {
        List<Accounts> accounts = new List<Accounts>();
        IDataService dataService;
        

        public dataProcess()
        {
             dataService = new InMemoryDataService();
        }
        
        public List<Accounts> GetAccounts()
        {
            return dataService.GetAll();
        }
        public bool AddTask(string username, string task) { 
            return dataService.AddTask(username, task);
        }
        public string GetTask(string username) { 
        return dataService.GetTasks(username);
        }
        public bool DeleteTask(int index, string username)
        {
            return dataService.DeleteTask(index, username);
        }
        public bool UpdateTask(int index, string username)
        {
            return dataService.UpdateTask(index, username);
        }
    }
}

