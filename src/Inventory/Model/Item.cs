using System;

namespace Inventory.Model
{
	public class Item
	{
		public Item(string code)
		{
			Code = code;
			IsActive = true;
		}

		public Guid Id { get; set; }

		public string Code { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public bool IsLotControlled { get; set; }
		public bool IsSerialControlled { get; set; }
		public PickingSequence? PickingSequence { get; set; }
	}
}
