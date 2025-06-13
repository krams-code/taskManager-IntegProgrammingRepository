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

        List<Accounts> accounts = new List<Accounts>();
        public InMemoryDataService()
        {
            DummyAccount();
        }

        public bool AddTask(string username, string task)
        {
            foreach (var account in accounts)
            {

                if (account.username == username)
                {
                    account.Tasks.Add(task);

                    return true;

                }
            }
            return false;

        }
        public string GetTasks(string username)
        {
            string tasks = "";
            foreach (var account in accounts)
            {

                for (int i = 0; i < account.Tasks.Count; i++)
                {
                    tasks += $"{i + 1}. {account.Tasks[i]}\n";

                }
            }
            return tasks;

        }

        

        public void DummyAccount()
        {

            accounts.Add(new Accounts
            {
                username = "admin",
                password = "admin"
            });
        }

        public List<Accounts> GetAll()
        {
            return accounts;
        }
        public bool DeleteTask(int index, string username)
        {
            foreach (var account in accounts)
            {
                if (account.username == username)
                {
                    if (index >= 0 && index < account.Tasks.Count)
                    {
                        account.Tasks.RemoveAt(index);
                        return true;
                    }
                }
            }
            return false;
        }
        /*public bool UpdateTask(int index, string username)
        {
            foreach (var account in accounts)
            {
                if (account.username == username)
                {
                    if (index >= 0 && index < account.Tasks.Count)
                    {
                        account.Tasks[index] = account.Tasks[index] + " Complete\n";
                        return true;
                    }
                }

            }
            return false;
        }*/
    }

       
}
