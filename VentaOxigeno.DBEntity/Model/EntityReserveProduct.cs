using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
	public class EntityReserveProduct : EntityBase
	{
		public string name { get; set; }
		public int id { get; set; }
		public string quantity { get; set; }
		public string price { get; set; }
		public string name_user { get; set; }
		public string name_product { get; set; }
		public int stateReserve { get; set; }
		public int userId { get; set; }
		public int productId { get; set; }
		
	}
}