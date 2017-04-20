using Inventory.Database;
using Inventory.Model;
using Marten;
using NUnit.Framework;

namespace Inventory.Tests.Integration
{
	[TestFixture]
	public class StockOperations
	{
		[Test]
		public void CanAddStock()
		{
			var store = InventoryDocumentStore.GetStore();

			var item = CreateTestItem(store);

			var stock = new Stock();

			stock.Name = "123";
			stock.ItemId = item.Id;

			using (var session = store.OpenSession())
			{
				session.Store(stock);

				session.SaveChanges();
			}

			using (var session = store.QuerySession())
			{
				var stockFromDb = session.Load<Stock>(stock.Id);
				Assert.IsNotNull(stockFromDb);
				Assert.AreEqual("123", stockFromDb.Name);
				Assert.AreEqual(item.Id, stockFromDb.ItemId);
			}
		}

		private Item CreateTestItem(DocumentStore store)
		{
			var item = new Item("acme")
			{
				PickingSequence = PickingSequence.Fefo,
				Description = "acme desc",
				IsLotControlled = true,
				IsSerialControlled = false
			};

			using (var session = store.OpenSession())
			{
				session.Store(item);

				session.SaveChanges();
			}

			return item;
		}
	}
}