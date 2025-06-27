using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;
using TaskManager_Common;


namespace TaskManager_DataLogic

{
    public class dataProcess
    {
        List<Tasks> task = new List<Tasks>();
        IDataService dataService;


        public dataProcess()
        {
            //dataService = new InMemoryDataService();
            //dataService = new TextFileDataService();
            //dataService = new JsonDataService();
            dataService = new DatabaseDataProcess();
        }
        public List<Tasks> GetAll()
        {
            return dataService.GetAll();
        }

        public bool AddTask(string task)
        {
            return dataService.AddTask(task);
        }
        public int GetTaskCount()
        {
            return dataService.GetTaskCount();
        }
        public bool DeleteTask(int index)
        {
            return dataService.DeleteTask(index);
        }
        public bool UpdateTask(int index)
        {
            return dataService.UpdateTask(index);
        }
    }
}
