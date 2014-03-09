using System.Collections.Generic;
using System.Linq;
using PoorUnitTests.ExcessiveSetup.Entities;

namespace PoorUnitTests.ExcessiveSetup.Services
{
    public class CatalogService : ICatelogService
    {
        List<CatalogItem> CatelogItems;

        public CatalogItem GetItem(string itemCode)
        {
            return CatelogItems.FirstOrDefault(x => x.ItemCode == itemCode);
        }

        public void InitializeCatalog(IEnumerable<CatalogItem> catelogItems)
        {
            CatelogItems = catelogItems.ToList();
        }
    }
}