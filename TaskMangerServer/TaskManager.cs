using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using log4net.Config;

namespace TaskMangerServer
{
    class TaskManager
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TaskManager));
        private static TaskManager instance;
        //private static Random random = new Random();       
        private TaskManager()
        {
            //taskList = new List<Task>(){new Task
            //{
            //    name = "task1",
            //    status = "Closed",
            //    description = "desc1",
            //    createdTime = "20200101010101",
            //    endTime = "20200101010101",
            //    id = random.Next(1000)
            //}, new Task
            //{
            //    name = "task2",
            //    status = "Open",
            //    description = "desc2",
            //    createdTime = "20200101010101",
            //    endTime = "20200101010101",
            //    id = random.Next(1000)
            //}, new Task
            //{
            //    name = "task1",
            //    status = "Closed",
            //    description = "desc1",
            //    createdTime = "20200101010101",
            //    endTime = "20200101010101",
            //    id = random.Next(1000)
            //}, new Task
            //{
            //    name = "task1",
            //    status = "Closed",
            //    description = "desc1",
            //    createdTime = "20200101010101",
            //    endTime = "20200101010101",
            //    id = random.Next(1000)
            //} };
        }
        // private readonly List<Task> taskList = new List<Task>();

        TaskDbSqlite taskDb = new TaskDbSqlite();
        public static TaskManager GetInstance()
        {
            if (instance == null)
            {
                instance = new TaskManager();
            }
            return instance;
        }
        public Task Create(Task task)
        {
            try
            {
                log.Debug("Creating a Task Details");
                //task.id = random.Next(0);
                // var taskcreate = taskDb.Create(task);
                return taskDb.Create(task);

                //task.id = random.Next(1000);
                //taskList.Add(task);
                //Console.WriteLine("Created");
                //return task;
            }
            catch (Exception ex)
            {
                log.Error("Error in Create() of TaskManager" + ex);
                return null;
            }
        }
        public Task Edit(Task task)
        {
            try
            {
                log.Debug("Edit the task details");               
                return taskDb.Edit(task);
                //var itemToEdit = Get(task.id);
                //var index = taskList.FindIndex(t => t.id == task.id);
                //if (index > -1)
                //{
                //    taskList[index] = task;
                //}                
                //return task;
            }
            catch (Exception ex)
            {
                log.Error("Error in Edit() of TaskManager" + ex);
                return null;
            }
        }
        public int Delete(int id)
        {
            try
            {
                log.Debug("Delete the task dtails");
                return taskDb.Delete(id);
                
                //var itemToRemove = taskList.SingleOrDefault(r => r.id == id);
                //if (itemToRemove != null)
                //    taskList.Remove(itemToRemove);
                //return id;
            }
            catch (Exception ex)
            {
                log.Error("Error  in Delete() of TaskManager" + ex);
                return ' ';
            }
        }
        public List<Task> GetAll()
        {
            try
            {
                log.Debug("To Diplay the task details");
                return taskDb.GetAll();
                
                //return taskList;
            }
            catch (Exception ex)
            {
                log.Error("Error in Display() of TaskManager" + ex);
                return null;
            }
        }
        public Task Get(int id)
        {
            try
            {
                log.Debug("To Diplay the task details");
                return taskDb.Get(id); ;
               // return taskList.Find(t => t.id == id);
            }
            catch (Exception ex)
            {
                log.Error("Error in Display() of TaskManager" + ex);
                return null;
            }
        }
    }
}
