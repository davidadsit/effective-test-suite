using System;
using System.Linq;
using BetterUnitTests.ExpressiveSetup.Entities;
using BetterUnitTests.ExpressiveSetup.ObjectMothers;
using BetterUnitTests.ExpressiveSetup.Services;
using Machine.Specifications;

namespace BetterUnitTests.ExpressiveSetup
{
    [Subject(typeof (OrderService))]
    public class When_creating_a_new_order : With_an_automocked<OrderService>
    {
        Establish context = () =>
                                {
                                    customer = CustomerMother.DefaultCustomer();
                                    catalogItem1 = CatalogItemMother.DefaultCatalogItem(1);
                                    catalogItem2 = CatalogItemMother.DefaultCatalogItem(2);
                                    orderItem1 = OrderItemMother.DefaultOrderItem(1);
                                    orderItem2 = OrderItemMother.DefaultOrderItem(2);
                                    orderItem1.ItemCode = catalogItem1.ItemCode;
                                    orderItem2.ItemCode = catalogItem2.ItemCode;

                                    GetTestDouble<ICatalogService>().Setup(x => x.GetItem(catalogItem1.ItemCode)).Returns(catalogItem1);
                                    GetTestDouble<ICatalogService>().Setup(x => x.GetItem(catalogItem2.ItemCode)).Returns(catalogItem2);

                                    GetTestDouble<ISalesTaxService>().Setup(x => x.GetTaxRate(customer.Address)).Returns(taxRate);
                                };

        Because of = () => order = ClassUnderTest.CreateOrder(customer, orderItem1, orderItem2);

        It should_set_the_item1_description = () => AssertDescriptionValue(orderItem2, catalogItem2);
        It should_set_the_item2_description = () => AssertDescriptionValue(orderItem2, catalogItem2);
        It should_calculate_the_item1_total = () => AssertLineItemTotal(orderItem1, catalogItem1);
        It should_calculate_the_item2_total = () => AssertLineItemTotal(orderItem2, catalogItem2);
        It should_calculate_the_sub_total = () => order.SubTotal.ShouldEqual(order.Items.Select(x => x.LineTotal).Sum());
        It should_calculate_the_sales_tax = () => order.SalesTax.ShouldEqual(Math.Round(order.SubTotal*taxRate, 2));
        It should_calculate_the_total = () => order.Total.ShouldEqual(order.SubTotal + order.SalesTax);

        static void AssertLineItemTotal(OrderItem orderItem, CatalogItem catalogItem)
        {
            order
                .Items
                .Single(x => x.ItemCode == orderItem.ItemCode)
                .LineTotal.ShouldEqual(orderItem.Quantity*catalogItem.Price);
        }

        static void AssertDescriptionValue(OrderItem orderItem, CatalogItem catalogItem)
        {
            var expectedOrderLineDescription = string.Format("{0} {1} {2}", orderItem.Size, orderItem.Color, catalogItem.ItemName);
            order.Items.Single(x => x.ItemCode == orderItem.ItemCode).Description.ShouldEqual(expectedOrderLineDescription);
        }

        static Customer customer;
        static OrderItem orderItem1;
        static OrderItem orderItem2;
        static CatalogItem catalogItem1;
        static CatalogItem catalogItem2;

        static Order order;
        static decimal taxRate = .0735m;
    }
}