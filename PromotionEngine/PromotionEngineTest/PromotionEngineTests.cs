using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    [TestClass]
    public class PromotionEngineTests
    {   
        private IList<Product> GetProductCatalogue()
        {
            //product catalogue.
            IList<Product> products = new List<Product>();
            products.Add(new Product() { Name = 'A', Price = 50 });
            products.Add(new Product() { Name = 'B', Price = 30 });
            products.Add(new Product() { Name = 'C', Price = 20 });
            products.Add(new Product() { Name = 'D', Price = 15 });
            return products;
        }

        private IList<Promotion> GetActivePromotion()
        {
            //Promotion
            IList<Promotion> promotions = new List<Promotion>();

            // 1st promotion
            IList<Product> promotionProductA = new List<Product>();
            promotionProductA.Add(new Product() { Name = 'A', Quantity = 3 });
            promotions.Add(new Promotion(promotionProductA, 130));

            //2nd promotion
            IList<Product> promotionProductB = new List<Product>();
            promotionProductB.Add(new Product() { Name = 'B', Quantity = 2 });
            promotions.Add(new Promotion(promotionProductB, 45));

            //3rd promotion
            IList<Product> promotionProductCD = new List<Product>();
            promotionProductCD.Add(new Product() { Name = 'C', Quantity = 1 });
            promotionProductCD.Add(new Product() { Name = 'D', Quantity = 1 });
            promotions.Add(new Promotion(promotionProductCD, 30));

            return promotions;
        }

        [TestMethod]
        public void OrderWithNoPromotion()
        {

            IList<Product> products = GetProductCatalogue();

            IList<Promotion> promotions = GetActivePromotion();

            //product ordered
            IList<Product> orderedProduct = new List<Product>();
            orderedProduct.Add(new Product() { Name = 'A', Quantity = 1 });
            orderedProduct.Add(new Product() { Name = 'B', Quantity = 1 });
            orderedProduct.Add(new Product() { Name = 'C', Quantity = 1 });
            Order order = new Order(orderedProduct);

            PromotionCalculator promotionCalculator = new PromotionCalculator();
            int result = promotionCalculator.GetPromotion(products, order, promotions);
            Assert.AreEqual(result, 100);
        }
    }
}
