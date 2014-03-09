using BetterUnitTests.ExpressiveSetup.Entities;

namespace BetterUnitTests.ExpressiveSetup.ObjectMothers
{
    public static class OrderItemMother
    {
        public static OrderItem DefaultOrderItem(int id)
        {
            return new OrderItem
                   {
                       Color = "color-" + id,
                       ItemCode = "item-code-" + id,
                       Quantity = 3,
                       Size = "size-" + id,
                   };
        }
    }
}