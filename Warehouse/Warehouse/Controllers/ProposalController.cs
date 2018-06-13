using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Warehouse.Models;



namespace Warehouse.Controllers
{
    public class ProposalController : Controller
    {
        // GET: Detail_Bill
        HomeModel db = new HomeModel();
        public ActionResult Index()
        {
            if (!ClassMore.Login_hasLogin)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Proposal> lsPro = db.Proposals.ToList();

            return View(lsPro);
        }
    }

}