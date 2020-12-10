using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Configuration;
using System.Web.Http.Routing;
using Newtonsoft.Json.Serialization;

namespace TaskMangerServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            string URL = ConfigurationManager.AppSettings["url"];
            var config = new HttpSelfHostConfiguration(URL);
            config.Routes.MapHttpRoute(
                        name: "DefaultApi",
                        routeTemplate: "api/{controller}/{action}/{id}",
                       defaults: new
                       {
                           id = RouteParameter.Optional
                       });
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("REST API is listening in " + URL);
                Console.ReadLine();
            }
        }
    }
}
