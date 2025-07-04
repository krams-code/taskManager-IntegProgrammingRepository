﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Common;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace TaskManager_DataLogic
{
    public class DatabaseDataProcess : IDataService
    {
        static string connectionString = "Data Source =LAPTOP-E0KUMBNB\\SQLEXPRESS01; Initial Catalog = db_task ; Integrated Security=true;TrustServerCertificate=True;";
        static SqlConnection sqlConnection;
        List<Tasks> list_tasks = new List<Tasks>();
        public DatabaseDataProcess()
        {
            sqlConnection = new SqlConnection(connectionString);
            GetDataFromDB();
        }
        public void GetDataFromDB()
        {
            sqlConnection.Open();
            string select = "select * from tbl_task";
            SqlCommand command = new SqlCommand(select, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list_tasks.Add(new Tasks
                {
                    TaskName = reader["TaskName"].ToString().Trim(),
                    Status = reader["Status"].ToString().Trim()
                });
            }
            sqlConnection.Close();
        }
        public bool AddTask(string task)
        {
            sqlConnection.Open();
            foreach (var tasks in list_tasks)
            {
                if (tasks.TaskName == task)
                {
                    sqlConnection.Close();
                    return false;
                }
            }
            list_tasks.Add(new Tasks
            {
                TaskName = task,
                Status = "Pending"
            });
            string insert = "insert into tbl_task (TaskName, Status) values (@task, @status)";
            SqlCommand insertCommand = new SqlCommand(insert, sqlConnection);
            insertCommand.Parameters.AddWithValue("@task", task);
            insertCommand.Parameters.AddWithValue("@status", "Pending");
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return true;
        }

        public bool DeleteTask(int index)
        {
            if (index < 0 || index >= list_tasks.Count)
            {
                return false;
            }
            list_tasks.RemoveAt(index);
            sqlConnection.Open();
            var taskToDelete = list_tasks[index];
            string delete = "delete from tbl_task where TaskName = @task";
            SqlCommand deleteCommand = new SqlCommand(delete, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@task", taskToDelete.TaskName);
            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
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
            sqlConnection.Open();
            var task = list_tasks[index];
            if (task.Status == "Pending")
            {
                task.Status = "Completed";
                string update = "update tbl_task set Status = @status where TaskName = @task";
                SqlCommand updateCommand = new SqlCommand(update, sqlConnection);
                updateCommand.Parameters.AddWithValue("@status", "Completed");
                updateCommand.Parameters.AddWithValue("@task", task.TaskName);
                updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            else if (task.Status == "Completed")
            {
                task.Status = "Pending";
                string update = "update tbl_task set Status = @status where TaskName = @task";
                SqlCommand updateCommand = new SqlCommand(update, sqlConnection);
                updateCommand.Parameters.AddWithValue("@status", "Pending");
                updateCommand.Parameters.AddWithValue("@task", task.TaskName);
                updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            else
            {
                sqlConnection.Close();
                return false;
            }
        }
    }
}