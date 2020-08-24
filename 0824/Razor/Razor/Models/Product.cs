using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razor.Models
{
    public class Product
    {
        /// <summary>
        /// 產品ID
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 價格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        public string Category { get; set; }
    }
}