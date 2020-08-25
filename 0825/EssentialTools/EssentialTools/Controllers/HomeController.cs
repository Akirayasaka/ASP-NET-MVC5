using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        #region [Field]
        private IValueCalculator _calc;

        private Product[] products =
        {
            new Product { Name = "Kayak", Category = "Watersports", Price = 275M },
            new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
            new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
            new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };
        #endregion

        #region [Constructor]
        public HomeController(IValueCalculator calcParam)
        {
            _calc = calcParam;
        }
        #endregion

        // GET: Home
        public ActionResult Index()
        {
            #region [沒有使用interface]
            //LinqValueCalculator calc = new LinqValueCalculator();

            //ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            //decimal totalValue = cart.CalculateProductTotal();

            //return View(totalValue);
            #endregion

            #region [使用Interface]
            //IValueCalculator calc = new LinqValueCalculator();

            //ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            //decimal totalValue = cart.CalculateProductTotal();

            //return View(totalValue);
            #endregion

            #region [使用Ninject]
            //IKernel ninjectKernel = new StandardKernel();// 實作 Ninject.Ikernel interface
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>(); // 透過Bind<介面interface>().To<要實作的類別class>()

            //IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();// 告知ninject要調用哪個interface

            //ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            //decimal totalValue = cart.CalculateProductTotal();

            //return View(totalValue);
            #endregion

            #region [使用DI & Ninject, 將建構式抽離Controller, 集中交給Ninject處理]
            ShoppingCart cart = new ShoppingCart(_calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
            #endregion
        }
    }
}