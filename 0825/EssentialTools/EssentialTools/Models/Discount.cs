using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper: IDiscountHelper
    {
        #region [原始實作]
        //public decimal ApplyDiscount(decimal totalParam)
        //{
        //    return (totalParam - (10m / 100m * totalParam));
        //}
        #endregion

        #region [增加屬性]
        //public decimal _DiscountSize { get; set; } //Property
        //public decimal ApplyDiscount(decimal totalParam)
        //{
        //    return (totalParam - (_DiscountSize / 100m * totalParam));
        //}
        #endregion

        #region [使用建構式constructor]
        public decimal _discountSize;

        public DefaultDiscountHelper(decimal discountParam)
        {
            _discountSize = discountParam;
        }

        public decimal ApplyDiscount(decimal totoalParam)
        {
            return (totoalParam - (_discountSize/ 100m * totoalParam));
        }
        #endregion
    }
}