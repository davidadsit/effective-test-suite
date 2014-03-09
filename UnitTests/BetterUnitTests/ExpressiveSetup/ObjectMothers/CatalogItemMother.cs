using BetterUnitTests.ExpressiveSetup.Entities;

namespace BetterUnitTests.ExpressiveSetup.ObjectMothers
{
    public static class CatalogItemMother
    {
        public static CatalogItem DefaultCatalogItem(int id = 0)
        {
            return new CatalogItem
                       {
                           CatalogNumber = "2013-13-" + id,
                           PageNumber = 53 + id,
                           ItemName = "Sweater",
                           ItemCode = string.Format("sw-{0}-ah", id),
                           Price = 5.99m + id,
                       };
        }
    }
}