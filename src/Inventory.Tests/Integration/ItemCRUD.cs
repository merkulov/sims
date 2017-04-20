using System;
using System.Configuration;
using Inventory.Database;
using Inventory.Model;
using Marten;
using NUnit.Framework;

namespace Inventory.Tests.Integration
{
	[TestFixture]
	public class ItemCRUD
	{
		[Test]
		public void New_Item_Can_Be_Saved_To_DB()
		{
			var store = InventoryDocumentStore.GetStore();

			var item = new Item("acme")
			{
				PickingSequence = PickingSequence.Fefo,
				Description = "acme desc",
				IsLotControlled = true,
				IsSerialControlled = false
			};

			Guid itemId;
			using (var session = store.OpenSession())
			{
				session.Store(item);

				session.SaveChanges();
				itemId = item.Id;
			}

			using (var session = store.QuerySession())
			{
				var itemFromDb = session.Load<Item>(itemId);
				Assert.IsNotNull(itemFromDb);
				Assert.AreEqual("acme", item.Code);
				Assert.AreEqual("acme desc", item.Description);
				Assert.AreEqual(true, item.IsLotControlled);
				Assert.AreEqual(false, item.IsSerialControlled);
				Assert.AreEqual(true, item.IsActive);
				Assert.AreEqual(PickingSequence.Fefo, item.PickingSequence);
			}
		}
	}
}