using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
        public int IdUser { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
