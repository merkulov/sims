using System.Configuration;
using System.Linq;
using Inventory.Model;
using Marten;
using NUnit.Framework;

namespace Inventory.Tests
{
	[TestFixture]
	public class StockOperations
	{
		[Test]
		public void CanAddStock()
		{
			var store = DocumentStore.For(
				options => {
					options.Connection(ConfigurationManager.ConnectionStrings["main"].ConnectionString);
				}
			);

			var stock = new Stock();
			stock.Name = "123";
			using (var session = store.OpenSession())
			{
				session.Store(stock);

				session.SaveChanges();
			}

			using (var session = store.QuerySession())
			{
				var stockFromDb = session.Query<Stock>().FirstOrDefault(s => s.Name == "123");
				Assert.IsNotNull(stockFromDb);
				Assert.AreEqual("123", stockFromDb.Name);
			}
		}
	}
}