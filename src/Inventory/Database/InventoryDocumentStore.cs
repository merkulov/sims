using System.Configuration;
using Inventory.Model;
using Marten;

namespace Inventory.Database
{
	public static class InventoryDocumentStore
	{
		public static DocumentStore GetStore()
		{
			return DocumentStore.For(
				options => {
					options.Connection(ConfigurationManager.ConnectionStrings["main"].ConnectionString);

					options.Schema.For<Stock>().ForeignKey<Item>(s => s.ItemId);
				}
			);
		}
	}
}
