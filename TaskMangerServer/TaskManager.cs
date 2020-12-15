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
        private readonly List<Task> taskList = new List<Task>();
        public void Create(Task task)
        {
            try
            {
                log.Debug("Creating a Task Details");
                taskList.Add(task);
                Console.WriteLine("Created");
            }
            catch (Exception ex)
            {
                log.Error("Error in Create() of TaskManager" + ex);
            }
        }
        public Task Edit(Task task)
        {
            try
            {
                log.Debug("Edit the task details");
                var itemToEdit = Get(task.id);
                if (itemToEdit != null)
                {
                    itemToEdit = task;
                }
                return itemToEdit;
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
                var itemToRemove = taskList.SingleOrDefault(r => r.id == id);
                if (itemToRemove != null)
                    taskList.Remove(itemToRemove);
                return id;
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
                return taskList;
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
                return taskList.Find(t => t.id == id);
            }
            catch (Exception ex)
            {
                log.Error("Error in Display() of TaskManager" + ex);
                return null;
            }
        }
    }
}
