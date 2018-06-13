using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Warehouse.Models;



namespace Warehouse.Controllers
{
    public class StockController : Controller
    {
        // GET: Detail_Bill
        HomeModel db = new HomeModel();
        public ActionResult Index()
        {
            if (!ClassMore.Login_hasLogin)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Stock> lsPro = db.Stocks.ToList();

            return View(lsPro);
        }
    }

}