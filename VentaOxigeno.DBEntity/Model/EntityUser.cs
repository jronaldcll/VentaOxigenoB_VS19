using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }

    }
}
