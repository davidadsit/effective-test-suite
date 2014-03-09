using PoorUnitTests.ExcessiveSetup.Entities;

namespace PoorUnitTests.ExcessiveSetup.Services
{
    public interface ISalesTaxService
    {
        decimal GetTaxRate(Address address);
    }
}