using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        public ActionResult List()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "List";
            return View("ActionName");
        }

        #region [從Route抓取 {id} 的值]
        //public ActionResult CustomVariable()
        //{
        //    ViewBag.Controller = "Home";
        //    ViewBag.Action = "CustomVariable";
        //    ViewBag.CustomVariable = RouteData.Values["id"];
        //    return View();
        //}
        #endregion

        #region [直接在方法新增參數, 讓MVC自動傳遞; 結果和上面相同]
        //public ActionResult CustomVariable(string id)
        //{
        //    ViewBag.Controller = "Home";
        //    ViewBag.Action = "CustomVariable";
        //    ViewBag.CustomVariable = id ?? "<no value>";
        //    return View();
        //}
        #endregion

        #region [同上,但給予初始值]
        public ActionResult CustomVariable(string id = "DefaultID")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = id;
            return View();
        }
        #endregion
    }
}