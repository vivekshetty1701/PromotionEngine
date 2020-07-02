using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class Promotion
    {
        public IList<Product> Products { get; private set; }
        public int TotalSum { get; private set; }

        public Promotion(IList<Product> Products, int TotalSum)
        {
            this.Products = Products;
            this.TotalSum = TotalSum;
        }


    }
}
