using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("enter the choice");
                Console.WriteLine("1.Create task");
                Console.WriteLine("2.Edit task");
                Console.WriteLine("3.Delete task");
                Console.WriteLine("4.Display all tasks");
                Console.WriteLine("5.Display task");
                Console.WriteLine("----------");
                TaskClient taskclient = new TaskClient();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:

                        taskclient.Create(GetTaskData());
                        break;
                    case 2:
                        taskclient.Edit(GetTaskData());
                        break;
                    case 3:
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        int d = taskclient.Delete(id1);
                        break;
                    case 4:
                        var tasks = taskclient.GetAll();
                        Console.WriteLine(JsonConvert.SerializeObject(tasks));
                        break;
                    case 5:
                        var task = taskclient.Get(GetId());
                        Console.WriteLine(JsonConvert.SerializeObject(task));
                        break;
                    default:
                        Console.WriteLine("no file exit");
                        break;
                }
            }
        }

        public static Task GetTaskData()
        {
            Console.WriteLine("enter id:");
            int id = GetId();

            Console.WriteLine("enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("enter description:");
            var description = Console.ReadLine();

            Console.WriteLine("enter startime(dd/mm/yyyy hh:mm:ss):");
            DateTime startTime = GetDatetime();

            Console.WriteLine("enter startime(dd/mm/yyyy hh:mm:ss):");
            DateTime endTime = GetDatetime();

            Console.WriteLine("enter status");
            var status = Console.ReadLine();

            return new Task()
            {
                id = id,
                name = name,
                description = description,
                status = status,
                createdTime = startTime.ToString("dd/MM/yyyy HH:mm:ss"),
                endTime = endTime.ToString("dd/MM/yyyy HH:mm:ss")
            };
        }

        public static DateTime GetDatetime()
        {
            DateTime dateTime = new DateTime();
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                Console.WriteLine("entered date is invalid(dd/MM/yyyy HH:mm:ss), try again");
            }
            return dateTime;
        }

        public static int GetId()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("input is not a number, try again");
            }
            return id;
        }
    }
}
