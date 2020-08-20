using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            // 透過ViewBag傳遞資料，ViewBag後方的名稱可自定義；等號右邊表示要賦予的資料
            ViewBag.Greeting = hour < 12 ? "Good Morning!" : "Good Afternoon!";
            ViewBag.Testing = "Test text";
            return View();
        }

        //public string Index()
        //{
        //    return "Hello World";
        //}

        // 預設初始畫面
        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View();
        }

        // 接收到POST時
        [HttpPost]
        public ActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                // 跳到 Thanks.cshtml 並且把表單內強型別資料一起帶入
                return View("Thanks", guestResponse);
            }
            else
            {
                // 參數錯誤
                return View();
            }
        }
    }
}