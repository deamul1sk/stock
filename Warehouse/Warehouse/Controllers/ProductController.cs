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
            if (!ClassMore.Login_hasLogin)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Product> lsPro = db.Products.ToList();
 
            return View(lsPro);
        }

        [HttpPost]
        public ActionResult Add(String name, String price, String idPro)
        {
            try
            {
                Product pro;
                if ("".Equals(idPro))
                {
                    pro = new Product();
                    pro.name = name.Trim();
                    pro.price = Decimal.Parse(price.Trim());
                    db.Products.Add(pro);
                    db.SaveChanges();

                }
                else
                {
                    int idProT = Int32.Parse(idPro.Trim());
                    pro = db.Products.FirstOrDefault(a => a.id == idProT);
                    if (pro != null)
                    {
                        pro.name = name.Trim();
                        pro.price = Decimal.Parse(price.Trim());
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                ClassMore.Login_hasLogin = false;
                return RedirectToAction("Login", "Home");
            }
            

            
            
            return RedirectToAction("Index", "Product");
        }

        
        public ActionResult Delete(String idPro)
        {
            try
            {
                int idProT = Int32.Parse(idPro.Trim());
                Product pro = db.Products.FirstOrDefault(a => a.id == idProT);
                if (pro != null)
                {
                    db.Products.Attach(pro);
                    db.Products.Remove(pro);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                ClassMore.Login_hasLogin = false;
                return RedirectToAction("Login", "Home");
            }
            

            return RedirectToAction("Index", "Product");
        }
    }
}