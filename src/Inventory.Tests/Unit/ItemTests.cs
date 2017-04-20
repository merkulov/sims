using Inventory.Model;
using NUnit.Framework;

namespace Inventory.Tests.Unit
{
	[TestFixture]
	public class ItemTests
	{
		[Test]
		public void When_Item_Is_Created_Is_Active_Set_To_True()
		{
			var item = new Item("acme");

			Assert.AreEqual(true, item.IsActive);
		}
	}
}