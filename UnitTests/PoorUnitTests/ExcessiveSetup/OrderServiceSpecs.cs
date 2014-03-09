using System.Linq;
using Machine.Specifications;
using PoorUnitTests.ExcessiveSetup.Entities;
using PoorUnitTests.ExcessiveSetup.Services;

namespace PoorUnitTests.ExcessiveSetup
{
    [Subject(typeof (OrderService))]
    public class When_creating_a_new_order
    {
        Establish context = () =>
                                {
                                    customer = new Customer
                                                   {
                                                       Name = new Name {FirstName = "Jane", LastName = "Doe", Prefix = "Ms."},
                                                       Address = new Address
                                                                     {
                                                                         Line1 = "123 Main Street",
                                                                         Line2 = "Suite 200",
                                                                         City = "Bend",
                                                                         State = "OR",
                                                                         PostalCode = "97707",
                                                                     },
                                                   };
                                    catalogItem1 = new CatalogItem
                                                       {
                                                           CatalogNumber = "2013-13",
                                                           PageNumber = 53,
                                                           ItemName = "Sweater",
                                                           ItemCode = "sw-3-ah",
                                                           Price = 31.98m,
                                                       };
                                    orderItem1 = new OrderItem {ItemCode = "sw-3-ah", Color = "Purple", Size = "Medium", Quantity = 2};

                                    catalogItem2 = new CatalogItem
                                                       {
                                                           CatalogNumber = "2013-13",
                                                           PageNumber = 14,
                                                           ItemName = "Tank Top",
                                                           ItemCode = "tt-76-wgb",
                                                           Price = 7.98m,
                                                       };
                                    orderItem2 = new OrderItem {ItemCode = "tt-76-wgb", Color = "Black", Size = "Small", Quantity = 3};

                                    catalogService = new CatalogService();
                                    catalogService.InitializeCatalog(new[] {catalogItem1, catalogItem2});
                                    salesTaxService = new SalesTaxServiceForTesting(taxRate);
                                };

        Because of = () =>
                         {
                             orderService = new OrderService(catalogService, salesTaxService);
                             order = orderService.CreateOrder(customer, orderItem1, orderItem2);
                         };

        It should_set_the_item1_description = () => order.Items.Single(x => x.ItemCode == orderItem1.ItemCode).Description.ShouldEqual("Medium Purple Sweater");
        It should_calculate_the_item1_total = () => order.Items.Single(x => x.ItemCode == orderItem1.ItemCode).LineTotal.ShouldEqual(63.96m);
        It should_set_the_item2_description = () => order.Items.Single(x => x.ItemCode == orderItem2.ItemCode).Description.ShouldEqual("Small Black Tank Top");
        It should_calculate_the_item2_total = () => order.Items.Single(x => x.ItemCode == orderItem2.ItemCode).LineTotal.ShouldEqual(23.94m);
        It should_calculate_the_sub_total = () => order.SubTotal.ShouldEqual(87.90m);
        It should_calculate_the_sales_tax = () => order.SalesTax.ShouldEqual(6.46m);
        It should_calculate_the_total = () => order.Total.ShouldEqual(94.36m);

        static Customer customer;
        static CatalogItem catalogItem1;
        static OrderItem orderItem1;
        static CatalogItem catalogItem2;
        static OrderItem orderItem2;
        static CatalogService catalogService;
        static SalesTaxServiceForTesting salesTaxService;
        static OrderService orderService;
        static Order order;
        static decimal taxRate = .0735m;
    }

    class SalesTaxServiceForTesting : ISalesTaxService
    {
        readonly decimal taxRate;

        public SalesTaxServiceForTesting(decimal taxRate)
        {
            this.taxRate = taxRate;
        }

        public decimal GetTaxRate(Address address)
        {
            return taxRate;
        }
    }
}