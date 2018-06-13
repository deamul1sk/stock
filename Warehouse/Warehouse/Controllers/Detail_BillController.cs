using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Warehouse.Models;



namespace Warehouse.Controllers
{
    public class Detail_BillController : Controller
    {
        // GET: Detail_Bill
        HomeModel db = new HomeModel();
        public ActionResult Index()
        {
            if(!ClassMore.Login_hasLogin)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Detail_Product> lsPro = db.Detail_Product.ToList();

            return View(lsPro);
        }

        [HttpPost]
        public ActionResult Add(String quantity, String price, String bill, String product, String idDet_Bil)
        {
            try
            {
                Detail_Product pro;
                if ("".Equals(idDet_Bil))
                {
                    pro = new Detail_Product();
                    pro.quantity = Int32.Parse(quantity.Trim());
                    pro.price = Decimal.Parse(price);
                    pro.idBill = Int32.Parse(bill);
                    pro.idProduct = Int32.Parse(product);
                    db.Detail_Product.Add(pro);
                    db.SaveChanges();

                }
                else
                {
                    int idProT = Int32.Parse(idDet_Bil.Trim());
                    pro = db.Detail_Product.FirstOrDefault(a => a.id == idProT);
                    if (pro != null)
                    {
                        pro.quantity = Int32.Parse(quantity.Trim());
                        pro.price = Decimal.Parse(price);
                        pro.idBill = Int32.Parse(bill);
                        pro.idProduct = Int32.Parse(product);
                        db.SaveChanges();
                    }

                }
            } catch (Exception e)
            {
                 ClassMore.Login_hasLogin = false;
                 return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("Index", "Detail_Bill");
        }

        public ActionResult Delete(String idDet_Bil)
        {
            try
            {
                int idProT = Int32.Parse(idDet_Bil.Trim());
                Detail_Product pro = db.Detail_Product.FirstOrDefault(a => a.id == idProT);
                if (pro != null)
                {
                    Sold sol = db.Solds.FirstOrDefault(a => a.idDetail_Product == pro.id);
                    db.Solds.Attach(sol);
                    db.Solds.Remove(sol);
                    db.SaveChanges();

                    db.Detail_Product.Attach(pro);
                    db.Detail_Product.Remove(pro);
                    db.SaveChanges();
                }
            } catch (Exception e)
            {
                 ClassMore.Login_hasLogin = false;
                 return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("Index", "Detail_Bill");
        }

        public String Initial_Product()
        {
            List<Product> lsPro = db.Products.ToList();
            String st = "[";
            int k = 0;
            foreach(Product pro in lsPro)
            {
                k++;
                st += "{\"id\":"+pro.id+",\"name\":\""+pro.name+"\"}";
                if(k != lsPro.Count)
                {
                    st += ",";
                }
            }
            st += "]";
            return st;
        }
        
        public String Initial_Bill(String id)
        {
            List<Bill> lsPro = db.Bills.ToList();
            String st = "[";
            int k = 0;
            foreach (Bill pro in lsPro)
            {
                k++;
                st += "{\"id\":" + pro.id + ",\"address\":\"" + pro.address + "\"}";
                if (k != lsPro.Count)
                {
                    st += ",";
                }
            }
            st += "]";
            return st;
        }
    }

}