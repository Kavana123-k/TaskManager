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
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace TaskMangerServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    public class TaskController : ApiController
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(TaskController));
        //TaskManager taskManager = new TaskManager();
        TaskManager taskManager = TaskManager.GetInstance();
        [HttpPost]
        public HttpResponseMessage create([FromBody] Task task)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, "value");             
                log.Debug("HttpPost to Create() task details");
                //var cTime = DateTime.ParseExact(createdTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                //var eTime = DateTime.ParseExact(endTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                var t = taskManager.Create(task);
                Console.WriteLine("created");
                response.Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.Unicode);
               // response.Headers.CacheControl = new CacheControlHeaderValue() { MaxAge = TimeSpan.FromMinutes(20) };
                return response;
            }
            catch (Exception)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, "value");
                log.Error("Exception in Create task");
                return response;
            }
        }
        [Route("Edit")]
        [HttpPost]
        public HttpResponseMessage Edit([FromBody] Task task)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
                log.Debug("HttpPost to Edit() task details");
                var t = taskManager.Edit(task);
                response.Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.Unicode);
                return response;
            }
            catch (Exception)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified, "value");
                log.Error("Exception in Edit task");
                return response;
            }
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] string id)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
                log.Debug("HttpPost to Delete() task details");
                var t = taskManager.Delete(int.Parse(id));
                response.Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.Unicode);
                return response;
            }
            catch (Exception)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotModified, "value");
                log.Error("Exception in Delete task");
                return response;
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
