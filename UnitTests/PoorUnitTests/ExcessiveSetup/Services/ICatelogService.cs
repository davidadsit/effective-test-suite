using System.Collections.Generic;
using PoorUnitTests.ExcessiveSetup.Entities;

namespace PoorUnitTests.ExcessiveSetup.Services
{
    public interface ICatelogService
    {
        CatalogItem GetItem(string itemCode);
        void InitializeCatalog(IEnumerable<CatalogItem> catelogItems);
    }
}