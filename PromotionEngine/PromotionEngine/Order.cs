using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class Order
    {
        public IList<Product> Products { get; private set; }

        public Order(IList<Product> Products)
        {
            this.Products = Products;
        }
    }
}
