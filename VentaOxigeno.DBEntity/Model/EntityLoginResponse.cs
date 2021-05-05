using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityLoginResponse
    {
        public int IdUser { get; set; } 
        public string Role { get; set; }
        public string Nombres { get; set; }
        public string Token { get; set; }
    }
}
