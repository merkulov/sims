using System;

namespace Inventory.Model
{
	public class Stock
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public Guid ItemId { get; set; }
	}
}