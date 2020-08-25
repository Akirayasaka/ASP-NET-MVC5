using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator: IValueCalculator
    {
        #region [尚未使用interface]
        //public decimal ValueProducts(IEnumerable<Product> products)
        //{
        //    return products.Sum(m => m.Price);
        //}
        #endregion

        #region [使用interface (IDiscountHelper)]
        private IDiscountHelper _discounter;
        //private static int counter = 0; // 確認scope功能

        public LinqValueCalculator(IDiscountHelper discountPatram)
        {
            _discounter = discountPatram;

            //System.Diagnostics.Debug.WriteLine(string.Format($"Instance {++counter} created!")); // 確認scope功能
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return _discounter.ApplyDiscount(products.Sum(m => m.Price));
        }
        #endregion
    }
}