using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using log4net.Config;
using Newtonsoft.Json;

namespace TaskManagerClient
{
    public class TaskClient
    {
        private static readonly string urlParameters;
        public static string URL = ConfigurationManager.AppSettings["URL"].ToString();
        //log4net.Config.BasicConfigurator.Configure();
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(TaskClient));
        public string Create(Task task)
        {
            try
            {
                log.Debug("Create task details");
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(URL + "Create", content).Result;// new Uri(URL + "UpdateFile", content);
                string resp = response.StatusCode.ToString();
                return resp;
            }
            catch (Exception ex)
            {
                log.Error("Error in Creating taskdetails of TestClient" + ex);
                return " ";
            }
        }
        public void Edit(Task task)
        {
            try
            {
                log.Debug("Edit task details in TasClient");
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(URL + "Edit", content).Result;// new Uri(URL + "UpdateFile", content);
                string resp = Convert.ToString(response);
                //return resp;
            }
            catch (Exception ex)
            {
                log.Error("Error in Edit task details TaskClient" + ex);
            }
        }
        public List<Task> GetAll()
        {
            try
            {
                log.Debug("Display task details of TaskClient ");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL + "GetAll");
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                return JsonConvert.DeserializeObject<List<Task>>(response.Content.ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error in display task details in TaskClient" + ex);
                return null;
            }
        }

        public Task Get()
        {
            try
            {
                log.Debug("Display task details of TaskClient ");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL + "Get");
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                return JsonConvert.DeserializeObject<Task>(response.Content.ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error in display task details in TaskClient" + ex);
                return null;
            }
        }
        public int Delete(int id)
        {
            try
            {
                log.Debug("Delete task details of TaskClient");
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(new { text = Convert.ToString(id) }), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(URL + "Delete", content).Result;// new Uri(URL + "UpdateFile", content);
                int resp = Convert.ToInt32(response);
                return resp;
            }
            catch (Exception ex)
            {
                log.Error("Error in deleting task details of TaskClient" + ex);
            }
            return 1;
        }
    }
}
