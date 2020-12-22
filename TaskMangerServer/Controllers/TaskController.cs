using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Configuration;
using log4net.Config;
using System.Globalization;
using System.Web.Http.Cors;

namespace TaskMangerServer.Controllers
{
   [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {        
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(TaskController));
        TaskManager taskManager = new TaskManager();
        [HttpPost]
        public void Create([FromBody] Task task)
        {
            try
            {
                log.Debug("HttpPost to Create() task details");
                //var cTime = DateTime.ParseExact(createdTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                //var eTime = DateTime.ParseExact(endTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                taskManager.Create(task);
                Console.WriteLine("created");
            }
            catch (Exception)
            {
                log.Error("Exception in Create task");
            }
        }
        [HttpPost]
        public Task Edit([FromBody] Task task)
        {
            try
            {
                log.Debug("HttpPost to Edit() task details");
                var t = taskManager.Edit(task);
                return t;
            }
            catch (Exception)
            {
                log.Error("Exception in Edit task");
                return null;
            }
        }
        [HttpPost]
        public int Delete([FromBody] int id)
        {
            try
            {
                log.Debug("HttpPost to Delete() task details");
                var t = taskManager.Delete(id);
                return t;
            }
            catch (Exception)
            {
                log.Error("Exception in Delete task");
                return ' ';
            }
        }
        [HttpGet]
        public List<Task> GetAll()
        {
            try
            {
                log.Debug("HttpGet to Display() task details");
                var t = taskManager.GetAll();
                return t;
            }
            catch
            {
                log.Error("Exception in Edit task");
                return null;
            }
        }
        [HttpGet]
        public Task Get(int id)
        {
            try
            {
                log.Debug("HttpGet to Display() task details");
                return taskManager.Get(id);
            }
            catch
            {
                log.Error("Exception in Edit task");
                return null;
            }
        }
    }
}
