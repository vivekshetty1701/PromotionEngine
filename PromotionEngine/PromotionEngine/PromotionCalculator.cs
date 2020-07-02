using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
    public class PromotionCalculator
    {
        public int GetPromotion(IList<Product> lstProducts, Order order, IList<Promotion> lstPromotion)
        {
            // Better to convert too array to fast access.
            Product[] products = lstProducts.ToArray();
            Product[] orderedProducts = order.Products.ToArray();
            Promotion[] promotions = lstPromotion.ToArray();

            // recursively apply all promotions remaining ordred products.
            return PromotionHelper(products, orderedProducts, promotions);
        }

        private int PromotionHelper(Product[] products, Product[] orderedProducts, Promotion[] promotions)
        {
            int minAmount = GetTotalAmount(products, orderedProducts);
            for(int i = 0; i<promotions.Length; i++)
            {
                Promotion promotion = promotions[i];
                Product[] cloneOrderedProducts = new Product[orderedProducts.Length];
                Array.Copy(orderedProducts, cloneOrderedProducts, orderedProducts.Length);

                bool isPromotionApplied = true;
                for(int j=0; j<orderedProducts.Length; j++)
                {
                    Product custProduct = orderedProducts[j];
                    //check exit in promotion
                    Product promotionProduct = promotion.Products.Where(p => p.Name.Equals(custProduct.Name)).FirstOrDefault();
                    if (promotionProduct == null)
                        break;
                    int remainingQuantity = custProduct.Quantity - promotionProduct.Quantity;
                    if (remainingQuantity < 0)
                    {
                        isPromotionApplied = false; break;
                    }
                    cloneOrderedProducts[j].Quantity = remainingQuantity;
                }

                if(isPromotionApplied)
                    minAmount = Math.Min(minAmount, promotion.TotalSum + PromotionHelper(products, cloneOrderedProducts, promotions));
            }

            return minAmount;
        }

        private int GetTotalAmount(Product[] products, Product[] orderedProducts)
        {
            int sum = 0;
            foreach(Product orderedProduct in orderedProducts)
            {
                int price = products.Where(p => p.Name.Equals(orderedProduct.Name)).First().Price;
                sum += orderedProduct.Quantity * price;
            }

            return sum;
        }
    }
}
