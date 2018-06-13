using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class SupplyController : Controller
    {
        // GET: Supply
        HomeModel db = new HomeModel();
        public ActionResult Index()
        {
            if (!ClassMore.Login_hasLogin)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Supply> lsPro = db.Supplies.ToList();
 
            return View(lsPro);
        }

        [HttpPost]
        public ActionResult Add(String name, String idSup)
        {
            try
            {
                Supply pro;
                if ("".Equals(idSup))
                {
                    pro = new Supply();
                    pro.name = name.Trim();
                    db.Supplies.Add(pro);
                    db.SaveChanges();

                }
                else
                {
                    int idProT = Int32.Parse(idSup.Trim());
                    pro = db.Supplies.FirstOrDefault(a => a.id == idProT);
                    if (pro != null)
                    {
                        pro.name = name.Trim();
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                ClassMore.Login_hasLogin = false;
                return RedirectToAction("Login", "Home");
            }
            
            
            return RedirectToAction("Index", "Supply");
        }

        
        public ActionResult Delete(String idSup)
        {
            try
            {
                int idProT = Int32.Parse(idSup.Trim());
                Supply pro = db.Supplies.FirstOrDefault(a => a.id == idProT);
                if (pro != null)
                {
                    db.Supplies.Attach(pro);
                    db.Supplies.Remove(pro);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                ClassMore.Login_hasLogin = false;
                return RedirectToAction("Login", "Home");
            }
         
            return RedirectToAction("Index", "Supply");
        }
    }
}