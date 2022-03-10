﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrowFrontendMVC.Models
{
    public class User
    {
        public string userGuid {get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<Devices> devices { get; set; } 
    }
}
