using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
        public int IdUser { get; set; } 
        public string Nombres { get; set; }
        public string LoginUsuario { get; set; }
        public string PasswordUsuario { get; set; }
        public string Role { get; set; }

    }
}
