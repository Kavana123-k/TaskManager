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
        public void Create(String s)
        {
            try
            {
                log.Debug("Creating a Task Details");
                taskList.Add(new Task { name = s });
                Console.WriteLine("Created");
            }
            catch (Exception ex)
            {
                log.Error("Error in Create() of TaskManager" + ex);
            }
        }
        //public Task Edit(Task task)
        //{
        //    try
        //    {
        //        log.Debug("Edit the task details");
        //        var itemToEdit = taskList.Find(t => t.id == task.id);
        //        if (itemToEdit != null)
        //        {
        //            itemToEdit = task;
        //        }
        //        return itemToEdit;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error in Edit() of TaskManager" + ex);
        //        return null;
        //    }
        //}
        //public int Delete(int id)
        //{
        //    try
        //    {
        //        log.Debug("Delete the task dtails");
        //        var itemToRemove = taskList.SingleOrDefault(r => r.id == id);
        //        if (itemToRemove != null)
        //            taskList.Remove(itemToRemove);
        //        return id;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error  in Delete() of TaskManager" + ex);
        //        return ' ';
        //    }
        //}
        public List<Task> Display()
        {
            try
            {
                log.Debug("To Diplay the task details");
                return taskList.ToList();
            }
            catch (Exception ex)
            {
                log.Error("Error in Display() of TaskManager" + ex);
                return null;
            }
        }
    }
}
