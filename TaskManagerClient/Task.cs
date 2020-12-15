﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TaskManagerClient
{
    public class Task
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string createdTime { get; set; }

        public string endTime { get; set; }
        public string status { get; set; }
    }
}

