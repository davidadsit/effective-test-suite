using NUnit.Framework;

namespace PoorUnitTests.CoupledToExternalComponent
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        [Test]
        public void Saved_product_can_be_loaded()
        {
            var productRepository = new ProductRepository();
            var product = new Product
                              {
                                  Name = "product-name",
                                  Description = "long description",
                                  Color = "green",
                                  QuantityOnHand = 101,
                              };
            var productId = productRepository.Add(product);
            var loadedProduct = productRepository.Find(productId);
            productRepository.Delete(productId);

            Assert.AreEqual(productId, loadedProduct.Id);
            Assert.AreEqual(product.Name, loadedProduct.Name);
            Assert.AreEqual(product.Description, loadedProduct.Description);
            Assert.AreEqual(product.Color, loadedProduct.Color);
            Assert.AreEqual(product.QuantityOnHand, loadedProduct.QuantityOnHand);

        }
    }
}