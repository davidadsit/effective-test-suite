using System;
using System.Linq;
using PoorUnitTests.ExcessiveSetup.Entities;

namespace PoorUnitTests.ExcessiveSetup.Services
{
    public class OrderService
    {
        readonly ICatelogService CatelogService;
        readonly ISalesTaxService SalesTaxService;

        public OrderService(ICatelogService catelogService, ISalesTaxService salesTaxService)
        {
            CatelogService = catelogService;
            SalesTaxService = salesTaxService;
        }

        public Order CreateOrder(Customer customer, params OrderItem[] orderItems)
        {
            var order = new Order
                            {
                                Items = orderItems.Select(GetOrderLineFromOrderItem),
                            };
            order.SubTotal = order.Items.Select(x => x.LineTotal).Sum();
            order.SalesTax = Math.Round(order.SubTotal * SalesTaxService.GetTaxRate(customer.Address), 2);
            order.Total = order.SubTotal + order.SalesTax;
            return order;
        }

        OrderLine GetOrderLineFromOrderItem(OrderItem orderItem)
        {
            var catelogItem = CatelogService.GetItem(orderItem.ItemCode);
            var orderLine = new OrderLine
                                {
                                    Description = orderItem.Size + " " + orderItem.Color + " " + catelogItem.ItemName,
                                    LineTotal = Math.Round(orderItem.Quantity*catelogItem.Price, 2),
                                    ItemCode = orderItem.ItemCode,
                                };
            return orderLine;
        }
    }
}