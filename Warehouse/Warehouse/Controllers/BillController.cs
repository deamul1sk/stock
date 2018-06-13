using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class BillController : Controller
    {
        
        // GET: Bill
        HomeModel db = new HomeModel();
        public ActionResult Index()
        {
            if (!ClassMore.Login_hasLogin)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Bill> lsPro = db.Bills.ToList();
 
            return View(lsPro);
        }

        [HttpPost]
        public ActionResult Add(String name, String address, String phone, String idBil)
        {
            try
            {
                Bill pro;
                if ("".Equals(idBil))
                {
                    pro = new Bill();
                    pro.name = name.Trim();
                    pro.address = address.Trim();
                    pro.phone = phone.Trim();
                    db.Bills.Add(pro);
                    db.SaveChanges();

                }
                else
                {
                    int idProT = Int32.Parse(idBil.Trim());
                    pro = db.Bills.FirstOrDefault(a => a.id == idProT);
                    if (pro != null)
                    {
                        pro.name = name.Trim();
                        pro.address = address.Trim();
                        pro.phone = phone.Trim();
                        db.SaveChanges();
                    }

                }
            } catch(Exception e)
            {
                ClassMore.Login_hasLogin = false;
                return RedirectToAction("Login", "Home");
            }
            return RedirectToAction("Index", "Bill");
        }

        
        public ActionResult Delete(String idBil)
        {
            try
            {
                int idProT = Int32.Parse(idBil.Trim());
                Bill pro = db.Bills.FirstOrDefault(a => a.id == idProT);
                if (pro != null)
                {
                    db.Bills.Attach(pro);
                    db.Bills.Remove(pro);
                    db.SaveChanges();
                }
            } catch (Exception e)
            {
                ClassMore.Login_hasLogin = false;
                return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("Index", "Bill");
        }
    }
}