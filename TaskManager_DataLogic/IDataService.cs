using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Common;

namespace TaskManager_DataLogic
{

    public interface IDataService
    {
        public List<Accounts> GetAll();
        public string GetTasks(string username);
        public bool UpdateTask(int index, string username);
        public bool DeleteTask(int index,string username);
        public bool AddTask(string username,string task);
        public void DummyAccount();

    }
}
