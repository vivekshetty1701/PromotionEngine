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
            throw new NotImplementedException();
        }
    }
}
