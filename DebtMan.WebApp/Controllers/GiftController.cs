using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DebtMan.WebApp.Models;

namespace DebtMan.WebApp.Controllers
{
    public class GiftController : Controller
    {
        public ActionResult Index()
        {
            var model = new GiftBox()
            {
                For = "Me!",
                Gifts = new Gift[] {
                    new Gift { Name = "Tall Hat", Price = 39.95 },
                    new Gift { Name = "Long Cloak", Price = 120.00 }
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(GiftBox giftBox)
        {
            return View("Completed", giftBox);
        }

        public ActionResult Add()
        {
            return PartialView("GiftEditorRow", new Gift());
        }
    }
}
