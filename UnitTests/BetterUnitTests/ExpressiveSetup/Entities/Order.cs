using System.Collections.Generic;

namespace BetterUnitTests.ExpressiveSetup.Entities
{
    public class Order
    {
        public IEnumerable<OrderLine> Items { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
    }
}