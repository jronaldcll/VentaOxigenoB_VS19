using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProvider : EntityBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string ruc { get; set; }
        public string email { get; set; }
        public string firtsname_representative { get; set; }
        public string lastname_representative { get; set; }
        public string hourStart { get; set; }
        public string hourEnd { get; set; }
        public string openOrClosed { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string state { get; set; }
    }
}