using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        #region [沒有使用interface, 造成高耦合]
        //private LinqValueCalculator calc;

        //public ShoppingCart(LinqValueCalculator calcParam)
        //{
        //    calc = calcParam;
        //}
        #endregion

        private IValueCalculator calc;

        public ShoppingCart(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        /// <summary>
        /// 產品集合 IEnumerable
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}