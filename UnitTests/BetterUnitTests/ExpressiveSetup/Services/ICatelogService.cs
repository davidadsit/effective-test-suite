using BetterUnitTests.ExpressiveSetup.Entities;

namespace BetterUnitTests.ExpressiveSetup.Services
{
    public interface ICatalogService
    {
        CatalogItem GetItem(string itemCode);
    }
}