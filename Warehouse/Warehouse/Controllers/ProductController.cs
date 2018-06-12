using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        HomeModel db = new HomeModel();
        public ActionResult Index()
        {
            List<Product> lsPro = db.Products.ToList();
 
            return View(lsPro);
        }
    }
}