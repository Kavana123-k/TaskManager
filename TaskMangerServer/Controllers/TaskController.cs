using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Configuration;
using log4net.Config;
using System.Globalization;

namespace TaskMangerServer.Controllers
{
    class TaskController : ApiController
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(TaskController));
        TaskManager taskManager = new TaskManager();
        [HttpPost]
        public void Create([FromBody] string text)
        {
            try
            {
                log.Debug("HttpPost to Create() task details");
                //var cTime = DateTime.ParseExact(createdTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                //var eTime = DateTime.ParseExact(endTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                taskManager.Create(text);
                Console.WriteLine("created");
            }
            catch (Exception)
            {
                log.Error("Exception in Create task");
            }
        }
        [HttpPost]
        //public Task Edit([FromBody] Text task)
        //{
        //    try
        //    {
        //        log.Debug("HttpPost to Edit() task details");
        //        var t = taskManager.Edit(task);
        //        return t;
        //    }
        //    catch (Exception)
        //    {
        //        log.Error("Exception in Edit task");
        //        return null;
        //    }
        //}
        //[HttpPost]
        //public int Delete([FromBody] int id)
        //{
        //    try
        //    {
        //        log.Debug("HttpPost to Delete() task details");
        //        var t = taskManager.Delete(id);
        //        return t;
        //    }
        //    catch (Exception)
        //    {
        //        log.Error("Exception in Delete task");
        //        return ' ';
        //    }
        //}
        [HttpGet]
        public List<Task> Display()
        {
            try
            {
                log.Debug("HttpGet to Display() task details");
                var t = taskManager.Display();
                return t;
            }
            catch
            {
                log.Error("Exception in Edit task");
                return null;
            }
        }
        public class Text
        {
            public string text { get; set; }
        }
    }
}
