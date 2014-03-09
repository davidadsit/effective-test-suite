using BetterUnitTests.ExpressiveSetup.Entities;

namespace BetterUnitTests.ExpressiveSetup.Services
{
    public interface ISalesTaxService
    {
        decimal GetTaxRate(Address address);
    }
}