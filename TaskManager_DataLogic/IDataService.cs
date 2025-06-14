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
        public List<Tasks> GetAll();
        public int GetTaskCount();
        public bool UpdateTask(int index);
        public bool DeleteTask(int index);
        public bool AddTask(string task);

    }
}