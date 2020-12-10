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
        public string Create(string s)
        {
            try
            {
                log.Debug("Create task details");
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(new { text = s }), Encoding.UTF8, "application/json");
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
        public void Edit(int id, string name, string description, DateTime createdTime, DateTime endTime, string status)
        {
            try
            {
                log.Debug("Edit task details in TasClient");
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(new { textId = id, textName = name, textDescription = description, textCreatedTime = createdTime, textEndTime = endTime, textStatus = status }), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(URL + "Edit", content).Result;// new Uri(URL + "UpdateFile", content);
                string resp = Convert.ToString(response);
                //return resp;
            }
            catch (Exception ex)
            {
                log.Error("Error in Edit task details TaskClient" + ex);
            }
        }
        public void Display()
        {
            try
            {
                log.Debug("Display task details of TaskClient ");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL + "Display");
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            }
            catch (Exception ex)
            {
                log.Error("Error in display task details in TaskClient" + ex);
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
