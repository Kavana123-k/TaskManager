using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMangerServer
{
    interface ITaskManager
    {
        Task Create(Task task);
        Task Edit(Task task);
        int Delete(int id);
        List<Task> GetAll();
        Task Get(int id);
    }
}
