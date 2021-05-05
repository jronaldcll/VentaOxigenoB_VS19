using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProduct : EntityBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string price { get; set; }
        public int providerId { get; set; }
        public string ruc { get; set; }
    }
}