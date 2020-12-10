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
                Console.WriteLine("4.Display task");
                Console.WriteLine("----------");
                TaskClient taskclient = new TaskClient();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //Console.WriteLine("enter id:");
                        //int id = 0;
                        //string name; //description, status;
                        //DateTime startTime = new DateTime();
                        //DateTime endTime = new DateTime();
                        //int.TryParse(Console.ReadLine(), out id);
                        //Console.WriteLine("enter name:");
                        //name = Console.ReadLine();
                        //Console.WriteLine("enter description:");
                        //description = Console.ReadLine();
                        //Console.WriteLine("enter startime(dd/mm/yyyy hh:mm:ss):");
                        //while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out startTime))
                        //{
                        //    Console.WriteLine("entered date is invalid, try again");
                        //}
                        //while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out endTime))
                        //{
                        //    Console.WriteLine("entered date is invalid, try again");
                        //}
                        //Console.WriteLine("enter status");
                        //status = Console.ReadLine();

                        //id = 101;
                        //name = "name";
                        //description = "description";
                        //status = "open";

                        //taskclient.Create(new Task()
                        //{
                        //    //id = id,
                        //    name = name
                        //    // description = description,
                        //    // status = status,
                        //    // createdTime = startTime.ToString("dd/MM/yyyy HH:mm:ss"),
                        //    //endTime = endTime.ToString("dd/MM/yyyy HH:mm:ss")
                        //}) ;
                        string name = Console.ReadLine();
                        string t = taskclient.Create(name);                       
                        break;
                    case 2:
                        //taskclient.Edit(id, name, description, startTime, endTime, status);
                        break;
                    case 3:
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        int d= taskclient.Delete(id1);
                        break;
                    case 4:
                        taskclient.Display();
                        break;
                    default:
                        Console.WriteLine("no file exit");
                        break;
                }
            }
        }
    }
}
