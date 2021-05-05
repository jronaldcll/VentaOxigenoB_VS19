using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityReserve : EntityBase
    {
		public int id { get; set; }
		public string quantity { get; set; }
		public string price { get; set; }
		public string name_user { get; set; }
		public string name_product { get; set; }
	}
}