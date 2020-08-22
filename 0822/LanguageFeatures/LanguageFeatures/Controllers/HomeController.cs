using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ActionResult AutoProperty()
        {
            Product myProduct = new Product
            {
                Name = "Kayak"
            };
            string productName = myProduct.Name;
            return View("Result", (object)String.Format($"Product name: {productName}"));
        }

        public ActionResult CreateProduct()
        {
            Product myProduct = new Product
            {
                ProductID = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            return View("Result", (object)String.Format($"Category: {myProduct.Category}"));
        }

        public ActionResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int>
            {
                { "apple", 10 }, { "orange", 20 }, { "plum", 30 }
            };

            return View("Result", (object)stringArray[1]);
        }

        public ActionResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "Kayak", Price = 275M },
                    new Product { Name = "Adam", Price = 48.95M },
                    new Product { Name = "Jack", Price = 19.50M },
                    new Product { Name = "Will", Price = 34.95M }
                }
            };

            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format($"Total: {cartTotal:C}"));
        }

        public ActionResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product { Name = "Kayak", Price = 275M },
                    new Product { Name = "Adam", Price = 48.95M },
                    new Product { Name = "Jack", Price = 19.50M },
                    new Product { Name = "Will", Price = 34.95M }
                }
            };

            Product[] productArray = {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Adam", Price = 48.95M },
                new Product { Name = "Jack", Price = 19.50M },
                new Product { Name = "Will", Price = 34.95M }
            };

            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();

            return View("Result", (object)String.Format($"Cart Total: {cartTotal}, Array Total: {arrayTotal}"));
        }

        public ActionResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product { Name = "Kayak", Price = 275M, Category = "Watersports"},
                    new Product { Name = "Adam", Price = 48.95M, Category = "Watersports"},
                    new Product { Name = "Jack", Price = 19.50M, Category = "Soccer"},
                    new Product { Name = "Will", Price = 34.95M, Category = "Soccer" }
                }
            };

            // 沒有把篩選條件抽離
            //decimal total = 0;
            //foreach (Product prod in products.FilterByCategory("Soccer"))
            //{
            //    total += prod.Price;
            //}

            // 抽離條件
            //Func<Product, bool> categoryFilter = delegate (Product prod)
            //{
            //    return prod.Category == "Soccer";
            //};

            // 抽離條件 & lambada
            //Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";
            //decimal total = 0;
            //foreach(Product prod in products.Filter(categoryFilter))
            //{
            //    total += prod.Price;
            //}

            // 直接在條件使用 lambada
            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer"))
            {
                total += prod.Price;
            }


            return View("Result", (object)String.Format($"Total : {total}"));
        }

        public ActionResult FindProducts()
        {
            Product[] products =
                {
                    new Product { Name = "Kayak", Price = 275M, Category = "Watersports"},
                    new Product { Name = "Adam", Price = 48.95M, Category = "Watersports"},
                    new Product { Name = "Jack", Price = 19.50M, Category = "Soccer"},
                    new Product { Name = "Will", Price = 34.95M, Category = "Soccer" }
                };

            // 使用LinQ 根據Price降冪排序,取3筆資料, 
            var foundProducts = products.OrderByDescending(m => m.Price).Take(3).Select(m => new { m.Name, m.Price });

            // 更改第三筆資料
            products[2] = new Product { Name = "Stadium", Price = 79600M };

            // 重組資料
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat($"Price: {p.Price}!");
            }

            // select()具有延遲特性，因此result會變成 Price: 79600 , Price: 275, Price: 48.95
            return View("Result", (object)result.ToString());
        }

        public ActionResult SumProducts()
        {
            Product[] products =
                {
                    new Product { Name = "Kayak", Price = 275M, Category = "Watersports"},
                    new Product { Name = "Adam", Price = 48.95M, Category = "Watersports"},
                    new Product { Name = "Jack", Price = 19.50M, Category = "Soccer"},
                    new Product { Name = "Will", Price = 34.95M, Category = "Soccer" }
                };

            // 使用LinQ加總所有Price
            var results = products.Sum(m => m.Price);
            // 變更第三筆資料
            products[2] = new Product { Name = "Stadium", Price = 79600M };

            // 因為Sum()沒有延遲特性,會以執行Sum()當下的資料做加總,所以結果顯示 Sum: $378.40
            return View("Result", (object)String.Format($"Sum: {results:C}"));
        }
    }
}